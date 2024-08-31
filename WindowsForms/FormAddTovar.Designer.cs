namespace WindowsForms
{
    partial class FormAddTovar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddTovar));
            this.numericGaranty = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.textBoxManufactur = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDownTOst = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.maskedTextBoxTMax = new System.Windows.Forms.MaskedTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.numericUpDownTWeihgt = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.numericUpDownTH = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.numericUpDownTWight = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxTColor = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxTName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxTdes = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.maskedTextBoxTMin = new System.Windows.Forms.MaskedTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDownTL = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxTArticle = new System.Windows.Forms.TextBox();
            this.bunifuThinButton26 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuThinButton25 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.warehouseDataSet = new WindowsForms.WarehouseDataSet();
            this.tovarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tovarTableAdapter = new WindowsForms.WarehouseDataSetTableAdapters.TovarTableAdapter();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryTableAdapter = new WindowsForms.WarehouseDataSetTableAdapters.CategoryTableAdapter();
            this.storageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.storageTableAdapter = new WindowsForms.WarehouseDataSetTableAdapters.StorageTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.numericGaranty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTOst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTWeihgt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTWight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tovarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // numericGaranty
            // 
            this.numericGaranty.Location = new System.Drawing.Point(20, 274);
            this.numericGaranty.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericGaranty.Name = "numericGaranty";
            this.numericGaranty.Size = new System.Drawing.Size(59, 20);
            this.numericGaranty.TabIndex = 92;
            this.numericGaranty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(17, 258);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(83, 13);
            this.label28.TabIndex = 91;
            this.label28.Text = "Гарантия, мес.";
            // 
            // textBoxManufactur
            // 
            this.textBoxManufactur.Location = new System.Drawing.Point(93, 274);
            this.textBoxManufactur.MaxLength = 50;
            this.textBoxManufactur.Name = "textBoxManufactur";
            this.textBoxManufactur.Size = new System.Drawing.Size(174, 20);
            this.textBoxManufactur.TabIndex = 90;
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.storageBindingSource;
            this.comboBox3.DisplayMember = "Name";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(18, 440);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(256, 21);
            this.comboBox3.TabIndex = 89;
            this.comboBox3.ValueMember = "Id";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(17, 424);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(89, 13);
            this.label36.TabIndex = 88;
            this.label36.Text = "Место хранения";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 23);
            this.button1.TabIndex = 87;
            this.button1.Text = "Выбор изображения";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(19, 350);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(248, 71);
            this.flowLayoutPanel1.TabIndex = 86;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(16, 462);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(57, 13);
            this.label27.TabIndex = 85;
            this.label27.Text = "Описание";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(216, 171);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 84;
            this.label14.Text = "Остаток";
            // 
            // numericUpDownTOst
            // 
            this.numericUpDownTOst.Location = new System.Drawing.Point(217, 187);
            this.numericUpDownTOst.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownTOst.Name = "numericUpDownTOst";
            this.numericUpDownTOst.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownTOst.TabIndex = 83;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(235, 220);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(27, 13);
            this.label25.TabIndex = 82;
            this.label25.Text = "руб.";
            // 
            // maskedTextBoxTMax
            // 
            this.maskedTextBoxTMax.Location = new System.Drawing.Point(183, 236);
            this.maskedTextBoxTMax.Mask = "#####.00";
            this.maskedTextBoxTMax.Name = "maskedTextBoxTMax";
            this.maskedTextBoxTMax.Size = new System.Drawing.Size(67, 20);
            this.maskedTextBoxTMax.TabIndex = 81;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(141, 220);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(88, 13);
            this.label26.TabIndex = 80;
            this.label26.Text = "Розничная цена";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(113, 258);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(86, 13);
            this.label24.TabIndex = 79;
            this.label24.Text = "Производитель";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(224, 132);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(26, 13);
            this.label23.TabIndex = 78;
            this.label23.Text = "Вес";
            // 
            // numericUpDownTWeihgt
            // 
            this.numericUpDownTWeihgt.Location = new System.Drawing.Point(217, 148);
            this.numericUpDownTWeihgt.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownTWeihgt.Name = "numericUpDownTWeihgt";
            this.numericUpDownTWeihgt.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownTWeihgt.TabIndex = 77;
            this.numericUpDownTWeihgt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(154, 171);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 13);
            this.label22.TabIndex = 76;
            this.label22.Text = "Высота";
            // 
            // numericUpDownTH
            // 
            this.numericUpDownTH.Location = new System.Drawing.Point(158, 187);
            this.numericUpDownTH.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTH.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTH.Name = "numericUpDownTH";
            this.numericUpDownTH.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownTH.TabIndex = 75;
            this.numericUpDownTH.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(90, 171);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 13);
            this.label21.TabIndex = 74;
            this.label21.Text = "Ширина";
            // 
            // numericUpDownTWight
            // 
            this.numericUpDownTWight.Location = new System.Drawing.Point(94, 187);
            this.numericUpDownTWight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTWight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTWight.Name = "numericUpDownTWight";
            this.numericUpDownTWight.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownTWight.TabIndex = 73;
            this.numericUpDownTWight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(21, 171);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 13);
            this.label20.TabIndex = 72;
            this.label20.Text = "Длина";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 132);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 13);
            this.label19.TabIndex = 71;
            this.label19.Text = "Цвет";
            // 
            // textBoxTColor
            // 
            this.textBoxTColor.Location = new System.Drawing.Point(20, 148);
            this.textBoxTColor.MaxLength = 50;
            this.textBoxTColor.Name = "textBoxTColor";
            this.textBoxTColor.Size = new System.Drawing.Size(137, 20);
            this.textBoxTColor.TabIndex = 70;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 13);
            this.label17.TabIndex = 69;
            this.label17.Text = "Наименование";
            // 
            // textBoxTName
            // 
            this.textBoxTName.Location = new System.Drawing.Point(19, 69);
            this.textBoxTName.MaxLength = 50;
            this.textBoxTName.Name = "textBoxTName";
            this.textBoxTName.Size = new System.Drawing.Size(256, 20);
            this.textBoxTName.TabIndex = 68;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(101, 220);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 66;
            this.label11.Text = "руб.";
            // 
            // textBoxTdes
            // 
            this.textBoxTdes.Location = new System.Drawing.Point(20, 478);
            this.textBoxTdes.MaxLength = 255;
            this.textBoxTdes.Multiline = true;
            this.textBoxTdes.Name = "textBoxTdes";
            this.textBoxTdes.Size = new System.Drawing.Size(256, 29);
            this.textBoxTdes.TabIndex = 65;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Шт"});
            this.comboBox2.Location = new System.Drawing.Point(20, 310);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(66, 21);
            this.comboBox2.TabIndex = 64;
            // 
            // maskedTextBoxTMin
            // 
            this.maskedTextBoxTMin.Location = new System.Drawing.Point(19, 235);
            this.maskedTextBoxTMin.Mask = "#####.00";
            this.maskedTextBoxTMin.Name = "maskedTextBoxTMin";
            this.maskedTextBoxTMin.Size = new System.Drawing.Size(67, 20);
            this.maskedTextBoxTMin.TabIndex = 63;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.categoryBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 108);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(256, 21);
            this.comboBox1.TabIndex = 62;
            this.comboBox1.ValueMember = "Id";
            // 
            // numericUpDownTL
            // 
            this.numericUpDownTL.Location = new System.Drawing.Point(25, 187);
            this.numericUpDownTL.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTL.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTL.Name = "numericUpDownTL";
            this.numericUpDownTL.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownTL.TabIndex = 61;
            this.numericUpDownTL.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 334);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 60;
            this.label12.Text = "Картинка";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 294);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 13);
            this.label13.TabIndex = 59;
            this.label13.Text = "Еденица измерения";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 220);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 13);
            this.label15.TabIndex = 58;
            this.label15.Text = "Ооптовая цена";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 57;
            this.label16.Text = "Категория";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 14);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 13);
            this.label18.TabIndex = 56;
            this.label18.Text = "Артикул";
            // 
            // textBoxTArticle
            // 
            this.textBoxTArticle.Location = new System.Drawing.Point(16, 30);
            this.textBoxTArticle.MaxLength = 10;
            this.textBoxTArticle.Name = "textBoxTArticle";
            this.textBoxTArticle.Size = new System.Drawing.Size(256, 20);
            this.textBoxTArticle.TabIndex = 55;
            // 
            // bunifuThinButton26
            // 
            this.bunifuThinButton26.ActiveBorderThickness = 1;
            this.bunifuThinButton26.ActiveCornerRadius = 20;
            this.bunifuThinButton26.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton26.ActiveForecolor = System.Drawing.Color.White;
            this.bunifuThinButton26.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton26.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton26.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton26.BackgroundImage")));
            this.bunifuThinButton26.ButtonText = "Отмена";
            this.bunifuThinButton26.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton26.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton26.IdleBorderThickness = 1;
            this.bunifuThinButton26.IdleCornerRadius = 20;
            this.bunifuThinButton26.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton26.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton26.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton26.Location = new System.Drawing.Point(44, 508);
            this.bunifuThinButton26.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuThinButton26.Name = "bunifuThinButton26";
            this.bunifuThinButton26.Size = new System.Drawing.Size(113, 31);
            this.bunifuThinButton26.TabIndex = 67;
            this.bunifuThinButton26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton26.Click += new System.EventHandler(this.bunifuThinButton26_Click);
            // 
            // bunifuThinButton25
            // 
            this.bunifuThinButton25.ActiveBorderThickness = 1;
            this.bunifuThinButton25.ActiveCornerRadius = 20;
            this.bunifuThinButton25.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton25.ActiveForecolor = System.Drawing.Color.White;
            this.bunifuThinButton25.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton25.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton25.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton25.BackgroundImage")));
            this.bunifuThinButton25.ButtonText = "Добавить";
            this.bunifuThinButton25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton25.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton25.IdleBorderThickness = 1;
            this.bunifuThinButton25.IdleCornerRadius = 20;
            this.bunifuThinButton25.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton25.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton25.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton25.Location = new System.Drawing.Point(167, 508);
            this.bunifuThinButton25.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuThinButton25.Name = "bunifuThinButton25";
            this.bunifuThinButton25.Size = new System.Drawing.Size(113, 31);
            this.bunifuThinButton25.TabIndex = 54;
            this.bunifuThinButton25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton25.Click += new System.EventHandler(this.bunifuThinButton25_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // warehouseDataSet
            // 
            this.warehouseDataSet.DataSetName = "WarehouseDataSet";
            this.warehouseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tovarBindingSource
            // 
            this.tovarBindingSource.DataMember = "Tovar";
            this.tovarBindingSource.DataSource = this.warehouseDataSet;
            // 
            // tovarTableAdapter
            // 
            this.tovarTableAdapter.ClearBeforeFill = true;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataMember = "Category";
            this.categoryBindingSource.DataSource = this.warehouseDataSet;
            // 
            // categoryTableAdapter
            // 
            this.categoryTableAdapter.ClearBeforeFill = true;
            // 
            // storageBindingSource
            // 
            this.storageBindingSource.DataMember = "Storage";
            this.storageBindingSource.DataSource = this.warehouseDataSet;
            // 
            // storageTableAdapter
            // 
            this.storageTableAdapter.ClearBeforeFill = true;
            // 
            // FormAddTovar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 553);
            this.Controls.Add(this.numericGaranty);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.textBoxManufactur);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.numericUpDownTOst);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.maskedTextBoxTMax);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.numericUpDownTWeihgt);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.numericUpDownTH);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.numericUpDownTWight);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBoxTColor);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBoxTName);
            this.Controls.Add(this.bunifuThinButton26);
            this.Controls.Add(this.bunifuThinButton25);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxTdes);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.maskedTextBoxTMin);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.numericUpDownTL);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBoxTArticle);
            this.MaximumSize = new System.Drawing.Size(309, 592);
            this.MinimumSize = new System.Drawing.Size(309, 592);
            this.Name = "FormAddTovar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление товара";
            this.Load += new System.EventHandler(this.FormAddTovar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericGaranty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTOst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTWeihgt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTWight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tovarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericGaranty;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBoxManufactur;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel flowLayoutPanel1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDownTOst;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTMax;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown numericUpDownTWeihgt;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown numericUpDownTH;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown numericUpDownTWight;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxTColor;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxTName;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton26;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton25;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxTdes;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTMin;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownTL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxTArticle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private WarehouseDataSet warehouseDataSet;
        private System.Windows.Forms.BindingSource tovarBindingSource;
        private WarehouseDataSetTableAdapters.TovarTableAdapter tovarTableAdapter;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private WarehouseDataSetTableAdapters.CategoryTableAdapter categoryTableAdapter;
        private System.Windows.Forms.BindingSource storageBindingSource;
        private WarehouseDataSetTableAdapters.StorageTableAdapter storageTableAdapter;
    }
}