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
using System.Data.SqlClient;

namespace Fangliste_2016
{
    public partial class Frm_Fischeintragen : Form
    {
        #region Variablen

        List<Fangliste> fangliste;
        List<Fischarten> fischartenliste;
        List<Foto> fotoliste;
        List<Gewässer> gewässerliste;

        Wetter wetter;
        Fangliste eintrag = new Fangliste();
        Angler1 aktueller_Fischer;
        //bool fotoEintragen = false;
        


        #endregion

        #region Konstruktor

        public Frm_Fischeintragen(Angler1 aktueller_Fischer)
        {
            InitializeComponent();

            this.aktueller_Fischer = aktueller_Fischer;
        }

        private void Frm_Fischeintragen_Load(object sender, EventArgs e)
        {
            tbx_Datum.MaxDate = DateTime.Today;

            ErstellenGewässerListe();

            ErstelleWetterliste();

            ErstelleFischartenliste();

            if (Properties.Settings.Default.FangVorlageAutomatik)
                AllesAusfüllen();
        }

        #endregion

        #region Eigenschaften

        public Fangliste Liefere_Fischeintrag
        {
            get
            {
                return this.eintrag;
            }
        }

        #endregion

        #region Events

        private void btn_vorlage1_Click(object sender, EventArgs e)
        {
            Frm_Vorlage v = new Frm_Vorlage(Frm_Vorlage.Selection.Angelplatzbeschreibung, tbx_Gewässer.Text);
            v.ShowDialog();

            tbx_Platzbeschreibung.Text = v.GetSelectedText;
        }

        private void btn_vorlage2_Click(object sender, EventArgs e)
        {
            Frm_Vorlage v = new Frm_Vorlage(Frm_Vorlage.Selection.Köderbeschreibung);
            v.ShowDialog();

            tbx_Köderbeschreibung.Text = v.GetSelectedText;
        }

        private void btn_eintragen_Click(object sender, EventArgs e)
        {
            if ((tbx_Fischart.Text == "") ||
                (tbx_Größe.Value == 0) ||
                (tbx_Gewicht.Value == 0) ||
                (tbx_Gewässer.Text == "") ||
                (tbx_Platzbeschreibung.Text == "") ||
                (tbx_Köderbeschreibung.Text == "") ||
                (tbx_Wetter.Text == ""))
            {
                MessageBox.Show("Es müssen alle Felder ausgefüllt werden!", "Achtung", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                int gewässer_id = Gewässer.Get_ID(gewässerliste, tbx_Gewässer.Text);
                if (gewässer_id == 0)
                {
                    ErstelleNeuesGewässer();
                    ErstellenGewässerListe();
                    gewässer_id = Gewässer.Get_ID(gewässerliste, tbx_Gewässer.Text);
                }

                SqlConnection con = new SqlConnection();
                con.ConnectionString = SQLCollection.GetConnectionString();
                //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";


                try
                {
                    con.Open();
                    SqlCommand insertCommand = new SqlCommand(
                "Insert into Fang (Angler_ID, Fischart_ID, Länge, Gewicht, Gewässer_ID, Köder, Angelplatz, Tiefe, Lufttemperatur, Wassertemperatur, Datum, Uhrzeit, Zurückgesetzt, Wetter, Kommentar) Values (@Angler_ID, @Fischart_ID, @Länge, @Gewicht, @Gewässer_ID, @Köder, @Angelplatz, @Tiefe, @Lufttemperatur, @Wassertemperatur, @Datum, @Uhrzeit, @Zurückgesetzt, @Wetter, @Kommentar)", con);
                    insertCommand.Parameters.Add("Angler_ID", SqlDbType.Int, 0).Value = aktueller_Fischer.ID;
                    insertCommand.Parameters.Add("Fischart_ID", SqlDbType.Int, 0).Value = Fischarten.Get_ID(fischartenliste, tbx_Fischart.Text);
                    insertCommand.Parameters.Add("Länge", SqlDbType.Float).Value = tbx_Größe.Value;
                    insertCommand.Parameters.Add("Gewicht", SqlDbType.Float).Value = tbx_Gewicht.Value;
                    insertCommand.Parameters.Add("Gewässer_ID", SqlDbType.Int, 0).Value = gewässer_id;
                    insertCommand.Parameters.Add("Köder", SqlDbType.Text, 0).Value = tbx_Köderbeschreibung.Text;
                    insertCommand.Parameters.Add("Angelplatz", SqlDbType.Text, 0).Value = tbx_Platzbeschreibung.Text;
                    insertCommand.Parameters.Add("Tiefe", SqlDbType.Float).Value = tbx_Tiefe.Value;
                    insertCommand.Parameters.Add("Lufttemperatur", SqlDbType.Float).Value = tbx_wassertemperatur.Value;
                    insertCommand.Parameters.Add("Wassertemperatur", SqlDbType.Float).Value = tbx_Gewicht.Value;
                    insertCommand.Parameters.Add("Datum", SqlDbType.Date, 0).Value = tbx_Datum.Value;
                    insertCommand.Parameters.Add("Uhrzeit", SqlDbType.DateTime, 0).Value = tbx_Uhrzeit.Value;
                    insertCommand.Parameters.Add("Zurückgesetzt", SqlDbType.Bit, 0).Value = tbx_zurückgesetzt.Checked;
                    insertCommand.Parameters.Add("Wetter", SqlDbType.VarChar, 0).Value = tbx_Wetter.Text;
                    insertCommand.Parameters.Add("Kommentar", SqlDbType.Text, 0).Value = tbx_kommentar.Text;

                    int queryResult = insertCommand.ExecuteNonQuery();
                    if (queryResult == 1)
                        MessageBox.Show("Petri Heil!", "Fang eintragen");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Fehler");
                }
                finally
                {
                    con.Close();
                }

                /*this.eintrag.ID = Fangliste.GetNewID(this.fangliste);
                this.eintrag.Name = this.aktueller_Fischer.Name;
                this.eintrag.Fischart = tbx_Fischart.Text;
                this.eintrag.Größe = Math.Round(Convert.ToDouble(tbx_Größe.Value), 2);
                this.eintrag.Gewicht = Math.Round(Convert.ToDouble(tbx_Gewicht.Value), 2);
                this.eintrag.Gewässer = tbx_Gewässer.Text;
                this.eintrag.Datum = tbx_Datum.Value;
                this.eintrag.Uhrzeit = tbx_Uhrzeit.Value;
                this.eintrag.Platzbesch = tbx_Platzbeschreibung.Text;
                this.eintrag.Köderbeschr = tbx_Köderbeschreibung.Text;
                this.eintrag.Tiefe = Convert.ToDouble(tbx_Tiefe.Value);
                this.eintrag.Lufttemperatur = Convert.ToDouble(tbx_Temperatur.Value);
                this.eintrag.Wetter = tbx_Wetter.Text;
                this.eintrag.Zurückgesetzt = tbx_zurückgesetzt.Checked;*/

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ErstelleNeuesGewässer()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";

            try
            {
                con.Open();
                SqlCommand insertCommand = new SqlCommand(
            "Insert into Gewässer (Name) Values ('" + tbx_Gewässer.Text + "')", con);
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

        private void tbx_Platzbeschreibung_Validated(object sender, EventArgs e)
        {
            epFehlermeldungen.Clear();
        }

        private void tbx_Platzbeschreibung_Validating(object sender, CancelEventArgs e)
        {
            if (tbx_Platzbeschreibung.Text == "")
            {

            }
            else if (Char.IsLower(tbx_Platzbeschreibung.Text[0]))
            {
                epFehlermeldungen.SetError(tbx_Platzbeschreibung, "Erster Buchtabe muss groß sein");
                e.Cancel = true;
            }

            if (tbx_Platzbeschreibung.Text == "")
            {

            }
            else if (!PrüfeEingabe(tbx_Platzbeschreibung.Text))
            {
                epFehlermeldungen.SetError(tbx_Platzbeschreibung, "Die Eingabe darf nur Buchstaben und Zahlen enthalten.");
                e.Cancel = true;
            }

            if (tbx_Platzbeschreibung.Text == "")
            {

            }
            else if (Char.IsNumber(tbx_Platzbeschreibung.Text, 0))
            {
                epFehlermeldungen.SetError(tbx_Platzbeschreibung, "Die Eingabe muss mit einem Buchstaben beginnen..");
                e.Cancel = true;
            }
        }

        private void tbx_Köderbeschreibung_Validated(object sender, EventArgs e)
        {
            epFehlermeldungen.Clear();
        }

        private void tbx_Köderbeschreibung_Validating(object sender, CancelEventArgs e)
        {
            if (tbx_Köderbeschreibung.Text == "")
            {

            }
            else if (Char.IsLower(tbx_Köderbeschreibung.Text[0]))
            {
                epFehlermeldungen.SetError(tbx_Köderbeschreibung, "Erster Buchstabe groß");
                e.Cancel = true;
            }

            if (tbx_Köderbeschreibung.Text == "")
            {

            }
            else if (!PrüfeEingabe(tbx_Köderbeschreibung.Text))
            {
                epFehlermeldungen.SetError(tbx_Köderbeschreibung, "Die Eingabe darf nur Buchstaben und Zahlen enthalten.");
                e.Cancel = true;
            }

            if (tbx_Köderbeschreibung.Text == "")
            {

            }
            else if (Char.IsNumber(tbx_Köderbeschreibung.Text, 0))
            {
                epFehlermeldungen.SetError(tbx_Köderbeschreibung, "Die Eingabe muss mit einem Buchstaben beginnen.");
                e.Cancel = true;
            }
        }

        private void tbx_Gewässer_Validated(object sender, EventArgs e)
        {
            epFehlermeldungen.Clear();
        }

        private void tbx_Gewässer_Validating(object sender, CancelEventArgs e)
        {
            if (tbx_Gewässer.Text == "")
            {

            }
            else if (Char.IsLower(tbx_Gewässer.Text[0]))
            {
                epFehlermeldungen.SetError(tbx_Gewässer, "Erster Buchtabe muss groß sein");
                e.Cancel = true;
            }

            if (tbx_Gewässer.Text == "")
            {

            }
            else if (!PrüfeEingabe(tbx_Gewässer.Text))
            {
                epFehlermeldungen.SetError(tbx_Köderbeschreibung, "Die Eingabe darf nur Buchstaben und Zahlen enthalten.");
                e.Cancel = true;
            }
        }

        private void tbx_Datum_Validated(object sender, EventArgs e)
        {
            epFehlermeldungen.Clear();
        }

        private void tbx_Datum_Validating(object sender, CancelEventArgs e)
        {
            if (tbx_Datum.Value > DateTime.Today.AddDays(1))
            {
                epFehlermeldungen.SetError(tbx_Datum, "Keine Fänge in der Zukunft möglich.");
                e.Cancel = true;
            }
        }

        private void tbx_Datum_ValueChanged(object sender, EventArgs e)
        {
            //datum_changed = true;
        }

        private void tbx_Uhrzeit_Validated(object sender, EventArgs e)
        {
            //epFehlermeldungen.Clear();
        }

        private void tbx_Uhrzeit_Validating(object sender, CancelEventArgs e)
        {
            //if (tbx_Uhrzeit.Value.Hour > DateTime.Now.Hour)
            //{
            //    epFehlermeldungen.SetError(tbx_Uhrzeit, "Keine Fänge in der Zukunft möglich.");
            //    e.Cancel = true;
            //}
        }

        private void tbx_Uhrzeit_ValueChanged(object sender, EventArgs e)
        {
            //uhrzeit_changed = true;
        }

        private void tbx_Größe_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //if (tbx_Gewicht.Value <= 0.1m)
                //{
                    double gewicht = FischKalkulator.FischGewichtBerechnen(Fischarten.GetK_FaktorFromFischart(this.fischartenliste, tbx_Fischart.Text), Convert.ToDouble(tbx_Größe.Value));
                    tbx_Gewicht.Value = Math.Round(Convert.ToDecimal(gewicht / 1000), 2);
                //}
            }
            catch { }
        }

        private void tbx_Gewicht_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void tbx_Größe_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //if (tbx_Gewicht.Value <= 0.1m)
                //{
                    double gewicht = FischKalkulator.FischGewichtBerechnen(Fischarten.GetK_FaktorFromFischart(this.fischartenliste, tbx_Fischart.Text), Convert.ToDouble(tbx_Größe.Value));
                    tbx_Gewicht.Value = Math.Round(Convert.ToDecimal(gewicht / 1000), 2);
                //}
            }
            catch { }
        }

        #endregion

        #region Methoden

        private void AllesAusfüllen()
        {
            //"SELECT TOP (1) * FROM Fang ORDER BY Name DESC"

            
                string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection con = new SqlConnection();

                try
                {
                    con.ConnectionString = ConnectionString;

                    //string text = "SELECT COUNT(*) FROM Angler";

                    string strSQL = "SELECT TOP (1) * FROM Fang ORDER BY Id DESC";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        try
                        {
                            tbx_Fischart.Text = Fischarten.Get_Name(fischartenliste, Convert.ToInt16(reader["Fischart_ID"]));
                            tbx_Größe.Value = Convert.ToDecimal(reader["Länge"]);
                            tbx_Gewicht.Value = Convert.ToDecimal(reader["Gewicht"]);
                        tbx_Gewässer.Text = Gewässer.Get_Name(gewässerliste, Convert.ToInt16(reader["Gewässer_ID"]));
                        tbx_Platzbeschreibung.Text = reader["Angelplatz"].ToString();
                            tbx_Köderbeschreibung.Text = reader["Köder"].ToString();
                            tbx_Temperatur.Value = Convert.ToDecimal(reader["Lufttemperatur"]);
                            tbx_wassertemperatur.Value = Convert.ToDecimal(reader["Wassertemperatur"]);
                            tbx_Tiefe.Value = Convert.ToDecimal(reader["Tiefe"]);
                            tbx_Datum.Value = Convert.ToDateTime(reader["Datum"]);
                            tbx_Uhrzeit.Value = Convert.ToDateTime(reader["Uhrzeit"]);
                            tbx_Wetter.Text = reader["Wetter"].ToString();
                            tbx_zurückgesetzt.Checked = Convert.ToBoolean(reader["Zurückgesetzt"]);
                            tbx_kommentar.Text = reader["Kommentar"].ToString();
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

        private void ErstellenGewässerListe()
        {
            tbx_Gewässer.Items.Clear();
            gewässerliste = new List<Gewässer>();

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT Id, Name " +
                                "FROM Gewässer";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        gewässerliste.Add(new Gewässer(Convert.ToInt16(reader["Id"]), reader["Name"].ToString()));
                        tbx_Gewässer.Items.Add(reader["Name"].ToString());
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

            /*bool exist_gewässer = false;
            string[] _gewässer = new string[this.fangliste.Count];
            int zähler_gewässer = 0;

            for (int i = 0; i < this.fangliste.Count; i++)
            {
                for (int a = 0; a < _gewässer.GetLength(0); a++)
                {
                    if (_gewässer[a] == this.fangliste[i].Gewässer)
                    {
                        exist_gewässer = true;
                        break;
                    }

                    if (zähler_gewässer == a)
                    {
                        break;
                    }
                }

                if (!exist_gewässer)
                {
                    _gewässer[i] = fangliste[i].Gewässer;

                }
                zähler_gewässer++;
                exist_gewässer = false;
            }

            for (int i = 0; i < _gewässer.GetLength(0); i++)
            {
                if (_gewässer[i] != null)
                {
                    tbx_Gewässer.Items.Add(_gewässer[i]);
                }
            }*/
        }

        private void ErstelleWetterliste()
        {
            tbx_Wetter.Items.Clear();

            wetter = new Wetter();

            for (int i = 0; i < wetter.Wetterliste.Length; i++)
            {
                tbx_Wetter.Items.Add(wetter.Wetterliste[i]);
            }
        }

        private bool PrüfeEingabe(string text)
        {
            string pat = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqerstuvwxyz.- _üöäÜÖÄß:<>()/§$%&[]={}?#+*|@!";
            foreach (char ch in text)
            {
                if (pat.IndexOf(ch) < 0)
                    return false;
            }
            return true;
        }

        private void ErstelleFischartenliste()
        {
            fischartenliste = new List<Fischarten>();

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT Id, Name, KF " +
                                "FROM Fisch";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        fischartenliste.Add(new Fischarten(Convert.ToInt16(reader["Id"]), reader["Name"].ToString(), Convert.ToDouble(reader["KF"])));
                        tbx_Fischart.Items.Add(reader["Name"].ToString());
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

            /*if (fischartenliste != null)
            {
                for (int i = 0; i < fischartenliste.Count; i++)
                {
                    tbx_Fischart.Items.Add(fischartenliste[i].Name);
                }
            }*/
        }

        #endregion
    }
}