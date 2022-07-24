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

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter an username", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_deleteAccount_Click(object sender, EventArgs e)
        {
            using (Deleted deleteAccount = new Deleted("Deleted Account","Your account will be deleted, are you sure?"))
            {
                var result = deleteAccount.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    DeleteAccount();
                }
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            DeleteSession();
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

        private void DeleteSession()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
