using RSBot.General.Models;
using System;
using System.Windows.Forms;

namespace RSBot.General.Views
{
    public partial class Accounts : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Accounts"/> class.
        /// </summary>
        public Accounts()
        {
            InitializeComponent();
            LoadList();
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

            Components.Accounts.SavedAccounts[listAccounts.SelectedIndex] = new Account
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Servername = txtServername.Text
            };

            LoadList();
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
                txtUsername.Clear();
                txtServername.Clear();
                btnSave.Enabled = false;
            }
            else
            {
                txtPassword.Text = Components.Accounts.SavedAccounts[listAccounts.SelectedIndex].Password;
                txtUsername.Text = Components.Accounts.SavedAccounts[listAccounts.SelectedIndex].Username;
                txtServername.Text = Components.Accounts.SavedAccounts[listAccounts.SelectedIndex].Servername;
                btnSave.Enabled = true;
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
        /// Loads the list.
        /// </summary>
        private void LoadList()
        {
            listAccounts.Items.Clear();
            foreach (var account in Components.Accounts.SavedAccounts)
                listAccounts.Items.Add(account.Username);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
                return;
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
                return;

            if (listAccounts.Items.Contains(txtUsername.Text))
            {
                MessageBox.Show(
                    "This account name is already registered, please use a different name",
                    "Invalid account name", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Components.Accounts.SavedAccounts.Add(new Account
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Servername = txtServername.Text
            });

            LoadList();
        }
    }
}