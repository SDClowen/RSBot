﻿using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Event;
using SDUI.Controls;

namespace RSBot.Log.Views;

[ToolboxItem(false)]
public partial class Main : DoubleBufferedControl
{

    /// <summary>
    ///     Initializes a new instance of the <see cref="Main" /> class.
    /// </summary>
    public Main()
    {
        CheckForIllegalCrossThreadCalls = false;
        InitializeComponent();
        LoadConfig();


        EventManager.SubscribeEvent("OnAddLog", new Action<string, LogLevel>(AppendLog));

        if (!Kernel.Debug)
        {
            checkDebug.Checked = false;
            checkError.Visible = false;
            checkNormal.Visible = false;
            checkWarning.Visible = false;
            checkDebug.Visible = false;
        }
    }

    /// <summary>
    ///     Appends the log.
    /// </summary>
    /// <param name="message">The message.</param>
    public void AppendLog(string message, LogLevel level = LogLevel.Notify)
    {
        if (!checkEnabled.Checked)
            return;

        var logFile = Path.Combine(Kernel.BasePath, "User", "Logs",
            Game.Player == null ? "Environment" : Game.Player.Name, $"{DateTime.Now:dd-MM-yyyy}.txt");

        if (level == LogLevel.Debug && !checkDebug.Checked)
            return;

        if (level == LogLevel.Error && !checkError.Checked)
            return;

        if (level == LogLevel.Notify && !checkNormal.Checked)
            return;

        if (level == LogLevel.Warning && !checkWarning.Checked)
            return;

        txtLog.Write($"<{level}> \t{message}", true, Kernel.Debug, logFile);
    }

    /// <summary>
    ///     Loads the configuration.
    /// </summary>
    private void LoadConfig()
    {
        checkEnabled.Checked = GlobalConfig.Get("RSBot.Log.logEnabled", true);
    }

    /// <summary>
    ///     Handles the CheckedChanged event of the checkEnabled control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void checkEnabled_CheckedChanged(object sender, EventArgs e)
    {
        GlobalConfig.Set("RSBot.Log.logEnabled", checkEnabled.Checked.ToString());
    }

    /// <summary>
    ///     Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnReset_Click(object sender, EventArgs e)
    {
        txtLog.Text = string.Empty;
    }
}