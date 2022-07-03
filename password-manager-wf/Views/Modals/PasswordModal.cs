using password_manager_wf.Controlles;
using password_manager_wf.Models;
using System.Windows.Forms;
using System;

namespace password_manager_wf.Views.Modals
{
    public partial class PasswordModal : Form
    {
        PasswordService passwordService = new PasswordService();
        WebsiteService websiteService = new WebsiteService();

        private int _id;
        private bool _updatePassword = false;

        public PasswordModal()
        {
            InitializeComponent();
            GetWebsites();
        }

        public PasswordModal(int id, bool updatePassword)
        {
            InitializeComponent();
            GetWebsites();

            this._id = id;
            this._updatePassword = updatePassword;
            lb_title.Text = "Update website";
            btn_save.Text = "Update";
        }

        private async void GetWebsites()
        {
            cb_website.DataSource = await websiteService.GetWebsites();
            cb_website.DisplayMember = "websiteName";
            cb_website.ValueMember = "id";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            InsertUpdate();
        }

        private void txt_usernameOrEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                InsertUpdate();
            }
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                InsertUpdate();
            }
        }

        private async void InsertUpdate()
        {
            if (_updatePassword == false)
            {
                if (!string.IsNullOrEmpty(txt_usernameOrEmail.Text.Trim()) && !string.IsNullOrEmpty(txt_password.Text.Trim()))
                {
                    Password password = new Password();
                    password.userId = 1;
                    password.websiteId = Convert.ToInt32(cb_website.SelectedValue);
                    password.usernameOrEmail = txt_usernameOrEmail.Text.Trim();
                    password.passwordToSave = txt_password.Text.Trim();

                    bool success = await passwordService.InsertPassword(password);

                    if (success)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else if (_updatePassword == true)
            {
                Password password = new Password();
                password.id = this._id;
                password.websiteId = Convert.ToInt32(cb_website.SelectedValue);
                password.usernameOrEmail = txt_usernameOrEmail.Text.Trim();
                password.passwordToSave = txt_password.Text.Trim();

                bool success = await passwordService.UpdatePassword(password);

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
