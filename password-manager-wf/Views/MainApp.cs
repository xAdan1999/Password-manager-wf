using System.Windows.Forms;
using System;
using System.Net;
using System.Drawing;
using password_manager_wf.Views.Modals;
using password_manager_wf.Cache;

namespace password_manager_wf.Views
{
    public partial class MainApp : Form
    {
        Form form = null;
        Login _login;

        public MainApp(Login login)
        {
            InitializeComponent();
            //OpenChildForm(new Home());
            GetUserInfo();
            _login = login;
        }

        private void GetUserInfo()
        {
            lb_username.Text = UserCache.username;
        }

        private void OpenChildForm(Form childForm)
        {
            if (form != null) form.Close();
            form = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            pl_container.Controls.Add(childForm);
            pl_container.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Home());
        }

        private void btn_websites_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Websites());
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
            _login.Show();
        }
    }
}
