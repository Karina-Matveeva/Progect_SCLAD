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
    public partial class FormAddStorage : Form
    {
        private FormDirectory formDirectory;

        public FormAddStorage(FormDirectory form)
        {
            InitializeComponent();

            formDirectory = form;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text.Length > 0 && textBox5.Text.Length > 0 && textBox4.Text.Length > 0)
                {
                    SqlConnection conect = new SqlConnection(Utils.connectionString);
                    conect.Open();
                    string sql = string.Format("Insert Into Storage " +
                       " ([Name], [MaxWeight], [MaxSize], [Description]) Values (@Name, @MaxWeight, @MaxSize, @Description)");
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection = conect;
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@Name", textBox6.Text.ToString());
                    cmd.Parameters.AddWithValue("@MaxWeight", float.Parse(textBox5.Text.ToString()));
                    cmd.Parameters.AddWithValue("@MaxSize", float.Parse(textBox4.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Description", textBox3.Text.ToString());
                    cmd.ExecuteNonQuery();
                    conect.Close();
                    MessageBox.Show("Данные успешно добавлены!", "Сообщение!");
                    formDirectory.UpdateStorageTable();
                    Close();
                }
                else MessageBox.Show("Введены не все данные, либо длина не соответствует стандарту!", "Внимание");
            }
            catch (Exception q) { MessageBox.Show(q.ToString(), "Ошибка"); }
        }
    }
}
