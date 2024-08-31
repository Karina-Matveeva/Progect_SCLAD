namespace WindowsForms
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.fragmentPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panelInfoUser = new System.Windows.Forms.Panel();
            this.metroLabelName = new MetroFramework.Controls.MetroLabel();
            this.metroLabelRole = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.ButtonTechnology = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ButtonReport = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ButtonSettings = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ButtonDirect = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ButtonGraphics = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ButtonInvoice = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ButtonExitSystem = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.bunifuThinButton22 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panelInfoUser.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 653);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.fragmentPanel);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1007, 653);
            this.panel5.TabIndex = 1;
            // 
            // fragmentPanel
            // 
            this.fragmentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fragmentPanel.Location = new System.Drawing.Point(200, 32);
            this.fragmentPanel.Name = "fragmentPanel";
            this.fragmentPanel.Size = new System.Drawing.Size(807, 621);
            this.fragmentPanel.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bunifuCustomLabel1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(200, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(807, 32);
            this.panel3.TabIndex = 1;
            this.panel3.DoubleClick += new System.EventHandler(this.panel3_DoubleClick);
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseUp);
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(14, 5);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(315, 20);
            this.bunifuCustomLabel1.TabIndex = 1;
            this.bunifuCustomLabel1.Text = "ИС управления складскими операциями";
            this.bunifuCustomLabel1.Click += new System.EventHandler(this.bunifuCustomLabel1_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(735, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(72, 32);
            this.panel4.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.pictureBox4);
            this.panel6.Controls.Add(this.pictureBox3);
            this.panel6.Controls.Add(this.pictureBox2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(72, 18);
            this.panel6.TabIndex = 5;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(23, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(12, 12);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(56, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(12, 12);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(40, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(12, 12);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 653);
            this.panel2.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.bunifuFlatButton1);
            this.panel9.Controls.Add(this.panelInfoUser);
            this.panel9.Controls.Add(this.ButtonTechnology);
            this.panel9.Controls.Add(this.ButtonReport);
            this.panel9.Controls.Add(this.ButtonSettings);
            this.panel9.Controls.Add(this.ButtonDirect);
            this.panel9.Controls.Add(this.ButtonGraphics);
            this.panel9.Controls.Add(this.ButtonInvoice);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 112);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(200, 479);
            this.panel9.TabIndex = 14;
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.SeaGreen;
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.Black;
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "О нас";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage")));
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 70D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(-1, 283);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.Black;
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.Green;
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(200, 51);
            this.bunifuFlatButton1.TabIndex = 11;
            this.bunifuFlatButton1.Text = "О нас";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // panelInfoUser
            // 
            this.panelInfoUser.Controls.Add(this.metroLabelName);
            this.panelInfoUser.Controls.Add(this.metroLabelRole);
            this.panelInfoUser.Controls.Add(this.metroLabel1);
            this.panelInfoUser.Location = new System.Drawing.Point(10, 397);
            this.panelInfoUser.Name = "panelInfoUser";
            this.panelInfoUser.Size = new System.Drawing.Size(181, 76);
            this.panelInfoUser.TabIndex = 9;
            // 
            // metroLabelName
            // 
            this.metroLabelName.AutoSize = true;
            this.metroLabelName.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabelName.Location = new System.Drawing.Point(3, 38);
            this.metroLabelName.Name = "metroLabelName";
            this.metroLabelName.Size = new System.Drawing.Size(67, 15);
            this.metroLabelName.TabIndex = 3;
            this.metroLabelName.Text = "вавававава";
            this.metroLabelName.UseCustomBackColor = true;
            this.metroLabelName.UseStyleColors = true;
            // 
            // metroLabelRole
            // 
            this.metroLabelRole.AutoSize = true;
            this.metroLabelRole.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabelRole.Location = new System.Drawing.Point(3, 19);
            this.metroLabelRole.Name = "metroLabelRole";
            this.metroLabelRole.Size = new System.Drawing.Size(67, 15);
            this.metroLabelRole.TabIndex = 2;
            this.metroLabelRole.Text = "вавававава";
            this.metroLabelRole.UseCustomBackColor = true;
            this.metroLabelRole.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(3, 2);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(87, 15);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Вы зашли, как: ";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseStyleColors = true;
            // 
            // ButtonTechnology
            // 
            this.ButtonTechnology.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ButtonTechnology.BackColor = System.Drawing.Color.Black;
            this.ButtonTechnology.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonTechnology.BorderRadius = 0;
            this.ButtonTechnology.ButtonText = "Настройки";
            this.ButtonTechnology.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonTechnology.DisabledColor = System.Drawing.Color.Gray;
            this.ButtonTechnology.Iconcolor = System.Drawing.Color.Transparent;
            this.ButtonTechnology.Iconimage = ((System.Drawing.Image)(resources.GetObject("ButtonTechnology.Iconimage")));
            this.ButtonTechnology.Iconimage_right = null;
            this.ButtonTechnology.Iconimage_right_Selected = null;
            this.ButtonTechnology.Iconimage_Selected = null;
            this.ButtonTechnology.IconMarginLeft = 0;
            this.ButtonTechnology.IconMarginRight = 0;
            this.ButtonTechnology.IconRightVisible = true;
            this.ButtonTechnology.IconRightZoom = 0D;
            this.ButtonTechnology.IconVisible = true;
            this.ButtonTechnology.IconZoom = 70D;
            this.ButtonTechnology.IsTab = false;
            this.ButtonTechnology.Location = new System.Drawing.Point(-1, 228);
            this.ButtonTechnology.Name = "ButtonTechnology";
            this.ButtonTechnology.Normalcolor = System.Drawing.Color.Black;
            this.ButtonTechnology.OnHovercolor = System.Drawing.Color.Green;
            this.ButtonTechnology.OnHoverTextColor = System.Drawing.Color.White;
            this.ButtonTechnology.selected = false;
            this.ButtonTechnology.Size = new System.Drawing.Size(200, 51);
            this.ButtonTechnology.TabIndex = 5;
            this.ButtonTechnology.Text = "Настройки";
            this.ButtonTechnology.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ButtonTechnology.Textcolor = System.Drawing.Color.White;
            this.ButtonTechnology.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ButtonTechnology.Click += new System.EventHandler(this.ButtonTechnology_Click);
            // 
            // ButtonReport
            // 
            this.ButtonReport.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ButtonReport.BackColor = System.Drawing.Color.Black;
            this.ButtonReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonReport.BorderRadius = 0;
            this.ButtonReport.ButtonText = "Отчеты";
            this.ButtonReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonReport.DisabledColor = System.Drawing.Color.Gray;
            this.ButtonReport.Iconcolor = System.Drawing.Color.Transparent;
            this.ButtonReport.Iconimage = ((System.Drawing.Image)(resources.GetObject("ButtonReport.Iconimage")));
            this.ButtonReport.Iconimage_right = null;
            this.ButtonReport.Iconimage_right_Selected = null;
            this.ButtonReport.Iconimage_Selected = null;
            this.ButtonReport.IconMarginLeft = 0;
            this.ButtonReport.IconMarginRight = 0;
            this.ButtonReport.IconRightVisible = true;
            this.ButtonReport.IconRightZoom = 0D;
            this.ButtonReport.IconVisible = true;
            this.ButtonReport.IconZoom = 70D;
            this.ButtonReport.IsTab = false;
            this.ButtonReport.Location = new System.Drawing.Point(0, 114);
            this.ButtonReport.Name = "ButtonReport";
            this.ButtonReport.Normalcolor = System.Drawing.Color.Black;
            this.ButtonReport.OnHovercolor = System.Drawing.Color.Green;
            this.ButtonReport.OnHoverTextColor = System.Drawing.Color.White;
            this.ButtonReport.selected = false;
            this.ButtonReport.Size = new System.Drawing.Size(200, 51);
            this.ButtonReport.TabIndex = 6;
            this.ButtonReport.Text = "Отчеты";
            this.ButtonReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ButtonReport.Textcolor = System.Drawing.Color.White;
            this.ButtonReport.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ButtonReport.Click += new System.EventHandler(this.ButtonReport_Click);
            // 
            // ButtonSettings
            // 
            this.ButtonSettings.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ButtonSettings.BackColor = System.Drawing.Color.Black;
            this.ButtonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonSettings.BorderRadius = 0;
            this.ButtonSettings.ButtonText = "Закупки";
            this.ButtonSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonSettings.DisabledColor = System.Drawing.Color.Gray;
            this.ButtonSettings.Iconcolor = System.Drawing.Color.Transparent;
            this.ButtonSettings.Iconimage = ((System.Drawing.Image)(resources.GetObject("ButtonSettings.Iconimage")));
            this.ButtonSettings.Iconimage_right = null;
            this.ButtonSettings.Iconimage_right_Selected = null;
            this.ButtonSettings.Iconimage_Selected = null;
            this.ButtonSettings.IconMarginLeft = 0;
            this.ButtonSettings.IconMarginRight = 0;
            this.ButtonSettings.IconRightVisible = true;
            this.ButtonSettings.IconRightZoom = 0D;
            this.ButtonSettings.IconVisible = true;
            this.ButtonSettings.IconZoom = 70D;
            this.ButtonSettings.IsTab = false;
            this.ButtonSettings.Location = new System.Drawing.Point(-1, 340);
            this.ButtonSettings.Name = "ButtonSettings";
            this.ButtonSettings.Normalcolor = System.Drawing.Color.Black;
            this.ButtonSettings.OnHovercolor = System.Drawing.Color.Green;
            this.ButtonSettings.OnHoverTextColor = System.Drawing.Color.White;
            this.ButtonSettings.selected = false;
            this.ButtonSettings.Size = new System.Drawing.Size(200, 51);
            this.ButtonSettings.TabIndex = 7;
            this.ButtonSettings.Text = "Закупки";
            this.ButtonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ButtonSettings.Textcolor = System.Drawing.Color.White;
            this.ButtonSettings.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ButtonSettings.Visible = false;
            this.ButtonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // ButtonDirect
            // 
            this.ButtonDirect.Activecolor = System.Drawing.Color.SeaGreen;
            this.ButtonDirect.BackColor = System.Drawing.Color.Black;
            this.ButtonDirect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonDirect.BorderRadius = 0;
            this.ButtonDirect.ButtonText = "Справочники";
            this.ButtonDirect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDirect.DisabledColor = System.Drawing.Color.Gray;
            this.ButtonDirect.Iconcolor = System.Drawing.Color.Transparent;
            this.ButtonDirect.Iconimage = ((System.Drawing.Image)(resources.GetObject("ButtonDirect.Iconimage")));
            this.ButtonDirect.Iconimage_right = null;
            this.ButtonDirect.Iconimage_right_Selected = null;
            this.ButtonDirect.Iconimage_Selected = null;
            this.ButtonDirect.IconMarginLeft = 0;
            this.ButtonDirect.IconMarginRight = 0;
            this.ButtonDirect.IconRightVisible = true;
            this.ButtonDirect.IconRightZoom = 0D;
            this.ButtonDirect.IconVisible = true;
            this.ButtonDirect.IconZoom = 70D;
            this.ButtonDirect.IsTab = false;
            this.ButtonDirect.Location = new System.Drawing.Point(0, 0);
            this.ButtonDirect.Name = "ButtonDirect";
            this.ButtonDirect.Normalcolor = System.Drawing.Color.Black;
            this.ButtonDirect.OnHovercolor = System.Drawing.Color.Green;
            this.ButtonDirect.OnHoverTextColor = System.Drawing.Color.White;
            this.ButtonDirect.selected = false;
            this.ButtonDirect.Size = new System.Drawing.Size(200, 51);
            this.ButtonDirect.TabIndex = 3;
            this.ButtonDirect.Text = "Справочники";
            this.ButtonDirect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ButtonDirect.Textcolor = System.Drawing.Color.White;
            this.ButtonDirect.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ButtonDirect.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ButtonGraphics
            // 
            this.ButtonGraphics.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ButtonGraphics.BackColor = System.Drawing.Color.Black;
            this.ButtonGraphics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonGraphics.BorderRadius = 0;
            this.ButtonGraphics.ButtonText = "График";
            this.ButtonGraphics.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonGraphics.DisabledColor = System.Drawing.Color.Gray;
            this.ButtonGraphics.Iconcolor = System.Drawing.Color.Transparent;
            this.ButtonGraphics.Iconimage = ((System.Drawing.Image)(resources.GetObject("ButtonGraphics.Iconimage")));
            this.ButtonGraphics.Iconimage_right = null;
            this.ButtonGraphics.Iconimage_right_Selected = null;
            this.ButtonGraphics.Iconimage_Selected = null;
            this.ButtonGraphics.IconMarginLeft = 0;
            this.ButtonGraphics.IconMarginRight = 0;
            this.ButtonGraphics.IconRightVisible = true;
            this.ButtonGraphics.IconRightZoom = 0D;
            this.ButtonGraphics.IconVisible = true;
            this.ButtonGraphics.IconZoom = 70D;
            this.ButtonGraphics.IsTab = false;
            this.ButtonGraphics.Location = new System.Drawing.Point(0, 171);
            this.ButtonGraphics.Name = "ButtonGraphics";
            this.ButtonGraphics.Normalcolor = System.Drawing.Color.Black;
            this.ButtonGraphics.OnHovercolor = System.Drawing.Color.Green;
            this.ButtonGraphics.OnHoverTextColor = System.Drawing.Color.White;
            this.ButtonGraphics.selected = false;
            this.ButtonGraphics.Size = new System.Drawing.Size(200, 51);
            this.ButtonGraphics.TabIndex = 10;
            this.ButtonGraphics.Text = "График";
            this.ButtonGraphics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ButtonGraphics.Textcolor = System.Drawing.Color.White;
            this.ButtonGraphics.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ButtonGraphics.Click += new System.EventHandler(this.ButtonGraphics_Click);
            // 
            // ButtonInvoice
            // 
            this.ButtonInvoice.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ButtonInvoice.BackColor = System.Drawing.Color.Black;
            this.ButtonInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonInvoice.BorderRadius = 0;
            this.ButtonInvoice.ButtonText = "   Движение товара";
            this.ButtonInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonInvoice.DisabledColor = System.Drawing.Color.Gray;
            this.ButtonInvoice.Iconcolor = System.Drawing.Color.Transparent;
            this.ButtonInvoice.Iconimage = ((System.Drawing.Image)(resources.GetObject("ButtonInvoice.Iconimage")));
            this.ButtonInvoice.Iconimage_right = null;
            this.ButtonInvoice.Iconimage_right_Selected = null;
            this.ButtonInvoice.Iconimage_Selected = null;
            this.ButtonInvoice.IconMarginLeft = 0;
            this.ButtonInvoice.IconMarginRight = 0;
            this.ButtonInvoice.IconRightVisible = true;
            this.ButtonInvoice.IconRightZoom = 0D;
            this.ButtonInvoice.IconVisible = true;
            this.ButtonInvoice.IconZoom = 70D;
            this.ButtonInvoice.IsTab = false;
            this.ButtonInvoice.Location = new System.Drawing.Point(0, 57);
            this.ButtonInvoice.Name = "ButtonInvoice";
            this.ButtonInvoice.Normalcolor = System.Drawing.Color.Black;
            this.ButtonInvoice.OnHovercolor = System.Drawing.Color.Green;
            this.ButtonInvoice.OnHoverTextColor = System.Drawing.Color.White;
            this.ButtonInvoice.selected = false;
            this.ButtonInvoice.Size = new System.Drawing.Size(197, 51);
            this.ButtonInvoice.TabIndex = 4;
            this.ButtonInvoice.Text = "   Движение товара";
            this.ButtonInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ButtonInvoice.Textcolor = System.Drawing.Color.White;
            this.ButtonInvoice.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ButtonInvoice.Click += new System.EventHandler(this.ButtonInvoice_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.ButtonExitSystem);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 591);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(200, 62);
            this.panel8.TabIndex = 13;
            // 
            // ButtonExitSystem
            // 
            this.ButtonExitSystem.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ButtonExitSystem.BackColor = System.Drawing.Color.Black;
            this.ButtonExitSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonExitSystem.BorderRadius = 0;
            this.ButtonExitSystem.ButtonText = "Выйти из системы";
            this.ButtonExitSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonExitSystem.DisabledColor = System.Drawing.Color.Gray;
            this.ButtonExitSystem.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonExitSystem.Iconcolor = System.Drawing.Color.Transparent;
            this.ButtonExitSystem.Iconimage = ((System.Drawing.Image)(resources.GetObject("ButtonExitSystem.Iconimage")));
            this.ButtonExitSystem.Iconimage_right = null;
            this.ButtonExitSystem.Iconimage_right_Selected = null;
            this.ButtonExitSystem.Iconimage_Selected = null;
            this.ButtonExitSystem.IconMarginLeft = 0;
            this.ButtonExitSystem.IconMarginRight = 0;
            this.ButtonExitSystem.IconRightVisible = true;
            this.ButtonExitSystem.IconRightZoom = 0D;
            this.ButtonExitSystem.IconVisible = true;
            this.ButtonExitSystem.IconZoom = 70D;
            this.ButtonExitSystem.IsTab = false;
            this.ButtonExitSystem.Location = new System.Drawing.Point(0, 0);
            this.ButtonExitSystem.Name = "ButtonExitSystem";
            this.ButtonExitSystem.Normalcolor = System.Drawing.Color.Black;
            this.ButtonExitSystem.OnHovercolor = System.Drawing.Color.Green;
            this.ButtonExitSystem.OnHoverTextColor = System.Drawing.Color.White;
            this.ButtonExitSystem.selected = false;
            this.ButtonExitSystem.Size = new System.Drawing.Size(200, 51);
            this.ButtonExitSystem.TabIndex = 11;
            this.ButtonExitSystem.Text = "Выйти из системы";
            this.ButtonExitSystem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ButtonExitSystem.Textcolor = System.Drawing.Color.White;
            this.ButtonExitSystem.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ButtonExitSystem.Click += new System.EventHandler(this.ButtonExitSystem_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.bunifuThinButton22);
            this.panel7.Controls.Add(this.bunifuCustomLabel2);
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 112);
            this.panel7.TabIndex = 12;
            // 
            // bunifuThinButton22
            // 
            this.bunifuThinButton22.ActiveBorderThickness = 1;
            this.bunifuThinButton22.ActiveCornerRadius = 20;
            this.bunifuThinButton22.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton22.ActiveForecolor = System.Drawing.Color.Transparent;
            this.bunifuThinButton22.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.bunifuThinButton22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton22.BackgroundImage")));
            this.bunifuThinButton22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bunifuThinButton22.ButtonText = "СКЛАД+";
            this.bunifuThinButton22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton22.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton22.IdleBorderThickness = 1;
            this.bunifuThinButton22.IdleCornerRadius = 20;
            this.bunifuThinButton22.IdleFillColor = System.Drawing.Color.Black;
            this.bunifuThinButton22.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton22.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton22.Location = new System.Drawing.Point(10, 48);
            this.bunifuThinButton22.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuThinButton22.Name = "bunifuThinButton22";
            this.bunifuThinButton22.Size = new System.Drawing.Size(181, 41);
            this.bunifuThinButton22.TabIndex = 9;
            this.bunifuThinButton22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton22.Click += new System.EventHandler(this.bunifuThinButton22_Click);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(12, 93);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(175, 13);
            this.bunifuCustomLabel2.TabIndex = 8;
            this.bunifuCustomLabel2.Text = "____________________________";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(162, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = null;
            this.bunifuDragControl1.Vertical = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 653);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1007, 653);
            this.Name = "MainForm";
            this.Text = "НЕ ОПЛАЧЕНО ИС управления запасами";
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panelInfoUser.ResumeLayout(false);
            this.panelInfoUser.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuFlatButton ButtonSettings;
        private Bunifu.Framework.UI.BunifuFlatButton ButtonReport;
        private Bunifu.Framework.UI.BunifuFlatButton ButtonTechnology;
        private Bunifu.Framework.UI.BunifuFlatButton ButtonInvoice;
        private Bunifu.Framework.UI.BunifuFlatButton ButtonDirect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel panelInfoUser;
        private MetroFramework.Controls.MetroLabel metroLabelName;
        private MetroFramework.Controls.MetroLabel metroLabelRole;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Panel fragmentPanel;
        private Bunifu.Framework.UI.BunifuFlatButton ButtonGraphics;
        private Bunifu.Framework.UI.BunifuFlatButton ButtonExitSystem;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton22;
    }
}

