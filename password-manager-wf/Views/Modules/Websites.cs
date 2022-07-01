using password_manager_wf.Controlles;
using password_manager_wf.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace password_manager_wf.Views
{
    public partial class Websites : Form
    {
        WebsiteService service = new WebsiteService();

        public Websites()
        {
            InitializeComponent();
        }

        private async void Websites_Load(object sender, EventArgs e)
        {
            List<Website> websites = await service.GetWebsites();

            if (websites != null)
            {
                dataGridView1.RowTemplate.Height = 50;
                dataGridView1.DataSource = websites;
                SetDataGridViewStyle();
                CountItems();
            }
        }

        private async void GetWebsites()
        {
            List<Website> websites = await service.GetWebsites();
            dataGridView1.DataSource = websites;
            CountItems();
        }

        private void SetDataGridViewStyle()
        {
            dataGridView1.Columns[0].DisplayIndex = 4;
            dataGridView1.Columns[1].DisplayIndex = 4;
            dataGridView1.Columns[0].Width = 20;
            dataGridView1.Columns[1].Width = 40;
            dataGridView1.Columns[2].HeaderText = "ID";
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[4].HeaderText = "Website name";
            dataGridView1.Columns[3].Visible = false;
        }

        private void CountItems()
        {
            int items = dataGridView1.Rows.Count;
            lb_countItems.Text = string.Format($"items: {items}");
        }

        private void btn_addWebsite_Click(object sender, EventArgs e)
        {
            WebsiteModal websiteModal = new WebsiteModal();
            var result = websiteModal.ShowDialog();

            if (result == DialogResult.OK)
            {
                GetWebsites();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[0].Selected)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    WebsiteModal websiteModal = new WebsiteModal(id, true);
                    websiteModal.txt_websiteName.Text = dataGridView1.Rows[e.RowIndex].Cells["websiteName"].Value.ToString();
                    var result = websiteModal.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        GetWebsites();
                    }
                }
                else if (dataGridView1.Rows[e.RowIndex].Cells[1].Selected)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    DeleteWebsite(id);
                }
            }
        }

        private async void DeleteWebsite(int id)
        {
            bool succes = await service.DeleteWebsite(id);

            if (succes)
            {
                GetWebsites();
            }
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            SearchWebsite();
        }

        private async void SearchWebsite()
        {
            string websiteName = txt_search.Text.Trim();
            List<Website> websites = await service.GetWebsite(websiteName);
            dataGridView1.DataSource = websites;
        }
    }
}
