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
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            LoadUserRole();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'warehouseDataSet.Role' table. You can move, or remove it, as needed.
            this.roleTableAdapter.Fill(this.warehouseDataSet.Role);



            textBox1.Text = "При полном резервном копировании создается резервная копия всей базы данных целиком. В нее входит часть журнала транзакций, что позволяет восстановить полную базу данных из полной резервной копии базы данных. Полные резервные копии базы данных отображают состояние базы данных на момент завершения резервного копирования.";
            LoadUserRole();
            
        }
        private void LoadUserRole()
        {
            try
            {
                SqlConnection conect = new SqlConnection(Utils.connectionString);
                conect.Open();
                                
                var com = new SqlCommand("SELECT        [User].Id, [User].Login, [User].Name, [User].Surname, [User].Patronymic, [User].Dolgnost, [User].Adress, [User].Phone, Role.Name AS Expr1, Role.Description "+
                      " FROM            Role INNER JOIN "+
                        "  UserRole ON Role.Id = UserRole.RoleId INNER JOIN "+
                        "  [User] ON UserRole.UserId = [User].Id", conect);
                var adapter = new SqlDataAdapter(com);
                DataSet ds2 = new DataSet();
                adapter.Fill(ds2, "Пользователи");

                BindingSource bs2 = new BindingSource();
                bs2.DataSource = ds2.Tables[0];
                bindingNavigator2.BindingSource = bs2;
                dataGridView1.DataSource = bs2;
                
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Логин";
                dataGridView1.Columns[2].HeaderText = "Имя";
                dataGridView1.Columns[3].HeaderText = "Фамилия";
                dataGridView1.Columns[4].HeaderText = "Отчество";
                dataGridView1.Columns[5].HeaderText = "Должность";
                dataGridView1.Columns[6].HeaderText = "Адрес";
                dataGridView1.Columns[7].HeaderText = "Телефон";
                dataGridView1.Columns[8].HeaderText = "Роль";
                dataGridView1.Columns[9].HeaderText = "Описание";

                conect.Close();
            }
            catch (Exception q)
            { MessageBox.Show(q.Message.ToString(), "Error Message"); }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            try
            {
                    SqlConnection conect = new SqlConnection(Utils.connectionString);
                    conect.Open();                  

                    SqlCommand cmd = new SqlCommand("WarehouseBackup", conect);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@path";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Value = Application.StartupPath + "\\Warehouse.bak";                   
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    conect.Close();
                    MessageBox.Show("Резервная копия БД успешно создана: "+ Application.StartupPath + "\\Warehouse.bak! ", "Сообщение!");
            }
            catch (Exception q) { MessageBox.Show(q.ToString(), "Ошибка"); }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0)
                {
                    SqlConnection conect = new SqlConnection(Utils.connectionString);
                    conect.Open();
                    string sql = string.Format("Insert Into [Warehouse].[dbo].[User]  " +
                       " ([Login],[Password] ,[Name],[Surname],[Patronymic]  ,[Dolgnost] ,[Adress] ,[Phone]) Values "+
                        " (@Login, @Password,@Name,@Surname,@Patronymic,@Dolgnost,@Adress,@Phone)");
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection = conect;
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@Login", textBox2.Text.ToString());
                    cmd.Parameters.AddWithValue("@Password", Utils.Encrypt(this.textBox3.Text.Trim().ToLower()));
                    cmd.Parameters.AddWithValue("@Name", textBox4.Text.ToString());
                    cmd.Parameters.AddWithValue("@Surname", textBox5.Text.ToString());
                    cmd.Parameters.AddWithValue("@Patronymic", textBox6.Text.ToString());
                    cmd.Parameters.AddWithValue("@Dolgnost", textBox7.Text.ToString());
                    cmd.Parameters.AddWithValue("@Adress", textBox8.Text.ToString());
                    cmd.Parameters.AddWithValue("@Phone", textBox9.Text.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    //получение Id User
                    cmd.CommandText = "SELECT @@IDENTITY";
                    int lastId = Convert.ToInt32(cmd.ExecuteScalar());
                    sql = string.Format("Insert Into [Warehouse].[dbo].[UserRole]  " +
                       " ([UserId],[RoleId] ) Values " +
                        " (@UserId, @RoleId)");
                    cmd.Parameters.Clear();
                    cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection = conect;
                    cmd.Parameters.AddWithValue("@UserId", lastId);
                    cmd.Parameters.AddWithValue("@RoleId", comboBox1.SelectedValue);
                    cmd.ExecuteNonQuery();


                    conect.Close();

                    MessageBox.Show("Данные успешно добавлены!", "Сообщение!");
                    LoadUserRole();

                }
                else MessageBox.Show("Введены не все данные, либо длина не соответствует стандарту!", "Внимание");
            }
            catch (Exception q) { MessageBox.Show(q.ToString(), "Ошибка"); }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить пользователя \"" + dataGridView1[1, dataGridView1.CurrentRow.Index].FormattedValue.ToString() + "\"? ", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SqlConnection conect = new SqlConnection(Utils.connectionString);
                    conect.Open();
                    string sql = string.Format("Delete  from UserRole where UserId = " + dataGridView1.CurrentRow.Cells[0].Value);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection = conect;                    
                    cmd.ExecuteNonQuery();
                    sql = string.Format("Delete  from [Warehouse].[dbo].[User] where Id = " + dataGridView1.CurrentRow.Cells[0].Value);
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = sql;
                    cmd2.Connection = conect;
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Пользователь успешно удален!", "Сообщение!");
                    LoadUserRole();
                }
            }
        }
    }
}
