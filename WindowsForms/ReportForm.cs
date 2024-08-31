using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsForms
{
    public partial class ReportForm : Form
    {
        BindingSource bs1 = new BindingSource();
        public ReportForm()
        {
            InitializeComponent();
        }

        private void LoadReport()
        {
            try
            {
                SqlConnection conect = new SqlConnection(Utils.connectionString);
                conect.Open();

                var com = new SqlCommand(" SELECT        InvoiceTovar.Id, InvoiceTovar.DateCreate, TypeInvoice_1.Name, Tovar.ArtNumber, Tovar.Name AS Expr1, DetailTovInvoice.Kol, DetailTovInvoice.EdIzm, " +
                " DetailTovInvoice.Price, DetailTovInvoice.Summa, DetailTovInvoice.Ostatok, InvoiceTovar.NameFrom, InvoiceTovar.Client" +
                   "  FROM            InvoiceTovar INNER JOIN" +
                       "  DetailTovInvoice ON InvoiceTovar.Id = DetailTovInvoice.IdInvoice INNER JOIN" +
               "  Tovar ON DetailTovInvoice.IdTovar = Tovar.Id INNER JOIN" +
               "  TypeInvoice AS TypeInvoice_1 ON InvoiceTovar.Type = TypeInvoice_1.Id", conect);
                var adapter = new SqlDataAdapter(com);
                DataSet ds1 = new DataSet();
                adapter.Fill(ds1, "НакладнаяСырье");

                //BindingSource bs1 = new BindingSource();
                bs1.DataSource = ds1.Tables[0];
                bindingNavigator1.BindingSource = bs1;
                dataGridView1.DataSource = bs1;

                dataGridView1.Columns[0].HeaderText = "Номер накладной";
                dataGridView1.Columns[1].HeaderText = "Дата накладной";
                dataGridView1.Columns[2].HeaderText = "Тип накладной";
                dataGridView1.Columns[3].HeaderText = "Артикул";
                dataGridView1.Columns[4].HeaderText = "Наименование";
                dataGridView1.Columns[5].HeaderText = "Количество";
                dataGridView1.Columns[6].HeaderText = "Ед.изм.";
                dataGridView1.Columns[7].HeaderText = "Цена за ед. руб.";
                dataGridView1.Columns[7].DefaultCellStyle.Format = "0.##";
                dataGridView1.Columns[8].HeaderText = "Сумма, руб.";
                dataGridView1.Columns[8].DefaultCellStyle.Format = "0.##";
                dataGridView1.Columns[9].HeaderText = "Остаток на складе";
                dataGridView1.Columns[9].DefaultCellStyle.Format = "0.##";
                dataGridView1.Columns[10].HeaderText = "Сдал";
                dataGridView1.Columns[11].HeaderText = "Принял";
                dataGridView1.RowHeadersWidth = 50;   
                conect.Close();
            }
            catch (Exception q)
            { MessageBox.Show(q.Message.ToString(), "Error Message"); }
        }

        private void ColorRowsDataGridView()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {                
                if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "Приход товара")
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
                if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "Расход товара продажа")
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LawnGreen;
                if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "Возврат товара")
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "Дефект товара")
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
            }
        }
        
        private void ReportForm_Load(object sender, EventArgs e)
        {            
            // TODO: данная строка кода позволяет загрузить данные в таблицу "warehouseDataSet.TypeInvoice". При необходимости она может быть перемещена или удалена.
            this.typeInvoiceTableAdapter.Fill(this.warehouseDataSet.TypeInvoice);
            LoadReport();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
            ColorRowsDataGridView();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            //myBindingSource.Filter = "myDateField >= '" + getSqlDate(myDateTime) + "' AND myDateField < '" + getSqlDate(myDateTime.AddDays(1)) + "'";
            try
            {
                if (checkBox1.Checked == false && checkBox2.Checked == false)
                {
                    bs1.RemoveFilter();
                }
                if (checkBox1.Checked == true && checkBox2.Checked == false)
                {
                    //dtSales.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, textBox1.Text);
                    bs1.RemoveFilter();
                    bs1.Filter = string.Format("Name = '"+ comboBox1.Text+"'");
                }
                if (checkBox2.Checked == true && checkBox1.Checked == false)
                {
                    bs1.RemoveFilter();
                    bs1.Filter = "DateCreate >= '" + getSqlDate(dateTimePicker1.Value) + "' AND DateCreate < '" + getSqlDate(dateTimePicker2.Value.AddDays(1)) + "'";
                }
                if (checkBox1.Checked == true && checkBox2.Checked == true)
                {
                    bs1.RemoveFilter();
                    bs1.Filter = "Name = '" + comboBox1.Text + "' AND DateCreate >= '" + getSqlDate(dateTimePicker1.Value) + "' AND DateCreate < '" + getSqlDate(dateTimePicker2.Value.AddDays(1)) + "'";
                }
            }
            catch (Exception q)
            { MessageBox.Show(q.Message.ToString(), "Error Message"); }
        }

        string getSqlDate(DateTime date)
        {
            string year = "" + date.Year;
            string month = (date.Month < 10) ? "0" + date.Month : "" + date.Month;
            string day = (date.Day < 10) ? "0" + date.Day : "" + date.Day;

            return year + "-" + month + "-" + day + " 00:00:00";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                //app.Workbooks.Open(Application.StartupPath.ToString() + "\\GoodsMove.xlsx", Type.Missing, true);

                //Microsoft.Office.Interop.Excel.Workbook book = app.ActiveWorkbook;
                //Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Worksheets[1];
                //app.Visible = true;

                //dataGridView1.Columns[0].HeaderText = "Номер накладной";
                //dataGridView1.Columns[1].HeaderText = "Дата накладной";
                //dataGridView1.Columns[2].HeaderText = "Тип накладной";
                //dataGridView1.Columns[3].HeaderText = "Артикул";
                //dataGridView1.Columns[4].HeaderText = "Наименование";
                //dataGridView1.Columns[5].HeaderText = "Количество";
                //dataGridView1.Columns[6].HeaderText = "Ед.изм.";
                //dataGridView1.Columns[7].HeaderText = "Цена за ед. руб.";
                //dataGridView1.Columns[8].HeaderText = "Сумма, руб.";
                //dataGridView1.Columns[9].HeaderText = "Остаток на складе";

                //int j = 2;
                //for (int i = 0; i < dataGridView1.RowCount; i++)
                //{
                //    sheet.get_Range("A" + j).Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                //    sheet.get_Range("B" + j).Value = DateTime.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()).ToShortDateString();
                //    sheet.get_Range("C" + j).Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
                //    sheet.get_Range("D" + j).Value = dataGridView1.Rows[i].Cells[3].Value.ToString();
                //    sheet.get_Range("E" + j).Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
                //    sheet.get_Range("F" + j).Value = dataGridView1.Rows[i].Cells[5].Value.ToString();
                //    sheet.get_Range("G" + j).Value = dataGridView1.Rows[i].Cells[6].Value.ToString();
                //    sheet.get_Range("H" + j).Value = Decimal.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                //    sheet.get_Range("I" + j).Value = Decimal.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());
                //    sheet.get_Range("J" + j).Value = dataGridView1.Rows[i].Cells[9].Value.ToString();
                //    sheet.get_Range("K" + j).Value = dataGridView1.Rows[i].Cells[10].Value.ToString();
                //    sheet.get_Range("L" + j).Value = dataGridView1.Rows[i].Cells[11].Value.ToString();
                //    j++;
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
