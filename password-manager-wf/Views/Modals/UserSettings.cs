using password_manager_wf.Views.Tools;
using password_manager_wf.Controlles;
using password_manager_wf.Models;
using System.Windows.Forms;
using System;

namespace password_manager_wf.Views.Modals
{
    public partial class UserSettings : Form
    {
        UserService userService = new UserService();

        public string type;

        public UserSettings()
        {
            InitializeComponent();
        }

        private void ChangeUsername_Load(object sender, EventArgs e)
        {
            txt_username.Text = Properties.Settings.Default.username;
        }

        private void txt_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                UpdateUsername();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            UpdateUsername();
        }

        private async void UpdateUsername()
        {
            if (!string.IsNullOrEmpty(txt_username.Text))
            {
                User user = new User();
                user.username = txt_username.Text.Trim();
                user.id = Properties.Settings.Default.userId;

                bool success = await userService.UpdateUsername(user);

                if (success)
                {
                    Properties.Settings.Default.username = txt_username.Text;
                    Properties.Settings.Default.Save();
                    this.type = "update";
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter a username", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_deleteAccount_Click(object sender, EventArgs e)
        {
            using (Message deleteAccount = new Message("Deleted Account","Your account will be deleted, are you sure?"))
            {
                var result = ModalBackgroud.CreateBackground(deleteAccount);

                if (result == DialogResult.Yes)
                {
                    DeleteAccount();
                }
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            using (Message logout = new Message("Log out", "Are you sure you want to log out??"))
            {
                var result = ModalBackgroud.CreateBackground(logout);

                if (result == DialogResult.Yes)
                {
                    DeleteSession();
                }
            }
        }

        private async void DeleteAccount()
        {
            bool success = await userService.DeleteUser(Properties.Settings.Default.userId);

            if (success)
            {
                Properties.Settings.Default.loggedIn = false;
                Properties.Settings.Default.userId = 0;
                Properties.Settings.Default.username = string.Empty;
                Properties.Settings.Default.token = string.Empty;
                Properties.Settings.Default.Save();
                this.type = "deleted account";
                this.Close();
            }
        }

        private void DeleteSession()
        {
            Properties.Settings.Default.loggedIn = false;
            Properties.Settings.Default.userId = 0;
            Properties.Settings.Default.username = string.Empty;
            Properties.Settings.Default.token = string.Empty;
            Properties.Settings.Default.Save();
            this.type = "logout";
            this.Close();
        }

        private void btn_cancel_Click_1(object sender, EventArgs e)
        {
            this.type = "close";
            this.Close();
        }
    }
}
