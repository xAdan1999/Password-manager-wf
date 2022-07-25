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

        //metodo para comprobar si hay una sesion guardada
        private void GetSession()
        {
            if (Properties.Settings.Default.loggedIn == true)
            {
                this.Hide();
                MainApp mainApp = new MainApp();
                mainApp.ShowDialog();
                this.Close();
            }
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

        private void txt_password_IconRightClick(object sender, EventArgs e)
        {
            if(txt_password.UseSystemPasswordChar == true)
            {
                txt_password.IconRight = Properties.Resources.hide_password;
                txt_password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.IconRight = Properties.Resources.show_password;
                txt_password.UseSystemPasswordChar = true;
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
                bool success = await userService.Login(user);

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
            btn_login.Enabled = false;
            btn_login.Text = "Wait...";
        }

        private void HideLoading()
        {
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
