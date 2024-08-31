namespace WindowsForms
{
    partial class AuthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel9 = new MetroFramework.Controls.MetroPanel();
            this.password = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.metroPanel8 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel5 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel7 = new MetroFramework.Controls.MetroPanel();
            this.login = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.metroPanel6 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.submit2 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.error_auth = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.metroPanel9.SuspendLayout();
            this.metroPanel5.SuspendLayout();
            this.metroPanel7.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroPanel4);
            this.metroPanel1.Controls.Add(this.metroPanel3);
            this.metroPanel1.Controls.Add(this.metroPanel2);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(269, 230);
            this.metroPanel1.TabIndex = 6;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroPanel4
            // 
            this.metroPanel4.Controls.Add(this.metroPanel9);
            this.metroPanel4.Controls.Add(this.metroPanel8);
            this.metroPanel4.Controls.Add(this.metroPanel5);
            this.metroPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(0, 23);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(269, 130);
            this.metroPanel4.TabIndex = 8;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // metroPanel9
            // 
            this.metroPanel9.Controls.Add(this.password);
            this.metroPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel9.HorizontalScrollbarBarColor = true;
            this.metroPanel9.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel9.HorizontalScrollbarSize = 10;
            this.metroPanel9.Location = new System.Drawing.Point(15, 61);
            this.metroPanel9.Name = "metroPanel9";
            this.metroPanel9.Size = new System.Drawing.Size(254, 69);
            this.metroPanel9.TabIndex = 8;
            this.metroPanel9.VerticalScrollbarBarColor = true;
            this.metroPanel9.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel9.VerticalScrollbarSize = 10;
            // 
            // password
            // 
            this.password.BorderColorFocused = System.Drawing.Color.Blue;
            this.password.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.password.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.password.BorderThickness = 3;
            this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.password.isPassword = true;
            this.password.Location = new System.Drawing.Point(41, 16);
            this.password.Margin = new System.Windows.Forms.Padding(4);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(171, 25);
            this.password.TabIndex = 6;
            this.password.Text = "admin";
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // metroPanel8
            // 
            this.metroPanel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.metroPanel8.HorizontalScrollbarBarColor = true;
            this.metroPanel8.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel8.HorizontalScrollbarSize = 10;
            this.metroPanel8.Location = new System.Drawing.Point(0, 61);
            this.metroPanel8.Name = "metroPanel8";
            this.metroPanel8.Size = new System.Drawing.Size(15, 69);
            this.metroPanel8.TabIndex = 7;
            this.metroPanel8.VerticalScrollbarBarColor = true;
            this.metroPanel8.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel8.VerticalScrollbarSize = 10;
            // 
            // metroPanel5
            // 
            this.metroPanel5.Controls.Add(this.metroPanel7);
            this.metroPanel5.Controls.Add(this.metroPanel6);
            this.metroPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel5.HorizontalScrollbarBarColor = true;
            this.metroPanel5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel5.HorizontalScrollbarSize = 10;
            this.metroPanel5.Location = new System.Drawing.Point(0, 0);
            this.metroPanel5.Name = "metroPanel5";
            this.metroPanel5.Size = new System.Drawing.Size(269, 61);
            this.metroPanel5.TabIndex = 6;
            this.metroPanel5.VerticalScrollbarBarColor = true;
            this.metroPanel5.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel5.VerticalScrollbarSize = 10;
            // 
            // metroPanel7
            // 
            this.metroPanel7.Controls.Add(this.login);
            this.metroPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel7.HorizontalScrollbarBarColor = true;
            this.metroPanel7.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel7.HorizontalScrollbarSize = 10;
            this.metroPanel7.Location = new System.Drawing.Point(15, 0);
            this.metroPanel7.Name = "metroPanel7";
            this.metroPanel7.Size = new System.Drawing.Size(254, 61);
            this.metroPanel7.TabIndex = 7;
            this.metroPanel7.VerticalScrollbarBarColor = true;
            this.metroPanel7.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel7.VerticalScrollbarSize = 10;
            // 
            // login
            // 
            this.login.BorderColorFocused = System.Drawing.Color.Blue;
            this.login.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.login.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.login.BorderThickness = 3;
            this.login.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.login.isPassword = false;
            this.login.Location = new System.Drawing.Point(41, 16);
            this.login.Margin = new System.Windows.Forms.Padding(4);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(171, 25);
            this.login.TabIndex = 5;
            this.login.Text = "админ";
            this.login.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // metroPanel6
            // 
            this.metroPanel6.BackColor = System.Drawing.Color.Green;
            this.metroPanel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.metroPanel6.HorizontalScrollbarBarColor = true;
            this.metroPanel6.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel6.HorizontalScrollbarSize = 10;
            this.metroPanel6.Location = new System.Drawing.Point(0, 0);
            this.metroPanel6.Name = "metroPanel6";
            this.metroPanel6.Size = new System.Drawing.Size(15, 61);
            this.metroPanel6.TabIndex = 2;
            this.metroPanel6.VerticalScrollbarBarColor = true;
            this.metroPanel6.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel6.VerticalScrollbarSize = 10;
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.submit2);
            this.metroPanel3.Controls.Add(this.error_auth);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(0, 153);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(269, 77);
            this.metroPanel3.TabIndex = 7;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // submit2
            // 
            this.submit2.ActiveBorderThickness = 1;
            this.submit2.ActiveCornerRadius = 20;
            this.submit2.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.submit2.ActiveForecolor = System.Drawing.Color.White;
            this.submit2.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.submit2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.submit2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("submit2.BackgroundImage")));
            this.submit2.ButtonText = "Войти";
            this.submit2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit2.ForeColor = System.Drawing.Color.SeaGreen;
            this.submit2.IdleBorderThickness = 1;
            this.submit2.IdleCornerRadius = 20;
            this.submit2.IdleFillColor = System.Drawing.Color.White;
            this.submit2.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.submit2.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.submit2.Location = new System.Drawing.Point(169, 19);
            this.submit2.Margin = new System.Windows.Forms.Padding(5);
            this.submit2.Name = "submit2";
            this.submit2.Size = new System.Drawing.Size(86, 34);
            this.submit2.TabIndex = 4;
            this.submit2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.submit2.Click += new System.EventHandler(this.submit2_Click);
            // 
            // error_auth
            // 
            this.error_auth.AutoSize = true;
            this.error_auth.ForeColor = System.Drawing.Color.Red;
            this.error_auth.Location = new System.Drawing.Point(4, 25);
            this.error_auth.Name = "error_auth";
            this.error_auth.Size = new System.Drawing.Size(161, 19);
            this.error_auth.Style = MetroFramework.MetroColorStyle.Red;
            this.error_auth.TabIndex = 3;
            this.error_auth.Text = "Неверный логин/пароль";
            this.error_auth.UseStyleColors = true;
            this.error_auth.Visible = false;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(269, 23);
            this.metroPanel2.TabIndex = 6;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 310);
            this.Controls.Add(this.metroPanel1);
            this.MaximumSize = new System.Drawing.Size(309, 310);
            this.MinimumSize = new System.Drawing.Size(309, 310);
            this.Name = "AuthForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Авторизация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Auth_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Auth_KeyUp);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel9.ResumeLayout(false);
            this.metroPanel5.ResumeLayout(false);
            this.metroPanel7.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroPanel metroPanel5;
        private MetroFramework.Controls.MetroPanel metroPanel6;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel9;
        private MetroFramework.Controls.MetroPanel metroPanel8;
        private MetroFramework.Controls.MetroPanel metroPanel7;
        private Bunifu.Framework.UI.BunifuMetroTextbox password;
        private Bunifu.Framework.UI.BunifuMetroTextbox login;
        private MetroFramework.Controls.MetroLabel error_auth;
        private Bunifu.Framework.UI.BunifuThinButton2 submit2;
    }
}