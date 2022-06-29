using password_manager_wf.Controlles;
using password_manager_wf.Models;
using System.Windows.Forms;
using System;

namespace password_manager_wf.Views
{
    public partial class WebsiteModal : Form
    {
        WebsiteService service= new WebsiteService();

        private int _id;
        private bool _updateWebsite = false;

        public WebsiteModal()
        {
            InitializeComponent();
        }

        public WebsiteModal(int id, bool updateWebsite)
        {
            InitializeComponent();

            this._id = id;
            this._updateWebsite = updateWebsite;
            lb_title.Text = "Update website";
            btn_add.Text = "Update";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            InsertUpdate();
        }

        private void txt_websiteName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                InsertUpdate();
            }
        }

        private async void InsertUpdate()
        {
            if (_updateWebsite == false)
            {
                if (!string.IsNullOrEmpty(txt_websiteName.Text))
                {
                    Website website = new Website();
                    website.userId = 1;
                    website.websiteName = txt_websiteName.Text.Trim();
                    bool success = await service.InsertWebsite(website);

                    if (success)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else if (_updateWebsite == true)
            {
                if (!string.IsNullOrEmpty(txt_websiteName.Text))
                {
                    Website website = new Website();
                    website.id = this._id;
                    website.websiteName = txt_websiteName.Text.Trim();
                    bool success = await service.UpdateWebsite(website);

                    if (success)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
