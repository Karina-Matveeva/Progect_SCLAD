using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace WindowsForms
{
    public partial class FormEditCategory : Form
    {
        private FormDirectory formDirectory;

        private DataGridViewCellCollection dataGridViewRow;

        public FormEditCategory(FormDirectory form, DataGridViewCellCollection row)
        {
            InitializeComponent();

            formDirectory = form;
            dataGridViewRow = row;
            textBoxCat.Text = dataGridViewRow[1].Value.ToString();
            textBoxCatDes.Text = dataGridViewRow[2].Value.ToString();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxCat.Text.Length > 0)
                {
                    SqlConnection conect = new SqlConnection(Utils.connectionString);
                    conect.Open();
                    string sql = string.Format("Update Category Set " +
                       " [Name] = @Name," +
                       " [Description] = @Description" +
                       " where [Id] = " + dataGridViewRow[0].Value);

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection = conect;
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@Name", textBoxCat.Text.ToString());
                    cmd.Parameters.AddWithValue("@Description", textBoxCatDes.Text.ToString());
                    cmd.ExecuteNonQuery();
                    conect.Close();
                    MessageBox.Show("Данные успешно сохранены!", "Сообщение!");
                    formDirectory.UpdateCategoryTable();
                    this.Close();
                }
                else MessageBox.Show("Введены не все данные, либо длина не соответствует стандарту!", "Внимание");
            }
            catch (Exception q) { MessageBox.Show(q.ToString(), "Ошибка"); }
        }
    }
}
