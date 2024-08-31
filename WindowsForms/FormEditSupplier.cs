using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class FormEditSupplier : Form
    {
        private FormDirectory formDirectory;

        private DataGridViewCellCollection dataGridViewRow;

        public FormEditSupplier(FormDirectory form, DataGridViewCellCollection row)
        {
            InitializeComponent();

            formDirectory = form;
            dataGridViewRow = row;
            Name1.Text = dataGridViewRow[1].Value.ToString();
            this.FullName.Text = dataGridViewRow[2].Value.ToString();
            this.Adres.Text = dataGridViewRow[3].Value.ToString();
            this.Phone.Text = dataGridViewRow[4].Value.ToString();
            this.inn.Text = dataGridViewRow[5].Value.ToString();
            this.kpp.Text = dataGridViewRow[6].Value.ToString();
            this.ogrn.Text = dataGridViewRow[7].Value.ToString();
            this.okpo.Text = dataGridViewRow[8].Value.ToString();
            this.RS.Text = dataGridViewRow[9].Value.ToString();
            this.bank.Text = dataGridViewRow[10].Value.ToString();
            this.adresbank.Text = dataGridViewRow[11].Value.ToString();
            this.bik.Text = dataGridViewRow[12].Value.ToString();
            this.Buhgalter.Text = dataGridViewRow[13].Value.ToString();
            this.Diretor.Text = dataGridViewRow[14].Value.ToString();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                if (Name1.Text.Length > 0)
                {
                    SqlConnection conect = new SqlConnection(Utils.connectionString);
                    conect.Open();
                    string sql = string.Format("Update Supplier Set " +
                       " [Name] = @Name," +
                       " [FullName] = @FullName," +
                       " [Adress] = @Adress," +
                       " [Phone] =  @Phone," +
                       " [INN] = @INN," +
                       " [KPP] = @KPP," +
                       " [OGRN] = @OGRN," +
                       " [OKPO] = @OKPO," +
                       " [Raschet] = @Raschet," +
                       " [Bank] = @Bank," +
                       " [AdressBank] = @AdressBank," +
                       " [BikBank] = @BikBank," +
                       " [Buhgalter] = @Buhgalter," +
                       " [Director] = @Director" +
                       " where [Id] = " + dataGridViewRow[0].Value);

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
                    MessageBox.Show("Данные успешно сохранены!", "Сообщение!");
                    formDirectory.UpdateSupplierTable();
                    this.Close();
                }
                else MessageBox.Show("Введены не все данные, либо длина не соответствует стандарту!", "Внимание");
            }
            catch (Exception q) { MessageBox.Show(q.ToString(), "Ошибка"); }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
