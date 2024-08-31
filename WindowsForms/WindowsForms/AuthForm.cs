using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsForms.models;
using MetroFramework.Forms;
using MetroFramework.Components;

namespace WindowsForms
{
    public partial class AuthForm : MetroForm
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {

        }
        private void Submit()
        {

            SqlConnection conn = new SqlConnection(Utils.connectionString);
            try
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT u.[Id],u.[Login],u.[Name],u.[Surname],r.[id], r.[Name],r.[Description] FROM [User] u " +
                    "LEFT JOIN [UserRole] ur ON u.id = ur.UserId " +
                    "LEFT JOIN [Role] r ON r.id = ur.RoleId " +
                    "WHERE @Login=Login AND @Password=Password"))
                {
                    cmd.Parameters.AddWithValue("@Login", this.login.Text.Trim().ToLower());
                    cmd.Parameters.AddWithValue("@Password", Utils.Encrypt(this.password.Text.Trim().ToLower()));
                    cmd.Connection = conn;

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        r.Read();
                        if (r.HasRows)
                        {
                            User user = new User();
                            Role role = new Role();
                            user.id = (Int32)r[0];
                            user.login = (String)r[1];
                            user.name = (String)r[2];
                            user.surName = (String)r[3];
                            role.id = (Int32)r[4];
                            role.name = (String)r[5];
                            role.description = (String)r[6];
                            user.Role = role;
                            Utils.currentUser = user;
                            MainForm toMain = new MainForm();
                            close = true;
                            toMain.FormClosed += new FormClosedEventHandler(Auth_FormClosed);
                            toMain.Show();
                            this.Hide();
                        }
                        else this.error_auth.Visible = true;
                    }
                }

            }
            catch (Exception )
            {
                this.error_auth.Visible = true;
            }
        }
        private bool close = false;
        
        private void Auth_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            if (close)
            {
                close = false;
                this.Close();
            }
        }

        private void Auth_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Submit();
            }
        }

        private void login_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.password.Focus();
            }
        }

        private void password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Submit();
            }
        }

        private void submit2_Click(object sender, EventArgs e)
        {
            Submit();
        }
    }
}

