using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Xml.Linq;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;

namespace WindowsForms
{
    public partial class FormEditTovar : Form
    {
        private FormDirectory formDirectory;

        private DataGridViewCellCollection dataGridViewRow;

        private String filePath = Application.StartupPath.ToString() + "\\not_image.jpg";

        public FormEditTovar(FormDirectory form, DataGridViewCellCollection row)
        {
            InitializeComponent();

            formDirectory = form;
            dataGridViewRow = row;

            textBoxTArticle.Text = dataGridViewRow[1].Value.ToString();
            textBoxTName.Text = dataGridViewRow[2].Value.ToString();
            comboBox1.SelectedValue = dataGridViewRow[3].Value.ToString();
            textBoxTColor.Text = dataGridViewRow[4].Value.ToString();
            numericUpDownTL.Text = dataGridViewRow[5].Value.ToString();
            numericUpDownTWight.Text = dataGridViewRow[6].Value.ToString();
            numericUpDownTH.Text = dataGridViewRow[7].Value.ToString();
            numericUpDownTWeihgt.Text = dataGridViewRow[8].Value.ToString();
            textBoxManufactur.Text = dataGridViewRow[9].Value.ToString();
            maskedTextBoxTMin.Text = dataGridViewRow[10].Value.ToString();
            maskedTextBoxTMax.Text = dataGridViewRow[11].Value.ToString();
            numericUpDownTOst.Text = dataGridViewRow[12].Value.ToString();
            comboBox2.SelectedItem = dataGridViewRow[13].Value.ToString();

            numericGaranty.Text= dataGridViewRow[15].Value.ToString();
            comboBox3.SelectedValue = dataGridViewRow[16].Value.ToString();
            textBoxTdes.Text = dataGridViewRow[17].Value.ToString();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxTName.Text.Length > 0)
                {
                    SqlConnection conect = new SqlConnection(Utils.connectionString);
                    conect.Open();
                    string sql = string.Format("Update Tovar Set" +
                       " [ArtNumber] = @ArtNumber," +
                       " [Name] = @Name, " +
                       "[IdCategory] = @IdCategory," +
                       "[Color] = @Color," +
                       "[Lenght] = @Lenght," +
                       " [Widht] = @Widht," +
                       " [Height] = @Height," +
                       " [Weight] = @Weight," +
                       " [Manufacturer] = @Manufacturer," +
                       " [MinPrice] = @MinPrice," +
                       " [MaxPrice] = @MaxPrice," +
                       " [Ostatok] = @Ostatok," +
                       " [EdIzm] = @EdIzm," +
                       " [Picture] = @Picture," +
                       " [Garanty] = @Garanty," +
                       " [Storage] = @Storage," +
                       " [Description] = @Description " +
                       " where [Id] = " + dataGridViewRow[0].Value);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection = conect;
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@ArtNumber", textBoxTArticle.Text.ToString());
                    cmd.Parameters.AddWithValue("@Name", textBoxTName.Text.ToString());
                    cmd.Parameters.AddWithValue("@IdCategory", Int32.Parse(comboBox1.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("@Color", textBoxTColor.Text.ToString());
                    cmd.Parameters.AddWithValue("@Lenght", Int32.Parse(numericUpDownTL.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Widht", Int32.Parse(numericUpDownTWight.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Height", Int32.Parse(numericUpDownTH.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Weight", Int32.Parse(numericUpDownTWeihgt.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Manufacturer", textBoxManufactur.Text.ToString());
                    cmd.Parameters.AddWithValue("@MinPrice", Decimal.Parse(maskedTextBoxTMin.Text.ToString()));
                    cmd.Parameters.AddWithValue("@MaxPrice", Decimal.Parse(maskedTextBoxTMax.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Ostatok", Int32.Parse(numericUpDownTOst.Text.ToString()));
                    cmd.Parameters.AddWithValue("@EdIzm", comboBox2.SelectedItem.ToString());
                    //  cmd.Parameters.Add("@Picture", SqlDbType.Image, 0, "Picture").Value = null;


                    byte[] picture = GetPhoto(filePath);

                    cmd.Parameters.Add("@Picture", SqlDbType.Image, picture.Length).Value = picture;
                    cmd.Parameters.AddWithValue("@Garanty", Int32.Parse(numericGaranty.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Storage", Int32.Parse(comboBox3.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("@Description", textBoxTdes.Text.ToString());
                    cmd.ExecuteNonQuery();
                    conect.Close();
                    MessageBox.Show("Данные успешно сохранены!", "Сообщение!");
                    formDirectory.UpdateTovarTable();
                    this.Close();
                }
                else MessageBox.Show("Введены не все данные, либо длина не соответствует стандарту!", "Внимание");
            }
            catch (Exception q) { MessageBox.Show(q.ToString(), "Ошибка"); }
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormEditTovar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'warehouseDataSet.Storage' table. You can move, or remove it, as needed.
            this.storageTableAdapter.Fill(this.warehouseDataSet.Storage);
            // TODO: This line of code loads data into the 'warehouseDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.warehouseDataSet.Category);

        }

        public static byte[] GetPhoto(string filePath)
        {
            FileStream stream = new FileStream(
                filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }

        private void uploadImage(String lastId)
        {
            String nameFile = "generateImage_" + lastId + ".jpg";
            String localName = filePath;

            String uploadUrl = "ftp://typedef.beget.tech";
            String Filename = "incom/public_html/components/com_jshopping/files/img_products/" + nameFile;

            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential("typedef_admin", "I*c!b64b");
                client.UploadFile(uploadUrl + @"/" + Filename, localName);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
               "All files (*.*)|*.*";

            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "My Image Browser";
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        filePath = file;
                        PictureBox pb = new PictureBox();
                        Image loadedImage = Image.FromFile(file);
                        pb.Height = loadedImage.Height;
                        pb.Width = loadedImage.Width;
                        pb.Image = loadedImage;
                        flowLayoutPanel1.Controls.Add(pb);
                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                        "Error message: " + ex.Message + "\n\n" +
                        "Details (send to Support):\n\n" + ex.StackTrace
                    );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                    }
                }
            }
        }
    }
}
