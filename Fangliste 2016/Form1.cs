using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Fangliste_2016
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString =
             @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                //string text = "SELECT COUNT(*) FROM Angler";

                string strSQL = "SELECT Id, Name, Bild " +
                                "FROM Angler";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0,-35}{1}", reader["Id"], reader["Name"]);
                    try
                    {

                        byte[] picData = reader["Bild"] as byte[] ?? null;

                        if (picData != null)
                        {
                            using (MemoryStream ms = new MemoryStream(picData))
                            {
                                // Load the image from the memory stream. How you do it depends
                                // on whether you're using Windows Forms or WPF.
                                // For Windows Forms you could write:
                                Bitmap bmp = new System.Drawing.Bitmap(ms);
                                pictureBox1.Image = bmp;
                                MessageBox.Show("Drücken Sie OK um das nächste Bild anzuzeigen.");
                            }
                        }
                        
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert,
                                       System.Drawing.Imaging.ImageFormat formatOfImage)
        {
            byte[] Ret;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception) { throw; }
            return Ret;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString =
                 @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";

                Image imag = Image.FromFile(pictureBox1.ImageLocation);

                try
                {
                    con.Open();
                    SqlCommand insertCommand = new SqlCommand(
                "Insert into Angler (Name, Bild) Values ('" + textBox1.Text + "', @Pic)", con);
                    insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value =
                        ConvertImageToByteArray(imag, ImageFormat.Jpeg);
                    int queryResult = insertCommand.ExecuteNonQuery();
                    if (queryResult == 1)
                        Console.WriteLine("Erfolgreich aktualisiert.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to connect to data source" + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Bitte geben Sie einen Namen ein!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult r = openFileDialog1.ShowDialog();

            if (r == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }
    }
}
