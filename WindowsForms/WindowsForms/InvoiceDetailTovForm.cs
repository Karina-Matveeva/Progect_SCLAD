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
    public partial class InvoiceDetailTovForm : Form
    {
        public InvoiceDetailTovForm(int invoiceId)
        {
            InitializeComponent();
            //FillDataGridviewMaterialOrders(invoiceId);
        }

        public void FillDataGridviewMaterialOrders(int invoiceId)
        {
            try
            {
                SqlConnection con = new SqlConnection(Utils.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.CommandText = "Select [DetailTovInvoice].Id, tovar.id, [DetailTovInvoice].Id, tovar.Name, [DetailTovInvoice].Kol, [DetailTovInvoice].EdIzm, [DetailTovInvoice].Price  " +
                    " From [DetailTovInvoice] " +
                    " JOIN tovar on tovar.id = [DetailTovInvoice].idTovar Where IdInvoice = @invoiceId ";
                cmd.Parameters.AddWithValue("@invoiceId", Convert.ToString(invoiceId));



                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    i++;
                    float count = float.Parse(reader[4].ToString());
                    var res = count * float.Parse(reader[6].ToString());
                    dataGridView1.Rows.Add(i++, reader[3], count, reader[5], reader[6], res);
                    textBox1.Text = SumMoneyGoods().ToString();
                }
                reader.Close();

                con.Close();
            }
            catch (Exception q) { MessageBox.Show(q.ToString()); }
        }

        private void loadPriceTovar()
        {
            try
            {
                SqlConnection connRC = new SqlConnection(Utils.connectionString);
                connRC.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connRC;
                if(radioButton1.Checked == true)
                    cmd.CommandText = "SELECT MaxPrice from Tovar where id = " + Int32.Parse(comboBox2.SelectedValue.ToString());
                else
                    cmd.CommandText = "SELECT MinPrice from Tovar where id = " + Int32.Parse(comboBox2.SelectedValue.ToString());
                Decimal Ostatok = Decimal.Parse(cmd.ExecuteScalar().ToString());
                maskedTextBox1.Text = Ostatok.ToString();
                connRC.Close();
            }
            catch (Exception q) { MessageBox.Show(q.ToString(), "Сообщение"); } 
        }

        private void loadMyCombobox()
        {
            try
            {
            SqlConnection connRC = new SqlConnection(Utils.connectionString);
            string command = "SELECT Id, ArtNumber +' '+ Name  + ' ( ' + EdIzm + ' )' as myName FROM Tovar";
            SqlDataAdapter da = new SqlDataAdapter(command, connRC);

            DataSet ds = new DataSet();
            connRC.Open();
            da.Fill(ds);
            connRC.Close();

            comboBox2.DataSource = ds.Tables[0];
            comboBox2.DisplayMember = "myName";
            comboBox2.ValueMember = "Id";
             }
            catch (Exception q) { MessageBox.Show(q.ToString(), "Сообщение"); } 
        }

        private void loadMyTypeInvoiceCombobox()
        {
            SqlConnection connRC = new SqlConnection(Utils.connectionString);
            string command = "SELECT Id, Name FROM TypeInvoice where id = 3 or id = 4 or id = 6 ";
            SqlDataAdapter da = new SqlDataAdapter(command, connRC);
            DataSet ds = new DataSet();
            connRC.Open();
            da.Fill(ds);
            connRC.Close();
            comboBox3.DataSource = ds.Tables[0];
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";
        }     

        private void button2_Click(object sender, EventArgs e)
        {
            new FormDirectory().Show();
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
                Sum += Decimal.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
            return Sum;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loadMyCombobox();
        }

        private void InvoiceDetailTovForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'warehouseDataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.warehouseDataSet.Supplier);
            maskedTextBox2.Text = DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm");
            comboBox4.SelectedIndex = 0;
            //textBox3.Text = Utils.currentUser.surName + " " + Utils.currentUser.name;
            dataGridView1.Columns[0].Visible = false;
            loadMyCombobox();
            loadMyTypeInvoiceCombobox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox3.SelectedValue.ToString() == "3")
                {
                    if (Decimal.Parse(maskedTextBox1.Text.ToString()) != 0)
                    {
                        if (ColumnFind(int.Parse(comboBox2.SelectedValue.ToString())) == false)
                        {
                        dataGridView1.Rows.Add(comboBox2.SelectedValue, comboBox2.Text.ToString(), Int32.Parse(numericUpDown1.Text.ToString()), comboBox4.Text.ToString(), Decimal.Parse(maskedTextBox1.Text.ToString()).ToString(), (Int32.Parse(numericUpDown1.Text.ToString()) * Decimal.Parse(maskedTextBox1.Text.ToString())));
                        textBox1.Text = SumMoneyGoods().ToString();
                        }
                        else MessageBox.Show("Внимание! Данное сырье уже добавлено в таблицу, для редактирования данных сырья удалите строку и добавьте ее занова!", "Сообщение");
                    
                    }
                    else MessageBox.Show("Внимание! Заполните все поля!", "Сообщение");
                }
                else if (comboBox3.SelectedValue.ToString() == "4" || comboBox3.SelectedValue.ToString() == "6")
                { 
                    if (ColumnFind(int.Parse(comboBox2.SelectedValue.ToString())) == false)
                        {
                    SqlConnection conect = new SqlConnection(Utils.connectionString);
                    conect.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conect;
                    //получение остатка товара 
                    cmd.CommandText = "SELECT Ostatok from Tovar where id = " + Int32.Parse(comboBox2.SelectedValue.ToString());
                    int Ostatok = Int32.Parse(cmd.ExecuteScalar().ToString());
                    if (Ostatok >= Int32.Parse(numericUpDown1.Text.ToString()))
                    {
                        //рачет цены 
                        ///cmd.CommandText = "SELECT Price from Tovar where id = " + Int32.Parse(comboBox2.SelectedValue.ToString());
                        //Decimal Price = Decimal.Parse(cmd.ExecuteScalar().ToString());
                        //maskedTextBox1.Text = Price.ToString();
                        if (Decimal.Parse(maskedTextBox1.Text.ToString()) != 0)
                        {
                            dataGridView1.Rows.Add(comboBox2.SelectedValue, comboBox2.Text.ToString(), Int32.Parse(numericUpDown1.Text.ToString()), comboBox4.Text.ToString(), Decimal.Parse(maskedTextBox1.Text.ToString()).ToString(), (Int32.Parse(numericUpDown1.Text.ToString()) * Decimal.Parse(maskedTextBox1.Text.ToString())));
                            textBox1.Text = SumMoneyGoods().ToString();



                        }
                        else MessageBox.Show("Внимание! Заполните все поля!", "Сообщение");
                    }
                    else
                    {
                        MessageBox.Show("Внимание! Введенное количество товара по расходу превышает количество на складе!", "Сообщение");
                    }
                   
                    cmd.Parameters.Clear();

                    conect.Close();
                        }
                    else MessageBox.Show("Внимание! Данное сырье уже добавлено в таблицу, для редактирования данных сырья удалите строку и добавьте ее занова!", "Сообщение");
                    
                }
            }
            catch (Exception q) { MessageBox.Show("Внимание! Заполните все поля!", "Сообщение"); } 
        
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                comboBox3.Enabled = true;
            else
                comboBox3.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount != 0)
                {
                    if (comboBox3.SelectedValue.ToString() == "3")
                    {
                        SqlConnection conect = new SqlConnection(Utils.connectionString);
                        conect.Open();
                        //добавление записи в таблицу Накладная
                        string sql = string.Format("Insert Into InvoiceTovar " +
                                " ([DateCreate], [Type], [NameFrom], [Client], [Adress], [Summa], [SupplierId]) " +
                                " Values (@DateCreate, @Type, @NameFrom, @Client, @Adress, @Summa, @SupplierId)");
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql;
                        cmd.Connection = conect;
                        cmd.Parameters.AddWithValue("@DateCreate", maskedTextBox2.Text.ToString());
                        cmd.Parameters.AddWithValue("@Type", Int32.Parse(comboBox3.SelectedValue.ToString()));
                        cmd.Parameters.AddWithValue("@NameFrom", textBox3.Text.ToString());
                        cmd.Parameters.AddWithValue("@Client", textBox2.Text.ToString());
                        cmd.Parameters.AddWithValue("@Adress", textBox4.Text.ToString());
                        cmd.Parameters.AddWithValue("@Summa", Decimal.Parse(textBox1.Text.ToString()));
                        cmd.Parameters.AddWithValue("@SupplierId", Int32.Parse(comboBox1.SelectedValue.ToString()));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        //получение Id накладной
                        cmd.CommandText = "SELECT @@IDENTITY";
                        int lastId = Convert.ToInt32(cmd.ExecuteScalar());
                        //добавление записи в таблицу детали Накладной
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            sql = string.Format("Insert Into DetailTovInvoice  " +
                                " ([IdInvoice], [IdTovar], [Kol], [EdIzm], [Price], [Summa], [Ostatok]) " +
                                " Values (@IdInvoice, @IdTovar, @Kol, @EdIzm, @Price, @Summa, @Ostatok)");
                            SqlCommand cmd2 = new SqlCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = sql;
                            cmd2.Connection = conect;
                            cmd2.Parameters.AddWithValue("@IdInvoice", lastId);
                            cmd2.Parameters.AddWithValue("@IdTovar", Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                            cmd2.Parameters.AddWithValue("@Kol", Int32.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                            cmd2.Parameters.AddWithValue("@EdIzm", dataGridView1.Rows[i].Cells[3].Value.ToString());
                            cmd2.Parameters.AddWithValue("@Price", Decimal.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()));
                            cmd2.Parameters.AddWithValue("@Summa", Decimal.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()));
                            //обновление остатка у товара
                            SqlCommand cmd3 = new SqlCommand();
                            cmd3.CommandType = CommandType.Text;
                            cmd3.Connection = conect;
                            cmd3.CommandText = "Update Tovar Set [Ostatok]=[Ostatok]+ @kol Where [Id]= @id";
                            cmd3.Parameters.Clear();
                            cmd3.Parameters.AddWithValue("@id", Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                            cmd3.Parameters.AddWithValue("@kol", Int32.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                            cmd3.ExecuteNonQuery();
                            cmd3.Parameters.Clear();
                            //получение остатка товара , сколько стало на складе
                            cmd3.CommandText = "SELECT Ostatok from Tovar where id = " + Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                            int Ostatok = Int32.Parse(cmd3.ExecuteScalar().ToString());
                            //добавляем получившийся остаток в Детали Накладной
                            cmd2.Parameters.AddWithValue("@Ostatok", Ostatok);
                            cmd2.ExecuteNonQuery();
                            cmd2.Parameters.Clear();
                        }
                        conect.Close();
                        MessageBox.Show("Накладная на " + comboBox3.Text.ToString() + " успешно сформирована! \n Номер накладной: " + lastId, "Данные успешно добавлены!");
                        this.Close();
                    }
                    else if (comboBox3.SelectedValue.ToString() == "4" || comboBox3.SelectedValue.ToString() == "6")
                    {
                        //расход товара , списание на производство либо бракованное сырье 
                        SqlConnection conect = new SqlConnection(Utils.connectionString);
                        conect.Open();
                        //добавление записи в таблицу Накладная
                        string sql = string.Format("Insert Into InvoiceTovar " +
                                " ([DateCreate], [Type], [NameFrom], [Client], [Adress], [Summa], [SupplierId]) " +
                                " Values (@DateCreate, @Type, @NameFrom, @Client, @Adress, @Summa, @SupplierId)");
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql;
                        cmd.Connection = conect;
                        cmd.Parameters.AddWithValue("@DateCreate", maskedTextBox2.Text.ToString());
                        cmd.Parameters.AddWithValue("@Type", Int32.Parse(comboBox3.SelectedValue.ToString()));
                        cmd.Parameters.AddWithValue("@NameFrom", textBox3.Text.ToString());
                        cmd.Parameters.AddWithValue("@Client", textBox2.Text.ToString());
                        cmd.Parameters.AddWithValue("@Adress", textBox4.Text.ToString());
                        cmd.Parameters.AddWithValue("@Summa", Decimal.Parse(textBox1.Text.ToString()));
                        cmd.Parameters.AddWithValue("@SupplierId", Int32.Parse(comboBox1.SelectedValue.ToString()));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        //получение Id накладной
                        cmd.CommandText = "SELECT @@IDENTITY";
                        int lastId = Convert.ToInt32(cmd.ExecuteScalar());
                        //добавление записи в таблицу детали Накладной
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            sql = string.Format("Insert Into DetailTovInvoice  " +
                                " ([IdInvoice], [IdTovar], [Kol], [EdIzm], [Price], [Summa], [Ostatok]) " +
                                " Values (@IdInvoice, @IdTovar, @Kol, @EdIzm, @Price, @Summa, @Ostatok)");
                            SqlCommand cmd2 = new SqlCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = sql;
                            cmd2.Connection = conect;
                            cmd2.Parameters.AddWithValue("@IdInvoice", lastId);
                            cmd2.Parameters.AddWithValue("@IdTovar", Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                            cmd2.Parameters.AddWithValue("@Kol", Int32.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                            cmd2.Parameters.AddWithValue("@EdIzm", dataGridView1.Rows[i].Cells[3].Value.ToString());
                            cmd2.Parameters.AddWithValue("@Price", Decimal.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()));
                            cmd2.Parameters.AddWithValue("@Summa", Decimal.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()));
                            //обновление остатка у товара
                            SqlCommand cmd3 = new SqlCommand();
                            cmd3.CommandType = CommandType.Text;
                            cmd3.Connection = conect;
                            cmd3.CommandText = "Update Tovar Set [Ostatok]=[Ostatok] - @kol Where [Id]= @id";
                            cmd3.Parameters.Clear();
                            cmd3.Parameters.AddWithValue("@id", Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                            cmd3.Parameters.AddWithValue("@kol", Int32.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                            cmd3.ExecuteNonQuery();
                            cmd3.Parameters.Clear();
                            //получение остатка товара , сколько стало на складе
                            cmd3.CommandText = "SELECT Ostatok from Tovar where id = " + Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                            int Ostatok = Int32.Parse(cmd3.ExecuteScalar().ToString());
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

        private bool ColumnFind(int n)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) == n)
                    return true;
            }
            return false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPriceTovar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
