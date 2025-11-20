using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RSBot.Core.Components;
using RSBot.General.Components;
using RSBot.General.Models;
using SDUI.Controls;

namespace RSBot.General.Views;

public partial class AccountsWindow : UIWindowBase
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AccountsWindow" /> class.
    /// </summary>
    public AccountsWindow()
    {
        InitializeComponent();
        comboBoxChannel.SelectedIndex = 0;
        Text = "Accounts";
    }

    /// <summary>
    ///     Clear the textboxes
    /// </summary>
    private void ClearTextboxes()
    {
        txtPassword.Text = string.Empty;
        textBoxSecondaryPassword.Text = string.Empty;
        txtUsername.Text = string.Empty;
        txtServername.Text = string.Empty;
        btnSave.Enabled = false;
        btnAdd.Visible = true;
    }

    /// <summary>
    ///     Handles the load event of the form control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void Accounts_Load(object sender, EventArgs e)
    {
        ClearTextboxes();
        listAccounts.BeginUpdate();

        listAccounts.Items.Clear();
        foreach (var account in Accounts.SavedAccounts)
            listAccounts.Items.Add(account);

        listAccounts.EndUpdate();
    }

    /// <summary>
    ///     Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnSave_Click(object sender, EventArgs e)
    {
        if (listAccounts.SelectedIndex == -1)
            return;

        var selectedAccount = listAccounts.SelectedItem as Account;
        if (selectedAccount == null)
            return;

        selectedAccount.Username = txtUsername.Text.ToLowerInvariant();
        selectedAccount.Password = txtPassword.Text;
        selectedAccount.SecondaryPassword = textBoxSecondaryPassword.Text;
        selectedAccount.Servername = txtServername.Text;
        selectedAccount.Channel = (byte)(comboBoxChannel.SelectedIndex + 1);

        /*
         * The listAccounts. Invalidate, Update, Refresh methods not updating the item text
         * with class override tostring method after update the account class.
         * For that i called the method again. No have more idea.
         */

        listAccounts.SelectedIndex = -1;
        Accounts_Load(sender, e);
    }

    /// <summary>
    ///     Handles the SelectedIndexChanged event of the listAccounts control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void listAccounts_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listAccounts.SelectedIndex == -1)
        {
            ClearTextboxes();
        }
        else
        {
            var selectedAccount = listAccounts.SelectedItem as Account;
            if (selectedAccount == null)
                return;

            txtUsername.Text = selectedAccount.Username;
            txtPassword.Text = selectedAccount.Password;
            textBoxSecondaryPassword.Text = selectedAccount.SecondaryPassword;
            txtServername.Text = selectedAccount.Servername;
            comboBoxChannel.SelectedIndex = selectedAccount.Channel - 1;
            btnSave.Enabled = true;
            btnAdd.Visible = false;
        }
    }

    /// <summary>
    ///     Handles the Click event of the btnOK control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnOK_Click(object sender, EventArgs e)
    {
        Accounts.Save();
    }

    /// <summary>
    ///     Handles the Click event of the linkLabelPwShowHide control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void linkLabelPwShowHide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        if (txtPassword.UseSystemPasswordChar)
        {
            txtPassword.UseSystemPasswordChar = false;
            linkLabelPwShowHide.Text = LanguageManager.GetLang("Hide");
        }
        else
        {
            txtPassword.UseSystemPasswordChar = true;
            linkLabelPwShowHide.Text = LanguageManager.GetLang("Show");
        }
    }

    /// <summary>
    ///     Handles the Click event of the linkLabelSecondaryPassword control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void linkLabelSecondaryPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        if (textBoxSecondaryPassword.UseSystemPasswordChar)
        {
            textBoxSecondaryPassword.UseSystemPasswordChar = false;
            linkLabelSecondaryPassword.Text = LanguageManager.GetLang("Hide");
        }
        else
        {
            textBoxSecondaryPassword.UseSystemPasswordChar = true;
            linkLabelSecondaryPassword.Text = LanguageManager.GetLang("Show");
        }
    }

    /// <summary>
    ///     Handles the Click event of the btnAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUsername.Text))
            return;

        if (string.IsNullOrWhiteSpace(txtPassword.Text))
            return;

        if (Accounts.SavedAccounts.Any(p => p.Username == txtUsername.Text))
        {
            var title = LanguageManager.GetLang("MsgBoxAlreadyRegisteredTitle");
            var content = LanguageManager.GetLang("MsgBoxAlreadyRegisteredContent");

            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
        }

        var account = new Account
        {
            Username = txtUsername.Text.ToLowerInvariant(),
            Password = txtPassword.Text,
            SecondaryPassword = textBoxSecondaryPassword.Text,
            Servername = txtServername.Text,
            SelectedCharacter = string.Empty,
            Channel = (byte)(comboBoxChannel.SelectedIndex + 1),
            Characters = new List<string>(4),
        };

        Accounts.SavedAccounts.Add(account);

        listAccounts.SelectedIndex = listAccounts.Items.Add(account);
    }

    /// <summary>
    ///     Handles the Click event of the buttonRemove control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void buttonRemove_Click(object sender, EventArgs e)
    {
        if (listAccounts.SelectedIndex == -1)
            return;

        var selectedAccount = listAccounts.SelectedItem as Account;
        if (selectedAccount == null)
            return;

        var isSuccess = Accounts.SavedAccounts.Remove(selectedAccount);
        if (isSuccess)
            listAccounts.Items.Remove(selectedAccount);
    }
}
