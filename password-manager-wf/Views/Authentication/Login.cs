using password_manager_wf.Controlles;
using password_manager_wf.Models;
using password_manager_wf.Views;
using System.Windows.Forms;
using System;

namespace password_manager_wf
{
    public partial class Login : Form
    {
        UserService userService = new UserService();

        public Login()
        {
            InitializeComponent();
            txt_password.UseSystemPasswordChar = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            GetSession();
        }

        private void GetSession()
        {
            if (Properties.Settings.Default.success == true)
            {
                this.Hide();
                MainApp mainApp = new MainApp();
                mainApp.ShowDialog();
                this.Close();
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

        private void txt_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                VerifyUser();
            }
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                VerifyUser();
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            VerifyUser();
        }

        private async void VerifyUser()
        {
            if (!string.IsNullOrEmpty(txt_email.Text) && !string.IsNullOrEmpty(txt_password.Text))
            {
                User user = new User();
                user.email = txt_email.Text.Trim();
                user.password = txt_password.Text.Trim();

                ShowLoading();
                bool success =
                await userService.Login(user);

                if (success)
                {
                    this.Hide();
                    MainApp mainApp = new MainApp();
                    mainApp.ShowDialog();
                    this.Close();
                }
                HideLoading();
            }
            else
            {
                MessageBox.Show("Email and Password required", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowLoading()
        {
            pb_loading.Enabled = true;
            pb_loading.Visible = true;
            btn_login.Enabled = false;
            btn_login.Text = "Wait...";
        }

        private void HideLoading()
        {
            pb_loading.Enabled = false;
            pb_loading.Visible = false;
            btn_login.Enabled = true;
            btn_login.Text = "Login";
        }

        private void link_createAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
            this.Close();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
