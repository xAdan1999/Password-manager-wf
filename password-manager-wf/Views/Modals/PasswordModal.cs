using password_manager_wf.Controlles;
using password_manager_wf.Models;
using password_manager_wf.Cache;
using System.Windows.Forms;
using System;

namespace password_manager_wf.Views.Modals
{
    public partial class PasswordModal : Form
    {
        PasswordService passwordService = new PasswordService();

        private int _id;
        private bool _updatePassword = false;

        public PasswordModal()
        {
            InitializeComponent();
            txt_password.UseSystemPasswordChar = true;
        }

        public PasswordModal(int id, bool updatePassword)
        {
            InitializeComponent();

            btn_showPassword.Visible = false;
            btn_hidePassword.Visible = true;

            this._id = id;
            this._updatePassword = updatePassword;
            lb_title.Text = "Update password";
            btn_save.Text = "Update";
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
                    password.userId = UserCache.userId;
                    password.title = txt_title.Text.Trim();
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
                password.title = txt_title.Text.Trim();
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
