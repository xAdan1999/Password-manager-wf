
namespace password_manager_wf.Views
{
    partial class MainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApp));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_exit = new Guna.UI2.WinForms.Guna2TileButton();
            this.btn_settings = new Guna.UI2.WinForms.Guna2TileButton();
            this.btn_websites = new Guna.UI2.WinForms.Guna2TileButton();
            this.btn_home = new Guna.UI2.WinForms.Guna2TileButton();
            this.pl_container = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.btn_exit);
            this.panel1.Controls.Add(this.btn_settings);
            this.panel1.Controls.Add(this.btn_websites);
            this.panel1.Controls.Add(this.btn_home);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(88, 588);
            this.panel1.TabIndex = 0;
            // 
            // btn_exit
            // 
            this.btn_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_exit.Animated = true;
            this.btn_exit.BorderRadius = 16;
            this.btn_exit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_exit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_exit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_exit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_exit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btn_exit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.Color.Gray;
            this.btn_exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_exit.Image")));
            this.btn_exit.Location = new System.Drawing.Point(6, 509);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 70);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "Exit";
            this.btn_exit.TextOffset = new System.Drawing.Point(1, 0);
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_settings
            // 
            this.btn_settings.Animated = true;
            this.btn_settings.BorderRadius = 16;
            this.btn_settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_settings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_settings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_settings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_settings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_settings.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btn_settings.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_settings.ForeColor = System.Drawing.Color.Gray;
            this.btn_settings.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_settings.Image = ((System.Drawing.Image)(resources.GetObject("btn_settings.Image")));
            this.btn_settings.Location = new System.Drawing.Point(6, 196);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(75, 70);
            this.btn_settings.TabIndex = 2;
            this.btn_settings.Text = "Settings";
            this.btn_settings.TextOffset = new System.Drawing.Point(1, 0);
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // btn_websites
            // 
            this.btn_websites.Animated = true;
            this.btn_websites.BorderRadius = 16;
            this.btn_websites.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(140)))), ((int)(((byte)(242)))));
            this.btn_websites.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_websites.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_websites.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_websites.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_websites.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_websites.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btn_websites.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_websites.ForeColor = System.Drawing.Color.Gray;
            this.btn_websites.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_websites.Image = ((System.Drawing.Image)(resources.GetObject("btn_websites.Image")));
            this.btn_websites.ImageSize = new System.Drawing.Size(17, 17);
            this.btn_websites.Location = new System.Drawing.Point(6, 108);
            this.btn_websites.Name = "btn_websites";
            this.btn_websites.Size = new System.Drawing.Size(75, 70);
            this.btn_websites.TabIndex = 1;
            this.btn_websites.Text = "Websites";
            this.btn_websites.TextOffset = new System.Drawing.Point(1, 0);
            this.btn_websites.Click += new System.EventHandler(this.btn_websites_Click);
            // 
            // btn_home
            // 
            this.btn_home.Animated = true;
            this.btn_home.BorderRadius = 16;
            this.btn_home.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(140)))), ((int)(((byte)(242)))));
            this.btn_home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_home.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_home.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_home.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_home.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_home.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btn_home.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_home.ForeColor = System.Drawing.Color.Gray;
            this.btn_home.HoverState.ForeColor = System.Drawing.Color.White;
            this.btn_home.Image = ((System.Drawing.Image)(resources.GetObject("btn_home.Image")));
            this.btn_home.Location = new System.Drawing.Point(6, 20);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(75, 70);
            this.btn_home.TabIndex = 0;
            this.btn_home.Text = "Home";
            this.btn_home.TextOffset = new System.Drawing.Point(1, 0);
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // pl_container
            // 
            this.pl_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_container.Location = new System.Drawing.Point(88, 0);
            this.pl_container.Name = "pl_container";
            this.pl_container.Size = new System.Drawing.Size(901, 588);
            this.pl_container.TabIndex = 1;
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(989, 588);
            this.Controls.Add(this.pl_container);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1005, 627);
            this.Name = "MainApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainApp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pl_container;
        private Guna.UI2.WinForms.Guna2TileButton btn_home;
        private Guna.UI2.WinForms.Guna2TileButton btn_settings;
        private Guna.UI2.WinForms.Guna2TileButton btn_websites;
        private Guna.UI2.WinForms.Guna2TileButton btn_exit;
    }
}