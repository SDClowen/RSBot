namespace RSBot.Python.Components.API.ModuleLoader
{
    public static class PythonPluginAccessor
    {
        public static dynamic get(string moduleName)
        {
            return ModuleLoader.Get(moduleName);
        }

        public static dynamic all()
        {
            return ModuleLoader.GetAll();
        }
    }
    public class PythonPluginInfo
    {
        public string FileName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
    }

}
