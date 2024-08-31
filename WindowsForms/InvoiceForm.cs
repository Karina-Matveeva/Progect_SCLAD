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

namespace WindowsForms
{
    public partial class InvoiceForm : Form
    {
        enum State { EqPage, DetPage };
        State state;
        public InvoiceForm()
        {
            state = State.EqPage;
            InitializeComponent();
        }


        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'warehouseDataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.warehouseDataSet.Supplier);
            // TODO: This line of code loads data into the 'warehouseDataSet.Company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.warehouseDataSet.Company);
            LoadInvoiceTovar();
        }

        private void LoadInvoiceTovar()
        {
            try
            {
                SqlConnection conect = new SqlConnection(Utils.connectionString);
                conect.Open();

                //var com = new SqlCommand("SELECT InvoiceTovar.Id, InvoiceTovar.DateCreate, TypeInvoice.Name, InvoiceTovar.NameFrom, InvoiceTovar.Client, InvoiceTovar.Adress, InvoiceTovar.Summa " +
                // " FROM InvoiceTovar INNER JOIN TypeInvoice ON InvoiceTovar.Type = TypeInvoice.Id", conect);
                var com = new SqlCommand("SELECT InvoiceTovar.Id, InvoiceTovar.DateCreate, TypeInvoice.Name, InvoiceTovar.NameFrom, InvoiceTovar.Client," +
                       " InvoiceTovar.Adress, InvoiceTovar.Summa,  Supplier.Name, Supplier.Adress, Supplier.Bank, Supplier.BikBank, Supplier.OKPO,Supplier.Buhgalter,Supplier.Director" +
                       " FROM InvoiceTovar INNER JOIN TypeInvoice ON InvoiceTovar.Type = TypeInvoice.Id" +
                       " INNER JOIN  Supplier ON InvoiceTovar.SupplierId = Supplier.Id", conect);
                var adapter = new SqlDataAdapter(com);
                DataSet ds2 = new DataSet();
                adapter.Fill(ds2, "НакладнаяТовар");

                BindingSource bs2 = new BindingSource();
                bs2.DataSource = ds2.Tables[0];
                bindingNavigator2.BindingSource = bs2;
                dataGridView2.DataSource = bs2;

                dataGridView2.Columns[0].HeaderText = "Номер накладной";
                dataGridView2.Columns[1].HeaderText = "Дата накладной";
                dataGridView2.Columns[2].HeaderText = "Тип накладной";
                dataGridView2.Columns[3].HeaderText = "Сдал";
                dataGridView2.Columns[4].HeaderText = "Принял";
                dataGridView2.Columns[5].HeaderText = "Адрес";
                dataGridView2.Columns[6].HeaderText = "Сумма, руб.";
                dataGridView2.Columns[6].DefaultCellStyle.Format = "0.##";
                dataGridView2.RowHeadersWidth = 50;
                dataGridView2.Columns[7].Visible = false;
                dataGridView2.Columns[8].Visible = false;
                dataGridView2.Columns[9].Visible = false;
                dataGridView2.Columns[10].Visible = false;
                dataGridView2.Columns[11].Visible = false;
                dataGridView2.Columns[12].Visible = false;
                dataGridView2.Columns[13].Visible = false;
                conect.Close();
            }
            catch (Exception q)
            { MessageBox.Show(q.Message.ToString(), "Error Message"); }
        }

        private void loadDetailInvoice()
        {
            try
            {
                SqlConnection conect = new SqlConnection(Utils.connectionString);
                conect.Open();

                var com = new SqlCommand("SELECT Tovar.ArtNumber, Tovar.Name, DetailTovInvoice.Kol, DetailTovInvoice.EdIzm, DetailTovInvoice.Price, DetailTovInvoice.Summa " +
       " FROM DetailTovInvoice INNER JOIN Tovar ON DetailTovInvoice.IdTovar = Tovar.Id " +
       " where DetailTovInvoice.IdInvoice = " + dataGridView2.CurrentRow.Cells[0].Value, conect);
                var adapter = new SqlDataAdapter(com);
                DataSet ds2 = new DataSet();
                adapter.Fill(ds2, "Детали накладной");

                BindingSource bs2 = new BindingSource();
                bs2.DataSource = ds2.Tables[0];
                bindingNavigator2.BindingSource = bs2;
                dataGridView1.DataSource = bs2;

                dataGridView1.Columns[0].HeaderText = "Артикул товара";
                dataGridView1.Columns[1].HeaderText = "Наименование";
                dataGridView1.Columns[2].HeaderText = "Количество";
                dataGridView1.Columns[3].HeaderText = "Ед изм";
                dataGridView1.Columns[4].HeaderText = "Цена за ед., руб.";
                dataGridView1.Columns[4].DefaultCellStyle.Format = "0.##";
                dataGridView1.Columns[5].HeaderText = "Сумма, руб.";
                dataGridView1.Columns[5].DefaultCellStyle.Format = "0.##";
                dataGridView1.RowHeadersWidth = 50;
                conect.Close();
            }
            catch (Exception q)
            { MessageBox.Show(q.Message.ToString(), "Error Message"); }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //new InvoiceDetailMatForm(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)).Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            new InvoiceDetailTovForm(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value)).Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            LoadInvoiceTovar();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0) return;
            var row = dataGridView2.SelectedRows[0];
            var num = 0;
            if(int.TryParse(row.Cells[0].Value.ToString(),out num))
            {
                SqlConnection conect = new SqlConnection(Utils.connectionString);
                conect.Open();
                var com = new SqlCommand($"DELETE FROM InvoiceTovar WHERE Id={num}", conect);
                var result = com.ExecuteNonQuery();
                conect.Close();
                LoadInvoiceTovar();
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 0)
            {
                state = State.EqPage;
                
            }
            else
            {
                state = State.DetPage;
                loadDetailInvoice();
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                loadDetailInvoice();
                /*dataGridView2.Columns[0].HeaderText = "Номер накладной";
                dataGridView2.Columns[1].HeaderText = "Дата накладной";
                dataGridView2.Columns[2].HeaderText = "Тип накладной";
                dataGridView2.Columns[3].HeaderText = "Сдал";
                dataGridView2.Columns[4].HeaderText = "Принял";
                dataGridView2.Columns[5].HeaderText = "Адрес";
                dataGridView2.Columns[6].HeaderText = "Сумма, руб.";
                Supplier.Name, Supplier.Adress, Supplier.Bank, 
                Supplier.BikBank, Supplier.OKPO,Supplier.Buhgalter,Supplier.Director*/

                //if (dataGridView2.CurrentRow.Cells[2].Value.ToString() == "Приход товара")
                //{
                //    DataView r = ((DataRowView)warehouse[0]).DataView;
                //    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                //    app.Workbooks.Open(Application.StartupPath.ToString() + "\\blank.xlsx", Type.Missing, true);
                //    Microsoft.Office.Interop.Excel.Workbook book = app.ActiveWorkbook;
                //    Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Worksheets[1];
                //    app.Visible = true;

                //    sheet.get_Range("A4").Value = dataGridView2.CurrentRow.Cells[7].Value.ToString() + ", " + dataGridView2.CurrentRow.Cells[8].Value.ToString() + ", " + dataGridView2.CurrentRow.Cells[9].Value.ToString() + ", " + dataGridView2.CurrentRow.Cells[10].Value.ToString();
                //    sheet.get_Range("I11").Value = dataGridView2.CurrentRow.Cells[7].Value.ToString() + ", " + dataGridView2.CurrentRow.Cells[8].Value.ToString() + ", " + dataGridView2.CurrentRow.Cells[9].Value.ToString() + ", " + dataGridView2.CurrentRow.Cells[10].Value.ToString();

                //    sheet.get_Range("L9").Value = r[0].Row[1].ToString() + ", " + r[0].Row[2].ToString() + ", " + r[0].Row[3].ToString() + ", " + r[0].Row[9].ToString();
                //    sheet.get_Range("I13").Value = r[0].Row[1].ToString() + ", " + r[0].Row[2].ToString() + ", " + r[0].Row[3].ToString() + ", " + r[0].Row[9].ToString();

                //    sheet.get_Range("CF10").Value = dataGridView2.CurrentRow.Cells[11].Value.ToString();
                //    sheet.get_Range("CF4").Value = dataGridView2.CurrentRow.Cells[11].Value.ToString();
                //    sheet.get_Range("CF9").Value = r[0].Row[7].ToString();
                //    sheet.get_Range("CF12").Value = r[0].Row[7].ToString();


                //    sheet.get_Range("CF14").Value = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                //    sheet.get_Range("CF16").Value = DateTime.Parse(dataGridView2.CurrentRow.Cells[1].Value.ToString()).ToShortDateString();

                //    sheet.get_Range("AX23").Value = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                //    sheet.get_Range("BI23").Value = DateTime.Parse(dataGridView2.CurrentRow.Cells[1].Value.ToString()).ToShortDateString();

                //    sheet.get_Range("CF20").Value = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                //    sheet.get_Range("AG37").Value = dataGridView2.CurrentRow.Cells[12].Value.ToString();
                //    sheet.get_Range("AG39").Value = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                //    sheet.get_Range("BY37").Value = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                //    int j = 28;
                //    for (int i = 0; i < dataGridView1.RowCount; i++)
                //    {

                //        sheet.get_Range("D" + j).Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                //        sheet.get_Range("T" + j).Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                //        sheet.get_Range("AM" + j).Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
                //        sheet.get_Range("X" + j).Value = dataGridView1.Rows[i].Cells[3].Value.ToString();
                //        sheet.get_Range("BH" + j).Value = Decimal.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                //        sheet.get_Range("BX" + j).Value = "18%";
                //        sheet.get_Range("A" + j).Value = i + 1;
                //        j++;
                //    }
                //}
                //else if (dataGridView2.CurrentRow.Cells[2].Value.ToString() == "Расход товара продажа")
                //{
                //    DataView r = ((DataRowView)warehouse[0]).DataView;
                //    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                //    app.Workbooks.Open(Application.StartupPath.ToString() + "\\blank.xlsx", Type.Missing, true);
                //    Microsoft.Office.Interop.Excel.Workbook book = app.ActiveWorkbook;
                //    Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Worksheets[1];
                //    app.Visible = true;

                //    sheet.get_Range("L9").Value = dataGridView2.CurrentRow.Cells[7].Value.ToString() + ", " + dataGridView2.CurrentRow.Cells[8].Value.ToString() + ", " + dataGridView2.CurrentRow.Cells[9].Value.ToString() + ", " + dataGridView2.CurrentRow.Cells[10].Value.ToString();
                //    sheet.get_Range("I13").Value = dataGridView2.CurrentRow.Cells[7].Value.ToString() + ", " + dataGridView2.CurrentRow.Cells[8].Value.ToString() + ", " + dataGridView2.CurrentRow.Cells[9].Value.ToString() + ", " + dataGridView2.CurrentRow.Cells[10].Value.ToString();

                //    sheet.get_Range("A4").Value = r[0].Row[1].ToString() + ", " + r[0].Row[2].ToString() + ", " + r[0].Row[3].ToString() + ", " + r[0].Row[9].ToString();
                //    sheet.get_Range("I11").Value = r[0].Row[1].ToString() + ", " + r[0].Row[2].ToString() + ", " + r[0].Row[3].ToString() + ", " + r[0].Row[9].ToString();

                //    sheet.get_Range("CF9").Value = dataGridView2.CurrentRow.Cells[11].Value.ToString();
                //    sheet.get_Range("CF12").Value = dataGridView2.CurrentRow.Cells[11].Value.ToString();
                //    sheet.get_Range("CF10").Value = r[0].Row[7].ToString();
                //    sheet.get_Range("CF4").Value = r[0].Row[7].ToString();


                //    sheet.get_Range("CF14").Value = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                //    sheet.get_Range("CF16").Value = DateTime.Parse(dataGridView2.CurrentRow.Cells[1].Value.ToString()).ToShortDateString();

                //    sheet.get_Range("AX23").Value = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                //    sheet.get_Range("BI23").Value = DateTime.Parse(dataGridView2.CurrentRow.Cells[1].Value.ToString()).ToShortDateString();

                //    sheet.get_Range("CF20").Value = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                //    sheet.get_Range("AG37").Value = r[0].Row[13].ToString();
                //    sheet.get_Range("AG39").Value = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                //    sheet.get_Range("BY37").Value = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                //    int j = 28;
                //    for (int i = 0; i < dataGridView1.RowCount; i++)
                //    {

                //        sheet.get_Range("D" + j).Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                //        sheet.get_Range("T" + j).Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                //        sheet.get_Range("AM" + j).Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
                //        sheet.get_Range("X" + j).Value = dataGridView1.Rows[i].Cells[3].Value.ToString();
                //        sheet.get_Range("BH" + j).Value = Decimal.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                //        sheet.get_Range("BX" + j).Value = "18%";
                //        sheet.get_Range("A" + j).Value = i + 1;
                //        j++;
                //    }
                //}
            }
            catch
            {
                MessageBox.Show("Невозможно сформировать отчет с помощью Microsoft Excel.", "Внимание, ошибка!",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }        
        }
    }
}
