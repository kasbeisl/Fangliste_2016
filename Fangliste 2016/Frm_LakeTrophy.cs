using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FanglisteLibrary;
using System.Media;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.IO;

namespace Fangliste_2016
{
    public partial class Frm_LakeTrophy : Form
    {
        #region Variablen

        List<Angler1> anglerliste;
        List<TrophyTeilnehmer> liste;
        SoundPlayer simpleSound_LakeTrophy;

        int ausgewähltesJahr;

        #endregion

        #region Konstruktor

        public Frm_LakeTrophy()
        {
            InitializeComponent();

            simpleSound_LakeTrophy = new SoundPlayer(Properties.Settings.Default.Data + "\\" + Properties.Settings.Default.TrophySound);
        }

        private void Frm_LakeTrophy_Load(object sender, EventArgs e)
        {
            ausgewähltesJahr = Jahre();
            GetAnglerliste();
            Datenauswerten();

            try
            {
                if (Properties.Settings.Default.PlaySound == true)
                    simpleSound_LakeTrophy.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fehler");
            }
        }

        #endregion

        #region Methoden

        private int Jahre()
        {
            int jahr_von_letzten_Fang = 0;
            List<int> jahre = new List<int>();

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT Datum FROM Fang";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    try
                    {
                        DateTime dt = Convert.ToDateTime(reader["Datum"]);
                        if (!jahre.Contains(dt.Year))
                            jahre.Add(dt.Year);
                    }
                    catch
                    {
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            cb_Jahre.Items.Clear();

            for (int i = 0; i < jahre.Count; i++)
            {
                cb_Jahre.Items.Add(jahre[i]);
            }

            for (int i = 0; i < jahre.Count; i++)
            {
                if (Convert.ToInt32(jahre[i]) > jahr_von_letzten_Fang)
                {
                    jahr_von_letzten_Fang = Convert.ToInt32(jahre[i]);
                }
            }

            return jahr_von_letzten_Fang;
        }

        private void Datenauswerten()
        {
            cb_Jahre.Text = ausgewähltesJahr.ToString();
            Label_Titel.Text = "Lake Trophy " + ausgewähltesJahr.ToString();

            liste = new List<TrophyTeilnehmer>();

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                //"SELECT (Angler.Bild), SUM(Fang.Gewicht) AS Gewicht, Angler.Name FROM Fang INNER JOIN Angler ON (Fang.Angler_ID = Angler.Id) WHERE Fang.Datum >= '2016-01-01 00:00:00' AND Fang.Datum < '2017-01-01 00:00:00'AND (Fischart_ID = '2' OR Fischart_ID = '3' OR Fischart_ID = '4') GROUP BY Angler.Name ORDER BY Gewicht DESC"
                string strSQL = "SELECT Angler_ID, SUM(Fang.Gewicht) AS Gewicht " + 
                                "FROM Fang " +  
                                "WHERE Datum >= '" + ausgewähltesJahr  + "-01-01 00:00:00' AND Datum < '" + (ausgewähltesJahr + 1) + "-01-01 00:00:00'AND (Fischart_ID = '2' OR Fischart_ID = '3' OR Fischart_ID = '4') " + 
                                "GROUP BY Angler_ID " +
                                "ORDER BY Gewicht DESC";

                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    try
                    {
                        //Console.WriteLine(reader["Angler_ID"].ToString() + " - " + reader["Gewicht"].ToString());

                        liste.Add(new TrophyTeilnehmer(Convert.ToInt16(reader["Angler_ID"]), Convert.ToDouble(reader["Gewicht"])));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            //int index = 0;
            //Add Image to list
            for (int i = 0; i < liste.Count; i++)
            {
                for (int a = 0; a < anglerliste.Count; a++)
                {
                    if (liste[i].Angler_ID == anglerliste[a].ID)
                    {
                        liste[i].Bild = anglerliste[a].Bild;
                        break;
                    }
                }
            }

             string ersterPlatz = "";
             string zweiterPlatz = "";
             string driterPlatz = "";
             string vierterPlatz = "";
             string fünfterPlatz = "";

            if (liste != null)
            {
                if (liste.Count >= 1)
                {
                    pictureBox_Platz1.Visible = true;
                    ersterPlatz = Angler1.Get_Name(anglerliste, liste[0].Angler_ID);
                    pictureBox_Platz1.Image = liste[0].Bild;
                    this.label4.Text = "1. Platz \"" + ersterPlatz + "\", mit einem Gesamtgewicht von " + liste[0].Gewicht + " kg.";
                }
                else
                {
                    this.label4.Text = String.Empty;
                    pictureBox_Platz1.Visible = false;
                }
                    

                if (liste.Count >= 2)
                {
                    pictureBox_Platz2.Visible = true;
                    zweiterPlatz = Angler1.Get_Name(anglerliste, liste[1].Angler_ID);
                    pictureBox_Platz2.Image = liste[1].Bild;
                    this.label5.Text = "2. Platz \"" + zweiterPlatz + "\", mit einem Gesamtgewicht von " + liste[1].Gewicht + " kg.";
                }
                else
                {
                    this.label5.Text = String.Empty;
                    pictureBox_Platz2.Visible = false;
                }
                    

                if (liste.Count >= 3)
                {
                    pictureBox_Platz3.Visible = true;
                    driterPlatz = Angler1.Get_Name(anglerliste, liste[2].Angler_ID);
                    pictureBox_Platz3.Image = liste[2].Bild;
                    this.label6.Text = "3. Platz \"" + driterPlatz + "\", mit einem Gesamtgewicht von " + liste[2].Gewicht + " kg.";
                }
                else
                {
                    this.label6.Text = String.Empty;
                    pictureBox_Platz3.Visible = false;
                }
                    

                if (liste.Count >= 4)
                {
                    vierterPlatz = Angler1.Get_Name(anglerliste, liste[3].Angler_ID);
                    this.label_platz4.Text = "4. Platz \"" + vierterPlatz + "\", mit einem Gesamtgewicht von " + liste[3].Gewicht + " kg.";
                }
                else
                {
                    
                    this.label_platz4.Text = String.Empty;
                }
                    

                if (liste.Count >= 5)
                {
                    fünfterPlatz = Angler1.Get_Name(anglerliste, liste[4].Angler_ID);
                    this.label_platz5.Text = "5. Platz \"" + fünfterPlatz + "\", mit einem Gesamtgewicht von " + liste[4].Gewicht + " kg.";
                }
                else
                {
                    this.label_platz5.Text = String.Empty;
                }
                    
            }
        }

        private void GetAnglerliste()
        {
            anglerliste = new List<Angler1>();
             
            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT Id, Name, Bild " +
                                "FROM Angler";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
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
                            }
                        }
                        else
                        {
                            if (File.Exists(Properties.Settings.Default.Data + "\\" + "error.png"))
                            {
                                bmp = new Bitmap(Properties.Settings.Default.Data + "\\" + "error.png");
                            }
                        }

                        anglerliste.Add(new Angler1(Convert.ToInt16(reader["Id"]), reader["Name"].ToString(), bmp));
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
        }

        private string GetImageFromAngler(List<Angler> anglerliste, string name)
        {
            string dateiname = "";

            for (int i = 0; i < anglerliste.Count; i++)
            {
                if (name == anglerliste[i].Name)
                {
                    dateiname = anglerliste[i].FotoDateiname;
                    break;
                }
            }

            return dateiname;
        }

        private void AddImageToImageList(ImageList iml, Bitmap bm, string key, float wid, float hgt)
        {
            // Make the bitmap.
            Bitmap iml_bm = new Bitmap(
            iml.ImageSize.Width,
            iml.ImageSize.Height);
            using (Graphics gr = Graphics.FromImage(iml_bm))
            {
                gr.Clear(Color.Transparent);
                gr.InterpolationMode = InterpolationMode.High;
                // See where we need to draw the image to scale it properly.
                RectangleF source_rect = new RectangleF(
                0, 0, bm.Width, bm.Height);
                RectangleF dest_rect = new RectangleF(
                0, 0, iml_bm.Width, iml_bm.Height);
                dest_rect = ScaleRect(source_rect, dest_rect);
                // Draw the image.
                gr.DrawImage(bm, dest_rect, source_rect,
                GraphicsUnit.Pixel);
            }
            // Add the image to the ImageList.
            iml.Images.Add(key, iml_bm);
        }

        private RectangleF ScaleRect(RectangleF source_rect, RectangleF dest_rect)
        {
            float source_aspect =
            source_rect.Width / source_rect.Height;
            float wid = dest_rect.Width;
            float hgt = dest_rect.Height;
            float dest_aspect = wid / hgt;
            if (source_aspect > dest_aspect)
            {
                // The source is relatively short and wide.
                // Use all of the available width.
                hgt = wid / source_aspect;
            }
            else
            {
                // The source is relatively tall and thin.
                // Use all of the available height.
                wid = hgt * source_aspect;
            }
            // Center it.
            float x = dest_rect.Left + (dest_rect.Width - wid) / 2;
            float y = dest_rect.Top + (dest_rect.Height - hgt) / 2;
            return new RectangleF(x, y, wid, hgt);
        }

        #endregion

        #region Events

        private void Frm_Trophy_FormClosed(object sender, FormClosedEventArgs e)
        {
            //wmp.controls.stop();
            simpleSound_LakeTrophy.Stop();
        }

        private void cb_Jahre_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ausgewähltesJahr = Convert.ToInt16(cb_Jahre.Text);
            Datenauswerten();
        }

        #region Mouse

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            toolTip1_label.Hide(label4);
        }

        private void pictureBox_Platz1_MouseLeave(object sender, EventArgs e)
        {
            toolTip1_label.Hide(pictureBox_Platz1);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            //toolTip1_label.Hide(panel1);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            toolTip1_label.Hide(label5);
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            //toolTip1_label.Hide(panel2);
        }

        private void pictureBox_Platz2_MouseLeave(object sender, EventArgs e)
        {
            toolTip1_label.Hide(pictureBox_Platz2);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            toolTip1_label.Hide(label6);
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            //toolTip1_label.Hide(panel3);
        }

        private void pictureBox_Platz3_MouseLeave(object sender, EventArgs e)
        {
            toolTip1_label.Hide(pictureBox_Platz3);
        }

        private void label_platz4_MouseLeave(object sender, EventArgs e)
        {
            toolTip1_label.Hide(label_platz4);
        }

        private void label_platz5_MouseLeave(object sender, EventArgs e)
        {
            toolTip1_label.Hide(label_platz5);
        }

        private void pictureBox_Platz2_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                toolTip1_label.ShowAlways = true;
                toolTip1_label.Show(Angler1.Get_Name(anglerliste, liste[1].Angler_ID), pictureBox_Platz2);
            }
            catch { }
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                toolTip1_label.ShowAlways = true;
                toolTip1_label.Show(Angler1.Get_Name(anglerliste, liste[0].Angler_ID), label4, 5000);
            }
            catch { }
        }

        private void pictureBox_Platz1_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                toolTip1_label.ShowAlways = true;
                toolTip1_label.Show(Angler1.Get_Name(anglerliste, liste[0].Angler_ID), pictureBox_Platz1);
            }
            catch { }

        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                toolTip1_label.ShowAlways = true;
                //toolTip1_label.Show(trophy.FischerName_ErsterPlatz, panel1);
            }
            catch { }
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                toolTip1_label.ShowAlways = true;
                toolTip1_label.Show(Angler1.Get_Name(anglerliste, liste[1].Angler_ID), label5);
            }
            catch { }
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                toolTip1_label.ShowAlways = true;
                //toolTip1_label.Show(trophy.FischerName_ZweiterPlatz, panel2);
            }
            catch { }
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                toolTip1_label.ShowAlways = true;
                toolTip1_label.Show(Angler1.Get_Name(anglerliste, liste[2].Angler_ID), label6);
            }
            catch { }
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                toolTip1_label.ShowAlways = true;
                //toolTip1_label.Show(trophy.FischerName_DriterPlatz, panel3);
            }
            catch { }
        }

        private void pictureBox_Platz3_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                toolTip1_label.ShowAlways = true;
                toolTip1_label.Show(Angler1.Get_Name(anglerliste, liste[2].Angler_ID), pictureBox_Platz3);
            }
            catch { }
        }

        private void label_platz4_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                toolTip1_label.ShowAlways = true;
                toolTip1_label.Show(Angler1.Get_Name(anglerliste, liste[3].Angler_ID), label_platz4);
            }
            catch { }
        }

        private void label_platz5_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                toolTip1_label.ShowAlways = true;
                toolTip1_label.Show(Angler1.Get_Name(anglerliste, liste[4].Angler_ID), label_platz5);
            }
            catch { }
        }

        #endregion

        private void pictureBox_Platz2_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
