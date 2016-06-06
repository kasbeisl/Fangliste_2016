using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Diagnostics;
using FanglisteLibrary;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Imaging;

namespace Fangliste_2016
{
    public partial class Frm_Hauptmenu : Form
    {
        #region Variablen, Klassen, Arrys, Sound Def., Forms

        List<Angler> anglerliste;
        Angler1 aktueller_Fischer;
        List<Fischarten> fischartenliste;
        List<Fangliste1> fangliste;
        List<Foto> fotoliste = null;

        //
        public static string EigeneDokumenteOrdner = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string DatenOrdner = EigeneDokumenteOrdner + "\\" + Properties.Settings.Default.FanglisteOrdner + "\\" + Properties.Settings.Default.DatenOrdner + "\\";
        public static string MusikOrdner = EigeneDokumenteOrdner + "\\" + Properties.Settings.Default.FanglisteOrdner + "\\" + Properties.Settings.Default.MusikOrdner + "\\";
        public static string FotoOrdner = EigeneDokumenteOrdner + "\\" + Properties.Settings.Default.FanglisteOrdner + "\\" + Properties.Settings.Default.FotoOrdner + "\\";

        SoundPlayer clickSound;
        bool play = false;

        #endregion

        #region Forms

        //Frm_LoadDialog frm_loadDialog;
        Frm_NamenAuswählen namen_auswählen;
        Frm_Hit_Parade hitparade;
        Frm_Alle_Fänge frm_alleFänge;
        Frm_Fänge_je_Jahr frm_fäng_je_jahr;
        Frm_PersönlicheFangliste frm_persönlicheFangliste;
        Frm_Fischeintragen frm_fischEintragen;
        Frm_FotoGallerie1 frm_fotoGallerie;
        Frm_LakeTrophy frm_trophy;
        Frm_FanglisteBearbeiten frm_fanglisteBearbeiten;
        Frm_Statistik frm_statistik;
        Frm_Einstellungen frm_einstellungen;
        Frm_AboutBox frm_aboutbox;
        Frm_FanglisteExportExcel frm_exportExcel;
        Frm_FanglisteImportieren frm_importieren;
        Frm_FischKalkulator frm_fischKalkulator;
        Frm_Fischartenliste frm_fischartenliste;
        Frm_Anglerdaten frm_anglerdaten;
        Frm_Umrechner frm_umrechner;
        Frm_Fangliste_Backup frm_fangliste_Backup;
        Frm_Download frm_download;

        #endregion

        #region Konstruktor

        public Frm_Hauptmenu()
        {
            InitializeComponent();

            try
            {
                if (File.Exists(Properties.Settings.Default.Data + "\\" + Properties.Settings.Default.ClickSound))
                    clickSound = new SoundPlayer(Properties.Settings.Default.Data + "\\" + Properties.Settings.Default.ClickSound);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fehler");
            }
        }

        private void Frm_Hauptmenu_Load(object sender, EventArgs e)
        {
            lb_jahresfänge.Text += " " + DateTime.Today.Year;

            PrüfenObOrdnerUndDatenExistieren();
            /*frm_loadDialog = new Frm_LoadDialog();
            frm_loadDialog.ShowDialog();*/

            NamenWählen();

            //LadeAlteFanglisteInDatenbank();

            /*if (frm_loadDialog.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.fangliste = frm_loadDialog.GetFangliste;
                this.anglerliste = frm_loadDialog.GetAnglerliste; ;
                this.fischartenliste = frm_loadDialog.GetFischartenliste;
                this.fotoliste = frm_loadDialog.GetFotoliste;

                NamenWählen();
            }
            else
            {
                MessageBox.Show("Daten konnten nicht geladen werden.", "Fehler");
                Application.Exit();
            }*/
        }

        private void LadeAlteFanglisteInDatenbank()
        {
            SQLCollection.DeleteTabel();

            List<Gewässer> g = new List<Gewässer>();
            List<Fischarten> f = new List<Fischarten>();
            List<Angler1> a = new List<Angler1>();

            string ConnectionString = SQLCollection.GetConnectionString();
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT * " +
                                "FROM Gewässer";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    g.Add(new Gewässer(Convert.ToInt16(reader["Id"]), reader["Name"].ToString()));
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
            //-----------------------------------------
            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT * " +
                                "FROM Fisch";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    f.Add(new Fischarten(Convert.ToInt16(reader["Id"]), reader["Name"].ToString(), Convert.ToDouble(reader["KF"])));
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

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT * " +
                                "FROM Angler";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Bitmap bmp = null;

                while (reader.Read())
                {
                    byte[] picData = reader["Bild"] as byte[] ?? null;

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

                    a.Add(new Angler1(Convert.ToInt16(reader["Id"]), reader["Name"].ToString(), bmp));
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

            OpenFileDialog op = new OpenFileDialog();
            DialogResult r = op.ShowDialog();
            if (r == DialogResult.OK)
            {
                fangliste = new List<Fangliste1>();
                List<Fangliste> fanglisteZuLaden;
                StreamReader leser1 = new StreamReader(op.FileName);
                fanglisteZuLaden = new List<Fangliste>();

                while (leser1.Peek() >= 0)
                {
                    fanglisteZuLaden.Add(new Fangliste(leser1.ReadLine()));
                }

                int angler_id = 0;
                int fisch_id = 0;
                int gewässer_id = 0;

                for (int i = 0; i < fanglisteZuLaden.Count; i++)
                {
                    for (int j = 0; j < a.Count; j++)
                    {
                        if (a[j].Name == fanglisteZuLaden[i].Name)
                        {
                            angler_id = a[j].ID;
                            break;
                        }
                    }

                    for (int j = 0; j < f.Count; j++)
                    {
                        if (f[j].Name == fanglisteZuLaden[i].Fischart)
                        {
                            fisch_id = f[j].ID;
                            break;
                        }
                    }

                    for (int j = 0; j < g.Count; j++)
                    {
                        if (g[j].Name == fanglisteZuLaden[i].Gewässer)
                        {
                            gewässer_id = g[j].ID;
                            break;
                        }
                    }

                    try
                    {
                        fangliste.Add(new Fangliste1(0, angler_id, fisch_id, fanglisteZuLaden[i].Größe, fanglisteZuLaden[i].Gewicht, gewässer_id, fanglisteZuLaden[i].Datum, fanglisteZuLaden[i].Uhrzeit, fanglisteZuLaden[i].Platzbesch, fanglisteZuLaden[i].Köderbeschr, fanglisteZuLaden[i].Tiefe, fanglisteZuLaden[i].Lufttemperatur, 0, fanglisteZuLaden[i].Wetter, fanglisteZuLaden[i].Zurückgesetzt, ""));
                    }
                    catch ( Exception ex )
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    
                }

                leser1.Close();
            }

            for (int i = 0; i < fangliste.Count; i++)
            {
                try
                {
                    con.Open();
                    SqlCommand insertCommand = new SqlCommand(
                "Insert into Fang (Angler_ID, Fischart_ID, Länge, Gewicht, Gewässer_ID, Köder, Angelplatz, Tiefe, Lufttemperatur, Wassertemperatur, Datum, Uhrzeit, Zurückgesetzt, Wetter, Kommentar) Values (@Angler_ID, @Fischart_ID, @Länge, @Gewicht, @Gewässer_ID, @Köder, @Angelplatz, @Tiefe, @Lufttemperatur, @Wassertemperatur, @Datum, @Uhrzeit, @Zurückgesetzt, @Wetter, @Kommentar)", con);
                    insertCommand.Parameters.Add("Angler_ID", SqlDbType.Int, 0).Value = fangliste[i].Angler_ID;
                    insertCommand.Parameters.Add("Fischart_ID", SqlDbType.Int, 0).Value = fangliste[i].Fischart_ID;
                    insertCommand.Parameters.Add("Länge", SqlDbType.Float).Value = fangliste[i].Größe;
                    insertCommand.Parameters.Add("Gewicht", SqlDbType.Float).Value = fangliste[i].Gewicht;
                    insertCommand.Parameters.Add("Gewässer_ID", SqlDbType.Int, 0).Value = fangliste[i].Gewässer_ID;
                    insertCommand.Parameters.Add("Köder", SqlDbType.Text, 0).Value = fangliste[i].Köderbeschr;
                    insertCommand.Parameters.Add("Angelplatz", SqlDbType.Text, 0).Value = fangliste[i].Platzbesch;
                    insertCommand.Parameters.Add("Tiefe", SqlDbType.Float).Value = fangliste[i].Tiefe;
                    insertCommand.Parameters.Add("Lufttemperatur", SqlDbType.Float).Value = fangliste[i].Lufttemperatur;
                    insertCommand.Parameters.Add("Wassertemperatur", SqlDbType.Float).Value = fangliste[i].Wassertemperatur;
                    insertCommand.Parameters.Add("Datum", SqlDbType.Date, 0).Value = fangliste[i].Datum;
                    insertCommand.Parameters.Add("Uhrzeit", SqlDbType.DateTime, 0).Value = fangliste[i].Uhrzeit;
                    insertCommand.Parameters.Add("Zurückgesetzt", SqlDbType.Bit, 0).Value = fangliste[i].Zurückgesetzt;
                    insertCommand.Parameters.Add("Wetter", SqlDbType.VarChar, 0).Value = fangliste[i].Wetter;
                    insertCommand.Parameters.Add("Kommentar", SqlDbType.Text, 0).Value = fangliste[i].Kommentar;

                    int queryResult = insertCommand.ExecuteNonQuery();
                    if (queryResult == 1)
                        Console.WriteLine("Erfolgreich aktualisiert.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Fehler");
                }
                finally
                {
                    con.Close();
                }
            }
        }


        #endregion

        #region Methoden

        private void NamenWählen()
        {
            namen_auswählen = new Frm_NamenAuswählen();
            DialogResult Name_ok = namen_auswählen.ShowDialog();

            if (Name_ok == DialogResult.OK)
            {
                this.aktueller_Fischer = namen_auswählen.Ausgewählter_Fischer;

                label_fischername.Text = this.aktueller_Fischer.Name;

                GesAnzahlderFänge_Hecht_Zander_Barsch_Andere();
            }

            if (Name_ok != DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Anglerliste_auslesen()
        {
            try
            {
                this.anglerliste = Angler.LadenAsList(DatenOrdner, Properties.Settings.Default.Anglerliste + Properties.Settings.Default.Datentyp);
            }
            catch
            {
                this.anglerliste = new List<Angler>();
            }
        }

        private void Fotoliste_auslesen()
        {
            try
            {
                this.fotoliste = Foto.LadenAsList(DatenOrdner, Properties.Settings.Default.Fotoliste + Properties.Settings.Default.Datentyp);
            }
            catch
            {
                this.fotoliste = new List<Foto>();
            }
        }

        private void Fangliste_auslesen()
        {
            /*try
            {
                this.fangliste = Fangliste.LadenAsList(DatenOrdner, Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp);
            }
            catch
            {
                this.fangliste = new List<Fangliste>();
            }*/
        }

        private void GesAnzahlderFänge_Hecht_Zander_Barsch_Andere()
        {
            int zählerHecht = 0; //2
            int zählerZander = 0; //3
            int zählerBarsch = 0; //4
            int zählerAndere = 0;

            zählerHecht = AnzahlDerFängeNachNameUndFischart(aktueller_Fischer.ID, 2);
            zählerZander = AnzahlDerFängeNachNameUndFischart(aktueller_Fischer.ID, 3);
            zählerBarsch = AnzahlDerFängeNachNameUndFischart(aktueller_Fischer.ID, 4);
            zählerAndere = AnzahlDerFängeNachNameUndFischart_AusHechtZanderBarsch(aktueller_Fischer.ID);

            //ZählerSchleife
            /*
            #region Hecht
            try
            {
                for (int i = 0; i < fangliste.Count; i++)
                {
                    if ("Hecht" == fangliste[i].Fischart)
                    {
                        if (this.aktueller_Fischer.Name == fangliste[i].Name)
                        {
                            zählerHecht++;
                        }
                    }
                }
            }
            catch { }
            #endregion

            #region Zander
            try
            {
                for (int i = 0; i < fangliste.Count; i++)
                {
                    if ("Zander" == fangliste[i].Fischart)
                    {
                        if (this.aktueller_Fischer.Name == fangliste[i].Name)
                        {
                            zählerZander++;
                        }
                    }
                }
            }
            catch { }
            #endregion

            #region Barsch
            try
            {
                for (int i = 0; i < fangliste.Count; i++)
                {
                    if ("Barsch" == fangliste[i].Fischart)
                    {
                        if (this.aktueller_Fischer.Name == fangliste[i].Name)
                        {
                            zählerBarsch++;
                        }
                    }
                }
            }
            catch { }
            #endregion

            #region Andere
            try
            {
                for (int i = 0; i < fangliste.Count; i++)
                {
                    if (("Hecht" != fangliste[i].Fischart) && ("Zander" != fangliste[i].Fischart) && ("Barsch" != fangliste[i].Fischart))
                    {
                        if (this.aktueller_Fischer.Name == fangliste[i].Name)
                        {
                            zählerAndere++;
                        }
                    }
                }
            }
            catch { }
            #endregion*/

            //Anzeige
            label_Hecht.Text = Convert.ToString(zählerHecht);
            label_Zander.Text = Convert.ToString(zählerZander);
            label_Barsch.Text = Convert.ToString(zählerBarsch);
            label_Andere.Text = Convert.ToString(zählerAndere);
        }

        private int AnzahlDerFängeNachNameUndFischart(int angler_id, int fischart_id)
        {
            int count = 0;

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT COUNT(*) Angler_ID FROM Fang WHERE Angler_ID = '" + angler_id + "' AND Fischart_ID = '" + fischart_id + "'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                count = Convert.ToInt32(cmd.ExecuteScalar());

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

            return count;
        }

        private int AnzahlDerFängeNachNameUndFischart_AusHechtZanderBarsch(int angler_id)
        {
            int count = 0;

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT COUNT(*) Angler_ID FROM Fang WHERE Angler_ID = '" + angler_id + "' AND NOT Fischart_ID = '2' AND NOT Fischart_ID = '3' AND NOT Fischart_ID = '4'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                count = Convert.ToInt32(cmd.ExecuteScalar());

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

            return count;
        }

        private void FischartenListe_auslesen()
        {
            try
            {
                this.fischartenliste = Fischarten.Laden(DatenOrdner, Properties.Settings.Default.Fischartenliste + Properties.Settings.Default.Datentyp);
            }
            catch
            {
                this.fischartenliste = new List<Fischarten>();
            }
        }

        private void PrüfenObOrdnerUndDatenExistieren()
        {
            if (!Directory.Exists(Properties.Settings.Default.FanglisteOrdner))
            {
                Directory.CreateDirectory(DatenOrdner);
            }

            if (!Directory.Exists(DatenOrdner))
            {
                Directory.CreateDirectory(DatenOrdner);
            }

            if (!Directory.Exists(DatenOrdner+ "Backup"))
            {
                Directory.CreateDirectory(DatenOrdner+ "Backup");
            }

            if (!Directory.Exists(FotoOrdner))
            {
                Directory.CreateDirectory(FotoOrdner);
            }

            if (!Directory.Exists(MusikOrdner))
            {
                Directory.CreateDirectory(MusikOrdner);
            }

            if (!File.Exists(DatenOrdner + "\\" + Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp))
            {
                File.WriteAllText(DatenOrdner + "\\" + Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp, "");
            }

            if (!File.Exists(DatenOrdner + "\\" + Properties.Settings.Default.Anglerliste + Properties.Settings.Default.Datentyp))
            {
                File.WriteAllText(DatenOrdner + "\\" + Properties.Settings.Default.Anglerliste + Properties.Settings.Default.Datentyp, "");
            }

            if (!File.Exists(DatenOrdner + "\\" + Properties.Settings.Default.Fischartenliste + Properties.Settings.Default.Datentyp))
            {
                File.WriteAllText(DatenOrdner + "\\" + Properties.Settings.Default.Fischartenliste + Properties.Settings.Default.Datentyp, "");
                this.fischartenliste = Fischarten.Standart_FischartenListe();
                Fischarten.Speichern(this.fischartenliste, DatenOrdner, Properties.Settings.Default.Fischartenliste + Properties.Settings.Default.Datentyp);
            }

            if (!File.Exists(DatenOrdner + "\\" + Properties.Settings.Default.Fotoliste + Properties.Settings.Default.Datentyp))
            {
                File.WriteAllText(DatenOrdner + "\\" + Properties.Settings.Default.Fotoliste + Properties.Settings.Default.Datentyp, "");
            }
        }

        private void StartInternetExplorer(string link)
        {
            try
            {
                Process.Start("IEXPLORE.EXE", link);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Der Internet Browser konnte nicht gestartet werden.\n\nInformation:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Buttons und Events

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* frm_exportExcel = new Frm_FanglisteExportExcel(this.fangliste, this.aktueller_Fischer);
            frm_exportExcel.ShowDialog();*/
        }

        private void nachFangWählenToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* Frm_alleFänge_nur_Liste nachFangExport = new Frm_alleFänge_nur_Liste(this.fangliste, true);
            nachFangExport.ShowDialog();

            if (nachFangExport.Ausgewählt == DialogResult.OK)
            {
                saveFileDialog1.Title = "Fangliste exportieren.";
                saveFileDialog1.Filter = "Fangliste (*.csv)|*.csv";
                saveFileDialog1.FileName = "Fangliste.csv";

                DialogResult save = saveFileDialog1.ShowDialog();

                if (save == DialogResult.OK)
                {
                    try
                    {
                        int zähler = 0;

                        for (int i = 0; i < nachFangExport.FangChecked.Count; i++)
                        {
                            if (nachFangExport.FangChecked[i] == true)
                            {
                                zähler++;
                            }
                        }

                        List<Fangliste> export = new List<Fangliste>();
                        int zähler2 = 0;

                        for (int i = 0; i < nachFangExport.AlleFänge.Count; i++)
                        {
                            if (nachFangExport.FangChecked[i] == true)
                            {
                                export.Add(nachFangExport.AlleFänge[i]);
                                zähler2++;
                            }
                        }

                        string pfad = Path.GetDirectoryName(saveFileDialog1.FileName) + "\\";
                        string datei = Path.GetFileName(saveFileDialog1.FileName);
                        Fangliste.SpeichernAsList(export, pfad, datei);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unbekannter Fehler.\n\nInformationen:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }*/
        }

        private void lb_Hitparade_Click(object sender, EventArgs e)
        {
            hitparade = new Frm_Hit_Parade();
            hitparade.ShowDialog();
        }

        private void lb_jahresfänge_Click(object sender, EventArgs e)
        {
            frm_fäng_je_jahr = new Frm_Fänge_je_Jahr();
            frm_fäng_je_jahr.ShowDialog();
        }

        private void lb_alleFänge_Click(object sender, EventArgs e)
        {
            frm_alleFänge = new Frm_Alle_Fänge();
            frm_alleFänge.ShowDialog();
        }

        private void lb_persönlicheFangliste_Click(object sender, EventArgs e)
        {
            frm_persönlicheFangliste = new Frm_PersönlicheFangliste(this.aktueller_Fischer);
            frm_persönlicheFangliste.ShowDialog();
        }

        private void lb_fisch_eintragen_Click(object sender, EventArgs e)
        {
            frm_fischEintragen = new Frm_Fischeintragen();
            frm_fischEintragen.ShowDialog();
            GesAnzahlderFänge_Hecht_Zander_Barsch_Andere();
            /*if (frm_fischEintragen.DialogResult == DialogResult.OK)
            {
                File.Copy(DatenOrdner + "\\" + Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp, 
                    DatenOrdner + "\\" + "Backup\\" + Properties.Settings.Default.Fangliste + "_" + DateTime.Now.ToShortDateString() + Properties.Settings.Default.Datentyp, true);
                
                this.fangliste.Add(frm_fischEintragen.Liefere_Fischeintrag);

                
                Fangliste.SpeichernAsList(this.fangliste, DatenOrdner, Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp);

                GesAnzahlderFänge_Hecht_Zander_Barsch_Andere();
            }*/
        }

        private void lb_foto_gallerie_Click(object sender, EventArgs e)
        {
            frm_fotoGallerie = new Frm_FotoGallerie1();
            frm_fotoGallerie.ShowDialog();
        }

        private void lb_LakeTrophy_Click(object sender, EventArgs e)
        {
            /*if (fangliste.Count < 2)
            {
                MessageBox.Show("Zu wenig einträge in der Fangliste.", "Information");
            }
            else
            {*/
                frm_trophy = new Frm_LakeTrophy();
                frm_trophy.ShowDialog();
            //}
        }

        private void lb_statistik_Click(object sender, EventArgs e)
        {
            frm_statistik = new Frm_Statistik();
            frm_statistik.ShowDialog();
        }

        private void wechselnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamenWählen();
        }

        private void stammdatenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm_userBearbeiten = new Frm_UserBearbeiten(this.alle_Fänge, this.alleFischer, this.aktueller_Fischer, this.einstellungen);
            //frm_userBearbeiten.ShowDialog();

            //if (frm_userBearbeiten.DialogResult == DialogResult.OK)
            //{
            //    if (frm_userBearbeiten.Namen_Ändern)
            //    {
            //        this.alle_Fänge = frm_userBearbeiten.AlleFänge_geändert;

            //        this.aktueller_Fischer = frm_userBearbeiten.Neuer_FischerName;

            //        Label_Benutzername.Text = aktueller_Fischer.Kürzel;

            //        GesAnzahlderFänge_Hecht_Zander_Barsch_Andere();
            //    }
            //}

            frm_anglerdaten = new Frm_Anglerdaten(this.aktueller_Fischer);
            DialogResult r = frm_anglerdaten.ShowDialog();

            if (r == DialogResult.OK)
            {

                this.aktueller_Fischer = frm_anglerdaten.AktuellerAngler;
                label_fischername.Text = this.aktueller_Fischer.Name;

                /*this.fangliste = frm_anglerdaten.AlleFänge_geändert;
                if (frm_anglerdaten.Neuer_FischerName != null)
                {
                    this.aktueller_Fischer = frm_anglerdaten.Neuer_FischerName;
                    label_fischername.Text = aktueller_Fischer.Name;
                }

                GesAnzahlderFänge_Hecht_Zander_Barsch_Andere();

                try
                {
                    Fangliste.SpeichernAsList(this.fangliste, DatenOrdner, Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Fehler");
                }*/
            }
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Hostname != "")
            {
                if (Properties.Settings.Default.Username != "")
                {
                    if (Properties.Settings.Default.Passwort != "")
                    {
                        DialogResult r = MessageBox.Show("Soll die Fangliste auf den Server geladen werden?", "Upload", MessageBoxButtons.YesNo);

                        if (r == System.Windows.Forms.DialogResult.Yes)
                        {
                            Frm_Upload frm_upload = new Frm_Upload();
                            frm_upload.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kein Passwort.", "Server Information");
                        frm_einstellungen = new Frm_Einstellungen();
                        frm_einstellungen.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Kein Username.", "Server Information");
                    frm_einstellungen = new Frm_Einstellungen();
                    frm_einstellungen.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Kein Hostname.", "Server Information");
                frm_einstellungen = new Frm_Einstellungen();
                frm_einstellungen.ShowDialog();
            }
        }

        private void bearbeitenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_fanglisteBearbeiten = new Frm_FanglisteBearbeiten();
            DialogResult fangliste_speichern = frm_fanglisteBearbeiten.ShowDialog();

            if (fangliste_speichern == DialogResult.OK)
            {
                //this.fangliste = frm_fanglisteBearbeiten.Aktuelle_Fangliste;

                /*try
                {
                    Fangliste.SpeichernAsList(this.fangliste, DatenOrdner, Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fangliste konnte nicht gespeichert werden\n\nInformation: " + ex.ToString(), "Fehler");
                }*/

                //frm_datenSpeichern = new Frm_Daten_Speichern(frm_fanglisteBearbeiten.Aktuelle_Fangliste, this.einstellungen);

                //DialogResult speichern_ok = frm_datenSpeichern.ShowDialog();

                //if (speichern_ok == DialogResult.OK)
                //{
                    GesAnzahlderFänge_Hecht_Zander_Barsch_Andere();
                //}
            }
        }

        private void exportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void importierentoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_importieren = new Frm_FanglisteImportieren();
            frm_importieren.ShowDialog();

            if (frm_importieren.DialogResult == DialogResult.OK)
            {
                File.Copy(DatenOrdner + "\\" + Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp,
                    DatenOrdner + "\\" + "Backup\\" + Properties.Settings.Default.Fangliste + "_" + DateTime.Now.ToShortDateString() + Properties.Settings.Default.Datentyp, true);

                //this.fangliste = frm_importieren.AlleFänge;
                GesAnzahlderFänge_Hecht_Zander_Barsch_Andere();
            }
        }

        private void speichernUnterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Fangliste speichern.";
            saveFileDialog1.Filter = "Fangliste (*.csv)|*.csv";
            saveFileDialog1.FileName = Properties.Settings.Default.Fangliste;

            DialogResult save = saveFileDialog1.ShowDialog();

            if (save == DialogResult.OK)
            {
                List<Fangliste1> liste = new List<Fangliste1>();

                string ConnectionString = SQLCollection.GetConnectionString();
                //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
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
                            liste.Add(new Fangliste1(Convert.ToInt16(reader["Id"]), Convert.ToInt16(reader["Angler_ID"]), Convert.ToInt16(reader["Fischart_ID"]), Convert.ToDouble(reader["Länge"]), Convert.ToDouble(reader["Gewicht"]), Convert.ToInt16(reader["Gewässer_ID"]), Convert.ToDateTime(reader["Datum"]), Convert.ToDateTime(reader["Uhrzeit"]), reader["Angelplatz"].ToString(), reader["Köder"].ToString(), Convert.ToDouble(reader["Tiefe"]), Convert.ToDouble(reader["Lufttemperatur"]), Convert.ToDouble(reader["Wassertemperatur"]), reader["Wetter"].ToString(), Convert.ToBoolean(reader["Zurückgesetzt"]), reader["Kommentar"].ToString()));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    reader.Close();
                    con.Close();

                    if (liste != null)
                        Fangliste1.SpeichernAsList(liste, saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                }



                string destFile = saveFileDialog1.FileName;
                try
                {
                    //File.Copy(DatenOrdner + "\\" + Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp, destFile, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Die Fangliste konnte nicht gespeichert werden.\n\nInformation:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void infosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_aboutbox = new Frm_AboutBox();
            frm_aboutbox.ShowDialog();
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_einstellungen = new Frm_Einstellungen();
            frm_einstellungen.ShowDialog();
        }

        private void toolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Ist nicht verfügbar.", "Demo version");

            try
            {
                Process.Start("FishingZoneTool.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fischKaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_fischKalkulator = new Frm_FischKalkulator();
            frm_fischKalkulator.ShowDialog();
        }

        private void fischartenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_fischartenliste = new Frm_Fischartenliste();
            frm_fischartenliste.ShowDialog();

            if(frm_fischartenliste.EsWurdeGespeichert)
                this.fischartenliste = frm_fischartenliste.Fischartenliste;
        }

        private void gewässerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void umrechnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_umrechner = new Frm_Umrechner();
            frm_umrechner.ShowDialog();
        }

        #endregion

        #region Links

        private void fischervereinTraunseeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartInternetExplorer("http://www.traunseefischer.at");
        }

        private void beissindexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartInternetExplorer("http://beissindex.de");
        }

        private void anglerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartInternetExplorer("http://oberoesterreich.anglerinfo.at/");
        }

        private void bissanzeigerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartInternetExplorer("http://bissanzeiger.net/");
        }

        #endregion

        #region Mouse Events

        private void lb_Hitparade_MouseMove(object sender, MouseEventArgs e)
        {
            lb_Hitparade.Font = new Font("Segoe Print", 11, FontStyle.Underline);
            try
            {
                if (play == false)
                {
                    play = true;
                    if (Properties.Settings.Default.PlaySound == true)
                        clickSound.Play();
                }
            }
            catch { }
        }

        private void lb_Hitparade_MouseLeave(object sender, EventArgs e)
        {
            lb_Hitparade.Font = new Font("Segoe Print", 11);
            //clickSound.Stop();
            play = false;
        }

        private void lb_jahresfänge_MouseMove(object sender, MouseEventArgs e)
        {
            lb_jahresfänge.Font = new Font("Segoe Print", 11, FontStyle.Underline);
            try
            {
                if (play == false)
                {
                    play = true;
                    if (Properties.Settings.Default.PlaySound == true)
                        clickSound.Play();
                }
            }
            catch { }
        }

        private void lb_jahresfänge_MouseLeave(object sender, EventArgs e)
        {
            lb_jahresfänge.Font = new Font("Segoe Print", 11);
            //clickSound.Stop();
            play = false;
        }

        private void lb_alleFänge_MouseMove(object sender, MouseEventArgs e)
        {
            lb_alleFänge.Font = new Font("Segoe Print", 11, FontStyle.Underline);
            try
            {
                if (play == false)
                {
                    play = true;
                    if (Properties.Settings.Default.PlaySound == true)
                        clickSound.Play();
                }
            }
            catch { }
        }

        private void lb_alleFänge_MouseLeave(object sender, EventArgs e)
        {
            lb_alleFänge.Font = new Font("Segoe Print", 11);
            //clickSound.Stop();
            play = false;
        }

        private void lb_persönlicheFangliste_MouseMove(object sender, MouseEventArgs e)
        {
            lb_persönlicheFangliste.Font = new Font("Segoe Print", 11, FontStyle.Underline);
            try
            {
                if (play == false)
                {
                    play = true;
                    if (Properties.Settings.Default.PlaySound == true)
                        clickSound.Play();
                }
            }
            catch { }
        }

        private void lb_persönlicheFangliste_MouseLeave(object sender, EventArgs e)
        {
            lb_persönlicheFangliste.Font = new Font("Segoe Print", 11);
            //clickSound.Stop();
            play = false;
        }

        private void lb_fisch_eintragen_MouseMove(object sender, MouseEventArgs e)
        {
            lb_fisch_eintragen.Font = new Font("Segoe Print", 11, FontStyle.Underline);
            try
            {
                if (play == false)
                {
                    play = true;
                    if (Properties.Settings.Default.PlaySound == true)
                        clickSound.Play();
                }
            }
            catch { }
        }

        private void lb_fisch_eintragen_MouseLeave(object sender, EventArgs e)
        {
            lb_fisch_eintragen.Font = new Font("Segoe Print", 11);
            //clickSound.Stop();
            play = false;
        }

        private void lb_foto_gallerie_MouseMove(object sender, MouseEventArgs e)
        {
            lb_foto_gallerie.Font = new Font("Segoe Print", 11, FontStyle.Underline);
            try
            {
                if (play == false)
                {
                    play = true;
                    if (Properties.Settings.Default.PlaySound == true)
                        clickSound.Play();
                }
            }
            catch { }
        }

        private void lb_foto_gallerie_MouseLeave(object sender, EventArgs e)
        {
            lb_foto_gallerie.Font = new Font("Segoe Print", 11);
            //clickSound.Stop();
            play = false;
        }

        private void lb_LakeTrophy_MouseMove(object sender, MouseEventArgs e)
        {
            lb_LakeTrophy.Font = new Font("Segoe Print", 11, FontStyle.Underline);
            try
            {
                if (play == false)
                {
                    play = true;
                    if (Properties.Settings.Default.PlaySound == true)
                        clickSound.Play();
                }
            }
            catch { }
        }

        private void lb_LakeTrophy_MouseLeave(object sender, EventArgs e)
        {
            lb_LakeTrophy.Font = new Font("Segoe Print", 11);
            //clickSound.Stop();
            play = false;
        }

        private void lb_statistik_MouseMove(object sender, MouseEventArgs e)
        {
            lb_statistik.Font = new Font("Segoe Print", 11, FontStyle.Underline);
            try
            {
                if (play == false)
                {
                    play = true;
                    if (Properties.Settings.Default.PlaySound == true)
                        clickSound.Play();
                }
            }
            catch { }
        }

        private void lb_statistik_MouseLeave(object sender, EventArgs e)
        {
            lb_statistik.Font = new Font("Segoe Print", 11);
            clickSound.Stop();
            play = false;
        }

        #endregion

        #region Drucken

        private void DruckerMethode(string documentName, List<Fangliste> fangliste)
        {
            printDocument1.DocumentName = documentName;
            printDocument1.PrinterSettings = printDialog1.PrinterSettings;
            //
            dataGridView1 = new DataGridView();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("colIndex", "Index");
            dataGridView1.Columns.Add("colName", "Name");
            dataGridView1.Columns.Add("colFischart", "Fischart");
            dataGridView1.Columns.Add("colGröße", "Größe");
            dataGridView1.Columns.Add("colGewicht", "Gewicht");
            dataGridView1.Columns.Add("colGewässer", "Gewässer");
            dataGridView1.Columns.Add("colDatum", "Datum");
            dataGridView1.Columns.Add("colUhrzeit", "Uhrzeit");
            dataGridView1.Columns.Add("colAngelplatz", "Angelplatz");
            dataGridView1.Columns.Add("colKöder", "Köder");
            dataGridView1.Columns.Add("colTiefe", "Tiefe");
            dataGridView1.Columns.Add("colTemp", "Temperatur");
            dataGridView1.Columns.Add("colWetter", "Wetter");

            for (int i = 0; i < fangliste.Count; i++)
            {
                string[] listToPrint = new string[fangliste[i].GetListToDraw.Length + 1];
                int index = i + 1;
                listToPrint[0] = index.ToString();
                int count = 1;
                for (int a = 0; a < fangliste[i].GetListToDraw.Length; a++)
                {
                    listToPrint[count] = fangliste[i].GetListToDraw[a];
                    count++;
                }

                dataGridView1.Rows.Add(listToPrint);
            }

            printDocument1.Print();
        }

        private void hitparadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printFont = new Font("Arial", 10);

            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                /*List<Fangliste> hecht = Fangliste.Spezifische_Fischart_Liste("Hecht", Frm_Hit_Parade.GetFanglisteNachFischart(this.fangliste, "Hecht"));
                List<Fangliste> zander = Fangliste.Spezifische_Fischart_Liste("Zander", Frm_Hit_Parade.GetFanglisteNachFischart(this.fangliste, "Hecht"));
                List<Fangliste> barsch = Fangliste.Spezifische_Fischart_Liste("Barsch", Frm_Hit_Parade.GetFanglisteNachFischart(this.fangliste, "Hecht"));
                List<Fangliste> andere = Fangliste.Andere_Fischarten_Liste(this.fangliste);

                DruckerMethode("Hitparade - Hecht", hecht);
                DruckerMethode("Hitparade - Zander", zander);
                DruckerMethode("Hitparade - Barsch", barsch);
                DruckerMethode("Hitparade - Andere", andere);*/
            }
        }

        private void fängeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printFont = new Font("Arial", 10);

            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                //List<Fangliste> heurige_Fänge = Fangliste.Fangliste_je_jahr(this.fangliste);

                //DruckerMethode("Fangliste " + DateTime.Today.Year, heurige_Fänge);
            }
        }

        private void alleFängeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printFont = new Font("Arial", 10);

            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                //DruckerMethode("Fangliste", this.fangliste);
            }
        }

        private void persFanglisteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printFont = new Font("Arial", 10);

            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                //List<Fangliste> persönliche_Liste = Fangliste.PersönlicheFangliste(this.fangliste, this.aktueller_Fischer);

                //DruckerMethode("Fangliste von " + aktueller_Fischer.Name, persönliche_Liste);
            }
        }

        #region variablen

        System.Drawing.Font printFont;

        const string strConnectionString = "data source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind;";
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        DataGridView dataGridView1;

        #endregion

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Fangliste", new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Fangliste", new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Fangliste", new Font(new Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Gesamt Anzahl

                            ////Männlich
                            //e.Graphics.DrawString("Männlich: " + männlich, new Font(dataGridView1.Font, FontStyle.Bold),
                            //        Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top + 20 -
                            //        e.Graphics.MeasureString("Männlich: " + männlich, new Font(dataGridView1.Font,
                            //        FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            ////Weiblich
                            //e.Graphics.DrawString("Weiblich: " + weiblich, new Font(dataGridView1.Font, FontStyle.Bold),
                            //        Brushes.Black, e.MarginBounds.Left + 190, e.MarginBounds.Top + 20 -
                            //        e.Graphics.MeasureString("Weiblich: " + weiblich, new Font(dataGridView1.Font,
                            //        FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            ////Unbekannt
                            //e.Graphics.DrawString("Unbekannt: " + unbekannt, new Font(dataGridView1.Font, FontStyle.Bold),
                            //        Brushes.Black, e.MarginBounds.Left + 380, e.MarginBounds.Top + 20 -
                            //        e.Graphics.MeasureString("Unbekannt: " + unbekannt, new Font(dataGridView1.Font,
                            //        FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            ////Gesamt
                            //e.Graphics.DrawString("Gesamt: " + gesamt, new Font(dataGridView1.Font, FontStyle.Bold),
                            //        Brushes.Black, e.MarginBounds.Left + 560, e.MarginBounds.Top + 20 -
                            //        e.Graphics.MeasureString("Gesamt: " + gesamt, new Font(dataGridView1.Font,
                            //        FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin + 20,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin + 20,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin + 20,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin + 20,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin + 20, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void downloadtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Hostname != "")
            {
                if (Properties.Settings.Default.Username != "")
                {
                    if (Properties.Settings.Default.Passwort != "")
                    {
                        frm_download = new Frm_Download();
                        frm_download.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Kein Passwort.", "Server Information");
                        frm_einstellungen = new Frm_Einstellungen();
                        frm_einstellungen.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Kein Username.", "Server Information");
                    frm_einstellungen = new Frm_Einstellungen();
                    frm_einstellungen.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Kein Hostname.", "Server Information");
                frm_einstellungen = new Frm_Einstellungen();
                frm_einstellungen.ShowDialog();
            }
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_fangliste_Backup = new Frm_Fangliste_Backup();
            frm_fangliste_Backup.ShowDialog();

            if (frm_fangliste_Backup.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Fangliste_auslesen();
                GesAnzahlderFänge_Hecht_Zander_Barsch_Andere();
            }
        }
    }
}
