using password_manager_wf.Views.Modals;
using password_manager_wf.Controlles;
using password_manager_wf.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace password_manager_wf.Views
{
    public partial class Home : Form
    {
        PasswordService passwordService = new PasswordService();

        public Home()
        {
            InitializeComponent();
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            List<Password> passwords = await passwordService.GetPasswords();

            if (passwords != null)
            {
                dataGridView1.RowTemplate.Height = 50;
                dataGridView1.DataSource = passwords;
                SetDataGridViewStyle();
                CountItems();
            }
        }

        private async void GetPasswords()
        {
            List<Password> passwords = await passwordService.GetPasswords();
            dataGridView1.DataSource = passwords;
            CountItems();
        }

        private void SetDataGridViewStyle()
        {
            dataGridView1.Columns[0].DisplayIndex = 7;
            dataGridView1.Columns[1].DisplayIndex = 7;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[2].HeaderText = "ID";
            dataGridView1.Columns[2].Width = 110;
            dataGridView1.Columns[5].HeaderText = "Website";
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].HeaderText = "Username or email";
            dataGridView1.Columns[6].Width = 250;
            dataGridView1.Columns[7].HeaderText = "Password";
            dataGridView1.Columns[7].Width = 450;
        }

        private void CountItems()
        {
            int items = dataGridView1.Rows.Count;
            lb_countItems.Text = string.Format($"items: {items}");
        }

        private void btn_addWebsite_Click(object sender, EventArgs e)
        {
            PasswordModal modal = new PasswordModal();
            var result = modal.ShowDialog();

            if (result == DialogResult.OK)
            {
                GetPasswords();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[0].Selected)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    PasswordModal modal = new PasswordModal(id, true);
                    modal.cb_website.Text = dataGridView1.Rows[e.RowIndex].Cells["websiteName"].Value.ToString();
                    modal.txt_usernameOrEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["usernameOrEmail"].Value.ToString();
                    modal.txt_password.Text = dataGridView1.Rows[e.RowIndex].Cells["passwordToSave"].Value.ToString();
                    var result = modal.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        GetPasswords();
                    }
                }
                else if (dataGridView1.Rows[e.RowIndex].Cells[1].Selected)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    DeletePassword(id);
                }
            }
        }

        private async void DeletePassword(int id)
        {
            bool succes = await passwordService.DeletePassword(id);

            if (succes)
            {
                GetPasswords();
            }
        }

        private void txt_search_TextChanged_1(object sender, EventArgs e)
        {
            SearchPassword();
        }

        private async void SearchPassword()
        {
            string search= txt_search.Text.Trim();
            List<Password> passwords = await passwordService.GetPassword(search);
            dataGridView1.DataSource = passwords;
        }
    }
}
