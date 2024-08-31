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
    public partial class Zakupki : Form
    {
        List<ZakMat> materials = new List<ZakMat>();

        public Zakupki()
        {
            InitializeComponent();
            AnalizOstatkiMaterial();            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ZakupkiAdd fr = new ZakupkiAdd(this.materials);
            fr.Show();
        }

        private void Zakupki_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "warehouseDataSet1.Supplier". При необходимости она может быть перемещена или удалена.
            this.supplierTableAdapter.Fill(this.warehouseDataSet1.Supplier);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "warehouseDataSet1.DetailZakupki". При необходимости она может быть перемещена или удалена.
            this.detailZakupkiTableAdapter1.Fill(this.warehouseDataSet1.DetailZakupki);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "warehouseDataSet1.Zakupki". При необходимости она может быть перемещена или удалена.
            this.zakupkiTableAdapter1.Fill(this.warehouseDataSet1.Zakupki);

            dataGridView1.Columns[0].Visible = false;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].Visible = false;
            dataGridView2.Columns[2].Visible = false;
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
                    float Ost1 = 0, Ost2= 0;
                    if(com.ExecuteScalar() != null)
                        Ost1 = float.Parse(com.ExecuteScalar().ToString());
                    com = new SqlCommand("SELECT SUM(CASE WHEN it.Type = 1 THEN dti.Kol WHEN it.Type IN (2, 5) THEN - dti.Kol END) AS summa     FROM         " +
                    "    Warehouse.dbo.DetailMatInvoice AS dti    JOIN    Warehouse.dbo.InvoiceMaterial AS it ON dti.IdInvoice = it.Id AND (it.Type IN (1, 2, 5)) " +
                    "   AND (CAST(it.DateCreate AS Date) <= '" + d2 + "') and (dti.IdMaterial = " + reader[0] + ")    JOIN    Warehouse.dbo.Material ON dti.IdMaterial = Material.Id    GROUP BY dti.IdMaterial, Material.ArtNumber, Material.Name ", conect2);
                    if(com.ExecuteScalar() != null)
                        Ost2 = float.Parse(com.ExecuteScalar().ToString());
                    float Srd = (Ost2 - Ost1) / CountDay;
                    z.SRD = Math.Abs(Srd);
                    materials.Add(z);
                }
                reader.Close();

                conect.Close();
                conect2.Close();
            }
            catch{}
        }
    }

    public class ZakMat
    {
        public int IdMaterial { get; set; }
        public string Name { get; set; }
        public string EdZ { get; set; }
        public float MGZ { get; set; }
        public float SRD { get; set; }
        public float Ost { get; set; }
        public decimal Price { get; set; }
    }
}
