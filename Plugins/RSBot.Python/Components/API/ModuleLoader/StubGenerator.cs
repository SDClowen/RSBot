using RSBot.Python.Components.API.GUI;
using RSBot.Python.Components.API.GUI.Wrapper;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;


namespace RSBot.Python.Components.API.ModuleLoader
{
    public static class PythonStubGenerator
    {
        public static void Generate(string outputPath)
        {
            var sb = new StringBuilder();

            sb.AppendLine("# Auto-generated .pyi stub for pycross");
            sb.AppendLine("# DO NOT EDIT – generated from C# plugin classes");
            sb.AppendLine($"# Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine();

            WritePluginFunctions(sb);

            WriteGuiClass(sb);

            WriteGuiWrappers(sb);

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
            File.WriteAllText(outputPath, sb.ToString(), Encoding.UTF8);
        }

        // 1 Plugin-Fucntions: def log(...): ..., etc.
        private static void WritePluginFunctions(StringBuilder sb)
        {
            var plugins = ModuleLoader.GetAll();

            if (plugins == null || plugins.Count == 0)
            {
                sb.AppendLine("# [Python-API] No Plugins found - no top-level functions created");
                sb.AppendLine();
                return;
            }

            sb.AppendLine("#[Python-API] Top-level API-Functions from Plugins");
            sb.AppendLine();

            foreach (var kv in plugins)
            {
                var pluginName = kv.Key;
                var plugin = kv.Value;
                var type = plugin.GetType();

                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                                  .Where(m =>
                                      !m.IsSpecialName &&                 
                                      m.Name != "Init" &&                   
                                      m.Name != "ToString" &&
                                      m.Name != "Equals" &&
                                      m.Name != "GetHashCode" &&
                                      m.Name != "GetType");

                foreach (var method in methods)
                {
                    var name = method.Name;
                    var parameters = method.GetParameters();
                    var paramList = string.Join(", ",
                        parameters.Select(p => $"{p.Name}: {MapType(p.ParameterType)}"));

                    var returnType = MapType(method.ReturnType);

                    sb.AppendLine($"def {name}({paramList}) -> {returnType}: ...  # from plugin '{pluginName}'");
                }

                sb.AppendLine();
            }
        }

        // 2 GUI Class (WFAPI.GUI)
        private static void WriteGuiClass(StringBuilder sb)
        {
            var guiNestedType = typeof(WFAPI).GetNestedType("GUI", BindingFlags.Public | BindingFlags.NonPublic);

            if (guiNestedType == null)
            {
                sb.AppendLine("#[Python-API] Info: WFAPI.GUI not found – did not creat GUI-Class.");
                sb.AppendLine();
                return;
            }

            sb.AppendLine("class GUI:");
            sb.AppendLine("    def __init__(self, plugin_name: str) -> None: ...");

            var methods = guiNestedType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                                       .Where(m =>
                                           !m.IsSpecialName &&
                                           m.Name != "ToString" &&
                                           m.Name != "Equals" &&
                                           m.Name != "GetHashCode" &&
                                           m.Name != "GetType");

            foreach (var method in methods)
            {
                var name = method.Name;
                var parameters = method.GetParameters();
                var paramList = string.Join(", ",
                    parameters.Select(p => $"{p.Name}: {MapType(p.ParameterType)}"));

                string returnType;

                if (typeof(GuiControlWrapper).IsAssignableFrom(method.ReturnType))
                {
                    returnType = method.ReturnType.Name;
                }
                else
                {
                    returnType = MapType(method.ReturnType);
                }


                sb.AppendLine($"    def {name}(self, {paramList}) -> {returnType}: ...");
            }

            sb.AppendLine();
        }
        // 3 GuiControlWrapper-Childs
        private static void WriteGuiWrappers(StringBuilder sb)
        {
            var asm = typeof(GuiControlWrapper).Assembly;

            var wrappers = asm.GetTypes()
                .Where(t =>
                    typeof(GuiControlWrapper).IsAssignableFrom(t) &&
                    !t.IsAbstract &&
                    t.IsClass);

            if (!wrappers.Any())
            {
                sb.AppendLine("#[Python-API] Did not find any GuiControlWrapper-Classes.");
                sb.AppendLine();
                return;
            }

            sb.AppendLine("#[Python-API] GUI-Wrapper-Classes");
            sb.AppendLine();

            foreach (var wrapperType in wrappers)
            {
                var className = wrapperType.Name;
                sb.AppendLine($"class {className}:");

                var methods = wrapperType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .Where(m =>
                           m.DeclaringType != typeof(object) &&
                           m.DeclaringType != typeof(Control) &&
                           !m.IsSpecialName &&
                           m.Name != "ToString" &&
                           m.Name != "Equals" &&
                           m.Name != "GetHashCode" &&
                           m.Name != "GetType");

                if (!methods.Any())
                {
                    sb.AppendLine("    pass");
                    sb.AppendLine();
                    continue;
                }

                foreach (var method in methods)
                {
                    var name = method.Name;
                    var parameters = method.GetParameters();
                    var paramList = string.Join(", ",
                        parameters.Select(p => $"{p.Name}: {MapType(p.ParameterType)}"));

                    string returnType;

                    if (typeof(GuiControlWrapper).IsAssignableFrom(method.ReturnType))
                    {
                        returnType = method.ReturnType.Name;
                    }
                    else
                    {
                        returnType = MapType(method.ReturnType);
                    }


                    if (paramList.Length > 0)
                        sb.AppendLine($"    def {name}(self, {paramList}) -> {returnType}: ...");
                    else
                        sb.AppendLine($"    def {name}(self) -> {returnType}: ...");
                }

                sb.AppendLine();
            }
        }

        // Typ-Mapping C# -> Python Typen
        private static string MapType(Type t)
        {
            if (t == typeof(void)) return "None";
            if (t == typeof(int)) return "int";
            if (t == typeof(long)) return "int";
            if (t == typeof(float) || t == typeof(double) || t == typeof(decimal)) return "float";
            if (t == typeof(string)) return "str";
            if (t == typeof(bool)) return "bool";

            if (typeof(System.Collections.IDictionary).IsAssignableFrom(t))
                return "dict";

            if (typeof(System.Collections.IEnumerable).IsAssignableFrom(t) && t != typeof(string))
                return "list";

            if (t.FullName == "Python.Runtime.PyObject")
                return "object";

            return "object";
        }
    }
}
