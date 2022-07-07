using password_manager_wf.Controlles;
using password_manager_wf.Models;
using password_manager_wf.Views;
using System.Windows.Forms;
using System;

namespace password_manager_wf
{
    public partial class SignUp : Form
    {
        UserService service = new UserService();

        public SignUp()
        {
            InitializeComponent();
            txt_password.UseSystemPasswordChar = true;
        }

        private void ShowLoading()
        {
            pb_loading.Enabled = true;
            pb_loading.Visible = true;
            btn_createAccount.Enabled = false;
            btn_createAccount.Text = "Creating account...";
        }

        private async void btn_createAccount_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_email.Text.Trim())
            && !string.IsNullOrEmpty(txt_password.Text.Trim())
            && !string.IsNullOrEmpty(txt_username.Text.Trim()))
            {
                User user = new User();
                user.email = txt_email.Text.Trim();
                user.password = txt_password.Text.Trim();
                user.username = txt_username.Text.Trim();

                ShowLoading();
                bool success = await service.SignUp(user);

                if (success)
                {
                    this.Hide();
                    MainApp mainApp = new MainApp();
                    mainApp.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_showPassword_Click(object sender, EventArgs e)
        {
            txt_password.Focus();
            btn_showPassword.Visible = false;
            btn_hidePassword.Visible = true;
            txt_password.UseSystemPasswordChar = false;
        }

        private void btn_hidePassword_Click(object sender, EventArgs e)
        {
            txt_password.Focus();
            btn_showPassword.Visible = true;
            btn_hidePassword.Visible = false;
            txt_password.UseSystemPasswordChar = true;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }
    }
}
