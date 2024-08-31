using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class MoveForm : MetroForm
    {
        public MoveForm()
        {
            InitializeComponent();
        }

        private void MoveForm_Load(object sender, EventArgs e)
        {
            

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
         
        }

        private void bunifuMetroTextbox1_KeyUp(object sender, KeyEventArgs e)
        {
           // var bd = (BindingSource)dataGridView1.DataSource;
            //var dt = (WarehouseDataSet)dataGridView1.DataSource;
           /* dt.Material.Select(string.Format("[searchString] like '%{0}%'", bunifuMetroTextbox1.Text.Trim().Replace("'", "''")));
            dataGridView1.DataSource = dt;*/
           // var temp = (WarehouseDataSet)dt.DataSource;
              //  temp.DefaultView.RowFilter = string.Format("[searchString] like '%{0}%'", bunifuMetroTextbox1.Text.Trim().Replace("'", "''"));
           /* dt.Material.Select(string.Format("[searchString] like '%{0}%'", bunifuMetroTextbox1.Text.Trim().Replace("'", "''")));
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();*/

          //  metroComboBox1.Va

            var bd = (BindingSource)metroComboBox1.DataSource;
            var bd2 = (BindingSource)metroComboBox1.DataSource;
            var temp = (WarehouseDataSet)bd2.DataSource;
            //metroComboBox1.DataSource= ((WarehouseDataSet)((BindingSource)metroComboBox1.DataSource).DataSource).Material.Select(string.Format("[searchString] like '%{0}%'", bunifuMetroTextbox1.Text.Trim().Replace("'", "''")));
          //  metroComboBox1.DataSource = (BindingSource)temp;
           // ((DataTable)dt.DataSource).DefaultView.RowFilter = string.Format("[searchString] like '%{0}%'", bunifuMetroTextbox1.Text.Trim().Replace("'", "''"));
            
            metroComboBox1.Refresh();         
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

       

       
    }
}
