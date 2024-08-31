using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;


namespace WindowsForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            metroLabelRole.Text = Utils.currentUser.Role.description.ToString();
            metroLabelName.Text = Utils.currentUser.surName.ToString() + " " + Utils.currentUser.name.ToString();
            if (Utils.currentUser.Role.name != "admin")
            {ButtonSettings.Visible = false;}
            if (Utils.currentUser.Role.name == "stockman")
            { ButtonReport.Visible = false; }
            panel2.BackColor = Color.FromArgb(34, 34, 34);
            ButtonDirect.Normalcolor = Color.FromArgb(34, 34, 34);
            ButtonInvoice.Normalcolor = Color.FromArgb(34, 34, 34);
            ButtonTechnology.Normalcolor = Color.FromArgb(34, 34, 34);
            ButtonReport.Normalcolor = Color.FromArgb(34, 34, 34);
            ButtonSettings.Normalcolor = Color.FromArgb(34, 34, 34);
            ButtonExitSystem.Normalcolor = Color.FromArgb(34, 34, 34);
            ButtonGraphics.Normalcolor = Color.FromArgb(34, 34, 34);
            bunifuFlatButton1.Normalcolor = Color.FromArgb(34, 34, 34);
        }    

        private void Button1_Click(object sender, EventArgs e)
        {
            fragmentPanel.Controls.Clear();
            var toForm = new FormDirectory();
            toForm.Dock = DockStyle.Fill;
            toForm.TopLevel = false;
            fragmentPanel.Controls.Add(toForm);
            toForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            toForm.Show();
        }

        private void ButtonInvoice_Click(object sender, EventArgs e)
        {
            fragmentPanel.Controls.Clear();
            var toForm = new InvoiceForm();
            toForm.TopLevel = false;
            toForm.Dock = DockStyle.Fill;
            fragmentPanel.Controls.Add(toForm);
            toForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            toForm.Show();
        }

        private void ButtonTechnology_Click(object sender, EventArgs e)
        {
            if (Utils.currentUser.Role.name == "admin")
            {
                fragmentPanel.Controls.Clear();
                var toForm = new FormSettings();
                toForm.TopLevel = false;
                toForm.Dock = DockStyle.Fill;
                fragmentPanel.Controls.Add(toForm);
                toForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                toForm.Show();
            }
            else MessageBox.Show("У вас нет прав!");
        }

        private void ButtonReport_Click(object sender, EventArgs e)
        {
            fragmentPanel.Controls.Clear();
            var toForm = new ReportForm();
            toForm.TopLevel = false;
            toForm.AutoScroll = true;
            toForm.Dock = DockStyle.Fill;
            fragmentPanel.Controls.Add(toForm);
            toForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            toForm.Show();
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            fragmentPanel.Controls.Clear();
            var toForm = new Zakupki();
            toForm.Dock = DockStyle.Fill;
            toForm.TopLevel = false;
            fragmentPanel.Controls.Add(toForm);
            toForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            toForm.Show();
        }

        private void ButtonGraphics_Click(object sender, EventArgs e)
        {
            fragmentPanel.Controls.Clear();
            var toForm = new Graphic();
            toForm.Dock = DockStyle.Fill;
            toForm.TopLevel = false;
            fragmentPanel.Controls.Add(toForm);
            toForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            toForm.Show();
        }

        private void ButtonExitSystem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel2.Width == 200)
            {
                pictureBox1.Location = new Point(12, 12);
                panel2.Width = 50;
                bunifuThinButton22.Visible = false;
                panelInfoUser.Visible = false;
            }
            else
            {
                panel2.Width = 200;
                pictureBox1.Location = new Point(162, 12);
                bunifuThinButton22.Visible = true;
                panelInfoUser.Visible = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;    
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel3_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private Int32 tmpX;
        private Int32 tmpY;
        private bool flMove = false;
  
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = Cursor.Position.X;
            tmpY = Cursor.Position.Y;
            flMove = true;
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            flMove = false;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (flMove)
            {
                this.Left = this.Left + (Cursor.Position.X - tmpX);
                this.Top = this.Top + (Cursor.Position.Y - tmpY);

                tmpX = Cursor.Position.X;
                tmpY = Cursor.Position.Y;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            fragmentPanel.Controls.Clear();
            var toForm = new About();
            toForm.Dock = DockStyle.Fill;
            toForm.TopLevel = false;
            fragmentPanel.Controls.Add(toForm);
            toForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            toForm.Show();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }
    }
}
