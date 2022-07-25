using password_manager_wf.Controlles;
using password_manager_wf.Models;
using password_manager_wf.Views;
using password_manager_wf.Tools;
using System.Windows.Forms;
using System;

namespace password_manager_wf
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            txt_password.UseSystemPasswordChar = true;
        }

        private void btn_createAccount_Click(object sender, EventArgs e)
        {
            CreateAccount();
        }

        private void txt_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CreateAccount();
            }
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_email.Text))
            {
                if (lb_help.Visible == true)
                { 
                    lb_help.Visible = false;
                }
            }
            else
            {
                if (!ValidateValues.ValidateEmail(txt_email.Text))
                {
                    lb_help.Visible = true;
                }
                else
                {
                    lb_help.Visible = false;
                }
            }
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CreateAccount();
            }
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_password.Text))
            {
                if (lb_help2.Visible == true)
                {
                    lb_help2.Visible = false;
                    lb_help3.Visible = false;
                }
            }
            else
            {
                if (ValidateValues.ValidatePassword(txt_password.Text) == false)
                {
                    lb_help2.Visible = true;
                    lb_help3.Visible = true;
                }
                else
                {
                    lb_help2.Visible = false;
                    lb_help3.Visible = false;
                }
            }
        }

        private void txt_password_IconRightClick(object sender, EventArgs e)
        {
            if (txt_password.UseSystemPasswordChar == true)
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

        private void txt_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CreateAccount();
            }
        }

        private async void CreateAccount()
        {
            if(!string.IsNullOrEmpty(txt_email.Text.Trim())
            && !string.IsNullOrEmpty(txt_password.Text.Trim())
            && !string.IsNullOrEmpty(txt_username.Text.Trim()))
            {
                User user = new User();
                user.email = txt_email.Text.Trim();
                user.password = txt_password.Text.Trim();
                user.username = txt_username.Text.Trim();

                if (lb_help.Visible == true || lb_help2.Visible == true)
                {
                    MessageBox.Show("Please check the email and password", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ShowLoading();

                UserService service = new UserService();
                bool success = await service.SignUp(user);

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
                MessageBox.Show("Please fill all fields!", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowLoading()
        {
            btn_createAccount.Enabled = false;
            btn_createAccount.Text = "Creating account...";
        }

        private void HideLoading()
        {
            btn_createAccount.Enabled = true;
            btn_createAccount.Text = "Create account";
        }

        private void SignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }
    }
}
