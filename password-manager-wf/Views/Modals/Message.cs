using System.Windows.Forms;
using System;

namespace password_manager_wf.Views.Modals
{
    public partial class Message : Form
    {
        public Message(string title, string message)
        {
            InitializeComponent();
            lb_title.Text = title;
            lb_message.Text = message;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
