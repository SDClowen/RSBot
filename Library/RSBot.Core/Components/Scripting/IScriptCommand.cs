using System.Collections.Generic;

namespace RSBot.Core.Components.Scripting;

public interface IScriptCommand
{
    #region Properties

    string Name { get; }

    bool IsBusy { get; }

    Dictionary<string, string> Arguments { get; }

    #endregion Properties

    #region Methods

    /// <summary>
    ///     Executes this instance.
    /// </summary>
    /// <returns>A value indicating if the command has been executed successfully.</returns>
    bool Execute(string[] arguments = null);

    /// <summary>
    ///     Stops the execution of the command
    /// </summary>
    void Stop();

    #endregion Methods
}
