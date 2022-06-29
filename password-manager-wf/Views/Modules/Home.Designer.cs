
namespace password_manager_wf.Views
{
    partial class Home
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
            this.lb_email = new System.Windows.Forms.Label();
            this.lb_username = new System.Windows.Forms.Label();
            this.lb_password = new System.Windows.Forms.Label();
            this.lb_token = new System.Windows.Forms.Label();
            this.lb_id = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_email
            // 
            this.lb_email.AutoSize = true;
            this.lb_email.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_email.ForeColor = System.Drawing.Color.Gray;
            this.lb_email.Location = new System.Drawing.Point(113, 181);
            this.lb_email.Name = "lb_email";
            this.lb_email.Size = new System.Drawing.Size(47, 17);
            this.lb_email.TabIndex = 17;
            this.lb_email.Text = "Email: ";
            this.lb_email.Click += new System.EventHandler(this.label2_Click);
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.ForeColor = System.Drawing.Color.White;
            this.lb_username.Location = new System.Drawing.Point(113, 80);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(228, 40);
            this.lb_username.TabIndex = 16;
            this.lb_username.Text = "Hello xAdan99!";
            this.lb_username.Click += new System.EventHandler(this.label1_Click);
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_password.ForeColor = System.Drawing.Color.Gray;
            this.lb_password.Location = new System.Drawing.Point(113, 207);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(66, 17);
            this.lb_password.TabIndex = 18;
            this.lb_password.Text = "Password";
            // 
            // lb_token
            // 
            this.lb_token.AutoSize = true;
            this.lb_token.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_token.ForeColor = System.Drawing.Color.Gray;
            this.lb_token.Location = new System.Drawing.Point(113, 233);
            this.lb_token.Name = "lb_token";
            this.lb_token.Size = new System.Drawing.Size(47, 17);
            this.lb_token.TabIndex = 19;
            this.lb_token.Text = "Token:";
            // 
            // lb_id
            // 
            this.lb_id.AutoSize = true;
            this.lb_id.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_id.ForeColor = System.Drawing.Color.Gray;
            this.lb_id.Location = new System.Drawing.Point(113, 155);
            this.lb_id.Name = "lb_id";
            this.lb_id.Size = new System.Drawing.Size(24, 17);
            this.lb_id.TabIndex = 20;
            this.lb_id.Text = "ID:";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(758, 493);
            this.Controls.Add(this.lb_id);
            this.Controls.Add(this.lb_token);
            this.Controls.Add(this.lb_password);
            this.Controls.Add(this.lb_email);
            this.Controls.Add(this.lb_username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_email;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.Label lb_token;
        private System.Windows.Forms.Label lb_id;
    }
}