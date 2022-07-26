using password_manager_wf.Models.Responses;
using password_manager_wf.Views.Modals;
using password_manager_wf.Views.Tools;
using password_manager_wf.Properties;
using password_manager_wf.Controlles;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace password_manager_wf.Views
{
    public partial class MainApp : Form
    {
        PasswordService passwordService = new PasswordService();

        List<PasswordResponse> passwords;

        public MainApp()
        {
            InitializeComponent();
        }

        private void MainApp_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 45;
            GetPasswords();
            GetUserInfo();
        }

        private void GetUserInfo()
        {
            lb_username.Text = Settings.Default.username;
        }

        private void btn_userSettings_Click(object sender, EventArgs e)
        {
            UserSettings userSettings = new UserSettings();
            ModalBackgroud.CreateBackground(userSettings);

            if(userSettings.type.Equals("update"))
            {
                GetUserInfo();
            }
            else if (userSettings.type.Equals("logout") || userSettings.type.Equals("deleted account"))
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
                this.Close();
            }
        }

        private async void GetPasswords()
        {
            lb_message.Visible = true;
            passwords = await passwordService.GetPasswords();
            dataGridView1.DataSource = passwords;
            lb_message.Visible = false;

            if (dataGridView1.Rows.Count > 0)
            {
                SetDataGridViewStyle();
                CountItems();
            }
        }

        private void SetDataGridViewStyle()
        {
            dataGridView1.Columns[0].DisplayIndex = 6;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Title";
            dataGridView1.Columns[3].HeaderText = "Username or email";
            dataGridView1.Columns[4].HeaderText = "Password";
            dataGridView1.Columns[5].HeaderText = "Created";
            dataGridView1.Columns[6].HeaderText = "Updated";
        }

        private async void SearchPassword()
        {
            string search = txt_search.Text.Trim();
            passwords = await passwordService.SearchPassword(search);
            dataGridView1.DataSource = passwords;
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            SearchPassword();
        }

        private void btn_addPassword_Click(object sender, EventArgs e)
        {
            using (PasswordModal modal = new PasswordModal())
            {
                var result = ModalBackgroud.CreateBackground(modal);

                if (result == DialogResult.OK)
                {
                    GetPasswords();
                }
            }
        }

        private void btn_reloadData_Click(object sender, EventArgs e)
        {
            GetPasswords();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[0].Selected)
                    {
                        int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                        PasswordModal modal = new PasswordModal(id, true);
                        modal.txt_title.Text = dataGridView1.Rows[e.RowIndex].Cells["title"].Value.ToString().Trim();
                        modal.txt_usernameOrEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["username_or_email"].Value.ToString().Trim();
                        modal.txt_password.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].Value.ToString().Trim();
                        var result = ModalBackgroud.CreateBackground(modal);

                        if (result == DialogResult.OK)
                        {
                            GetPasswords();
                        }
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                e.Value = new string('●', e.Value.ToString().Length);
            }
        }

        private void CountItems()
        {
            int items = dataGridView1.Rows.Count;
            lb_countItems.Text = string.Format($"{items} items");
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
