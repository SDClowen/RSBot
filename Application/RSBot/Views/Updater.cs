using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSBot.Core;

namespace RSBot.Views;

public partial class Updater : Form
{
    /// <summary>
    ///     Update address
    /// </summary>
    private readonly string _updateUrl = "https://rsbot.app/update";

    /// <summary>
    ///     Get or sets the web client
    /// </summary>
    private WebClient _webClient;

    public Updater()
    {
        InitializeComponent();
        CheckForIllegalCrossThreadCalls = false;
    }

    /// <summary>
    ///     Get current version
    /// </summary>
    private Version _currentVersion => Assembly.GetExecutingAssembly().GetName().Version;

    private void Append(string text, Color color, FontStyle fontStyle = FontStyle.Regular, float emSize = 0)
    {
        rtbUpdateInfo.SuspendLayout();
        rtbUpdateInfo.Select(rtbUpdateInfo.TextLength, text.Length);
        rtbUpdateInfo.SelectionColor = color;
        rtbUpdateInfo.SelectionFont = new Font(
            Font.FontFamily,
            emSize == 0 ? rtbUpdateInfo.Font.Size : emSize,
            fontStyle
        );
        rtbUpdateInfo.Write(text);
        rtbUpdateInfo.ResumeLayout();
    }

    private void _Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        Process.Start(Kernel.BasePath + "\\Replacer.exe");
        Environment.Exit(0);
    }

    private void _Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        try
        {
            downloadProgress.Value = e.ProgressPercentage;
            lblDownloadInfo.Text = string.Format(
                "{0} MB / {1} MB",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00")
            );
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
    }

    private void btnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            downloadProgress.Visible = true;
            downloadProgress.Location = new Point(16, 40);
            cbChangeLog.Checked = false;
            centerPanel.Visible = false;
            lblInfo.Text = "Downloading updates ...";
            var tempDirectory = Path.Combine(Kernel.BasePath, "rsbot_download_temp");

            if (!Directory.Exists(tempDirectory))
                Directory.CreateDirectory(tempDirectory).Attributes = FileAttributes.Directory | FileAttributes.Hidden;

            _webClient.DownloadFileAsync(new Uri(_updateUrl + "download/latest.zip"), tempDirectory + "\\latest.zip");
            _webClient.DownloadProgressChanged += _Client_DownloadProgressChanged;
            _webClient.DownloadFileCompleted += _Client_DownloadFileCompleted;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
    }

    private async void cbChangeLog_CheckedChanged(object sender, EventArgs e)
    {
        await Task.Run(() =>
        {
            if (cbChangeLog.Checked)
                for (var i = Height; i <= 451; i += 4)
                    Height += 4;
            else
                for (var i = Height; i >= 78; i -= 4)
                    Height -= 4;
        });
    }

    /// <summary>
    ///     Check for Updates
    /// </summary>
    /// <returns><c>true</c> if there is otherwise, <c>false</c>.</returns>
    public async Task<bool> Check()
    {
        return false; // disabled for now.
        try
        {
            _webClient = new WebClient();
            var updateInfo = (await _webClient.DownloadStringTaskAsync(_updateUrl + "/latest.txt")).Split(
                new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries
            );

            var version = new Version(updateInfo[0]);

            if (version > _currentVersion)
            {
                var date = updateInfo[1];

                Append("Build " + version, Color.FromArgb(99, 33, 99), FontStyle.Regular, 13);
                Append(date, Color.DarkGray, FontStyle.Italic, 9);

                for (var i = 2; i < updateInfo.Length; i++)
                    Append(updateInfo[i], Color.DarkSlateGray);

                rtbUpdateInfo.SelectionStart = 0;

                return true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return false;
    }
}
