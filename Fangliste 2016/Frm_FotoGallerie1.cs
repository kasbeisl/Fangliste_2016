using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Net;
using System.Threading;
using FanglisteLibrary;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;

namespace Fangliste_2016
{
    public partial class Frm_FotoGallerie1 : Form
    {
       #region Variablen

        BackgroundWorker Diashow;

        List<Fangliste1> fangliste;
        List<Foto1> fotoliste;
        //List<string> images;

        Frm_FotoÜbersicht1 frm_fotoÜbersicht;
        Frm_Fotoliste frm_fotoliste;
        Frm_FotolisteImportieren frm_fotolisteImportieren;

        int start_foto = 0;
        int foto_jetzt = 0;
        int foto_vorher = 0;
        Random rnd = new Random();
        //int ges_anzahl_fotos = 0;
        bool diashowrun = false;
        int diashow_time = 4000;//Zeit in ms.

        //diashow speed
        int min = 2000; //Zeit in ms. (2 sec.)
        int max = 10000; //Zeit in ms. (10 sec.)

        ////Foto Ordner
        private string Ordner;
        //private string[] _gewässer = null;

        private bool none_foto = false;
        private bool fotolisteExist = false;

        WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayer();
        //bool audioOptionenVisible = false;

        #endregion

       #region Konstruktor

       public Frm_FotoGallerie1()
        {
           InitializeComponent();
        }

        private void Frm_Gallerie_Load(object sender, EventArgs e)
        {
            trackBar_speed.Minimum = min / 1000;
            trackBar_speed.Maximum = max / 1000;

            Aktualisieren();

            fangliste = new List<Fangliste1>();

            string ConnectionString =
             @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Directory.GetCurrentDirectory() + @"\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConnectionString;

                //string text = "SELECT COUNT(*) FROM Angler";

                string strSQL = "SELECT * " +
                                "FROM Fang";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        fangliste.Add(new Fangliste1(Convert.ToInt16(reader["Id"]), Convert.ToInt16(reader["Angler_ID"]), Convert.ToInt16(reader["Fischart_ID"]), Convert.ToDouble(reader["Länge"]), Convert.ToDouble(reader["Gewicht"]), Convert.ToInt16(reader["Gewässer_ID"]), Convert.ToDateTime(reader["Datum"]), Convert.ToDateTime(reader["Uhrzeit"]), reader["Angelplatz"].ToString(), reader["Köder"].ToString(), Convert.ToDouble(reader["Tiefe"]), Convert.ToDouble(reader["Lufttemperatur"]), Convert.ToDouble(reader["Wassertemperatur"]), reader["Wetter"].ToString(), Convert.ToBoolean(reader["Zurückgesetzt"]), reader["Kommentar"].ToString()));
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

            //images = Foto.SortiereFilesNachDatum(Foto.GetFilesFromDirection(Frm_Hauptmenu.FotoOrdner));

            label_kommentar.Text = "";
            lb_fotoInfo.Text = "";

            if ((fotoliste == null) || (fotoliste.Count == 0))
                speichernUnterToolStripMenuItem.Enabled = false;

                fotolisteExist = true;

            DatenLaden();

            #region Diashow background
            Diashow = new BackgroundWorker();
            Diashow.WorkerReportsProgress = true;
            Diashow.WorkerSupportsCancellation = true;
            Diashow.DoWork += new DoWorkEventHandler(Diashow_DoWork);
            Diashow.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Diashow_RunWorkerCompleted);
            #endregion

            diashowShuffleToolStripMenuItem.Enabled = false;

            if (this.fotoliste.Count == 0)
            {
                button_back.Enabled = false;
                button_vor.Enabled = false;
            }

            try
            {
                trackBar_volume.Value = wmp.settings.volume;
            }
            catch { }
        }

        private void Aktualisieren()
        {
            fotoliste = new List<Foto1>();

            string ConnectionString =
             @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Directory.GetCurrentDirectory() + @"\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                //string text = "SELECT COUNT(*) FROM Angler";

                string strSQL = "SELECT * " +
                                "FROM Foto";
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
                                //this.imageList_Fischer.Images.Add(Image.FromFile(Properties.Settings.Default.Data + "\\" + "error.png"));
                                bmp = new Bitmap(Properties.Settings.Default.Data + "\\" + "error.png");
                            }
                        }

                        fotoliste.Add(new Foto1(Convert.ToInt16(reader["Id"]), Convert.ToInt16(reader["Angler_ID"]), Convert.ToInt16(reader["Fang_ID"]), Convert.ToInt16(reader["Ordner_ID"]), reader["Kommentar"].ToString(), bmp));
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

        private void Aktualisieren1(int ordner = 2)
        {
            fotoliste = new List<Foto1>();

            string ConnectionString =
             @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Directory.GetCurrentDirectory() + @"\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                //string text = "SELECT COUNT(*) FROM Angler";

                string strSQL = "SELECT * " +
                                "FROM Foto WHERE Ordner_ID = '" + ordner + "'";
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
                                //this.imageList_Fischer.Images.Add(Image.FromFile(Properties.Settings.Default.Data + "\\" + "error.png"));
                                bmp = new Bitmap(Properties.Settings.Default.Data + "\\" + "error.png");
                            }
                        }

                        fotoliste.Add(new Foto1(Convert.ToInt16(reader["Id"]), Convert.ToInt16(reader["Angler_ID"]), Convert.ToInt16(reader["Fang_ID"]), Convert.ToInt16(reader["Ordner_ID"]), reader["Kommentar"].ToString(), bmp));
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

        #endregion

        private void DatenLaden()
        {
            trackBar_speed.Value = Properties.Settings.Default.FotoDiashowSpeed;
            label_speed.Text = trackBar_speed.Value + " sec./ Foto";

            if (!fotolisteExist)
            {
                cb_gewässer.Visible = false;
                cb_anzahlFotos.Visible = false;
                button_diashow.Enabled = false;
                trackBar_speed.Enabled = false;
                btn_bearbeiten.Enabled = false;
                button_foto_löschen.Enabled = false;
                //lb_speichern.Enabled = false;
                //lb_exportieren.Enabled = false;
            }
            else
            {
                //lb_speichern.Enabled = true;
                //lb_exportieren.Enabled = true;
            }

            //datenLaden.CancelAsync();

            ComboBoxFüllen();

            Wieviel_fotos();

            Label_foto_nr_setzen();

            try
            {
                if((fotoliste != null) && (fotoliste.Count != 0))
                    pictureBox1.Image = fotoliste[start_foto].Bild;
            }
            catch { }

            this.Cursor = Cursors.Default;

            try
            {
                if (!none_foto)
                {
                    button_diashow.Enabled = true;
                    if (foto_jetzt == 0)
                    {
                    }
                    else
                    {
                        button_back.Enabled = true;
                    }
                    if (foto_jetzt == this.fotoliste.Count - 1)
                    {
                    }
                    else
                    {
                        button_vor.Enabled = true;
                    }
                    pictureBox1.Visible = true;
                    label_foto_von_anzahl.Visible = true;
                    cb_anzahlFotos.Visible = true;
                    button_foto_löschen.Enabled = true;
                    cb_gewässer.Visible = true;
                    button_fotos_hinzufügen.Enabled = true;
                }
                else
                {
                    pictureBox1.Visible = false;
                    label_foto_von_anzahl.Visible = false;
                    cb_anzahlFotos.Visible = false;
                    button_foto_löschen.Enabled = false;
                    button_diashow.Enabled = false;
                    button_back.Enabled = false;
                    button_vor.Enabled = false;
                }
            }
            catch
            {
            }

            btn_audio_back.Enabled = false;
            btn_audio_next.Enabled = false;

            if (fotoliste == null || fotoliste.Count == 0)
            {
                ZeigeToolTipKeinFoto(true);
                //lb_importieren.Enabled = false;
                //lb_exportieren.Enabled = false;
                //lb_speichern.Enabled = false;
            }
        }

       #region Backgroundworker Diashow

        public void Diashow_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = foto_jetzt; i <= fotoliste.Count; i++)
                {
                    if (diashowrun)
                    {
                        if (diashowShuffleToolStripMenuItem.Checked)
                        {
                            i = rnd.Next(0, this.fotoliste.Count);

                            if (foto_vorher == i)
                            {
                                bool exist = true;
                                while (exist)
                                {
                                    i = rnd.Next(0, this.fotoliste.Count);

                                    if (foto_vorher != i)
                                    {
                                        exist = false;
                                    }
                                }
                            }
                        }

                        foto_jetzt = i;
                        foto_vorher = i;
                        pictureBox1.Image = fotoliste[i].Bild;
                        //FotoInfos_Set();
                        Thread.Sleep(diashow_time);

                        if (i == this.fotoliste.Count - 1)
                        {
                            //Thread.Sleep(diashow_time);
                            i = -1;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch
            {
                //MessageBox.Show("Bild konnte nicht geladen werden.", "Fehler");
            }
        }

        public void Diashow_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        #endregion

       #region Button

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
            pictureBox1.Image = fotoliste[zahl].Bild;
            foto_jetzt = zahl;

            //FotoInfos_Set();

            //btn_extras.Text = "v";
            //panel_extras.Visible = false;
        }

        private void button_vor_Click(object sender, EventArgs e)
        {
            try
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
                pictureBox1.Image = fotoliste[zahl].Bild;
                foto_jetzt = zahl;

                //FotoInfos_Set();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fehler.");
            }

            //btn_extras.Text = "v";
            //panel_extras.Visible = false;
        }

        private void button_foto_hinzufügen_Click(object sender, EventArgs e)
        {
            FotoHinzufügen();
        }

        private void cb_anzahlFotos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.fotoliste.Count != 0)
                {
                    int foto = cb_anzahlFotos.SelectedIndex;
                    foto_jetzt = foto;
                    pictureBox1.Image = fotoliste[foto_jetzt].Bild;
                    if (foto_jetzt == 0)
                    {
                        button_back.Enabled = false;
                        button_vor.Enabled = true;
                    }
                    if (foto_jetzt > 0)
                    {
                        button_back.Enabled = true;
                        button_vor.Enabled = true;
                    }
                    if (foto_jetzt == this.fotoliste.Count - 1)
                    {
                        button_vor.Enabled = false;
                    }

                    //FotoInfos_Set();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fehler");
            }
        }

        private void cb_gewässer_MouseClick(object sender, MouseEventArgs e)
        {
            //btn_extras.Text = "v";
            //panel_extras.Visible = false;
        }

        private void cb_anzahlFotos_MouseClick(object sender, MouseEventArgs e)
        {
            //btn_extras.Text = "v";
            //panel_extras.Visible = false;
        }

        private void button_diashow_Click(object sender, EventArgs e)
        {
            if (this.fotoliste.Count != 0)
            {
                if (diashowrun == true)
                {
                    diashowrun = false;
                    try
                    {
                        Diashow.CancelAsync();
                    }
                    catch
                    {
                    }
                    //button_diashow.Text = "Diashow Starten";
                    if (File.Exists(Properties.Settings.Default.Data + "\\" + "play.png"))
                    {
                        Bitmap b = new Bitmap(Properties.Settings.Default.Data + "\\" + "play.png");
                        button_diashow.BackgroundImage = b;
                    }
                    if (foto_jetzt == 0)
                    {
                        button_back.Enabled = false;
                        button_vor.Enabled = true;
                    }
                    else
                    {
                        if (foto_jetzt == fotoliste.Count - 1)
                        {
                            button_back.Enabled = true;
                            button_vor.Enabled = false;
                        }
                        else
                        {
                            button_back.Enabled = true;
                            button_vor.Enabled = true;
                        }
                    }

                    btn_audio_back.Enabled = false;
                    btn_audio_next.Enabled = false;
                    trackBar_speed.Enabled = true;
                    cb_anzahlFotos.Visible = true;
                    cb_gewässer.Enabled = true;
                    button_foto_löschen.Enabled = true;
                    //btn_extras.Enabled = true;
                    button_fotos_hinzufügen.Enabled = true;
                    btn_bearbeiten.Enabled = true;

                    übersichtToolStripMenuItem.Enabled = true;
                    duplikateSuchenToolStripMenuItem.Enabled = true;
                    //fotolisteToolStripMenuItem.Enabled = true;
                    wmp.controls.stop();
                    diashowShuffleToolStripMenuItem.Enabled = false;
                    
                    if ((fotoliste == null) || (fotoliste.Count == 0))
                        speichernUnterToolStripMenuItem.Enabled = true;
                }
                else
                {
                    diashowrun = true;
                    try
                    {
                        Diashow.RunWorkerAsync();
                    }
                    catch
                    {
                    }
                    //button_diashow.Text = "Diashow STOP";
                    if(File.Exists(Properties.Settings.Default.Data + "\\" + "pause.png"))
                    {
                        Bitmap b = new Bitmap(Properties.Settings.Default.Data + "\\" + "pause.png");
                        button_diashow.BackgroundImage = b;
                    }
                    btn_audio_back.Enabled = true;
                    btn_audio_next.Enabled = true;
                    button_back.Enabled = false;
                    button_vor.Enabled = false;
                    trackBar_speed.Enabled = true;
                    cb_anzahlFotos.Visible = false;
                    cb_gewässer.Enabled = false;
                    button_foto_löschen.Enabled = false;
                    //btn_extras.Enabled = false;
                    button_fotos_hinzufügen.Enabled = false;
                    btn_bearbeiten.Enabled = false;
                    speichernUnterToolStripMenuItem.Enabled = false;
                    duplikateSuchenToolStripMenuItem.Enabled = false;

                    übersichtToolStripMenuItem.Enabled = false;
                    //fotolisteToolStripMenuItem.Enabled = false;
                    diashowShuffleToolStripMenuItem.Enabled = true;
                    backgroundWorker_MusikLaden.RunWorkerAsync();
                    //MusikAbspielen();
                }
            }

            //btn_extras.Text = "v";
            //panel_extras.Visible = false;
        }

        private void trackBar_speed_Scroll(object sender, EventArgs e)
        {
            diashow_time = 1000 * trackBar_speed.Value;
            label_speed.Text = trackBar_speed.Value + " sec./ Foto";
            Properties.Settings.Default.FotoDiashowSpeed = trackBar_speed.Value;
            Properties.Settings.Default.Save();
        }

        private void Frm_Gallerie_FormClosed(object sender, FormClosedEventArgs e)
        {
            wmp.controls.stop();
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Label_foto_nr_setzen();

            FotoInfos_Set();
        }

        private void button_foto_löschen_Click(object sender, EventArgs e)
        {
            //btn_extras.Text = "v";
            //panel_extras.Visible = false;

            DialogResult sicher = MessageBox.Show("Sind Sie sicher, dass Sie dieses Foto löschen wollen?", "Foto Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (sicher == DialogResult.Yes)
            {
                FotoLöschen();
            }
        }

        private void btn_bearbeiten_Click(object sender, EventArgs e)
        {
            /*Frm_FotoinfoEditor frm_fotoEditor = new Frm_FotoinfoEditor(this.fangliste, this.fotoliste, images[foto_jetzt]);
            frm_fotoEditor.ShowDialog();

            if (frm_fotoEditor.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                File.Copy(Frm_Hauptmenu.DatenOrdner + "\\" + Properties.Settings.Default.Fotoliste + Properties.Settings.Default.Datentyp,
                    Frm_Hauptmenu.DatenOrdner + "\\" + "Backup\\" + Properties.Settings.Default.Fotoliste + "_" + DateTime.Now.ToShortDateString() + Properties.Settings.Default.Datentyp, true);

                if (frm_fotoEditor.NeuerEintrag != null)
                {
                    if (frm_fotoEditor.Edit)
                    {
                        fotoliste[frm_fotoEditor.GetIndex] = frm_fotoEditor.NeuerEintrag;
                    }
                    else
                    {
                        fotoliste.Add(frm_fotoEditor.NeuerEintrag);
                    }

                    Foto.Speichere_Fotoliste(this.fotoliste, Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Fotoliste + Properties.Settings.Default.Datentyp);
                    
                }
            }

            FotoInfos_Set();*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /*if (this.images.Count != 0)
            {
                Diashow.CancelAsync();

                if (!none_foto)
                {
                    Form full = new Frm_Vollbild(this.images, this.fangliste, this.fotoliste,this.foto_jetzt, this.diashowrun, this.diashow_time, diashowShuffleToolStripMenuItem.Checked);
                    full.ShowDialog();
                }
            }

            if(!Diashow.IsBusy)
                Diashow.RunWorkerAsync();
                */
            //btn_extras.Text = "v";
            //panel_extras.Visible = false;
        }

        private void cb_gewässer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (this.ges_anzahl_fotos != 0)
            //{
                Gewässer_auswählen();

                FotoInfos_Set();
            //}
        }

        private void lb_musikOrdnerÖffnen_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "audio"));
        }

        private void trackBar_volume_Scroll(object sender, EventArgs e)
        {
            try
            {
                wmp.settings.volume = trackBar_volume.Value;
            }
            catch { }
        }

        private void btn_audio_back_Click(object sender, EventArgs e)
        {
            try
            {
                wmp.controls.previous();
            }
            catch { }
        }

        private void btn_audio_next_Click(object sender, EventArgs e)
        {
            try
            {
                wmp.controls.next();
            }
            catch { }
        }

        private void cb_audio_shuffle_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_audio_shuffle.Checked)
            {
                wmp.settings.setMode("shuffle", true);
            }
            else
            {
                wmp.settings.setMode("shuffle", false);
            }
        }

        private void übersichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*frm_fotoÜbersicht = new Frm_FotoÜbersicht1(this.fotoliste);
            frm_fotoÜbersicht.ShowDialog();

            if (frm_fotoÜbersicht.DialogResult == DialogResult.OK)
            {
                //cb_gewässer.Text = "Alle Fotos";
                foto_jetzt = frm_fotoÜbersicht.SelectedIndex;
                pictureBox1.ImageLocation = images[foto_jetzt];

                Label_foto_nr_setzen();
                Set_combobox();

                if (foto_jetzt > 1)
                {
                    button_back.Enabled = true;
                }
            }*/
        }

        private void fotolisteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* frm_fotoliste = new Frm_Fotoliste(this.fotoliste);
            frm_fotoliste.ShowDialog();

            if (frm_fotoliste.DialogResult == DialogResult.OK)
            {
                cb_gewässer.Text = "Alle Fotos";
                foto_jetzt = frm_fotoliste.Index;
                //this.alleFotos_kopie = new Foto[this.alleFotos.Length];
                //this.alleFotos_kopie = alleFotos;
                //pictureBox1.ImageLocation = einstellungen.FotoOrdner + this.alleFotos[frm_fotoliste.Index].DateinameDest;

                Label_foto_nr_setzen();
                Set_combobox();

                if (foto_jetzt > 1)
                {
                    button_back.Enabled = true;
                }
            }*/
        }       

        #endregion

        #region Methoden

        private void ComboBoxFüllen()
        {
            cb_gewässer.Items.Clear();
            cb_gewässer.Items.Add("Alle Fotos");
            cb_gewässer.Text = "Alle Fotos";
            Ordner = cb_gewässer.Text;

            string ConnectionString =
             @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Directory.GetCurrentDirectory() + @"\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT * " +
                                "FROM Ordner";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        cb_gewässer.Items.Add(reader["Name"].ToString());
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


            /*try
            {
                cb_gewässer.Items.Clear();
                cb_gewässer.Items.Add("Alle Fotos");
                string[] ordner = Directory.GetDirectories(Frm_Hauptmenu.FotoOrdner);

                for (int i = 0; i < ordner.Length; i++)
                {
                    DirectoryInfo di = new DirectoryInfo(ordner[i]);
                    cb_gewässer.Items.Add(di.Name);
                }

                cb_gewässer.Text = "Alle Fotos";

                Ordner = cb_gewässer.Text;
            }
            catch
            {
            }*/
        }

        private void Wieviel_fotos()
        {
            try
            {
                cb_anzahlFotos.Items.Clear();

                for (int i = 1; i < fotoliste.Count + 1; i++)
                {
                    //ges_anzahl_fotos++;
                    cb_anzahlFotos.Items.Add(Convert.ToString(i));
                }
            }
            catch
            {
            }
        }

        private void Gewässer_auswählen()
        {
            try
            {
                if (cb_gewässer.Visible == true)
                {
                    Ordner = cb_gewässer.Text;
                    foto_jetzt = 0;

                    if (cb_gewässer.Text == "Alle Fotos")
                    {
                        Aktualisieren();
                    }
                    else
                    {
                        Aktualisieren1(1);
                    }

                    Set_combobox();
                    Label_foto_nr_setzen();
                    pictureBox1.Image = fotoliste[start_foto].Bild;
                }
            }
            catch { }
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

        private void FotoHinzufügen()
        {
            openFileDialog1.Title = "Wählen Sie ihre Fotos aus.";
            openFileDialog1.Filter = "JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png";
            openFileDialog1.FileName = "DeinFoto.jpg";
            openFileDialog1.Multiselect = true;

            DialogResult r = openFileDialog1.ShowDialog();

            if (r == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString =
                 @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";

                Image imag = Image.FromFile(openFileDialog1.FileName);
                Image icon = ResizeImage(imag, 100, 100);
                UpdateIconToFang(icon);

                try
                {
                    con.Open();
                    SqlCommand insertCommand = new SqlCommand(
                "Insert into Foto (Angler_ID, Fang_ID, Kommentar, Bild) Values ('" +"12" + "', '3', 'BlaBlakommentar', @Pic)", con);
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
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void UpdateIconToFang(Image bild)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Fang SET Icon = @Pic WHERE Id = '1'";
                    command.Parameters.Add("Pic", SqlDbType.Image, 0).Value =
                        ConvertImageToByteArray(bild, ImageFormat.Jpeg);

                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void FotoLöschen()
        {
           /* try
            {
                for (int i = 0; i < fotoliste.Count; i++)
                {
                    if (Frm_Hauptmenu.FotoOrdner + fotoliste[i].Dateiname == images[foto_jetzt])
                    {
                        fotoliste.RemoveAt(i);
                        Foto.Speichere_Fotoliste(this.fotoliste, Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Fotoliste + Properties.Settings.Default.Datentyp);
                        break;
                    }
                }

                File.Delete(images[foto_jetzt]);

                images.RemoveAt(foto_jetzt);

                if (foto_jetzt >= images.Count)
                    foto_jetzt = images.Count - 1;

                if ((images != null) && (images.Count != 0))
                {
                    pictureBox1.ImageLocation = images[foto_jetzt];
                    
                }
                else
                {
                    pictureBox1.ImageLocation = "";
                    ZeigeToolTipKeinFoto(true);
                }

                Label_foto_nr_setzen();
                FotoInfos_Set();
            }
            catch { }*/
        }

        private void ZeigeToolTipKeinFoto(bool show)
        {
            if (show)
            {
                toolTip_keinFoto.Show("Kein Foto vorhanden", pictureBox1, 300, 100);
            }
            else
            {
                toolTip_keinFoto.Hide(pictureBox1);
            }
        }

        private void Set_combobox()
        {
            //ges_anzahl_fotos = 0;
            cb_anzahlFotos.Items.Clear();
            for (int i = 1; i < this.fotoliste.Count + 1; i++)
            {
                cb_anzahlFotos.Items.Add(i);
                //ges_anzahl_fotos++;
            }
            cb_anzahlFotos.Text = Convert.ToString(foto_jetzt);
        }

        private void Label_foto_nr_setzen()
        {
            Wieviel_fotos();

            if (this.fotoliste.Count == 0)
            {
                label_foto_von_anzahl.Text = (0) + " von " + 0;
                trackBar_speed.Enabled = false;
                button_vor.Enabled = false;
                button_back.Enabled = false;
                btn_bearbeiten.Enabled = false;
                button_foto_löschen.Enabled = false;
                button_diashow.Enabled = false;
                pictureBox1.ImageLocation = "";
                //cb_gewässer.Visible = false;
                cb_anzahlFotos.Enabled = false;
                cb_anzahlFotos.Text = "0";
                label_foto_von_anzahl.Visible = false;
                cb_anzahlFotos.Visible = false;
                none_foto = true;
                ZeigeToolTipKeinFoto(true);
            }
            else
            {
                ZeigeToolTipKeinFoto(false);
                label_foto_von_anzahl.Text = (foto_jetzt + 1) + " von " + fotoliste.Count;
                cb_anzahlFotos.Enabled = true;
                cb_anzahlFotos.Text = Convert.ToString(foto_jetzt + 1);
                none_foto = false;
                if (!diashowrun)
                {
                    if (foto_jetzt == 0)
                    {
                        button_back.Enabled = false;
                    }
                    //if (ges_anzahl_fotos >= this.images.Count)
                    //{
                        if (foto_jetzt == (fotoliste.Count - 1))
                        {
                            button_vor.Enabled = false;
                        }
                        else
                        {
                            button_vor.Enabled = true;
                        }
                    //}
                    //else
                    //{
                    //    button_vor.Enabled = false;
                    //}
                }
            }
        }

        private void FotoInfos_Set()
        {
            lb_fotoInfo.Text = "";
            label_kommentar.Text = "";

            try
            {
                if ((fotoliste != null) || (fotoliste.Count != 0))
                {
                    for (int j = 0; j < fotoliste.Count; j++)
                    {
                        int id = 0;
                        if (id == fotoliste[foto_jetzt].ID)
                        {
                            label_kommentar.Text = fotoliste[j].Kommentar;
                            for (int i = 0; i < fangliste.Count; i++)
                            {
                                if (fangliste[i].ID == fotoliste[j].ID)
                                {
                                    lb_fotoInfo.Text = "Name: " + this.fangliste[i].ID + ", Fischart: " + this.fangliste[i].Fischart_ID + ", gefangen am: " + this.fangliste[i].Datum.ToShortDateString() + " um " + this.fangliste[i].Uhrzeit.ToShortTimeString() + ", Größe: " + this.fangliste[i].Größe + "cm und einem Gewicht von: " + this.fangliste[i].Gewicht + "kg.";
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            catch { }
        }

        private void MusikAbspielen()
        {
            //Alter Code Zufällige wiedergabe (nur ein Lied wird abgespielt)
            //string[] audioFiles = GetAllSongsInPath();

            //Random rdm = new Random();
            //int rdm_zahl = rdm.Next(0, audioFiles.Length);

            //wmp.URL = audioFiles[rdm_zahl];

            //wmp.controls.play();

            try
            {
                string[] audioFiles = GetAllSongsInPath();
                CreateNewPlaylistAndStartPlaying(audioFiles, "FishingZonePlaylist");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim abspielern der Musik.\n\nInformationen:\n" + ex.ToString(), "Unerwarteter Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateNewPlaylistAndStartPlaying(string[] audioFiles, string playlistName)
        {
            //audioFiles = GetAllSongsInPath();

            WMPLib.IWMPPlaylist playlist = wmp.playlistCollection.newPlaylist(playlistName);
            WMPLib.IWMPMedia media;

            for (int i = 0; i < audioFiles.Length; i++)
            {
                media = wmp.newMedia(audioFiles[i]);
                playlist.appendItem(media);
            }

            //Zufällig
            wmp.settings.setMode("shuffle", true);
            //
            wmp.currentPlaylist = playlist;
            wmp.controls.play();
        }

        private string[] GetAllSongsInPath()
        {
            string[] allFiles = System.IO.Directory.GetFiles(Frm_Hauptmenu.MusikOrdner);
            string[] audioFiles;

            int zähler = 0;

            FileInfo file;

            for (int i = 0; i < allFiles.Length; i++)
            {
                file = new FileInfo(allFiles[i]);

                if ((file.Extension == ".mp3") || (file.Extension == ".wav"))
                {
                    zähler++;
                }
            }

            audioFiles = new string[zähler];

            int index = 0;

            for (int i = 0; i < allFiles.Length; i++)
            {
                file = new FileInfo(allFiles[i]);

                if ((file.Extension == ".mp3") || (file.Extension == ".wav"))
                {
                    audioFiles[index] = allFiles[i];
                    index++;
                }
            }

            return audioFiles;

        }

        #endregion

        private void cb_anzahlFotos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void diashowShuffleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(Frm_Hauptmenu.MusikOrdner))
                Process.Start("explorer.exe", Frm_Hauptmenu.MusikOrdner);
        }

        private void speichernUnterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Fotoliste speichern.";
            saveFileDialog1.Filter = "Fotoliste (*.csv)|*.csv";
            saveFileDialog1.FileName = Properties.Settings.Default.Fotoliste;

            DialogResult save = saveFileDialog1.ShowDialog();

            if (save == DialogResult.OK)
            {
                string destFile = saveFileDialog1.FileName;
                try
                {
                    File.Copy(Frm_Hauptmenu.DatenOrdner + "\\" + Properties.Settings.Default.Fotoliste + Properties.Settings.Default.Datentyp, destFile, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Die Fotoliste konnte nicht gespeichert werden.\n\nInformation:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void importierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*frm_fotolisteImportieren = new Frm_FotolisteImportieren(this.fotoliste);
            frm_fotolisteImportieren.ShowDialog();*/
        }

        private void exportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm_fotolisteExportieren = new Frm_FotolisteExportieren();
            //frm_fotolisteExportieren.ShowDialog();
        }

        private void duplikateSuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_DoppelteFotos frm_doppelteFotos = new Frm_DoppelteFotos();
            frm_doppelteFotos.ShowDialog();
        }

        private void backgroundWorker_MusikLaden_DoWork(object sender, DoWorkEventArgs e)
        {
            MusikAbspielen();
        }

        //#region Extras

        //#region Variablen

        //#endregion

        //#region Forms

        ////Frm_Fotoliste_Importieren frm_fotol_import;
        ////Frm_Fotoliste_Exportieren frm_fotol_export;

        //#endregion

        //#region Methoden

        //#endregion

        //private void btn_extras_Click(object sender, EventArgs e)
        //{
        //    //if (panel_extras.Visible)
        //    //{
        //    //    panel_extras.Visible = false;
        //    //    btn_extras.Text = "v";
        //    //}
        //    //else
        //    //{
        //    //    panel_extras.Visible = true;
        //    //    btn_extras.Text = "-";
        //    //}
        //}

        //private void lb_importieren_Click(object sender, EventArgs e)
        //{
        //    //panel_extras.Visible = false;
        //    //btn_extras.Text = "v";

        //    //frm_fotol_import = new Frm_Fotoliste_Importieren(this.alleFotos, this.einstellungen);
        //    //frm_fotol_import.ShowDialog();

        //    //if (frm_fotol_import.DialogResult == DialogResult.OK)
        //    //{
        //    //    this.alleFotos = new Foto[frm_fotol_import.AlleFotos.Length];
        //    //    this.alleFotos = frm_fotol_import.AlleFotos;

        //    //    ZeigeToolTipKeinFoto(false);
        //    //    //pictureBox_keinFoto.Visible = false;
        //    //    pictureBox1.Visible = true;
        //    //    cb_gewässer.Visible = true;
        //    //    cb_anzahlFotos.Visible = true;
        //    //    label_foto_von_anzahl.Visible = true;
        //    //    lb_fotoInfo.Visible = true;
        //    //    button_diashow.Enabled = true;

        //    //    ComboBoxFüllen();
        //    //    Gewässer_auswählen();
        //    //    cb_gewässer.Enabled = true;

        //    //    button_foto_löschen.Enabled = true;
        //    //    btn_bearbeiten.Enabled = true;

        //    //    //lb_speichern.Enabled = true;
        //    //    //lb_importieren.Enabled = true;
        //    //    //lb_exportieren.Enabled = true;
        //    //}
        //}

        //private void lb_exportieren_Click(object sender, EventArgs e)
        //{
        //    //panel_extras.Visible = false;
        //    //btn_extras.Text = "v";

        //    folderBrowserDialog1.Description = "Wähle einen Ordner aus. (wo die Fotoliste u. Fotos kopiert werden.)";
        //    DialogResult folderdialog = folderBrowserDialog1.ShowDialog();

        //    if (folderdialog == DialogResult.OK)
        //    {
        //        frm_fotol_export = new Frm_Fotoliste_Exportieren(this.alleFotos, this.einstellungen, folderBrowserDialog1.SelectedPath);
        //        frm_fotol_export.ShowDialog();
        //    }
        //}

        //private void lb_speichern_Click(object sender, EventArgs e)
        //{
        //    //panel_extras.Visible = false;
        //    //btn_extras.Text = "v";

        //    saveFileDialog1.Title = "Fotoliste speichern";
        //    saveFileDialog1.Filter = "Fotoliste (*.fzp)|*.fzp|Alle Datein (*.*)|*.*";
        //    saveFileDialog1.FileName = einstellungen.Dateiname_Fotoliste;

        //    DialogResult save = saveFileDialog1.ShowDialog();

        //    if (save == DialogResult.OK)
        //    {
        //        try
        //        {
        //            File.Copy(einstellungen.Pfad + einstellungen.Dateiname_Fotoliste, saveFileDialog1.FileName, true);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Die Fotoliste konnte nicht kopiert werden.\n\nInformation:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        //private void diashowShuffleToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //}

        //#endregion

    }
}
