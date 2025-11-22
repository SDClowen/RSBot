using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;
using RSBot.Python.API;
using RSBot.Python.Views;

namespace RSBot.Python.API.Inventory
{
    /// <summary>
    /// Dieses Plugin stellt Inventar-Funktionen für Python bereit,
    /// z.B. Items verschieben, Inventar aktualisieren, usw.
    /// </summary>
    public class InventoryAPI : IPythonPlugin
    {
        private Main? _main;

        /// <summary>
        /// Eindeutiger Name des Plugins.
        /// </summary>
        public string ModuleName => "inventory";

        /// <summary>
        /// Init wird einmal aufgerufen, um die main zu übergeben.
        /// </summary>
        public void Init(Main main)
        {
            _main = main;
        }
        public void Refresh()
        {
            _main?.AppendLog("Inventardaten aktualisiert.");
        }
        public PyDict MoveItem(int fromSlot, int toSlot, int quantity = 1)
        {
            using (Py.GIL())
            {
                var result = new PyDict();
                result.SetItem(new PyString("from"), new PyInt(fromSlot));
                result.SetItem(new PyString("to"), new PyInt(toSlot));
                result.SetItem(new PyString("quantity"), new PyInt(quantity));

                return result;
            }
        }
    }
}
