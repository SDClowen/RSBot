using RSBot.General.Models;
using RSBot.Theme.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RSBot.General.Views
{
    public partial class Accounts : CleanForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Accounts"/> class.
        /// </summary>
        public Accounts()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the load event of the form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Accounts_Load(object sender, EventArgs e)
        {
            listAccounts.BeginUpdate();

            listAccounts.Items.Clear();
            foreach (var account in Components.Accounts.SavedAccounts)
                listAccounts.Items.Add(account);

            listAccounts.EndUpdate();
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

            /*
             * The listAccounts. Invalidate, Update, Refresh methods not updating the item text 
             * with class override tostring method after update the account class.
             * For that i called the method again. No have more idea.
             */

            listAccounts.SelectedIndex = -1;
            Accounts_Load(sender, e);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the listAccounts control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void listAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listAccounts.SelectedIndex == -1)
            {
                txtPassword.Clear();
                textBoxSecondaryPassword.Clear();
                txtUsername.Clear();
                txtServername.Clear();
                btnSave.Enabled = false;
                btnAdd.Visible = true;
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

                btnSave.Enabled = true;
                btnAdd.Visible = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Components.Accounts.Save();
        }

        /// <summary>
        /// Handles the Click event of the linkLabelPwShowHide control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void linkLabelPwShowHide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                linkLabelPwShowHide.Text = "Hide";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                linkLabelPwShowHide.Text = "Show";
            }
        }

        /// <summary>
        /// Handles the Click event of the linkLabelSecondaryPassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void linkLabelSecondaryPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBoxSecondaryPassword.UseSystemPasswordChar)
            {
                textBoxSecondaryPassword.UseSystemPasswordChar = false;
                linkLabelSecondaryPassword.Text = "Hide";
            }
            else
            {
                textBoxSecondaryPassword.UseSystemPasswordChar = true;
                linkLabelSecondaryPassword.Text = "Show";
            }
        }

        /// <summary>
        /// Handles the Click event of the btnAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
                return;

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
                return;

            if (Components.Accounts.SavedAccounts.Any(p => p.Username == txtUsername.Text))
            {
                MessageBox.Show(
                    "This account name is already registered, please use a different name",
                    "Invalid account name", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var account = new Account
            {
                Username = txtUsername.Text.ToLowerInvariant(),
                Password = txtPassword.Text,
                SecondaryPassword = textBoxSecondaryPassword.Text,
                Servername = txtServername.Text,
                SelectedCharacter = string.Empty,
                Characters = new List<string>(4)
            };

            Components.Accounts.SavedAccounts.Add(account);

            listAccounts.SelectedIndex = listAccounts.Items.Add(account);
        }

        /// <summary>
        /// Handles the Click event of the buttonRemove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedIndex == -1)
                return;

            var selectedAccount = listAccounts.SelectedItem as Account;
            if (selectedAccount == null)
                return;

            var isSuccess = Components.Accounts.SavedAccounts.Remove(selectedAccount);
            if (isSuccess)
                listAccounts.Items.Remove(selectedAccount);
        }
    }
}