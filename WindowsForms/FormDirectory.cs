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
using System.Data.SqlClient;
using System.Security;
using System.IO;
using System.Data.Common;
using System.Net;
using WindowsForms.WarehouseDataSetTableAdapters;

namespace WindowsForms
{
    public partial class FormDirectory : Form
    {

        enum State { EqPage, DetPage };
        State state;
        
        
        public FormDirectory()
        {
            this.state = State.EqPage;
            InitializeComponent();
        }

       private void FormDirectory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'warehouseDataSet1.Tovar' table. You can move, or remove it, as needed.
            this.tovarTableAdapter1.Fill(this.warehouseDataSet1.Tovar);
            // TODO: This line of code loads data into the 'warehouseDataSet1.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter1.Fill(this.warehouseDataSet1.Category);
            // TODO: This line of code loads data into the 'warehouseDataSet1.Storage' table. You can move, or remove it, as needed.
            this.storageTableAdapter1.Fill(this.warehouseDataSet1.Storage);
            // TODO: This line of code loads data into the 'warehouseDataSet1.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter1.Fill(this.warehouseDataSet1.Supplier);


            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Полное наименование";
            dataGridView1.Columns[3].HeaderText = "Адрес";
            dataGridView1.Columns[4].HeaderText = "Телефон";
            dataGridView1.Columns[5].HeaderText = "ИНН";
            dataGridView1.Columns[6].HeaderText = "КПП";
            dataGridView1.Columns[7].HeaderText = "ОГРН";
            dataGridView1.Columns[8].HeaderText = "ОКПО";
            dataGridView1.Columns[9].HeaderText = "Р/С";
            dataGridView1.Columns[10].HeaderText = "Банк";
            dataGridView1.Columns[11].HeaderText = "Адрес банка";
            dataGridView1.Columns[12].HeaderText = "БИК";
            dataGridView1.Columns[13].HeaderText = "Бухгалтер";
            dataGridView1.Columns[14].HeaderText = "Директор";

            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].HeaderText = "Наименование";
            dataGridView2.Columns[2].HeaderText = "Описание";
            dataGridView2.Columns[1].Width = 150;

            dataGridView3.Columns[0].Visible = false;
            dataGridView3.Columns[1].HeaderText = "Артикул";
            dataGridView3.Columns[2].HeaderText = "Наименование";
            dataGridView3.Columns[3].HeaderText = "Категория";
            dataGridView3.Columns[1].ReadOnly = true;
            dataGridView3.Columns[3].Visible = false;
            dataGridView3.Columns[4].HeaderText = "Цвет";
            dataGridView3.Columns[5].HeaderText = "Длина";
            dataGridView3.Columns[6].HeaderText = "Ширина";
            dataGridView3.Columns[7].HeaderText = "Высота";
            dataGridView3.Columns[8].HeaderText = "Вес";
            dataGridView3.Columns[9].HeaderText = "Производитель";
            dataGridView3.Columns[10].HeaderText = "Оптовая цена";
            dataGridView3.Columns[11].HeaderText = "Розничная цена";
            dataGridView3.Columns[12].HeaderText = "Остаток";
            dataGridView3.Columns[12].ReadOnly = true;
            dataGridView3.Columns[13].ReadOnly = true;
            dataGridView3.Columns[14].ReadOnly = true;
            dataGridView3.Columns[13].HeaderText = "Ед.измерения";
            dataGridView3.Columns[14].HeaderText = "Изображение";
            dataGridView3.Columns[15].HeaderText = "Гарантия";
            dataGridView3.Columns[16].HeaderText = "Место хранения";
            dataGridView3.Columns[17].HeaderText = "Описание";

           

            dataGridView5.Columns[0].Visible = false;
            dataGridView5.Columns[1].Width = 150;
            dataGridView5.Columns[1].HeaderText = "Наименование";
            dataGridView5.Columns[2].HeaderText = "Макс вес";
            dataGridView5.Columns[3].HeaderText = "Макс объем";
            dataGridView5.Columns[4].HeaderText = "Описание";
        }
        
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            /*int foundIndex = supplierBindingSource.Find("Name", bunifuMetroTextbox1.Text.ToString());
            if (foundIndex > -1)
            {
                dataGridView1.CurrentCell = dataGridView1[1, foundIndex];
            }
            else MessageBox.Show("В справочнике нет интересующей вас информации!");*/
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
           
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                this.state = State.EqPage;
                this.bindingNavigator2.BindingSource = this.categoryBindingSource;
                this.dataGridView2.Columns[0].Visible = false;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                this.state = State.DetPage;
                this.bindingNavigator2.BindingSource = this.fKTovarCategoryBindingSource;
                this.dataGridView3.Columns[0].Visible = false;
            }
        }


        private void toolStripButton8_Click(object sender, EventArgs e)
        {
             this.tovarTableAdapter1.Update(this.warehouseDataSet1.Tovar);

              this.tableAdapterManager.UpdateAll(this.warehouseDataSet1);
             this.tovarTableAdapter1.Fill(this.warehouseDataSet1.Tovar);
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }

        private void dataGridView3_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }

        private void dataGridView4_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }

        private void dataGridView5_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            
        }

       
        

       
        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SqlConnection conect = new SqlConnection(Utils.connectionString);
                conect.Open();
                string sql = "";
                string value = dataGridView3.CurrentRow.Cells[e.ColumnIndex].Value.ToString();
                //UpdateMySQLTovar(e.ColumnIndex, value);
                if (e.ColumnIndex == 2)
                    sql = "Update Tovar Set Name = '"+ value +"'";
                if (e.ColumnIndex == 4)
                    sql = "Update Tovar Set Color = '" + value + "'";
                if (e.ColumnIndex == 5)
                    sql = "Update Tovar Set Lenght = " + int.Parse(value);
                if (e.ColumnIndex == 6)
                    sql = "Update Tovar Set Widht = " + int.Parse(value);
                if (e.ColumnIndex == 7)
                    sql = "Update Tovar Set Height = " + int.Parse(value);
                if (e.ColumnIndex == 8)
                    sql = "Update Tovar Set Weight = " + int.Parse(value);
                if (e.ColumnIndex == 9)
                    sql = "Update Tovar Set SquareMeter = " + int.Parse(value);
                if (e.ColumnIndex == 10)
                {
                    sql = "Update Tovar Set MinPrice = @MP Where ArtNumber = '" + dataGridView3.CurrentRow.Cells[1].Value.ToString() +"'";
                    SqlCommand cmd2 = new SqlCommand(sql, conect);
                    cmd2.Parameters.AddWithValue("@MP", decimal.Parse(value));
                    cmd2.ExecuteNonQuery();
                    conect.Close();
                    return;
                }
                if (e.ColumnIndex == 11)
                {
                    sql = "Update Tovar Set MaxPrice = @MP Where ArtNumber = '" + dataGridView3.CurrentRow.Cells[1].Value.ToString() + "'";
                    SqlCommand cmd2 = new SqlCommand(sql, conect);
                    cmd2.Parameters.AddWithValue("@MP", decimal.Parse(value));
                    cmd2.ExecuteNonQuery();
                    conect.Close();
                    return;
                }
                    if (e.ColumnIndex == 16)
                    sql = "Update Tovar Set Description = '" + value + "'";
                sql += " Where ArtNumber = '" + dataGridView3.CurrentRow.Cells[1].Value.ToString() +"'";
                SqlCommand cmd = new SqlCommand(sql,conect);
                cmd.ExecuteNonQuery();
                conect.Close();

            }
            catch (Exception q) { MessageBox.Show(q.ToString(), "Ошибка"); }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            if (state == State.DetPage)
            {
                fKTovarCategoryBindingSource.Filter = "Name Like '%" + bunifuMetroTextbox2.Text + "%'";
                
            }
        }

        private void bunifuMetroTextbox4_OnValueChanged(object sender, EventArgs e)
        {
                storageBindingSource.Filter = "Name Like '%" + bunifuMetroTextbox4.Text + "%'";
            
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            supplierBindingSource.Filter = "Name Like '%" + bunifuMetroTextbox1.Text + "%'";
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            supplierTableAdapter1.Update(warehouseDataSet1.Supplier);
            warehouseDataSet1.AcceptChanges();
            MessageBox.Show("Данные успешно сохранены!", "Сообщение!");
        }

        private void bunifuThinButton23_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить поставщика \"" + dataGridView1[1, dataGridView1.CurrentRow.Index].FormattedValue.ToString() + "\"? ", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    this.supplierTableAdapter1.Update(this.warehouseDataSet1.Supplier);
                }
            }
        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            //Добавить контрагента
            var toForm = new FormAddAgent(this);
            toForm.Show();
        }

        public void UpdateSupplierTable()
        {
            this.supplierTableAdapter1.Update(this.warehouseDataSet1.Supplier);
            this.supplierTableAdapter1.Fill(this.warehouseDataSet1.Supplier);
        }

        public void UpdateCategoryTable()
        {
            this.categoryTableAdapter1.Update(this.warehouseDataSet1.Category);
            this.categoryTableAdapter1.Fill(this.warehouseDataSet1.Category);
        }

        public void UpdateTovarTable()
        {
            this.tovarTableAdapter1.Update(this.warehouseDataSet1.Tovar);
            this.tovarTableAdapter1.Fill(this.warehouseDataSet1.Tovar);
        }

        public void UpdateStorageTable()
        {
            this.storageTableAdapter1.Update(this.warehouseDataSet1.Storage);
            this.storageTableAdapter1.Fill(this.warehouseDataSet1.Storage);
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            //Редактировать контрагента
            if (dataGridView1.CurrentRow == null)
            {
                var result = MessageBox.Show("Не выбран поставщик.", "Вопрос", MessageBoxButtons.OK);
            }
            else
            { 
                var toForm = new FormEditSupplier(this, dataGridView1.CurrentRow.Cells);
                toForm.Show();
            }            
        }

        private void bunifuThinButton24_Click_1(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить категорию \"" + dataGridView2[1, dataGridView2.CurrentRow.Index].FormattedValue.ToString() + "\"? Также удалятся все товары данной категории!", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                    this.categoryTableAdapter1.Update(this.warehouseDataSet1.Category);
                }
            }
        }

        private void bunifuThinButton28_Click_1(object sender, EventArgs e)
        {
            var toForm = new FormAddCategory(this);
            toForm.Show();
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            var toForm = new FormEditCategory(this, dataGridView2.CurrentRow.Cells);
            toForm.Show();
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton25_Click_1(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow != null)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить товар \"" + dataGridView3[1, dataGridView3.CurrentRow.Index].FormattedValue.ToString() + "\"? ", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //DeleteMySqlTovar(dataGridView3.CurrentRow.Cells[1].Value.ToString());
                    dataGridView3.Rows.RemoveAt(dataGridView3.CurrentRow.Index);
                    this.tovarTableAdapter1.Update(this.warehouseDataSet1.Tovar);
                }
            }
        }

        private void bunifuThinButton29_Click_1(object sender, EventArgs e)
        {
            var toForm = new FormAddTovar(this);
            toForm.Show();
        }

        private void bunifuThinButton26_Click_1(object sender, EventArgs e)
        {
            var toForm = new FormEditTovar(this, dataGridView3.CurrentRow.Cells);
            toForm.Show();
        }

        private void bunifuThinButton212_Click(object sender, EventArgs e)
        {
            var toForm = new FormAddStorage(this);
            toForm.Show();
        }

        private void bunifuThinButton211_Click(object sender, EventArgs e)
        {
            var toForm = new FormEditStorage(this, dataGridView5.CurrentRow.Cells);
            toForm.Show();
        }

        private void bunifuThinButton210_Click_1(object sender, EventArgs e)
        {
            if (dataGridView5.CurrentRow != null)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить  \"" + dataGridView5[1, dataGridView5.CurrentRow.Index].FormattedValue.ToString() + "\"? ", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dataGridView5.Rows.RemoveAt(dataGridView5.CurrentRow.Index);
                    this.storageTableAdapter1.Update(this.warehouseDataSet1.Storage);
                }
            }
        }
    }
}
