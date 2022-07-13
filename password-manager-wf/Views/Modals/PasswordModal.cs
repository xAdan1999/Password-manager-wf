using password_manager_wf.Controlles;
using password_manager_wf.Models;
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
            txt_password.UseSystemPasswordChar = true;

            this._id = id;
            this._updatePassword = updatePassword;
        }

        private void PasswordModal_Load(object sender, EventArgs e)
        {
            lb_title.Text = "Update password";
            btn_save.Text = "Update";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            InsertUpdate();
        }

        private void txt_title_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                InsertUpdate();
            }
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
            //verificar que ningun campo este vacio
            if ( !string.IsNullOrEmpty(txt_title.Text.Trim())
            && !string.IsNullOrEmpty(txt_usernameOrEmail.Text.Trim())
            && !string.IsNullOrEmpty(txt_password.Text.Trim()))
            {
                //crear el objeto con los valoes base
                Password password = new Password();
                password.title = txt_title.Text.Trim();
                password.usernameOrEmail = txt_usernameOrEmail.Text.Trim();
                password.passwordToSave = txt_password.Text.Trim();

                //para manejar la respuesta
                bool success;

                if (_updatePassword == false)
                {
                    /*como se va a agregar, construir el objeto con el userId
                     * ya que se agregara el registro para ese usuario*/
                    password.userId = Properties.Settings.Default.userId;
                    success = await passwordService.InsertPassword(password);
                }
                else
                {
                    /*si se actualiza, contruir el objeto solo añadiendo el id del registro*/
                    password.id = this._id;
                    success = await passwordService.UpdatePassword(password);
                }

                //evaluar la respuesta
                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields!", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
