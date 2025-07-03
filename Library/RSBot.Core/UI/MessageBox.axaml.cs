using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System.Threading.Tasks;

namespace RSBot.Core.UI;

/// <summary>
/// A custom MessageBox implementation for Avalonia that provides a modern dialog experience
/// with support for various button combinations and themes
/// </summary>
public partial class MessageBox : Window
{
    /// <summary>
    /// Initializes a new instance of the MessageBox class
    /// </summary>
    /// <param name="title">The title of the message box</param>
    /// <param name="message">The message to display</param>
    /// <param name="buttons">The buttons to show in the message box</param>
    public MessageBox(string title, string message, MessageBoxButtons buttons = MessageBoxButtons.Ok)
    {
        AvaloniaXamlLoader.Load(this);
        Title = title;
        DataContext = new MessageBoxViewModel(this, title, message, buttons);
    }

    /// <summary>
    /// Shows a message box with the specified parameters
    /// </summary>
    /// <param name="owner">The owner window of the message box</param>
    /// <param name="message">The message to display</param>
    /// <param name="title">The title of the message box</param>
    /// <param name="buttons">The buttons to show in the message box</param>
    /// <returns>The result indicating which button was clicked</returns>
    public static async Task<MessageBoxResult> Show(Window owner, string message, string title = "Message", MessageBoxButtons buttons = MessageBoxButtons.Ok)
    {
        var messageBox = new MessageBox(title, message, buttons);
        return await messageBox.ShowDialog<MessageBoxResult>(owner);
    }

    /// <summary>
    /// Shows a message box with the specified parameters
    /// </summary>
    /// <param name="owner">The owner window of the message box</param>
    /// <param name="message">The message to display</param>
    /// <param name="title">The title of the message box</param>
    /// <param name="buttons">The buttons to show in the message box</param>
    /// <returns>The result indicating which button was clicked</returns>
    public static async Task<MessageBoxResult> Show(string message, string title = "Message", MessageBoxButtons buttons = MessageBoxButtons.Ok)
    {
        if(Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
        {
            var owner = desktopLifetime.MainWindow;
            var messageBox = new MessageBox(title, message, buttons);
            return await messageBox.ShowDialog<MessageBoxResult>(owner);
        }

        return MessageBoxResult.None;
    }
}

