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
    public partial class ZakupkiAdd : Form
    {
        List<ZakMat> materials = new List<ZakMat>();


        public ZakupkiAdd(List<ZakMat> b)
        {
            InitializeComponent();             
            FillDataGrid(b);
            int t = (int)numericUpDown1.Value;
            DateTime d = DateTime.Today.AddDays(t);
            dateTimePicker2.Value = d; 
        }

        private void ZakupkiAdd_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "warehouseDataSet1.Material". При необходимости она может быть перемещена или удалена.
              
                // TODO: данная строка кода позволяет загрузить данные в таблицу "warehouseDataSet1.Supplier". При необходимости она может быть перемещена или удалена.
                this.supplierTableAdapter1.Fill(this.warehouseDataSet1.Supplier);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "warehouseDataSet.Material". При необходимости она может быть перемещена или удалена.
      
                // TODO: данная строка кода позволяет загрузить данные в таблицу "warehouseDataSet.Supplier". При необходимости она может быть перемещена или удалена.
                this.supplierTableAdapter.Fill(this.warehouseDataSet.Supplier);
            }
            catch { }
        }

        private void FillDataGrid(List<ZakMat> materials)
        {
            int j=0;
            for (int i = 0; i < materials.Count; i++)
            {
                float mgz = materials[i].MGZ;
                float pu = materials[i].MGZ*(int)numericUpDown2.Value/100;
                float op = materials[i].SRD * (int)numericUpDown1.Value;
                float Rz = mgz - pu + op;
                decimal SummRz = materials[i].Price * decimal.Parse(Rz.ToString());
                dataGridView1.Rows.Add(materials[i].IdMaterial, materials[i].Name, materials[i].Ost, materials[i].EdZ, materials[i].Price, Math.Round(Rz, 2), Math.Round(mgz, 2), Math.Round(pu, 2), Math.Round(op, 2), SummRz, comboBox1.SelectedValue, comboBox1.Text, 2000);
                if (materials[i].Ost <= pu) 
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                AnalizOstatkiMaterial();
                FillDataGrid(materials);
            }
            catch{}
        }

        private void AnalizOstatkiMaterial()
        {
            try
            {
                materials.Clear();
                int CountDay = 7;
                SqlConnection conect = new SqlConnection(Utils.connectionString);
                SqlConnection conect2 = new SqlConnection(Utils.connectionString);
                conect.Open(); conect2.Open();
                DateTime d2 = DateTime.Today;
                DateTime d1 = DateTime.Today.AddDays(-CountDay);

                SqlCommand cmd = new SqlCommand("SELECT mat.Id, mat.ArtNumber, mat.Name, mat.Ostatok, mat.EdIzm, " +
                    " mat.Price, st.MaxWeight FROM Warehouse.dbo.Material AS mat JOIN    Warehouse.dbo.Storage AS st ON mat.Storage = st.Id ", conect);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ZakMat z = new ZakMat();
                    z.IdMaterial = int.Parse(reader[0].ToString());
                    z.Name = reader[2].ToString();
                    z.MGZ = float.Parse(reader[6].ToString());
                    z.Ost = float.Parse(reader[3].ToString());
                    z.EdZ = reader[4].ToString();
                    z.Price = decimal.Parse(reader[5].ToString());
                    SqlCommand com = new SqlCommand("SELECT SUM(CASE WHEN it.Type = 1 THEN dti.Kol WHEN it.Type IN (2, 5) THEN - dti.Kol END) AS summa     FROM         " +
                    "    Warehouse.dbo.DetailMatInvoice AS dti    JOIN    Warehouse.dbo.InvoiceMaterial AS it ON dti.IdInvoice = it.Id AND (it.Type IN (1, 2, 5)) " +
                    "   AND (CAST(it.DateCreate AS Date) <= '" + d1 + "') and (dti.IdMaterial = " + reader[0] + ")    JOIN    Warehouse.dbo.Material ON dti.IdMaterial = Material.Id    GROUP BY dti.IdMaterial, Material.ArtNumber, Material.Name ", conect2);
                    float Ost1 = 0, Ost2 = 0;
                    if (com.ExecuteScalar() != null)
                        Ost1 = float.Parse(com.ExecuteScalar().ToString());
                    com = new SqlCommand("SELECT SUM(CASE WHEN it.Type = 1 THEN dti.Kol WHEN it.Type IN (2, 5) THEN - dti.Kol END) AS summa     FROM         " +
                    "    Warehouse.dbo.DetailMatInvoice AS dti    JOIN    Warehouse.dbo.InvoiceMaterial AS it ON dti.IdInvoice = it.Id AND (it.Type IN (1, 2, 5)) " +
                    "   AND (CAST(it.DateCreate AS Date) <= '" + d2 + "') and (dti.IdMaterial = " + reader[0] + ")    JOIN    Warehouse.dbo.Material ON dti.IdMaterial = Material.Id    GROUP BY dti.IdMaterial, Material.ArtNumber, Material.Name ", conect2);
                    if (com.ExecuteScalar() != null)
                        Ost2 = float.Parse(com.ExecuteScalar().ToString());
                    float Srd = (Ost2 - Ost1) / CountDay;
                    z.SRD = Math.Abs(Srd);
                    materials.Add(z);
                }
                reader.Close();

                conect.Close();
                conect2.Close();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    dataGridView1.CurrentRow.Cells[10].Value = comboBox1.SelectedValue;
                    dataGridView1.CurrentRow.Cells[11].Value = comboBox1.Text;
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conect = new SqlConnection(Utils.connectionString);
                conect.Open();
                //for (int i = 0; i < dataGridView1.RowCount; i++ )
                {
                    int i = dataGridView1.CurrentRow.Index;
                    //if (dataGridView1.Rows[i].Cells[10].Value != null && dataGridView1.Rows[i].Cells[11].Value != null)
                    {
                        if (float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) <= float.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString()))
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = conect;
                            string sql = string.Format("Insert Into Zakupki " +
                                    " ([DateCreate], [DateDostavki], [Supplier], [Status], [Srok], [Dostavka], [Total], [Subtotal]) " +
                                    " Values (@DateCreate, @DateDostavki, @Supplier, @Status, @Srok, @Dostavka, @Total, @Subtotal)");                           
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@DateCreate", dateTimePicker1.Value.Date);
                            cmd.Parameters.AddWithValue("@DateDostavki", dateTimePicker2.Value.Date);
                            cmd.Parameters.AddWithValue("@Supplier", "2");
                            cmd.Parameters.AddWithValue("@Status", "Заказано");
                            cmd.Parameters.AddWithValue("@Srok", (int)numericUpDown1.Value);
                            cmd.Parameters.AddWithValue("@Dostavka", decimal.Parse(dataGridView1.Rows[i].Cells[12].Value.ToString()));
                            cmd.Parameters.AddWithValue("@Total", decimal.Parse(dataGridView1.CurrentRow.Cells[9].Value.ToString()));
                            cmd.Parameters.AddWithValue("@Subtotal", (decimal.Parse(dataGridView1.CurrentRow.Cells[9].Value.ToString()) + decimal.Parse(dataGridView1.CurrentRow.Cells[12].Value.ToString())));
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            cmd.CommandText = "SELECT @@IDENTITY";
                            int lastId = Convert.ToInt32(cmd.ExecuteScalar());
                            sql = string.Format("Insert Into DetailZakupki  " +
                                " ([IdZakup], [IdMaterial], [NameMaterial], [Quantity], [EdIzm], [Price]) " +
                                " Values (@IdZakup, @IdMaterial, @NameMaterial, @Quantity, @EdIzm, @Price)");
                            SqlCommand cmd2 = new SqlCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = sql;
                            cmd2.Connection = conect;
                            cmd2.Parameters.AddWithValue("@IdZakup", lastId);
                            cmd2.Parameters.AddWithValue("@IdMaterial", int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                            cmd2.Parameters.AddWithValue("@NameMaterial", dataGridView1.Rows[i].Cells[1].Value.ToString());
                            cmd2.Parameters.AddWithValue("@Quantity", float.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()));
                            cmd2.Parameters.AddWithValue("@EdIzm", dataGridView1.Rows[i].Cells[3].Value.ToString());
                            cmd2.Parameters.AddWithValue("@Price", decimal.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString()));
                            cmd2.ExecuteNonQuery();
                            MessageBox.Show("Закупки успешно сформированы!", "Сообщение");
                        }
                        else MessageBox.Show("Пороговый уровень запаса меньше остатка на складе", "Сообщение");
                    }
                    //else MessageBox.Show("Не заполнены данные о поставщиках!","Сообщение");
                }
               
                conect.Close();
            }
            catch (Exception q) { MessageBox.Show(q.ToString()); }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int t = (int)numericUpDown1.Value;
            DateTime d = dateTimePicker1.Value.Date.AddDays(t);
            dateTimePicker2.Value = d; 
        }
    }
}
