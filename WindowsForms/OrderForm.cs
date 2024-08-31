using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;


namespace WindowsForms
{
    public partial class OrderForm : Form
    {
        enum State { EqPage, DetPage };
        State state;
        List<Status> ListStatus = new List<Status>();

        class Status
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public OrderForm()
        {
            this.state = State.EqPage;
            InitializeComponent();
            FillOrdersGrid();
            LoadComboboxStatus();

            dataGridView1.Columns[0].HeaderText = "Номер заказа";
            dataGridView1.Columns[1].HeaderText = "Номер заказа";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Дата";
            dataGridView1.Columns[3].HeaderText = "Фамилия";
            dataGridView1.Columns[4].HeaderText = "Имя";
            dataGridView1.Columns[5].HeaderText = "Отчество";
            dataGridView1.Columns[6].HeaderText = "Сумма с доставкой";
            dataGridView1.Columns[7].HeaderText = "Сумма без доставки";
            dataGridView1.Columns[8].HeaderText = "Валюта";
            dataGridView1.Columns[9].HeaderText = "Статус";
            dataGridView1.Columns[10].HeaderText = "Фирма";
            dataGridView1.Columns[11].HeaderText = "Почта";
            dataGridView1.Columns[12].HeaderText = "Улица";
            dataGridView1.Columns[13].HeaderText = "Дом";
            dataGridView1.Columns[14].HeaderText = "Кв";
            dataGridView1.Columns[15].HeaderText = "";
            dataGridView1.Columns[16].HeaderText = "Город";
            dataGridView1.Columns[17].HeaderText = "Область";
            dataGridView1.Columns[18].HeaderText = "телефон";
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].Visible = false;
        }

        private void LoadComboboxStatus()
        {
            try
            {
                /*MySqlConnection connRC = new MySqlConnection(Utils.MySqlconnectionString);
                connRC.Open();
                MySqlCommand com = new MySqlCommand("SELECT `status_id`, `name_ru-RU` FROM `vtgad_jshopping_order_status`", connRC);
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    ListStatus.Add(new Status { Id = int.Parse(reader[0].ToString()), Name = reader[1].ToString() });
                }
                reader.Close();
                connRC.Close();
                comboBox1.DataSource = ListStatus;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";*/
            }
            catch (Exception q) { MessageBox.Show(q.ToString(), "Сообщение"); }
        }

        public void FillOrdersGrid()
        {
            /*try
            {
                MySqlConnection Conn = new MySqlConnection(Utils.MySqlconnectionString);
                MySqlConnection Conn2 = new MySqlConnection(Utils.MySqlconnectionString);
                SqlConnection ConnSQL = new SqlConnection(Utils.connectionString);
                Conn.Open(); Conn2.Open();
                ConnSQL.Open();
                DataSet dataset = new DataSet();
                if (Conn.State.ToString() == "Open")
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = Conn;
                    cmd.CommandText = "SELECT `order_id`, `order_number`, `order_date`, `d_f_name` , `d_l_name`, `d_m_name`,  `order_total`, " +
                        "`order_subtotal`, `currency_code`, `vtgad_jshopping_order_status`.`name_ru-RU`, " +
                        "   `d_firma_name`, `d_email`, " +
                        "`d_street`, `d_home`, `d_apartment`, `d_zip`, `d_city`, `d_state`, `d_phone` " +
                        "FROM `vtgad_jshopping_orders` join `vtgad_jshopping_order_status` on `vtgad_jshopping_orders`.`order_status` = `vtgad_jshopping_order_status`.`status_id` where user_id != -1";

                    SqlCommand cmdSQL = new SqlCommand();
                    cmdSQL.CommandType = CommandType.Text;
                    cmdSQL.Connection = ConnSQL;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmdSQL.CommandText = "SELECT Number from Orders where Number = '" + reader[1].ToString() + "'";
                        var n = cmdSQL.ExecuteScalar();
                        if (n == null)
                        {
                            string sql = string.Format("Insert Into Orders " +
                                " ([Number], [Date], [F_name], [L_name], [M_name], [Total], [Subtotal], [Currency_code], [Status], [Firma] ,[Email], [Street], [Home], [Apartament], [Zip], [City], [State], [Phone]) " +
                                " Values (@Number, @Date, @F_name, @L_name, @M_name, @Total, @Subtotal, @Currency_code, @Status, @Firma, @Email, @Street, @Home, @Apartament, @Zip, @City, @State, @Phone)");
                            cmdSQL.Parameters.Clear();
                            cmdSQL.CommandText = sql;
                            cmdSQL.Connection = ConnSQL;
                            cmdSQL.Parameters.AddWithValue("@Number", reader[1].ToString());
                            cmdSQL.Parameters.AddWithValue("@Date", DateTime.Parse(reader[2].ToString()));
                            cmdSQL.Parameters.AddWithValue("@F_name", reader[3].ToString());
                            cmdSQL.Parameters.AddWithValue("@L_name", reader[4].ToString());
                            cmdSQL.Parameters.AddWithValue("@M_name", reader[5].ToString());
                            cmdSQL.Parameters.AddWithValue("@Total", Decimal.Parse(reader[6].ToString()));
                            cmdSQL.Parameters.AddWithValue("@Subtotal", Decimal.Parse(reader[7].ToString()));
                            cmdSQL.Parameters.AddWithValue("@Currency_code", reader[8].ToString());
                            cmdSQL.Parameters.AddWithValue("@Status", reader[9].ToString());
                            cmdSQL.Parameters.AddWithValue("@Firma", reader[10].ToString());
                            cmdSQL.Parameters.AddWithValue("@Email", reader[11].ToString());
                            cmdSQL.Parameters.AddWithValue("@Street", reader[12].ToString());
                            cmdSQL.Parameters.AddWithValue("@Home", reader[13].ToString());
                            cmdSQL.Parameters.AddWithValue("@Apartament", reader[14].ToString());
                            cmdSQL.Parameters.AddWithValue("@Zip", reader[15].ToString());
                            cmdSQL.Parameters.AddWithValue("@City", reader[16].ToString());
                            cmdSQL.Parameters.AddWithValue("@State", reader[17].ToString());
                            cmdSQL.Parameters.AddWithValue("@Phone", reader[18].ToString());
                            cmdSQL.ExecuteNonQuery();
                            cmdSQL.Parameters.Clear();

                            SqlCommand cmdSQL_ID = new SqlCommand();
                            cmdSQL_ID.CommandType = CommandType.Text;
                            cmdSQL_ID.Connection = ConnSQL;
                            cmdSQL_ID.CommandText = "SELECT @@IDENTITY";
                            int insertedID = Convert.ToInt32(cmdSQL_ID.ExecuteScalar());

                            MySqlCommand cmd1 = new MySqlCommand();
                            cmd1.Connection = Conn2;
                            cmd1.CommandText = "SELECT `order_item_id`, `order_id`, `product_id`, `product_ean`, `product_name`, `product_quantity`, `product_item_price` FROM `vtgad_jshopping_order_item` WHERE `order_id` = " + reader[0].ToString();
                            MySqlDataReader readerOrderTov = cmd1.ExecuteReader();
                            while (readerOrderTov.Read())
                            {
                                sql = string.Format("Insert Into OrdersTovar " +
                                " ([IdOrders], [TovarArtNumber], [Name], [Quantity], [Price]) " +
                                " Values (@IdOrders, @TovarArtNumber, @Name, @Quantity, @Price)");
                                cmdSQL.Parameters.Clear();
                                cmdSQL.CommandText = sql;
                                cmdSQL.Connection = ConnSQL;
                                cmdSQL.Parameters.AddWithValue("@IdOrders", insertedID);
                                cmdSQL.Parameters.AddWithValue("@TovarArtNumber", readerOrderTov[3].ToString());
                                cmdSQL.Parameters.AddWithValue("@Name", readerOrderTov[4].ToString());
                                cmdSQL.Parameters.AddWithValue("@Quantity", Decimal.ToInt32(Decimal.Parse(readerOrderTov[5].ToString())));
                                cmdSQL.Parameters.AddWithValue("@Price", Decimal.Parse(readerOrderTov[6].ToString()));
                                cmdSQL.ExecuteNonQuery();
                                cmdSQL.Parameters.Clear();
                            }
                            readerOrderTov.Close();
                        }
                    }
                    reader.Close();
                }
                Conn.Close();
                Conn2.Close();
                ConnSQL.Close();
            }

            catch (Exception q) { MessageBox.Show(q.ToString(), "Ошибка"); }*/
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                this.state = State.EqPage;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                this.state = State.DetPage;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Visible = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    MySqlConnection Conn = new MySqlConnection(Utils.MySqlconnectionString);
                    Conn.Open();
                    if (Conn.State.ToString() == "Open")
                    {
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = Conn;
                        cmd.CommandText = "UPDATE `vtgad_jshopping_orders` SET `order_status`= " + comboBox1.SelectedValue.ToString() + " WHERE `order_number`= " + dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        cmd.ExecuteNonQuery();
                    }
                    Conn.Close();
                }
                FillOrdersGrid();
                MessageBox.Show("Статус успешно изменен!", "Сообщение");
            }
            catch (Exception q) { MessageBox.Show(q.ToString(), "Ошибка"); }*/
        }

       

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.ordersTovarTableAdapter.Fill(this.warehouseDataSet.OrdersTovar);
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "warehouseDataSet.Tovar". При необходимости она может быть перемещена или удалена.
            this.tovarTableAdapter.Fill(this.warehouseDataSet.Tovar);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "warehouseDataSet.OrdersTovar". При необходимости она может быть перемещена или удалена.
            this.ordersTovarTableAdapter.Fill(this.warehouseDataSet.OrdersTovar);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "warehouseDataSet.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.warehouseDataSet.Orders);

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            OrdersAddForm addF = new OrdersAddForm();
            addF.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (state == State.EqPage)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var result = MessageBox.Show("Вы действительно хотите удалить заказ \"" + dataGridView1[0, dataGridView1.CurrentRow.Index].FormattedValue.ToString() + "\"? ", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                        this.ordersTableAdapter.Update(this.warehouseDataSet.Orders);
                    }
                }
            }
            else if (state == State.DetPage)
            {
                if (dataGridView2.CurrentRow != null)
                {
                    var result = MessageBox.Show("Вы действительно хотите удалить товар ? ", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                        this.ordersTovarTableAdapter.Update(this.warehouseDataSet.OrdersTovar);
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                MinPrice();
            else MaxPrice();
        }

        public void MinPrice()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(Utils.connectionString);
                Conn.Open();
                SqlCommand cmdSQL = new SqlCommand();
                cmdSQL.CommandType = CommandType.Text;
                cmdSQL.Connection = Conn;
                cmdSQL.CommandText = "Select MinPrice from Tovar Where Id = " + comboBox2.SelectedValue;
                textBox1.Text = cmdSQL.ExecuteScalar().ToString();
                Conn.Close();
            }
            catch { }
        }

        public void MaxPrice()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(Utils.connectionString);
                Conn.Open();
                SqlCommand cmdSQL = new SqlCommand();
                cmdSQL.CommandType = CommandType.Text;
                cmdSQL.Connection = Conn;
                cmdSQL.CommandText = "Select MaxPrice from Tovar Where Id = " + comboBox2.SelectedValue;
                textBox1.Text = cmdSQL.ExecuteScalar().ToString();
                Conn.Close();
            }
            catch { }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                MinPrice();
            else MaxPrice();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                MinPrice();
            else MaxPrice();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(Utils.connectionString);
                Conn.Open();
                SqlCommand cmdSQL = new SqlCommand();
                cmdSQL.CommandType = CommandType.Text;
                cmdSQL.Connection = Conn;
                cmdSQL.CommandText = "Select ArtNumber from Tovar Where Id = " + comboBox2.SelectedValue;
                string art = cmdSQL.ExecuteScalar().ToString();

                this.ordersTovarTableAdapter.Insert(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), art, comboBox2.Text, (int)numericUpDown1.Value, decimal.Parse(textBox1.Text.ToString()));
                this.ordersTovarTableAdapter.Update(this.warehouseDataSet.OrdersTovar);
                this.ordersTovarTableAdapter.Fill(this.warehouseDataSet.OrdersTovar);

                string sql = "Update Orders Set Total = @T, Subtotal = @s Where Id = " + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                SqlCommand cmd2 = new SqlCommand(sql, Conn);
                cmd2.Parameters.AddWithValue("@S", SumMoneyGoods());
                cmd2.Parameters.AddWithValue("@T", SumMoneyGoods() + decimal.Parse(textBox2.Text.ToString()));
                cmd2.ExecuteNonQuery();
                this.ordersTableAdapter.Update(this.warehouseDataSet.Orders);
                this.ordersTableAdapter.Fill(this.warehouseDataSet.Orders);
                Conn.Close();
            }
            catch (Exception q) { MessageBox.Show(q.ToString()); }
        }

        public Decimal SumMoneyGoods()
        {
            Decimal Sum = 0;
            for (int i = 0; i < dataGridView2.RowCount; i++)
                Sum += Decimal.Parse(dataGridView2.Rows[i].Cells[4].Value.ToString()) * Decimal.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString());
            return Sum;
        }
    }
}
