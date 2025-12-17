using RSBot.Python.Components.API.ModuleLoader;
using System.IO;
using System.Text.RegularExpressions;

namespace RSBot.Python.Components.API.Handler
{
    public static class PluginMetaReader
    {
        public static PythonPluginInfo ReadPythonPluginInfo(string filePath)
        {
            string text = File.ReadAllText(filePath);
            string fileName = Path.GetFileName(filePath);

            string ReadConst(string key)
            {
                var m = Regex.Match(
                    text,
                    $@"^\s*{key}\s*=\s*[""'](?<v>[^""']+)[""']\s*$",
                    RegexOptions.Multiline
                );
                return m.Success ? m.Groups["v"].Value.Trim() : null;
            }

            string ReadHeader(string key)
            {
                var m = Regex.Match(
                    text,
                    $@"^\s*#\s*{key}\s*:\s*(?<v>.+)\s*$",
                    RegexOptions.Multiline | RegexOptions.IgnoreCase
                );
                return m.Success ? m.Groups["v"].Value.Trim() : null;
            }

            return new PythonPluginInfo
            {
                FileName = fileName,
                Name = ReadConst("NAME") ?? ReadHeader("Name") ?? Path.GetFileNameWithoutExtension(fileName),
                Description = ReadConst("DESCRIPTION") ?? ReadHeader("Description") ?? "",
                Author = ReadConst("AUTHOR") ?? ReadHeader("Author") ?? "",
                Version = ReadConst("VERSION") ?? ReadHeader("Version") ?? ""
            };
        }
    }
}
