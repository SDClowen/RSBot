using System;
using System.Collections.Generic;

namespace RSBot.Core.Components.Scripting
{
    public interface IScriptCommand
    {
        #region Properties

        string Name { get; }
        
        bool IsRunning { get; }

        Dictionary<string, string> Arguments { get; }

        #endregion Properties
        
        #region Methods

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <returns>A value indicating if the command has been executed successfully.</returns>
        bool Execute(string[] arguments = null);

        #endregion Methods
    }
}