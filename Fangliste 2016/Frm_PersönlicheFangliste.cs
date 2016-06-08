using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using FanglisteLibrary;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Drawing2D;

namespace Fangliste_2016
{
    public partial class Frm_PersönlicheFangliste : Form
    {
        #region Variablen

        List<Fangliste> alleFänge;
        List<Foto> fotoliste;
        List<Fangliste> persönliche_Liste; 
        Angler1 angler;

        List<PersönlicheFanglisteView> view = new List<PersönlicheFanglisteView>();

        Frm_FotosVonFang frm_fotosVonFang;
        Frm_PersönlFangliste_Detail frm_perönlFanglisteDetail;

        SoundPlayer schade;
        SoundPlayer jubel;

        #endregion

        #region Konstruktor

        public Frm_PersönlicheFangliste(Angler1 angler)
        {
            InitializeComponent();

            this.angler = angler;

            schade = new SoundPlayer(Properties.Settings.Default.Data + "\\" + Properties.Settings.Default.LoserSound);
            jubel = new SoundPlayer(Properties.Settings.Default.Data + "\\" + Properties.Settings.Default.JubelSound);
        }

        private void Frm_PersönlicheFangliste_Load(object sender, EventArgs e)
        {

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT Fang.Icon, Fisch.Name AS Fischart, Gewässer.Name AS Gewässer, Angler.Name, Fang.Länge, Fang.Gewicht, Fang.Köder, Fang.Angelplatz, Fang.Tiefe, Fang.Lufttemperatur, Fang.Wassertemperatur, Fang.Datum, Fang.Uhrzeit, Fang.Wetter, Fang.Kommentar  " +
                                "FROM Fang JOIN Fisch ON (Fang.Fischart_ID = Fisch.Id) JOIN Gewässer ON (Fang.Gewässer_ID = Gewässer.Id) JOIN Angler ON (Fang.Angler_ID = Angler.ID) WHERE Fang.Angler_ID = '" + angler.ID + "'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                SqlDataAdapter dataAdapterPers = new SqlDataAdapter(strSQL, con.ConnectionString);

                SqlCommandBuilder comBuilder = new SqlCommandBuilder(dataAdapterPers);
                System.Data.DataSet ds = new System.Data.DataSet();
                dataAdapterPers.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }


            /////////////

            //this.Cursor = Cursors.WaitCursor;
            fotoAnzeigenToolStripMenuItem.Enabled = false;

            PlaySound();

            this.WindowState = FormWindowState.Maximized;
            //listPersönlich.Items.Clear();

            //SpezifischeFotolisteErstellen();

            this.Text = "Persönliche Fangliste von " + angler.Name;

            comboBox1.Items.Add("Alle");

            /*for (int i = 0; i < this.view.Count; i++)
            {
                ListViewItem item = new ListViewItem(this.view[i].GetList, i);

                listPersönlich.Items.Add(item);

                if (!comboBox1.Items.Contains(this.view[i].Datum.Year))
                    comboBox1.Items.Add(this.view[i].Datum.Year);
            }*/

            comboBox1.Text = "Alle";

            lb_gesAnzahlAktuell_Info.Text = "Gesamtanzahl der gefangenen Fische (" + DateTime.Now.Year + "):";
            GesAnzahlFängeAktuell();
        }

        #endregion

        #region Methoden

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
            try
            {
                this.Invoke(new MethodInvoker(delegate { iml.Images.Add(key, iml_bm); }));
            }
            catch { }
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

        private void SpezifischeFotolisteErstellen()
        {
            imageList1.Images.Clear();

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString;

            try
            {
                for (int i = 0; i < view.Count; i++)
                {
                    string strSQL = "SELECT Bild " +
                                "FROM Foto WHERE Fang_ID = '" + view[i].Fang_ID + "'";
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
                                    AddImageToImageList(imageList1, bmp, "", imageList1.ImageSize.Width, imageList1.ImageSize.Height);
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
                                    AddImageToImageList(imageList1, bmp, "", imageList1.ImageSize.Width, imageList1.ImageSize.Height);
                                }
                            }

                            view[i].Bild = bmp;
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    reader.Close();
                    con.Close();
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

        }

        private void GesAnzahlFängeAktuell()
        {
            int anzahl = 0;
            int jahr = DateTime.Now.Year;

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT COUNT(*) FROM Fang WHERE Angler_ID = '" + angler.ID + "' AND Datum BETWEEN '" + jahr + "/01/01' AND '" + (jahr + 1) + "/01/01'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                anzahl = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
            }



            /*try
            {
                for (int i = 0; i < this.view.Count; i++)
                {
                    if (this.view[i].Datum.Year == DateTime.Now.Year)
                    {
                        anzahl++;
                    }
                }
            }
            catch { }*/

            lb_gesAnzahlAktuell.Text = anzahl.ToString();
        }

        private void PlaySound()
        {
            try
            {
                if (Properties.Settings.Default.PlaySound == true)
                {
                    if (!Fangliste1.HeuerEtwasGefangen(DateTime.Now.Year, angler))
                    {
                        schade.Play();
                    }
                    else
                    {
                        jubel.Play();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Events

        private void fotoAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*int index = listPersönlich.SelectedIndices[0];
            List<Foto> fangFotos = new List<Foto>();

            for (int i = 0; i < fotoliste.Count; i++)
            {
                if (fotoliste[i].ID == persönliche_Liste[index].ID)
                    fangFotos.Add(fotoliste[i]);
            }

            if ((fangFotos != null) && (fangFotos.Count != 0))
            {
                frm_fotosVonFang = new Frm_FotosVonFang(this.persönliche_Liste, fangFotos, index);
                frm_fotosVonFang.ShowDialog();
            }*/
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_details_Click(sender, e);
        }

        private void Frm_PersönlicheFangliste_FormClosed(object sender, FormClosedEventArgs e)
        {
            jubel.Stop();
            schade.Stop();
        }

        private void listPersönlich_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           /* if (e.Button == MouseButtons.Left)
            {
                int index = listPersönlich.SelectedIndices[0];
                List<Foto> fangFotos = new List<Foto>();

                for (int i = 0; i < fotoliste.Count; i++)
                {
                    if (fotoliste[i].ID == persönliche_Liste[index].ID)
                        fangFotos.Add(fotoliste[i]);
                }

                if ((fangFotos != null) && (fangFotos.Count != 0))
                {
                    frm_fotosVonFang = new Frm_FotosVonFang(this.persönliche_Liste, fangFotos, index);
                    frm_fotosVonFang.ShowDialog();
                }
            }*/
        }

        private void btn_details_Click(object sender, EventArgs e)
        {
            frm_perönlFanglisteDetail = new Frm_PersönlFangliste_Detail(angler);
            frm_perönlFanglisteDetail.ShowDialog();
        }

        private void listPersönlich_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (listPersönlich.SelectedItems.Count > 0)
            {
                if (listPersönlich.SelectedItems[0].Text != "")
                {
                    fotoAnzeigenToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                fotoAnzeigenToolStripMenuItem.Enabled = false;
            }*/
        }

        #endregion

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
           /* if (comboBox1.Text != "Alle")
            {
                listPersönlich.Items.Clear();

                for (int i = 0; i < this.persönliche_Liste.Count; i++)
                {
                    if (comboBox1.Text == this.persönliche_Liste[i].Datum.Year.ToString())
                    {
                        ListViewItem item = new ListViewItem(this.persönliche_Liste[i].Get_Persönliche_List, i);

                        listPersönlich.Items.Add(item);
                    }
                }
            }
            else
            {
                listPersönlich.Items.Clear();

                for (int i = 0; i < this.persönliche_Liste.Count; i++)
                {
                    ListViewItem item = new ListViewItem(this.persönliche_Liste[i].Get_Persönliche_List, i);

                    listPersönlich.Items.Add(item);
                }
            }*/
        }
    }

}


