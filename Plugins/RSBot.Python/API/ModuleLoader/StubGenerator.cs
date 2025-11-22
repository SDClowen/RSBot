using RSBot.Python.API.GUI;
using RSBot.Python.API.GUI.Controls;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;


namespace RSBot.Python.API.ModuleLoader
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

            // 1) Plugin-Funktionen als top-level defs (wie bisher)
            WritePluginFunctions(sb);

            // 2) GUI-Klasse (WFAPI.GUI)
            WriteGuiClass(sb);

            // 3) Alle Wrapper-Typen (GuiControlWrapper-Abkömmlinge)
            WriteGuiWrappers(sb);

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
            File.WriteAllText(outputPath, sb.ToString(), Encoding.UTF8);
        }

        // --------------------------------------------------------
        // 1) Plugin-Funktionen: def log(...): ..., etc.
        // --------------------------------------------------------
        private static void WritePluginFunctions(StringBuilder sb)
        {
            var plugins = ModuleLoader.GetAll(); // Dictionary<string, object>

            if (plugins == null || plugins.Count == 0)
            {
                sb.AppendLine("# (Keine Plugins gefunden – keine top-level Funktionen erzeugt)");
                sb.AppendLine();
                return;
            }

            sb.AppendLine("# Top-level API-Funktionen aus Plugins");
            sb.AppendLine();

            foreach (var kv in plugins)
            {
                var pluginName = kv.Key;
                var plugin = kv.Value;
                var type = plugin.GetType();

                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                                  .Where(m =>
                                      !m.IsSpecialName &&                  // keine get_/set_-Properties
                                      m.Name != "Init" &&                   // Init(Form1) nicht nach außen
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

        // --------------------------------------------------------
        // 2) GUI Klasse (WFAPI.GUI)
        // --------------------------------------------------------
        private static void WriteGuiClass(StringBuilder sb)
        {
            var guiNestedType = typeof(WFAPI).GetNestedType("GUI", BindingFlags.Public | BindingFlags.NonPublic);

            if (guiNestedType == null)
            {
                sb.AppendLine("# Hinweis: WFAPI.GUI nicht gefunden – keine GUI-Klasse im Stub erzeugt.");
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
                    // z.B.: "LabelWrapper", "ButtonWrapper"
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

        // --------------------------------------------------------
        // 3) Alle GuiControlWrapper-Abkömmlinge
        //    -> LabelWrapper, ButtonWrapper, etc.
        // --------------------------------------------------------
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
                sb.AppendLine("# Keine GuiControlWrapper-Klassen gefunden.");
                sb.AppendLine();
                return;
            }

            sb.AppendLine("# GUI-Wrapper-Klassen (LabelWrapper, ButtonWrapper, ...)");
            sb.AppendLine();

            foreach (var wrapperType in wrappers)
            {
                var className = wrapperType.Name;
                sb.AppendLine($"class {className}:");

                // ALLE geerbten + eigenen Methoden sammeln
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
                        // z.B.: "LabelWrapper", "ButtonWrapper"
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


        // --------------------------------------------------------
        // Typ-Mapping C# -> Python Typen
        // --------------------------------------------------------
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

            // Dynamic / PyObject / sonstiges => object
            if (t.FullName == "Python.Runtime.PyObject")
                return "object";

            return "object";
        }
    }
}
