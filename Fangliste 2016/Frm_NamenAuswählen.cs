using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FanglisteLibrary;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace Fangliste_2016
{
    public partial class Frm_NamenAuswählen : Form
    {
        #region Variablen

        ListViewItem heldDownItem;
        Point heldDownPoint;

        int index;
        string selectedFischer = "";

        private List<Angler1> anglerliste;

        Frm_NeuerFischer neuername;

        #endregion

        #region Konstruktor

        public Frm_NamenAuswählen()
        {
            InitializeComponent();
        }

        private void Frm_NamenAuswählen_Load(object sender, EventArgs e)
        {
            anglerliste = new List<Angler1>();

            Aktualisieren();

            namenLöschenToolStripMenuItem.Enabled = false;
            toolStripButton_löschen.Enabled = false;

            if ((anglerliste == null) || (anglerliste.Count == 0))
            {
                timer1.Start();
            }


            //backgroundWorker1.RunWorkerAsync();
            //ImageLaden();
        }

        #endregion

        #region Button usw...

        private void timer1_Tick(object sender, EventArgs e)
        {
            namenHinzufügenToolStripMenuItem_Click(sender, e);
        }

        private void namenHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            neuername = new Frm_NeuerFischer(anglerliste);
            neuername.ShowDialog();

            if (neuername.DialogResult == DialogResult.OK)
            {
                Aktualisieren();
                //listView_Fischer.Refresh();
            }
                /*if ((anglerliste == null) || anglerliste.Count == 0)
                { 
                    Angler neuerFischer = new Angler();
                    neuerFischer = neuername.NeuerFischer;
                    neuerFischer.FotoDateiname = "";

                    anglerliste = new List<Angler>();
                    anglerliste.Add(neuerFischer);

                    if (FotoWählen(neuername.NeuerFischer.Name))
                    {
                        listView_Fischer.Items.Add(neuername.NeuerFischer.Name, 0);
                    }
                    else
                    {
                        Bitmap b = null;

                            if (File.Exists(Properties.Settings.Default.Data + "\\" + "error.png"))
                            {
                                //this.imageList_Fischer.Images.Add(Image.FromFile(Properties.Settings.Default.Data + "\\" + "error.png"));
                                b = new Bitmap(Properties.Settings.Default.Data + "\\" + "error.png");
                                AddImageToImageList(imageList_Fischer, b, "", imageList_Fischer.ImageSize.Width, imageList_Fischer.ImageSize.Height);
                            }
                        //this.imageList_Fischer.Images.Add(Image.FromFile(Properties.Settings.Default.Data + "\\" + "error.png"));
                        listView_Fischer.Items.Add(neuername.NeuerFischer.Name, 0);
                    }

                    Angler.SpeichernAsList(Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Anglerliste + Properties.Settings.Default.Datentyp, this.anglerliste);
                }
                else
                {
                    if (neuername.FischerEintragen == true)
                    {
                        try
                        {
                            Angler neuerFischer = new Angler();
                            neuerFischer = neuername.NeuerFischer;

                            anglerliste.Add(neuerFischer);

                            if (FotoWählen(neuername.NeuerFischer.Name))
                            {
                                listView_Fischer.Items.Add(neuername.NeuerFischer.Name, imageList_Fischer.Images.Count - 1);
                            }
                            else
                            {
                                Bitmap b = null;
                                if (File.Exists(Properties.Settings.Default.Data + "\\" + "error.png"))
                                {
                                    //this.imageList_Fischer.Images.Add(Image.FromFile(Properties.Settings.Default.Data + "\\" + "error.png"));
                                    b = new Bitmap(Properties.Settings.Default.Data + "\\" + "error.png");
                                    AddImageToImageList(imageList_Fischer, b, "", imageList_Fischer.ImageSize.Width, imageList_Fischer.ImageSize.Height);
                                }
                                listView_Fischer.Items.Add(neuername.NeuerFischer.Name, imageList_Fischer.Images.Count - 1);
                            }

                            Angler.SpeichernAsList(Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Anglerliste + Properties.Settings.Default.Datentyp, this.anglerliste);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                listView_Fischer.Refresh();
            }*/
            }

        private void namenLöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult löschen = MessageBox.Show("Sind Sie sicher, dass Sie Den Fischer löschen möchten?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (löschen == DialogResult.Yes)
            {
                try
                {
                    string ConnectionString =
             @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";

                    using (var sc = new SqlConnection(ConnectionString))
                    using (var cmd = sc.CreateCommand())
                    {
                        sc.Open();
                        cmd.CommandText = "DELETE FROM Angler WHERE Name = @name";
                        cmd.Parameters.AddWithValue("@name", listView_Fischer.SelectedItems[0].Text);
                        cmd.ExecuteNonQuery();
                    }

                    Aktualisieren();
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
                }
            }


            /*try
            {
                int index = 0;

                for (int i = 0; i < anglerliste.Count; i++)
                {
                    if (listView_Fischer.SelectedItems[0].Text == anglerliste[i].Name)
                    {
                        index = i;
                        break;
                    }
                }

                listView_Fischer.SelectedItems[0].Remove();
                try
                {
                    File.Delete(Frm_Hauptmenu.DatenOrdner + anglerliste[index].FotoDateiname);
                }
                catch { }

                anglerliste.RemoveAt(index);

                try
                {
                    Angler.SpeichernAsList(Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Anglerliste + Properties.Settings.Default.Datentyp, this.anglerliste);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Fehler beim speichern der Fischerliste.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        

            namenLöschenToolStripMenuItem.Enabled = false;
        }

        private void Frm_NamenAuswählen_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void listView_Fischer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Fischer.SelectedItems.Count > 0)
            {
                if (listView_Fischer.SelectedItems[0].Text != "")
                {
                    //für den button löschen (Beschreibung: wenn der button gedrückt wird, geht das Selektierte Item verloren und es gibt keinen text).
                    selectedFischer = listView_Fischer.SelectedItems[0].Text;
                    namenLöschenToolStripMenuItem.Enabled = true;
                    toolStripButton_löschen.Enabled = true;
                }
            }
            else
            {
                namenLöschenToolStripMenuItem.Enabled = false;
                toolStripButton_löschen.Enabled = false;
            }
        }

        private void listView_Fischer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView_Fischer.SelectedItems.Count > 0)
            {
                if (listView_Fischer.SelectedItems[0].Text != "")
                {
                    Auswählen();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void listView_Fischer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (listView_Fischer.Text != "")
            {
                Auswählen();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void listView_Fischer_MouseDown(object sender, MouseEventArgs e)
        {
            listView_Fischer.AutoArrange = false;
            heldDownItem = listView_Fischer.GetItemAt(e.X, e.Y);
            if (heldDownItem != null)
            {
                heldDownPoint = new Point(e.X - heldDownItem.Position.X,
                                          e.Y - heldDownItem.Position.Y);
            }
        }

        private void listView_Fischer_MouseUp(object sender, MouseEventArgs e)
        {
            heldDownItem = null;
            listView_Fischer.AutoArrange = true;
        }

        private void listView_Fischer_MouseMove(object sender, MouseEventArgs e)
        {
            if (heldDownItem != null)
            {
                heldDownItem.Position = new Point(e.Location.X - heldDownPoint.X,
                                                  e.Location.Y - heldDownPoint.Y);
            }
        }

        private void listView_Fischer_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (this.listView_Fischer.View == View.LargeIcon)
            {
                e.Graphics.DrawImage(Image.FromFile(e.Item.Text), e.Bounds);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ImageLaden();
        }

        private void Frm_NamenAuswählen_FormClosing(object sender, FormClosingEventArgs e)
        {
            //backgroundWorker1.CancelAsync();
        }

        private void toolStripButton_hinzufügen_Click(object sender, EventArgs e)
        {
            namenHinzufügenToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton_löschen_Click(object sender, EventArgs e)
        {
            namenLöschenToolStripMenuItem_Click(sender, e);
        }

        #endregion

        #region Methoden

        private void Aktualisieren()
        {
            imageList_Fischer.Images.Clear();
            listView_Fischer.Items.Clear();
            int count = 0;

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
                                AddImageToImageList(imageList_Fischer, bmp, "", imageList_Fischer.ImageSize.Width, imageList_Fischer.ImageSize.Height);
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
                                AddImageToImageList(imageList_Fischer, bmp, "", imageList_Fischer.ImageSize.Width, imageList_Fischer.ImageSize.Height);
                            }
                        }

                        anglerliste.Add(new Angler1(Convert.ToInt16(reader["Id"]), reader["Name"].ToString(), bmp));
                        listView_Fischer.Items.Add(anglerliste[count].Name, count);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Fehler");
                    }

                    
                    count++;
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

        private void ImageLaden()
        {
            this.Invoke(new MethodInvoker(delegate { imageList_Fischer.Images.Clear(); }));
            this.Invoke(new MethodInvoker(delegate { listView_Fischer.Items.Clear(); }));

            for (int i = 0; i < anglerliste.Count; i++)
            {
                Bitmap b = null;

                try
                {
                    //this.imageList_Fischer.Images.Add(Image.FromFile(Frm_Hauptmenu.DatenOrdner + "\\" + anglerliste[i].FotoDateiname));
                    b = new Bitmap(Frm_Hauptmenu.DatenOrdner + "\\" + anglerliste[i].Bild);
                    //imageList_Fischer.Images.Add(b);
                    AddImageToImageList(imageList_Fischer, b, "", imageList_Fischer.ImageSize.Width, imageList_Fischer.ImageSize.Height);
                }
                catch
                {
                    if (File.Exists(Properties.Settings.Default.Data + "\\" + "error.png"))
                    {
                        //this.imageList_Fischer.Images.Add(Image.FromFile(Properties.Settings.Default.Data + "\\" + "error.png"));
                        b = new Bitmap(Properties.Settings.Default.Data + "\\" + "error.png");
                        //imageList_Fischer.Images.Add(b);
                        AddImageToImageList(imageList_Fischer, b, "", imageList_Fischer.ImageSize.Width, imageList_Fischer.ImageSize.Height);
                    }
                }

                this.Invoke(new MethodInvoker(delegate { listView_Fischer.Items.Add(anglerliste[i].Name, i); }));
            }
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
            try
            {
                this.Invoke(new MethodInvoker(delegate { iml.Images.Add(key, iml_bm); }));
            }
            catch { }
        }

        private Bitmap BytesToImage(byte[] bytes)
        {
            using (MemoryStream image_stream =
            new MemoryStream(bytes))
            {
                Bitmap bm = new Bitmap(image_stream);
                return bm;
            }
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

        private void Auswählen()
        {
            for (int i = 0; i < this.anglerliste.Count; i++)
            {
                if (listView_Fischer.SelectedItems[0].Text == this.anglerliste[i].Name)
                {
                    this.index = i;
                }
            }
        }

        private string[] GetAllVideosInPath()
        {
            //string[] allFiles = System.IO.Directory.GetFiles(this.einstellungen.Pfad);
            string[] videoFiles = null;

            //int zähler = 0;

            //FileInfo file;

            //for (int i = 0; i < allFiles.Length; i++)
            //{
            //    file = new FileInfo(allFiles[i]);

            //    if (file.Extension == ".mp4")
            //    {
            //        zähler++;
            //    }
            //}

            //videoFiles = new string[zähler];

            //int index = 0;

            //for (int i = 0; i < allFiles.Length; i++)
            //{
            //    file = new FileInfo(allFiles[i]);

            //    if (file.Extension == ".mp4")
            //    {
            //        videoFiles[index] = allFiles[i];
            //        index++;
            //    }
            //}

            return videoFiles;
        }

        private void PlayVideo()
        {
            try
            {
                string[] videoFiles = GetVideolist();

                Random rdm = new Random();
                int rdm_zahl = rdm.Next(0, videoFiles.Length);

                //FlashPlayer gehört in die Form eingefügt!!!
                //axShockwaveFlash1.Movie = videoFiles[rdm_zahl];
            }
            catch { }
        }

        private string[] GetVideolist()
        {
            string[] videolist = null;

            try
            {
                //Network.Download(einstellungen.Http_Adresse_Videoliste, einstellungen.Pfad, einstellungen.Dateiname_Videoliste);

                //videolist = new string[LeseVideolisteAus(einstellungen.Pfad, einstellungen.Dateiname_Videoliste).Length];
                //videolist = LeseVideolisteAus(einstellungen.Pfad, einstellungen.Dateiname_Videoliste);
            }
            catch { }

            return videolist;
        }

        private string[] LeseVideolisteAus(string pfad, string dateiname)
        {
            string[] gesamtliste = null;
            string[] alleVideos;

            try
            {
                StreamReader leser = new StreamReader(pfad + dateiname);
                int zeilen = 0;
                while (leser.Peek() >= 0)
                {
                    leser.ReadLine();
                    zeilen++;
                }
                leser.Close();

                if (zeilen > 1)
                {
                    throw new InvalidDataException("Videolist Datei ist größer als eine Zeile.");
                }

                if (zeilen == 0)
                {
                    gesamtliste = new string[0];
                    alleVideos = new string[0];
                }
                else
                {
                    gesamtliste = new string[zeilen];

                    StreamReader leser2 = new StreamReader(pfad + dateiname);

                    gesamtliste = leser2.ReadLine().Split(';');

                    leser2.Close();

                    alleVideos = new string[gesamtliste.Length];

                    for (int i = 0; i < gesamtliste.Length; i++)
                    {
                        alleVideos[i] = gesamtliste[i];
                    }
                }
            }
            catch
            {
                throw new InvalidOperationException("Keine Datei zum Lesen vorhanden!");
            }

            return alleVideos;
        }

        private bool FotoWählen(string fischerName)
        {
            bool fotofile = false;
            /*
            openFileDialog1.Title = "Wählen Sie ein Foto aus.";
            openFileDialog1.Filter = "JPEG (*.jpg)|*.jpg";
            openFileDialog1.FileName = "IhrFoto.jpg";
            DialogResult select = openFileDialog1.ShowDialog();

            if (select == DialogResult.OK)
            {
                //Benötige nur den namen des Ordners, um später die Datei zu vergleichen.
                //einstellung.pfad heit einen / um den ordner anzugeben. 
                //Benötigt wird aber \\ zu vergleichen mit den inputVerzeichnis von openfileDialog.
                DirectoryInfo pfad = new DirectoryInfo(Frm_Hauptmenu.DatenOrdner);

                string destFile = pfad.FullName + "\\" +  fischerName + Path.GetExtension(openFileDialog1.FileName);

                try
                {
                    //if (openFileDialog1.FileName != destFile)
                    //{
                    //Bitmap bild = new Bitmap(openFileDialog1.FileName);
                    //bild.Size = new System.Drawing.Size(163, 197);
                    //bild.Save(destFile);

                        File.Copy(openFileDialog1.FileName, destFile, true);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Das Foto existiert bereits.", "Fehler.");
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Datei konnte nicht kopiert werden.\n\nInformation:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Bitmap b = null;

                try
                {
                    b = new Bitmap(destFile);
                    AddImageToImageList(imageList_Fischer, b, "", imageList_Fischer.ImageSize.Width, imageList_Fischer.ImageSize.Height);
                    this.anglerliste[this.anglerliste.Count - 1].FotoDateiname = fischerName + ".jpg";
                }
                catch
                {
                    if (File.Exists(Properties.Settings.Default.Data + "\\" + "error.png"))
                    {
                        b = new Bitmap(Properties.Settings.Default.Data + "\\" + "error.png");
                        AddImageToImageList(imageList_Fischer, b, "", imageList_Fischer.ImageSize.Width, imageList_Fischer.ImageSize.Height);
                    }
                }

                //try
                //{
                //    this.imageList_Fischer.Images.Add(Image.FromFile(destFile));
                //    this.anglerliste[this.anglerliste.Count - 1].FotoDateiname = fischerName + ".jpg";
                //}
                //catch
                //{
                //    this.imageList_Fischer.Images.Add(Image.FromFile(Properties.Settings.Default.Data + "\\" + "error.png"));
                //}
                fotofile = true;
            }*/

            return fotofile;
        }

        #endregion

        #region Eigenschaften

        public Angler1 Ausgewählter_Fischer
        {
            get
            {
                return this.anglerliste[index];
            }
        }

        public List<Angler1> Alle_Fischer_Liste
        {
            get
            {
                return this.anglerliste;
            }
        }

        #endregion
    }
}
