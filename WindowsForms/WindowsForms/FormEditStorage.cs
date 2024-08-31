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
    public partial class FormEditStorage : Form
    {
        private FormDirectory formDirectory;

        private DataGridViewCellCollection dataGridViewRow;

        public FormEditStorage(FormDirectory form, DataGridViewCellCollection row)
        {
            InitializeComponent();

            formDirectory = form;
            dataGridViewRow = row;

            textBox6.Text = dataGridViewRow[1].Value.ToString();
            textBox5.Text = dataGridViewRow[2].Value.ToString();
            textBox4.Text = dataGridViewRow[3].Value.ToString();
            textBox3.Text = dataGridViewRow[4].Value.ToString();
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
                    string sql = string.Format("Update Storage Set " +
                       " [Name] = @Name," +
                       " [MaxWeight] = @MaxWeight," +
                       " [MaxSize] = @MaxSize," +
                       " [Description] = @Description" +
                       " where [Id] = " + dataGridViewRow[0].Value);

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
                    MessageBox.Show("Данные успешно сохранены!", "Сообщение!");
                    formDirectory.UpdateStorageTable();
                    Close();
                }
                else MessageBox.Show("Введены не все данные, либо длина не соответствует стандарту!", "Внимание");
            }
            catch (Exception q) { MessageBox.Show(q.ToString(), "Ошибка"); }
        }
    }
}
