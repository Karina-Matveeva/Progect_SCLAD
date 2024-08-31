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
    public partial class OrdersInvoiceDetailMatForm : Form
    {
        public OrdersInvoiceDetailMatForm(string ArtNumber, int kol)
        {
            InitializeComponent();
            FillDataGridviewMaterialOrders(ArtNumber, kol);
        }

        private void InvoiceDetailMatForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "warehouseDataSet3.Material". При необходимости она может быть перемещена или удалена.
            
            // TODO: данная строка кода позволяет загрузить данные в таблицу "warehouseDataSet3.Supplier". При необходимости она может быть перемещена или удалена.
            this.supplierTableAdapter2.Fill(this.warehouseDataSet3.Supplier);
        
            maskedTextBox2.Text = DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm");
            comboBox4.SelectedIndex = 0;
            textBox2.Text = Utils.currentUser.surName + " " + Utils.currentUser.name;
            dataGridView1.Columns[0].Visible = false;
            loadMyTypeInvoiceCombobox();
            loadMyCombobox();
        }

        private void loadMyCombobox()
        {
            SqlConnection connRC = new SqlConnection(Utils.connectionString);
            string command = "SELECT Id, ArtNumber +' '+ Name  + ' ( ' + EdIzm + ' )' as myName FROM Material";
            SqlDataAdapter da = new SqlDataAdapter(command, connRC);

            DataSet ds = new DataSet();
            connRC.Open();
            da.Fill(ds);
            connRC.Close();

            comboBox2.DataSource = ds.Tables[0];
            comboBox2.DisplayMember = "myName";
            comboBox2.ValueMember = "Id";
            //comboBox2.SelectedValue = "Id";
        }

        private void loadMyTypeInvoiceCombobox()
        {
            SqlConnection connRC = new SqlConnection(Utils.connectionString);
            string command = "SELECT Id, Name FROM TypeInvoice where id = 2";
            SqlDataAdapter da = new SqlDataAdapter(command, connRC);
            DataSet ds = new DataSet();
            connRC.Open();
            da.Fill(ds);
            connRC.Close();
            comboBox3.DataSource = ds.Tables[0];
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";
        }     
        
        private void button1_Click(object sender, EventArgs e)
        {
            new FormDirectory().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FormDirectory().Show();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox3.SelectedValue.ToString() == "1")
                {
                    if (Decimal.Parse(maskedTextBox1.Text.ToString()) != 0)
                    {
                        if (ColumnFind(int.Parse(comboBox2.SelectedValue.ToString())) == false)
                        {
                            var res = float.Parse(maskedTextBox3.Text.ToString()) * float.Parse(maskedTextBox1.Text.ToString());
                            dataGridView1.Rows.Add(comboBox2.SelectedValue, comboBox2.Text.ToString(), float.Parse(maskedTextBox3.Text.ToString()), comboBox4.Text.ToString(), Decimal.Parse(maskedTextBox1.Text.ToString()).ToString(), res);
                            textBox1.Text = SumMoneyGoods().ToString();
                        }
                        else MessageBox.Show("Внимание! Данное сырье уже добавлено в таблицу, для редактирования данных сырья удалите строку и добавьте ее занова!", "Сообщение");
                    }
                    else MessageBox.Show("Внимание! Заполните все поля!", "Сообщение");
                }
                else if (comboBox3.SelectedValue.ToString() == "2" || comboBox3.SelectedValue.ToString() == "5")
                {
                    if (ColumnFind(int.Parse(comboBox2.SelectedValue.ToString())) == false)
                        {
                    SqlConnection conect = new SqlConnection(Utils.connectionString);
                    conect.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conect;
                    //получение остатка сырья 
                    cmd.CommandText = "SELECT Ostatok from Material where id = " + Int32.Parse(comboBox2.SelectedValue.ToString());
                    float Ostatok = float.Parse(cmd.ExecuteScalar().ToString());
                    if (Ostatok >= float.Parse(maskedTextBox3.Text.ToString()))
                    {
                        //расчет цены 
                        cmd.CommandText = "SELECT Price from Material where id = " + Int32.Parse(comboBox2.SelectedValue.ToString());
                        Decimal Price = Decimal.Parse(cmd.ExecuteScalar().ToString());
                        maskedTextBox1.Text = Price.ToString();
                        if (Decimal.Parse(maskedTextBox1.Text.ToString()) != 0)
                        {
                            Decimal res = Decimal.Parse(maskedTextBox3.Text.ToString()) * Decimal.Parse(maskedTextBox1.Text.ToString());
                            dataGridView1.Rows.Add(comboBox2.SelectedValue, comboBox2.Text.ToString(), float.Parse(maskedTextBox3.Text.ToString()), comboBox4.Text.ToString(), Decimal.Parse(maskedTextBox1.Text.ToString()).ToString(), res);
                            textBox1.Text = SumMoneyGoods().ToString();



                        }
                        else MessageBox.Show("Внимание! Заполните все поля!", "Сообщение");
                    }
                    else
                    {
                        MessageBox.Show("Внимание! Введенное количество сырья по расходу превышает количество на складе!", "Сообщение");
                    }
                   
                    cmd.Parameters.Clear();

                    conect.Close();
                        }
                     else MessageBox.Show("Внимание! Данное сырье уже добавлено в таблицу, для редактирования данных сырья удалите строку и добавьте ее занова!", "Сообщение");
                   
                }
            }
            catch (Exception q) { MessageBox.Show("Внимание! Заполните все поля!", "Сообщение"); } 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                textBox1.Text = SumMoneyGoods().ToString();
            }
        }

        public Decimal SumMoneyGoods()
        {
            Decimal Sum = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
                Sum += Decimal.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()) ;
            return Sum;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount != 0)
                {
                    if(comboBox3.SelectedValue.ToString() == "1")
                    {
                        SqlConnection conect = new SqlConnection(Utils.connectionString);
                        conect.Open();
                        //добавление записи в таблицу Накладная
                        string sql = string.Format("Insert Into InvoiceMaterial " +
                                " ([DateCreate], [Type], [NameFrom], [NameTo], [Summa]) " +
                                " Values (@DateCreate, @Type, @NameFrom, @NameTo, @Summa)");
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql;
                        cmd.Connection = conect;
                        cmd.Parameters.AddWithValue("@DateCreate", maskedTextBox2.Text.ToString());
                        cmd.Parameters.AddWithValue("@Type", Int32.Parse(comboBox3.SelectedValue.ToString()));
                        cmd.Parameters.AddWithValue("@NameFrom", Int32.Parse(comboBox1.SelectedValue.ToString()));
                        cmd.Parameters.AddWithValue("@NameTo", textBox2.Text.ToString());
                        cmd.Parameters.AddWithValue("@Summa", Decimal.Parse(textBox1.Text.ToString()));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        //получение Id накладной
                        cmd.CommandText = "SELECT @@IDENTITY";
                        int lastId = Convert.ToInt32(cmd.ExecuteScalar());
                        //добавление записи в таблицу детали Накладной
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            sql = string.Format("Insert Into DetailMatInvoice  " +
                                " ([IdInvoice], [IdMaterial], [Kol], [EdIzm], [Price], [Summa], [Ostatok]) " +
                                " Values (@IdInvoice, @IdMaterial, @Kol, @EdIzm, @Price, @Summa, @Ostatok)");
                            SqlCommand cmd2 = new SqlCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = sql;
                            cmd2.Connection = conect;
                            cmd2.Parameters.AddWithValue("@IdInvoice", lastId);
                            cmd2.Parameters.AddWithValue("@IdMaterial", Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                            cmd2.Parameters.AddWithValue("@Kol", float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                            cmd2.Parameters.AddWithValue("@EdIzm", dataGridView1.Rows[i].Cells[3].Value.ToString());
                            cmd2.Parameters.AddWithValue("@Price", Decimal.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()));
                            cmd2.Parameters.AddWithValue("@Summa", Decimal.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()));
                            //обновление остатка у сырья
                            SqlCommand cmd3 = new SqlCommand();
                            cmd3.CommandType = CommandType.Text;
                            cmd3.Connection = conect;
                            cmd3.CommandText = "Update Material Set [Ostatok]=[Ostatok]+ @kol Where [Id]= @id";
                            cmd3.Parameters.Clear();
                            cmd3.Parameters.AddWithValue("@id", Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                            cmd3.Parameters.AddWithValue("@kol", float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                            cmd3.ExecuteNonQuery();
                            cmd3.Parameters.Clear();
                            //получение остатка сырья , сколько стало на складе
                            cmd3.CommandText = "SELECT Ostatok from Material where id = " + Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                            float Ostatok = float.Parse(cmd3.ExecuteScalar().ToString());
                            //добавляем получившийся остаток в Детали Накладной
                            cmd2.Parameters.AddWithValue("@Ostatok", Ostatok);
                            cmd2.ExecuteNonQuery();
                            cmd2.Parameters.Clear();
                        }
                        conect.Close();
                        MessageBox.Show("Накладная на " + comboBox3.Text.ToString() + " успешно сформирована! \n Номер накладной: " + lastId, "Данные успешно добавлены!");
                        this.Close();
                    }
                    else if (comboBox3.SelectedValue.ToString() == "2" || comboBox3.SelectedValue.ToString() == "5")
                    {
                        //расход сырья , списание на производство либо бракованное сырье 
                        SqlConnection conect = new SqlConnection(Utils.connectionString);
                        conect.Open();
                        //добавление записи в таблицу Накладная
                        string sql = string.Format("Insert Into InvoiceMaterial " +
                                " ([DateCreate], [Type], [NameFrom], [NameTo], [Summa]) " +
                                " Values (@DateCreate, @Type, @NameFrom, @NameTo, @Summa)");
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql;
                        cmd.Connection = conect;
                        cmd.Parameters.AddWithValue("@DateCreate", maskedTextBox2.Text.ToString());
                        cmd.Parameters.AddWithValue("@Type", Int32.Parse(comboBox3.SelectedValue.ToString()));
                        cmd.Parameters.AddWithValue("@NameFrom", Int32.Parse(comboBox1.SelectedValue.ToString()));
                        cmd.Parameters.AddWithValue("@NameTo", textBox2.Text.ToString());
                        cmd.Parameters.AddWithValue("@Summa", Decimal.Parse(textBox1.Text.ToString()));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        //получение Id накладной
                        cmd.CommandText = "SELECT @@IDENTITY";
                        int lastId = Convert.ToInt32(cmd.ExecuteScalar());
                        //добавление записи в таблицу детали Накладной
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            sql = string.Format("Insert Into DetailMatInvoice  " +
                                " ([IdInvoice], [IdMaterial], [Kol], [EdIzm], [Price], [Summa], [Ostatok]) " +
                                " Values (@IdInvoice, @IdMaterial, @Kol, @EdIzm, @Price, @Summa, @Ostatok)");
                            SqlCommand cmd2 = new SqlCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = sql;
                            cmd2.Connection = conect;
                            cmd2.Parameters.AddWithValue("@IdInvoice", lastId);
                            cmd2.Parameters.AddWithValue("@IdMaterial", Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                            cmd2.Parameters.AddWithValue("@Kol", float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                            cmd2.Parameters.AddWithValue("@EdIzm", dataGridView1.Rows[i].Cells[3].Value.ToString());
                            cmd2.Parameters.AddWithValue("@Price", Decimal.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()));
                            cmd2.Parameters.AddWithValue("@Summa", Decimal.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()));
                            //обновление остатка у сырья
                            SqlCommand cmd3 = new SqlCommand();
                            cmd3.CommandType = CommandType.Text;
                            cmd3.Connection = conect;
                            cmd3.CommandText = "Update Material Set [Ostatok]=[Ostatok] - @kol Where [Id]= @id";
                            cmd3.Parameters.Clear();
                            cmd3.Parameters.AddWithValue("@id", Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                            cmd3.Parameters.AddWithValue("@kol", float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                            cmd3.ExecuteNonQuery();
                            cmd3.Parameters.Clear();
                            //получение остатка сырья , сколько стало на складе
                            cmd3.CommandText = "SELECT Ostatok from Material where id = " + Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                            float Ostatok = float.Parse(cmd3.ExecuteScalar().ToString());
                            //добавляем получившийся остаток в Детали Накладной
                            cmd2.Parameters.AddWithValue("@Ostatok", Ostatok);
                            cmd2.ExecuteNonQuery();
                            cmd2.Parameters.Clear();
                        }
                        conect.Close();
                        MessageBox.Show("Накладная на " + comboBox3.Text.ToString() + " успешно сформирована! \n Номер накладной: " + lastId, "Данные успешно добавлены!");
                        this.Close();
                    }
                }
                else MessageBox.Show("Таблица пуста! Заполните форму!", "Внимание");
            }
            catch (Exception q) { MessageBox.Show(q.ToString(), "Ошибка"); }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'warehouseDataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.warehouseDataSet.Supplier);
            loadMyCombobox();
        }

        private void supplierBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private bool ColumnFind(int n)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++ )
            {
                if (int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) == n)
                    return true;
            }
            return false;
        }

        public void FillDataGridviewMaterialOrders(string art, int kol)
        {
            try
            {
                SqlConnection con = new SqlConnection(Utils.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.CommandText = "Select Id From Tovar Where ArtNumber = @art";
                cmd.Parameters.AddWithValue("@art", art);
                int IdTov = int.Parse(cmd.ExecuteScalar().ToString());
                               
                string sql = "SELECT Technology.Id, Technology.IdTovar, Technology.IdMaterial, Material.Name, Technology.Kol, Technology.EdIzm, Material.Price "+
                    " FROM  Material INNER JOIN  Technology ON Material.Id = Technology.IdMaterial "+
                    " WHERE (Technology.IdTovar = " + IdTov + " ) ";
                cmd.CommandText = sql;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    float count = float.Parse(reader[4].ToString()) * kol;
                    var res = count * float.Parse(reader[6].ToString());
                    dataGridView1.Rows.Add(reader[2], reader[3], count, reader[5], reader[6], res);
                    textBox1.Text = SumMoneyGoods().ToString();
                }
                reader.Close();  

                con.Close();
            }
            catch (Exception q) { MessageBox.Show(q.ToString()); }
        }

    }
}
