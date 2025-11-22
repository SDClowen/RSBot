using RSBot.Python;
using RSBot.Python.Views;

namespace RSBot.Python.API
{
    /// <summary>
    /// Dieses Interface beschreibt ein allgemeines "Python-Plugin".
    /// Jedes API-Modul (Core, Inventory, GUI, etc.) soll dieses Interface
    /// implementieren, damit wir sie später einheitlich laden und initialisieren können.
    /// </summary>
    public interface IPythonPlugin
    {
        /// <summary>
        /// Der eindeutige Name des Moduls.
        /// Beispiel: "core", "inventory", "gui".
        /// Diesen Namen können wir später in einer Registry oder aus Python nutzen.
        /// </summary>
        string ModuleName { get; }

        /// <summary>
        /// Diese Methode wird einmal aufgerufen, wenn das Modul initialisiert wird.
        /// Über das Form1-Objekt können Module z.B. Logging, UI-Elemente oder andere
        /// Funktionen des Hauptprogramms verwenden.
        /// </summary>
        /// <param name="form">
        /// Die Haupt-Form der Anwendung (Form1), die das Plugin benutzen kann.
        /// </param>
        void Init(Main form);
    }
}
