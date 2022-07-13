using password_manager_wf.Controlles;
using password_manager_wf.Models;
using System.Windows.Forms;
using System;

namespace password_manager_wf.Views.Modals
{
    public partial class UserSettings : Form
    {
        UserService userService = new UserService();

        public UserSettings()
        {
            InitializeComponent();
        }

        private void ChangeUsername_Load(object sender, EventArgs e)
        {
            txt_username.Text = Properties.Settings.Default.username;
        }

        private void btn_updateUsername_Click(object sender, EventArgs e)
        {
            UpdateUsername();
        }

        private void txt_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                UpdateUsername();
            }
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
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                Properties.Settings.Default.username = txt_username.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Please enter an username", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_deleteAccount_Click(object sender, EventArgs e)
        {
            DeleteAccount();
        }

        private async void DeleteAccount()
        {
            int id = Properties.Settings.Default.userId;
            bool success = await userService.DeleteUser(id);

            if (success)
            {
                Properties.Settings.Default.success = false;
                Properties.Settings.Default.userId = 0;
                Properties.Settings.Default.username = string.Empty;
                Properties.Settings.Default.token = string.Empty;
                Properties.Settings.Default.Save();

                this.Hide();
                Login login = new Login();
                login.ShowDialog();
                this.Close();
            }
        }
    }
}
