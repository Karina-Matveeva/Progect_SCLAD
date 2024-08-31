using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class FormAddAgent : Form
    {
        private FormDirectory formDirectory;

        public FormAddAgent(FormDirectory form)
        {
            formDirectory = form;
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            //Добавление/Редактирование контрагента
            try
            {
                if (Name1.Text.Length > 0)
                {
                    SqlConnection conect = new SqlConnection(Utils.connectionString);
                    conect.Open();
                    string sql = string.Format("Insert Into Supplier " +
                       " ([Name] ,[FullName],[Adress],[Phone],[INN],[KPP] ,[OGRN],[OKPO],[Raschet] ,[Bank]" +
                       ",[AdressBank],[BikBank],[Buhgalter],[Director]) " +
                       " Values (@Name, @FullName, @Adress, @Phone, @INN, @KPP, @OGRN, @OKPO, @Raschet, @Bank, @AdressBank, @BikBank, @Buhgalter, @Director)");

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection = conect;
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@Name", Name1.Text.ToString());
                    cmd.Parameters.AddWithValue("@FullName", FullName.Text.ToString());
                    cmd.Parameters.AddWithValue("@Adress", Adres.Text.ToString());
                    cmd.Parameters.AddWithValue("@Phone", Phone.Text.ToString());
                    cmd.Parameters.AddWithValue("@INN", inn.Text.ToString());
                    cmd.Parameters.AddWithValue("@KPP", kpp.Text.ToString());
                    cmd.Parameters.AddWithValue("@OGRN", ogrn.Text.ToString());
                    cmd.Parameters.AddWithValue("@OKPO", okpo.Text.ToString());
                    cmd.Parameters.AddWithValue("@Raschet", RS.Text.ToString());
                    cmd.Parameters.AddWithValue("@Bank", bank.Text.ToString());
                    cmd.Parameters.AddWithValue("@AdressBank", adresbank.Text.ToString());
                    cmd.Parameters.AddWithValue("@BikBank", bik.Text.ToString());
                    cmd.Parameters.AddWithValue("@Buhgalter", Buhgalter.Text.ToString());
                    cmd.Parameters.AddWithValue("@Director", Diretor.Text.ToString());
                    cmd.ExecuteNonQuery();
                    conect.Close();
                    MessageBox.Show("Данные успешно добавлены!", "Сообщение!");
                    formDirectory.UpdateSupplierTable();
                    this.Close();
                }
                else MessageBox.Show("Введены не все данные, либо длина не соответствует стандарту!", "Внимание");
            }
            catch (Exception q) { MessageBox.Show(q.ToString(), "Ошибка"); }
        }

    }
}
