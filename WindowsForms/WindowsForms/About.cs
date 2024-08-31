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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            LoadCatalog();
        }

        public void LoadCatalog()
        {
            SqlConnection conect = new SqlConnection(Utils.connectionString);
            conect.Open();

            var com2 = new SqlCommand("SELECT * FROM Company", conect);
            var adapter2 = new SqlDataAdapter(com2);
            DataSet ds2 = new DataSet();
            adapter2.Fill(ds2, "Company");
      
            Name1.Text = ds2.Tables[0].Rows[0].Field<string>("Name");
            FullName.Text = ds2.Tables[0].Rows[0].Field<string>("FullName");
            Adres.Text = ds2.Tables[0].Rows[0].Field<string>("Adress").ToString();
            Phone.Text = ds2.Tables[0].Rows[0].Field<string>("Phone").ToString();
            inn.Text = ds2.Tables[0].Rows[0].Field<string>("INN");
            kpp.Text = ds2.Tables[0].Rows[0].Field<string>("KPP");
            ogrn.Text = ds2.Tables[0].Rows[0].Field<string>("OGRN");
            okpo.Text = ds2.Tables[0].Rows[0].Field<string>("OKPO");
            RS.Text = ds2.Tables[0].Rows[0].Field<string>("Raschet").ToString();
            bank.Text = ds2.Tables[0].Rows[0].Field<string>("Bank").ToString();
            adresbank.Text = ds2.Tables[0].Rows[0].Field<string>("AdressBank");
            bik.Text = ds2.Tables[0].Rows[0].Field<string>("BikBank");
            Buhgalter.Text = ds2.Tables[0].Rows[0].Field<string>("Buhgalter");
            Diretor.Text = ds2.Tables[0].Rows[0].Field<string>("Director");
            conect.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                if (Name1.TextLength != 0)
                {
                    SqlConnection conect = new SqlConnection(Utils.connectionString);
                    conect.Open();
                    var com = new SqlCommand("Update Company Set [Name]= '" + (Name1.Text.ToString()) + " ', "
                    + "[FullName]= '" + (FullName.Text.ToString()) + " ', "
                    + "[Adress]= '" + (Adres.Text.ToString()) + "' , "
                    + "[Phone]= '" + (Phone.Text.ToString()) + "' , "
                    + "[INN]= '" + (inn.Text.ToString()) + "' , "
                    + "[KPP]= '" + (kpp.Text.ToString()) + "' , "
                    + "[OGRN]=' " + (ogrn.Text.ToString()) + "' , "
                    + "[OKPO]= '" + (okpo.Text.ToString()) + "' , "
                    + "[Raschet]= '" + (RS.Text.ToString()) + "' , "
                    + "[AdressBank]= '" + (adresbank.Text.ToString()) + "' , "
                    + "[BikBank]= '" + (bik.Text.ToString()) + "' , "
                    + "[Buhgalter]= '" + (Buhgalter.Text.ToString()) + "' , "
                    + "[Director]= '" + (Diretor.Text.ToString()) + "' ", conect);
                    com.ExecuteNonQuery();
                    conect.Close();
                    MessageBox.Show("Данные успешно сохранены!", "Сообщение");
                }
                else MessageBox.Show("Неверно заполнены поля!", "Ошибка");

            }
            catch (Exception q)
            {
                MessageBox.Show(q.ToString(), "Ошибка");
                //MessageBox.Show("Неверно заполнены поля!", "Ошибка");
            }
        }
    }
}
