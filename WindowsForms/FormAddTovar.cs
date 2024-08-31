using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class FormAddTovar : Form
    {
        private FormDirectory formDirectory;

        private String filePath = Application.StartupPath.ToString() + "\\not_image.jpg";

        public FormAddTovar(FormDirectory formDirectory)
        {
            InitializeComponent();
            this.formDirectory = formDirectory;
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
                try
                {
                    SqlConnection conect = new SqlConnection(Utils.connectionString);
                    conect.Open();
                    string sql = string.Format("Insert Into Tovar " +
                       " ([ArtNumber], [Name], [IdCategory], [Color], [Lenght], [Widht], [Height], [Weight], " +
                       " [Manufacturer], [MinPrice], [MaxPrice], [Ostatok], [EdIzm],  [Picture], [Garanty], [Storage], [Description]) " +
                    " Values (@ArtNumber, @Name, @IdCategory, @Color, @Lenght, @Widht, " +
                    " @Height, @Weight, @Manufacturer, @MinPrice, @MaxPrice, @Ostatok, " +
                    " @EdIzm,  @Picture, @Garanty, @Storage,  @Description)");
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

                    int catid = Int32.Parse(comboBox1.SelectedValue.ToString());
                    if (catid == 11)
                        catid = 3;
                    if (catid == 12)
                        catid = 4;
                    //InsertMySQLTovar(Decimal.Parse(maskedTextBoxTMax.Text.ToString()), textBoxTName.Text.ToString(), textBoxTColor.Text.ToString(), textBoxTArticle.Text.ToString(), Int32.Parse(numericUpDownTL.Text.ToString()), Int32.Parse(numericUpDownTWight.Text.ToString()), Int32.Parse(numericUpDownTH.Text.ToString()), Int32.Parse(numericUpDownTWeihgt.Text.ToString()), Int32.Parse(numericUpDownTSq.Text.ToString()), catid);

                    MessageBox.Show("Данные успешно добавлены!", "Сообщение!");

                    formDirectory.UpdateTovarTable();
                    Close();
                }
                catch (Exception q)
                {
                    MessageBox.Show("Ошибка введенных данных, либо не заполнены обязательные поля!", "Внимание");
                }
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

        private void FormAddTovar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'warehouseDataSet.Storage' table. You can move, or remove it, as needed.
            this.storageTableAdapter.Fill(this.warehouseDataSet.Storage);
            // TODO: This line of code loads data into the 'warehouseDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.warehouseDataSet.Category);
            // TODO: This line of code loads data into the 'warehouseDataSet.Tovar' table. You can move, or remove it, as needed.
            this.tovarTableAdapter.Fill(this.warehouseDataSet.Tovar);

        }
    }
}
