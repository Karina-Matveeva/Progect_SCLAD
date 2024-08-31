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
    public partial class OrdersAddForm : Form
    {
        public OrdersAddForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection ConnSQL = new SqlConnection(Utils.connectionString);
            ConnSQL.Open();
            SqlCommand cmdSQL = new SqlCommand();
            cmdSQL.CommandType = CommandType.Text;
            cmdSQL.Connection = ConnSQL;
            string sql = string.Format("Insert Into Orders " +
                                " ([Number], [Date], [F_name], [L_name], [M_name], [Total], [Subtotal], [Currency_code], [Status], [Firma] ,[Email], [Street], [Home], [Apartament], [Zip], [City], [State], [Phone]) " +
                                " Values (@Number, @Date, @F_name, @L_name, @M_name, @Total, @Subtotal, @Currency_code, @Status, @Firma, @Email, @Street, @Home, @Apartament, @Zip, @City, @State, @Phone)");
            cmdSQL.Parameters.Clear();
            cmdSQL.CommandText = sql;
            cmdSQL.Connection = ConnSQL;
            cmdSQL.Parameters.AddWithValue("@Number", "");
            cmdSQL.Parameters.AddWithValue("@Date", DateTime.Parse(dateTimePicker1.Value.ToString()));
            cmdSQL.Parameters.AddWithValue("@F_name", textBox1.Text.ToString());
            cmdSQL.Parameters.AddWithValue("@L_name", textBox2.Text.ToString());
            cmdSQL.Parameters.AddWithValue("@M_name", textBox3.Text.ToString());
            cmdSQL.Parameters.AddWithValue("@Total", 0);
            cmdSQL.Parameters.AddWithValue("@Subtotal", 0);
            cmdSQL.Parameters.AddWithValue("@Currency_code", "Руб");
            cmdSQL.Parameters.AddWithValue("@Status", "Ожидание");
            cmdSQL.Parameters.AddWithValue("@Firma", textBox4.Text.ToString());
            cmdSQL.Parameters.AddWithValue("@Email", textBox5.Text.ToString());
            cmdSQL.Parameters.AddWithValue("@Street", textBox6.Text.ToString());
            cmdSQL.Parameters.AddWithValue("@Home", textBox7.Text.ToString());
            cmdSQL.Parameters.AddWithValue("@Apartament", textBox8.Text.ToString());
            cmdSQL.Parameters.AddWithValue("@Zip", textBox9.Text.ToString());
            cmdSQL.Parameters.AddWithValue("@City", textBox10.Text.ToString());
            cmdSQL.Parameters.AddWithValue("@State", textBox11.Text.ToString());
            cmdSQL.Parameters.AddWithValue("@Phone", textBox12.Text.ToString());
            cmdSQL.ExecuteNonQuery();
            ConnSQL.Close();
            this.Close();
        }
    }
}
