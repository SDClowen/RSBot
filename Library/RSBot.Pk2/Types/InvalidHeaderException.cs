using System;

namespace RSBot.Pk2.Types
{
    public class InvalidHeaderException : Exception
    {
        /// <summary>
        /// Ruft eine Meldung ab, die die aktuelle Ausnahme beschreibt.
        /// </summary>
        public override string Message => "The requested file has an invalid PK2 header. Either the file is damaged or not a Joymax PK2 archive.";
    }
}