using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;


namespace WindowsForms
{
    public partial class Graphic : Form
    {
        BindingSource bs1 = new BindingSource();
        List<String> days = new List<string>();
        List<Tovar> tovars = new List<Tovar>();

        public Graphic()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today.AddDays(-5);

            LoadListBox();
            if (tovars.Count != 0)
            {
                list.SetSelected(0, true);
                //list.SetSelected(1, true);
                list.SetSelected(2, true);
                // list.SetSelected(3, true);

                LoadOstatkiTov();
            }
                        
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
        }
        //загружаем ListBox данные о товарах и загружаем id в chart
        private void LoadListBox()
        {
            try
            {
                    SqlConnection connRC = new SqlConnection(Utils.connectionString);
                    connRC.Open();
                    SqlCommand com = new SqlCommand("SELECT Id, ArtNumber +' '+ Name as myName, ArtNumber, MinPrice, MaxPrice FROM Tovar", connRC);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        tovars.Add(new Tovar { Id = int.Parse(reader[0].ToString()), Name = reader[1].ToString(), Article = reader[2].ToString(), MinPrice = reader[3].ToString(), MaxPrice = reader[4].ToString() });
                    }
                    reader.Close();
                    connRC.Close();
                    list.DataSource = tovars;
                    list.DisplayMember = "Name";
                    list.ValueMember = "Id";
            }
            catch (Exception q) { MessageBox.Show(q.ToString(), "Сообщение"); }
        }

        //загружаем список дат
        private void fillDate()
        {
            DateTime d1 = dateTimePicker1.Value;
            days.Clear();
            days.Add(d1.Date.ToShortDateString());
            while (d1.Date != dateTimePicker2.Value.Date)
            {
                d1 = d1.AddDays(1);
                days.Add(d1.Date.ToShortDateString());
            }
        }
        //рисуем график остатков на даты
        private void LoadOstatkiTov()
        {
            try
            {
                fillDate();
                chart.Series.Clear();
                
                if (radioButtonTovar.Checked)
                {
                    bool fl = false;
                    foreach (Object obj in list.SelectedItems)
                    {
                        chart.Series.Add(((Tovar)obj).Name.ToString());
                        chart.Series.Last().ChartType = SeriesChartType.Line;
                        chart.Series.Last().BorderWidth = 4;
                        chart.Series.Last().MarkerSize = 15;

                    }
                    SqlConnection conect = new SqlConnection(Utils.connectionString);
                    conect.Open();
                    int j = 0;
                    for (int i = 0; i < days.Count; i++)
                    {
                        SqlCommand com = new SqlCommand("SELECT        dti.IdTovar, " +
                           "  SUM(CASE WHEN it.Type = 3 THEN dti.Kol WHEN it.Type IN (4, 6) THEN - dti.Kol END) AS summa,  " +
                            " Tovar.ArtNumber + ' ' + Tovar.Name AS MyName " +
                            " FROM             " +
                            " Warehouse.dbo.DetailTovInvoice AS dti " +
                            "LEFT JOIN    Warehouse.dbo.InvoiceTovar AS it ON dti.IdInvoice = it.Id AND (it.Type IN (3, 4, 6)) AND (CAST(it.DateCreate AS Date) <= '" + days[i] + "')  " +
                            "LEFT JOIN    Warehouse.dbo.Tovar ON dti.IdTovar = Tovar.Id " +
                            " GROUP BY dti.IdTovar, Tovar.ArtNumber, Tovar.Name", conect);

                        SqlDataReader reader = com.ExecuteReader();
                        
                        while (reader.Read())
                        {
                            if (chart.Series.IndexOf(reader[2].ToString()) != -1)
                            {
                                String temp2 = reader[1].ToString();
                                int sumI = temp2 == "" ? 0 : (Int32)Double.Parse(reader[1].ToString());
                                String sum = sumI > 0 ? sumI.ToString() : "0";
                                fl = true;
                                chart.Series[reader[2].ToString()].Points.AddXY(days[i], sum);
                                chart.Series[reader[2].ToString()].Points[j].ToolTip = sum;
                                chart.Series[reader[2].ToString()].Points[j].MarkerStyle = MarkerStyle.Diamond;
                                chart.Series[reader[2].ToString()].Points[j].MarkerSize = 12;
                                if (checkBox1.Checked)
                                    chart.Series[reader[2].ToString()].Points[j].Label = sum.ToString();
                            }
                        } j++;
                      
                     
                        reader.Close();
                    }
                    if (!fl)
                    {
                        chart.Series[0].Points.AddXY(days[0], 0);
                        chart.Series[0].Points[0].MarkerStyle = MarkerStyle.Diamond;
                        chart.Series[0].Points[0].MarkerSize = 12;
                       
                    }
                    conect.Close();
                }
                else
                {
                    foreach (Object obj in listMat.SelectedItems)
                    {
                       
                        chart.Series.Last().ChartType = SeriesChartType.Line;
                        chart.Series.Last().BorderWidth = 4;
                        chart.Series.Last().MarkerSize = 15;

                    }
                    SqlConnection conect = new SqlConnection(Utils.connectionString);
                    conect.Open();
                    int j = 0;
                    for (int i = 0; i < days.Count; i++)
                    {
                        SqlCommand com = new SqlCommand("SELECT        dti.IdMaterial,    SUM(CASE WHEN it.Type = 1 THEN dti.Kol WHEN it.Type IN (2, 5) THEN - dti.Kol END) AS summa,      Material.ArtNumber + ' ' + Material.Name AS MyName     FROM         "+
                            "    Warehouse.dbo.DetailMatInvoice AS dti    LEFT JOIN    Warehouse.dbo.InvoiceMaterial AS it ON dti.IdInvoice = it.Id AND (it.Type IN (1, 2, 5)) "+
                            "   AND (CAST(it.DateCreate AS Date) <= '" + days[i] + "')   LEFT JOIN    Warehouse.dbo.Material ON dti.IdMaterial = Material.Id    GROUP BY dti.IdMaterial, Material.ArtNumber, Material.Name " , conect);

                        SqlDataReader reader = com.ExecuteReader();
                        while (reader.Read())
                        {
                            if (chart.Series.IndexOf(reader[2].ToString()) != -1)
                            {
                                String temp = reader[1].ToString();
                                int sumI = temp == "" ? 0 : (Int32)Double.Parse(reader[1].ToString());
                                String sum = sumI > 0 ? sumI.ToString() : "0";
                                
                                chart.Series[reader[2].ToString()].Points.AddXY(days[i], sum.ToString());
                                chart.Series[reader[2].ToString()].Points[j].ToolTip = sum.ToString();
                                chart.Series[reader[2].ToString()].Points[j].MarkerStyle = MarkerStyle.Diamond;
                                chart.Series[reader[2].ToString()].Points[j].MarkerSize = 12;
                                if (checkBox1.Checked)
                                    chart.Series[reader[2].ToString()].Points[j].Label = sum.ToString();

                              
                            }
                        } j++;
                        reader.Close();
                    }
                    conect.Close();
                }
            }
            catch (Exception q)
            { MessageBox.Show(q.Message.ToString(), "Error Message"); }
        }

        private void LoadIzlishkiTov()
        {
            try
            {
                fillDate();
                chart.Series.Clear();
                if (radioButtonTovar.Checked)
                {
                    foreach (Object obj in list.SelectedItems)
                    {
                        chart.Series.Add(((Tovar)obj).Name.ToString());
                        chart.Series.Last().ChartType = SeriesChartType.Line;
                        chart.Series.Last().BorderWidth = 4;
                        chart.Series.Last().MarkerSize = 15;

                    }
                    SqlConnection conect = new SqlConnection(Utils.connectionString);
                    conect.Open();
                    int j = 0;
                    for (int i = 0; i < days.Count; i++)
                    {
                        SqlCommand com = new SqlCommand("SELECT        dti.IdTovar, " +
                           "  SUM(CASE WHEN it.Type = 3 THEN dti.Kol WHEN it.Type IN (4, 6) THEN - dti.Kol END) AS summa,  " +
                            " Tovar.ArtNumber + ' ' + Tovar.Name AS MyName " +
                            " FROM             " +
                            " Warehouse.dbo.DetailTovInvoice AS dti " +
                            "LEFT JOIN    Warehouse.dbo.InvoiceTovar AS it ON dti.IdInvoice = it.Id AND (it.Type IN (3, 4, 6)) AND (CAST(it.DateCreate AS Date) <= '" + days[i] + "')  " +
                            "LEFT JOIN    Warehouse.dbo.Tovar ON dti.IdTovar = Tovar.Id " +
                            " GROUP BY dti.IdTovar, Tovar.ArtNumber, Tovar.Name", conect);

                        SqlDataReader reader = com.ExecuteReader();
                       
                        while (reader.Read())
                        {
                            if (chart.Series.IndexOf(reader[2].ToString()) != -1)
                            {
                                decimal d;
                                string temp = reader[1].ToString();
                                string temp2 = tovars.Find(x => x.Name == reader[2].ToString()).MinPrice;
                                if (temp == "")
                                    d = 0;
                                else
                                    d = decimal.Parse(temp) * decimal.Parse(temp2);

                             
                                String sum = d > 0 ? d.ToString() : "0";

                                chart.Series[reader[2].ToString()].Points.AddXY(days[i], sum.ToString());
                                chart.Series[reader[2].ToString()].Points[j].ToolTip = sum.ToString();
                                chart.Series[reader[2].ToString()].Points[j].MarkerStyle = MarkerStyle.Diamond;
                                chart.Series[reader[2].ToString()].Points[j].MarkerSize = 12;
                                if (checkBox1.Checked)  
                                    chart.Series[reader[2].ToString()].Points[j].Label = sum.ToString();
                                
                            }
                        } j++;
                        reader.Close();

                    }
                    conect.Close();
                }                
            }
            catch (Exception q)
            { MessageBox.Show(q.Message.ToString(), "Error Message"); }
        }

        private void LoadZapas()
        {
            try
            {
                if (radioButtonTovar.Checked)
                {
                    if (radioButton4.Checked)
                    {
                        chart.Series.Clear();
                        chart.Series.Add("Остаток на складе");
                        chart.Series.Last().ChartType = SeriesChartType.StackedColumn;
                        chart.Series.Add("Максимальный Объем");
                        chart.Series.Last().ChartType = SeriesChartType.StackedColumn;
                        SqlConnection conect = new SqlConnection(Utils.connectionString);
                        conect.Open();
                        SqlCommand com = new SqlCommand("SELECT        Tovar.Id, Tovar.ArtNumber +' '+ Tovar.Name as Ar, Tovar.Lenght / 1000.0 * Tovar.Widht / 1000.0 * Tovar.Height / 1000.0 * Tovar.Ostatok AS OstS, " +
                                    " Tovar.Ostatok * Tovar.Weight AS OstW, Storage.MaxSize, Storage.MaxWeight, Tovar.Ostatok FROM " + " Tovar INNER JOIN  Storage ON Tovar.Storage = Storage.Id ", conect);
                        SqlDataReader reader = com.ExecuteReader();
                        int i = 0;
                        while (reader.Read())
                        {
                            foreach (Object obj in list.SelectedItems)
                            {
                                if (((Tovar)obj).Name.ToString() == reader[1].ToString())
                                {
                                    float temp = float.Parse(reader[4].ToString()) - float.Parse(reader[2].ToString());

                                    decimal d = Convert.ToDecimal( reader[2]);
                                  
                                    String sum = d > 0 ? d.ToString() : "0";
                                    chart.Series["Остаток на складе"].Points.AddXY(reader[1], sum);
                                    chart.Series["Остаток на складе"].Points[i].Label = sum.ToString();


                                    chart.Series["Максимальный Объем"].Points.AddXY(reader[1], temp);
                                    chart.Series["Максимальный Объем"].Points[i].Label = temp.ToString();
                                    i++;
                                }
                            }
                        }
                        reader.Close();
                        conect.Close();
                    }
                    else if (radioButton5.Checked)
                    {
                        chart.Series.Clear();
                        chart.Series.Add("Остаток на складе");
                        chart.Series.Last().ChartType = SeriesChartType.StackedColumn;
                        chart.Series.Add("Максимальный вес");
                        chart.Series.Last().ChartType = SeriesChartType.StackedColumn;
                        SqlConnection conect = new SqlConnection(Utils.connectionString);
                        conect.Open();
                        SqlCommand com = new SqlCommand("SELECT        Tovar.Id, Tovar.ArtNumber +' '+ Tovar.Name as Ar, Tovar.Lenght / 1000.0 * Tovar.Widht / 1000.0 * Tovar.Height / 1000.0 * Tovar.Ostatok AS OstS, " +
                                    " Tovar.Ostatok * Tovar.Weight AS OstW, Storage.MaxSize, Storage.MaxWeight, Tovar.Ostatok FROM " + " Tovar INNER JOIN  Storage ON Tovar.Storage = Storage.Id ", conect);
                        SqlDataReader reader = com.ExecuteReader();
                        int i = 0;
                        while (reader.Read())
                        {
                            foreach (Object obj in list.SelectedItems)
                            {
                                if (((Tovar)obj).Name.ToString() == reader[1].ToString())
                                {
                                    float temp = float.Parse(reader[5].ToString()) - float.Parse(reader[3].ToString());
                                    decimal d = Convert.ToDecimal(reader[3]);
                                    String sum = d > 0 ? d.ToString() : "0";
                                    chart.Series["Остаток на складе"].Points.AddXY(reader[1], sum);
                                    chart.Series["Остаток на складе"].Points[i].Label = sum;
                                    chart.Series["Максимальный вес"].Points.AddXY(reader[1], temp);
                                    chart.Series["Максимальный вес"].Points[i].Label = temp.ToString();
                                    i++;
                                }
                            }
                        }
                       
                        reader.Close();
                        conect.Close();
                    }
                }                
            }
            catch (Exception q)
            { MessageBox.Show(q.Message.ToString(), "Error Message"); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel5.Width == 173)
            {
                panel5.Width = 0;
            }
            else
            {
                panel5.Width = 173;
            }
        }

        private void bunifuTileButton1_Click_1(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
                LoadOstatkiTov();
            if(radioButton2.Checked)
                LoadIzlishkiTov();
            if(radioButton3.Checked)
                LoadZapas();
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Дата 'С' не должна быть позже второй", "Некорректная дата");
                dateTimePicker1.Value = dateTimePicker1.Value.Date.AddDays(-1);
            }
        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Дата 'По' не должна быть раньше первой", "Некорректная дата");
                dateTimePicker2.Value = dateTimePicker1.Value.Date.AddDays(1);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                groupBox4.Visible = true;
            else groupBox4.Visible = false;
        }

        private void radioButtonTovar_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTovar.Checked)
                list.Visible = true;
            else list.Visible = false;
        }

        

        
    }

    class Tovar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
    }
    
}
