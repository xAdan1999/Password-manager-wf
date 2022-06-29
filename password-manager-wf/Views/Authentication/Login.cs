using password_manager_wf.Views;
using System.Windows.Forms;
using System;

namespace password_manager_wf
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void link_createAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUp = new SignUp(this);
            signUp.Show();
            this.Hide();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            MainApp mainApp = new MainApp();
            mainApp.ShowDialog();
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
