using Python.Runtime;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Python.Components.API.Interface;
using RSBot.Python.Views;
using System;

namespace RSBot.Python.Components.API.Core.Training
{
    public class TrainingAPI : IPythonPlugin
    {
        private Main _main;

        /// <summary>
        /// Unique module name of the plugin.
        /// </summary>
        public string ModuleName => "training";

        /// <summary>
        /// Called once at startup to provide the main form to the plugin.
        /// </summary>
        /// <param name="main">Main form</param>
        public void Init(Main main)
        {
            _main = main;
        }

        private bool SetTrainingArea(string name)
        {
            var areas = PlayerConfig.GetArray<string>("RSBot.Training.Areas");
            foreach (var area in areas)
            {
                var split = area.Split("|", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                if (split.Length <= 0)
                    continue;

                if (!Area.TryParse(split, out var trainingArea))
                    continue;

                var regionName = Game.ReferenceManager.GetTranslation(trainingArea.Position.Region.ToString());

                if (trainingArea.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    SetTrainingPosition(trainingArea.Position.X, trainingArea.Position.Y, trainingArea.Position.Region, trainingArea.Radius);
                    return true;
                }
            }
            return false;
        }
        private bool SetTrainingPosition(float x, float y, ushort region, int radius)
        {
            if(Game.Player == null)
            {
                return false;
            }
            try
            {
                var area = Kernel.Bot.Botbase.Area;
                Position pos = new(x, y, region);

                PlayerConfig.Set("RSBot.Area.Region", pos.Region);
                PlayerConfig.Set("RSBot.Area.X", pos.XOffset);
                PlayerConfig.Set("RSBot.Area.Y", pos.YOffset);
                PlayerConfig.Set("RSBot.Area.Z", pos.ZOffset);
                PlayerConfig.Set("RSBot.Area.Radius", radius);

                Log.Notify("[Python-API] New training area coordinates set. " +
                    $"X: {pos.XOffset}, Y: {pos.YOffset}, Z: {pos.ZOffset}, Region: {pos.Region}");
                EventManager.FireEvent("OnSetTrainingArea");
                return true;
            }
            catch (Exception e)
            {
                Log.Notify($"[Python-API] An error occurred while trying to change training area: {e}");
                return false;
            }
        }
        private bool SetTrainingScript(string path)
        {
            return false;
        }
        private PyDict GetTrainingArea(string name)
        {
            using (Py.GIL())
            {
                var result = new PyDict();
                var areas = PlayerConfig.GetArray<string>("RSBot.Training.Areas");
                foreach (var area in areas)
                {
                    var split = area.Split("|", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    if (split.Length <= 0)
                        continue;

                    if (!Area.TryParse(split, out var trainingArea))
                        continue;

                    var regionName = Game.ReferenceManager.GetTranslation(trainingArea.Position.Region.ToString());

                    if (trainingArea.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        result.SetItem(new PyString("name"), new PyString(trainingArea.Name));
                        result.SetItem(new PyString("x"), new PyFloat(trainingArea.Position.X));
                        result.SetItem(new PyString("y"), new PyFloat(trainingArea.Position.Y));
                        result.SetItem(new PyString("z"), new PyFloat(trainingArea.Position.ZOffset));
                        result.SetItem(new PyString("radius"), new PyInt(trainingArea.Radius));
                        result.SetItem(new PyString("region"), new PyInt(trainingArea.Position.Region));
                        result.SetItem(new PyString("region_name"), new PyString(regionName));
                        return result;
                    }
                }
                return result;
            }
        }
        private PyDict GetTrainingPosition()
        {
            using (Py.GIL())
            {
                var result = new PyDict();
                if (Game.Player == null)
                {
                    return result;
                }
                var area = Kernel.Bot.Botbase.Area;
                result.SetItem(new PyString("x"), new PyFloat(area.Position.X));
                result.SetItem(new PyString("y"), new PyFloat(area.Position.Y));
                result.SetItem(new PyString("z"), new PyFloat(area.Position.ZOffset));
                result.SetItem(new PyString("radius"), new PyInt(area.Radius));
                result.SetItem(new PyString("region"), new PyInt(area.Position.Region.Id));
                result.SetItem(new PyString("region_name"), new PyString(Game.ReferenceManager.GetTranslation(area.Position.Region.ToString())));
                return result;
            }
        }
        private bool GetTrainingScript(string path)
        {
            return false;
        }
        public bool set_training_area(string name)
        {
            return SetTrainingArea(name);
        }
        public bool set_training_position(float x, float y, ushort region, int radius)
        {
            return SetTrainingPosition(x, y, region, radius);
        }
        public bool set_training_script(string path)
        {
            return SetTrainingScript(path);
        }
        public PyDict get_training_area(string name)
        {
            return GetTrainingArea(name);
        }
        public PyDict get_training_position()
        {
            return GetTrainingPosition();
        }
        public PyDict get_training_script()
        {
            return new PyDict();
        }
    }
}
