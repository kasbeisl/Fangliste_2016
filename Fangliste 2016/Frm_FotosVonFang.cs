using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FanglisteLibrary;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace Fangliste_2016
{
    public partial class Frm_FotosVonFang : Form
    {
        #region Variablen

        int foto_jetzt = 0;
        List<Foto1> fotoliste;
        List<Fangliste1> fangliste;
        int fang_ID;
        int position;

        #endregion

        #region Konstruktor

        public Frm_FotosVonFang(int fang_ID)
        {
            InitializeComponent();

            this.fang_ID = fang_ID;
            fotoliste = new List<Foto1>();
            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                //string text = "SELECT COUNT(*) FROM Angler";

                string strSQL = "SELECT * " +
                                "FROM Foto WHERE Fang_ID = '" + fang_ID + "'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine("{0,-35}{1}", reader["Id"], reader["Name"]);
                    try
                    {

                        byte[] picData = reader["Bild"] as byte[] ?? null;
                        Bitmap bmp = null;

                        if (picData != null)
                        {
                            using (MemoryStream ms = new MemoryStream(picData))
                            {
                                // Load the image from the memory stream. How you do it depends
                                // on whether you're using Windows Forms or WPF.
                                // For Windows Forms you could write:
                                bmp = new System.Drawing.Bitmap(ms);
                                //AddImageToImageList(imageList_Fischer, bmp, "", imageList_Fischer.ImageSize.Width, imageList_Fischer.ImageSize.Height);
                                //MessageBox.Show("Drücken Sie OK um das nächste Bild anzuzeigen.");
                            }
                        }
                        else
                        {
                            if (File.Exists(Properties.Settings.Default.Data + "\\" + "error.png"))
                            {
                                //this.imageList_Fischer.Images.Add(Image.FromFile(Properties.Settings.Default.Data + "\\" + "error.png"));
                                bmp = new Bitmap(Properties.Settings.Default.Data + "\\" + "error.png");
                                //imageList_Fischer.Images.Add(b);
                                //AddImageToImageList(imageList_Fischer, bmp, "", imageList_Fischer.ImageSize.Width, imageList_Fischer.ImageSize.Height);
                            }
                        }

                        fotoliste.Add(new Foto1(Convert.ToInt16(reader["Id"]), Convert.ToInt16(reader["Angler_ID"]), Convert.ToInt16(reader["Fang_ID"]), Convert.ToInt16(reader["Ordner_ID"]), reader["Kommentar"].ToString(), bmp));
                        //listView_Fischer.Items.Add(anglerliste[count].Name, count);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Fehler");
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

            

            //pictureBox1.ImageLocation = Frm_Hauptmenu.FotoOrdner + "\\" + this.fotos[foto_jetzt];
        }

        private void Frm_FotosVonFang_Load(object sender, EventArgs e)
        {
            if (fotoliste == null || fotoliste.Count == 0)
                this.Close();

            try
            {
                pictureBox1.Image = fotoliste[foto_jetzt].Bild;
            }
            catch { }

            position = foto_jetzt + 1;
            //this.Text = "Gefangen von " + fangliste[fang_ID].Name + " am " + fangliste[fang_ID].Datum.ToShortDateString() + " um " + fangliste[fang_ID].Uhrzeit.ToShortTimeString() + " (Gewicht: " + fangliste[fang_ID].Gewicht + "kg, Größe: " + fangliste[fang_ID].Größe + "cm, Gewässer: " + fangliste[fang_ID].Gewässer + ") " + position + " von " + alleFotos.Count;

            button_back.Enabled = false;

            if (fotoliste != null)
            {
                if (fotoliste.Count == 1)
                {
                    button_vor.Enabled = false;
                }
            }
            else
            {
                button_vor.Enabled = false;
            }
        }

        #endregion

        #region Button

        private void button_vor_Click(object sender, EventArgs e)
        {
            int zahl;
            if (foto_jetzt < fotoliste.Count - 1)
            {
                zahl = foto_jetzt + 1;
                button_back.Enabled = true;
            }
            else
            {
                zahl = foto_jetzt;
            }
            if (zahl == fotoliste.Count - 1)
            {
                button_vor.Enabled = false;
            }

            foto_jetzt = zahl;
            pictureBox1.Image = this.fotoliste[foto_jetzt].Bild;

            position = foto_jetzt + 1;
            //this.Text = "Gefangen von " + fangliste[fang_ID].Name + " am " + fangliste[fang_ID].Datum.ToShortDateString() + " um " + fangliste[fang_ID].Uhrzeit.ToShortTimeString() + " (Gewicht: " + fangliste[fang_ID].Gewicht + "kg, Größe: " + fangliste[fang_ID].Größe + "cm, Gewässer: " + fangliste[fang_ID].Gewässer + ") " + position + " von " + fotoliste.Count;

        }

        private void button_back_Click(object sender, EventArgs e)
        {
            int zahl;
            if (foto_jetzt > 0)
            {
                zahl = foto_jetzt - 1;
                button_vor.Enabled = true;
            }
            else
            {
                zahl = foto_jetzt;
            }
            if (zahl == 0)
            {
                button_back.Enabled = false;
            }

            foto_jetzt = zahl;
            pictureBox1.Image = this.fotoliste[foto_jetzt].Bild;

            position = foto_jetzt + 1;
            //this.Text = "Gefangen von " + fangliste[fang_ID].Name + " am " + fangliste[fang_ID].Datum.ToShortDateString() + " um " + fangliste[fang_ID].Uhrzeit.ToShortTimeString() + " (Gewicht: " + fangliste[fang_ID].Gewicht + "kg, Größe: " + fangliste[fang_ID].Größe + "cm, Gewässer: " + fangliste[fang_ID].Gewässer + ") " + position + " von " + fotoliste.Count;
        }


        #endregion

        #region Methoden

        #endregion
    }
}
