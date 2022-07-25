using System.Windows.Forms;
using System;

namespace password_manager_wf.Views.Tools
{
    class ModalBackgroud
    {
        public static DialogResult CreateBackground(Form dialog)
        {
            using (var plexi = new Form())
            {
                plexi.FormBorderStyle = FormBorderStyle.None;
                plexi.Bounds = Screen.FromPoint(dialog.Location).Bounds;
                plexi.StartPosition = FormStartPosition.Manual;
                plexi.AutoScaleMode = AutoScaleMode.None;
                plexi.ShowInTaskbar = false;
                plexi.BackColor = System.Drawing.Color.Black;
                plexi.Opacity = 0.45;
                plexi.Show();
                dialog.StartPosition = FormStartPosition.CenterParent;
                return dialog.ShowDialog(plexi);
            }
        }
    }
}
