using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FanglisteLibrary;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace Fangliste_2016
{
    public partial class Frm_Statistik : Form
    {
        #region Variablen

        List<Fangliste> alleFänge;
        List<Fischarten> fischartenliste;

        //SQL Variablen
        string connectionString = SQLCollection.GetConnectionString();
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        #endregion

        #region Konstruktor

        public Frm_Statistik(List<Fangliste> alleFänge, List<Fischarten> fischartenliste)
        {
            InitializeComponent();

            //this.alleFänge = alleFänge;
            //this.fischartenliste = fischartenliste;
        }

        private void Frm_Statistik_Load(object sender, EventArgs e)
        {
            GetFischartenlisteFromDB();
            ComboBox_Fischart_mit_Daten_füllen();



            ////Test 
            ////(wird in der Textbox rechts oben angezeigt)
            //this.con = new SqlConnection();
            //try
            //{

            //    this.con.ConnectionString = this.connectionString;

            //    // Abfrage liest alle Fische aus und gruppiert nach Stunde (unsortiert)
            //    string strSQL = "SELECT Count(Fang.Id) AS Anzahl, Fisch.Name, DATEPART(HOUR, [Uhrzeit]) FROM Fang "
            //        + "JOIN Fisch ON (Fang.Fischart_ID = Fisch.Id) "
            //        + "GROUP BY Fisch.Name, DATEPART(HOUR, [Uhrzeit])";

            //    //// Abfrage liest Hechte aus und gruppiert nach Stunde
            //    //string strSQL = "SELECT Count(Fang.Id) AS Anzahl, Fisch.Name, DATEPART(HOUR, [Uhrzeit]) FROM Fang "
            //    //    + "JOIN Fisch ON (Fang.Fischart_ID = Fisch.Id) "
            //    //    + "WHERE Fisch.Name = 'Hecht'"
            //    //    + "GROUP BY Fisch.Name, DATEPART(HOUR, [Uhrzeit]) "
            //    //    + "ORDER BY DATEPART(HOUR, [Uhrzeit])";


            //    this.cmd = new SqlCommand(strSQL, con);
            //    this.con.Open();
            //    this.reader = cmd.ExecuteReader();
            //    this.textBox1.Text = "";
            //    while (reader.Read())
            //    {
            //        //textBox1.Text += "Anzahl "+reader["C"].ToString() +"  Fischart " +reader["Fischart_ID"].ToString();
            //        //textBox1.Text += Environment.NewLine;
            //        this.textBox1.Text += "Anzahl "+reader[0].ToString() + " Fisch " + reader[1].ToString() + " Uhr " + reader[2].ToString();
            //        this.textBox1.Text += Environment.NewLine;
            //    }
            //    this.reader.Close();
            //    this.con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    this.con.Close();
            //}
        }

        #endregion

        #region Events

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cb_Fischart.Text != "" && cb_Kategorie.Text != "")
            {
                btn_brechnen.Enabled = true;
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cb_Fischart.Text != "" && cb_Kategorie.Text != "")
            {
                btn_brechnen.Enabled = true;
            }
        }

        private void btn_brechnen_Click(object sender, EventArgs e)
        {
            DatenAuswerten();
        }

        #endregion

        #region Eigenschaften

        #endregion

        #region Methoden

        /// <summary>
        /// Diese Funktion lest alle Fischarten aus der DB und speichert sie in der 
        /// Liste ab.
        /// </summary>
        private void GetFischartenlisteFromDB()
        {
            List<Fischarten> liste = new List<Fischarten>();

            //string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = this.connectionString;

                //string text = "SELECT COUNT(*) FROM Angler";

                string strSQL = "SELECT Id, Name, KF " +
                                "FROM Fisch";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    try
                    {
                        liste.Add(new Fischarten(Convert.ToInt16(reader["Id"]), reader["Name"].ToString(), Convert.ToDouble(reader["KF"])));
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

            if (liste == null)
                this.fischartenliste = new List<Fischarten>();
            else
            {
                this.fischartenliste = Fischarten.SortiereNachNamen(liste);
            }
        }

        /// <summary>
        /// Füllt die Fischarten-Combobox mit den Fischarten
        /// </summary>
        private void ComboBox_Fischart_mit_Daten_füllen()
        {
            if (this.fischartenliste != null)
            {
                for (int i = 0; i < this.fischartenliste.Count; i++)
                {
                    cb_Fischart.Items.Add(fischartenliste[i].Name);
                }
            }
        }

        /// <summary>
        /// Wertet die eingegebenen Daten aus den Comboboxen aus und 
        /// zeigt sie im Chart an
        /// </summary>
        private void DatenAuswerten()
        {
            chart1.Series.Clear();

            chart1.Series.Add(cb_Fischart.Text);

            switch (cb_Kategorie.Text)
            {
                case "Uhrzeit":
                    Uhrzeit();
                    break;
                case "Datum":
                    Datum();
                    break;
                case "Temperatur":
                    Temperatur();
                    break;
                case "Tiefe":
                    Tiefe();
                    break;
                case "Größe":
                    Größe();
                    break;
                case "Gewicht":
                    Gewicht();
                    break;
                case "Wetter":
                    Wetter();
                    break;
            }
        }

        private void Uhrzeit()
        {
            string[] xWerte = new string[] 
            { "00:00", "01:00", "02:00", "03:00", "04:00", "05:00"
            , "06:00", "07:00", "08:00", "09:00", "10:00", "11:00"
            , "12:00", "13:00", "14:00", "15:00", "16:00", "17:00"
            , "18:00", "19:00", "20:00", "21:00", "22:00", "23:00" };

            int[] yWerte = new int[xWerte.Length];

            for (int i = 0; i < yWerte.Length; i++)
            {
                yWerte[i] = 0;
            }


            string strSQL = "SELECT Count(Fang.Id) AS Anzahl, Fisch.Name, DATEPART(HOUR, [Uhrzeit]) FROM Fang "
            + "JOIN Fisch ON (Fang.Fischart_ID = Fisch.Id) "
            + "WHERE Fisch.Name = '" + this.cb_Fischart.Text + "' "
            + "GROUP BY Fisch.Name, DATEPART(HOUR, [Uhrzeit]) "
            + "ORDER BY DATEPART(HOUR, [Uhrzeit])";
            
            try
            {
                this.ExecuteSQLCommand(strSQL);

                while (this.reader.Read())
                {
                    yWerte[Convert.ToInt32(this.reader[2])] = Convert.ToInt32(this.reader[0]);
                }
                this.reader.Close();
                this.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.con.Close();
            }

            listView1.Items.Clear();

            for (int i = 0; i < xWerte.Length; i++)
            {
                listView1.Items.Add(xWerte[i] + " Uhr = " + yWerte[i]);
            }

            //chart1.Series[cb_Fischart.Text].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[cb_Fischart.Text].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart1.Series[0].BorderWidth = 10;
            chart1.Series[0].Color = Color.DarkGreen;




            chart1.Series[cb_Fischart.Text].Points.DataBindXY(xWerte ,yWerte);

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 24;

            chart1.ChartAreas[0].AxisX.Title = Environment.NewLine + "Uhrzeit";
        }

        private void ExecuteSQLCommand(string strSQL)
        {
            this.con = new SqlConnection();

            this.con.ConnectionString = this.connectionString;

            this.cmd = new SqlCommand(strSQL, con);
            this.con.Open();
            this.reader = cmd.ExecuteReader();
        }

        private void Datum()
        {
            Statistik.Datum datum = new Statistik.Datum(this.alleFänge, cb_Fischart.Text);

            bool keineWerte = true;
            int anzahl_derFäge = 0;

            for (int i = 0; i < datum.Y_Werte.Length; i++)
            {
                if (datum.Y_Werte[i] != 0)
                {
                    keineWerte = false;
                }

                if (datum.Y_Werte[i] != 0)
                {
                    anzahl_derFäge++;
                }
            }

            if (keineWerte)
            {
                MessageBox.Show("Keine Werte vorhanden.", "Information");
            }
            else
            {
                //if (anzahl_derFäge < 3)
                //{
                //    MessageBox.Show("Es sind zu wengige Werte vorhanden.", "Information");
                //}
            }

            string[] xWerte = new string[] { "Jänner", "Februar", "März", "April", "Mai", "Juni", "July", "August", "September", "Oktober", "November", "Dezember" };

            listView1.Items.Clear();

            for (int i = 0; i < xWerte.Length; i++)
            {
                listView1.Items.Add(xWerte[i] + " = " + datum.Y_Werte[i]);
            }

            chart1.Series[cb_Fischart.Text].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            chart1.Series[cb_Fischart.Text].Points.DataBindXY(xWerte, datum.Y_Werte);

            chart1.ChartAreas[0].AxisX.Minimum = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 12;

            chart1.ChartAreas[0].AxisX.Title = Environment.NewLine + "Datum";
        }

        private string ZahlMonat_in_StringMonat(int monat)
        {
            string smonat = "";

            switch (monat)
	        {
                case 1:
                    smonat = "Jänner";
                    break;
		        case 2:
                    smonat = "Februar";
                    break;
                case 3:
                    smonat = "März";
                    break;
                case 4:
                    smonat = "April";
                    break;
                case 5:
                    smonat = "Mai";
                    break;
                case 6:
                    smonat = "Juni";
                    break;
                case 7:
                    smonat = "July";
                    break;
                case 8:
                    smonat = "August";
                    break;
                case 9:
                    smonat = "September";
                    break;
                case 10:
                    smonat = "Oktober";
                    break;
                case 11:
                    smonat = "November";
                    break;
                case 12:
                    smonat = "Dezember";
                    break;
                default:
                    smonat = "Falscher Wert";
                    break;
	        }

            return smonat;
        }

        private void Temperatur()
        {
            Statistik.Temperatur temperatur = new Statistik.Temperatur(this.alleFänge, cb_Fischart.Text);

            bool keineWerte = true;
            int anzahl_derFäge = 0;

            for (int i = 0; i < temperatur.Y_Werte.Length; i++)
            {
                if (temperatur.Y_Werte[i] != 0)
                {
                    keineWerte = false;
                }

                if (temperatur.Y_Werte[i] != 0)
                {
                    anzahl_derFäge++;
                }
            }

            if (keineWerte)
            {
                MessageBox.Show("Keine Werte vorhanden.", "Information");
            }
            else
            {
                //if (anzahl_derFäge < 3)
                //{
                //    MessageBox.Show("Es sind zu wengige Werte vorhanden.", "Information");
                //}
            }

            string[] xWerte = new string[temperatur.Y_Werte.Length];

            listView1.Items.Clear();
            int sw = -20;

            for (int i = 0; i < xWerte.Length; i++)
            {
                xWerte[i] = sw.ToString();
                sw++;
            }

            for (int i = 0; i < xWerte.Length; i++)
            {
                listView1.Items.Add(xWerte[i] + " C° = " + temperatur.Y_Werte[i]);
            }

            chart1.Series[cb_Fischart.Text].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            chart1.Series[cb_Fischart.Text].Points.DataBindY(temperatur.Y_Werte);

            chart1.ChartAreas[0].AxisX.Minimum = -20;
            chart1.ChartAreas[0].AxisX.Maximum = 40;

            chart1.ChartAreas[0].AxisX.Title = Environment.NewLine + "Temperatur";
        }

        private void Tiefe()
        {
            Statistik.Tiefe tiefe = new Statistik.Tiefe(this.alleFänge, cb_Fischart.Text);

            bool keineWerte = true;
            int anzahl_derFäge = 0;

            for (int i = 0; i < tiefe.Y_Werte.Length; i++)
            {
                if (tiefe.Y_Werte[i] != 0)
                {
                    keineWerte = false;
                }

                if (tiefe.Y_Werte[i] != 0)
                {
                    anzahl_derFäge++;
                }
            }

            if (keineWerte)
            {
                MessageBox.Show("Keine Werte vorhanden.", "Information");
            }
            else
            {
                //if (anzahl_derFäge < 3)
                //{
                //    MessageBox.Show("Es sind zu wengige Werte vorhanden.", "Information");
                //}
            }

            string[] xWerte = new string[tiefe.Y_Werte.Length];

            listView1.Items.Clear();
            int sw = 0;

            for (int i = 0; i < xWerte.Length; i++)
            {
                xWerte[i] = sw.ToString();
                sw++;
            }

            for (int i = 0; i < xWerte.Length; i++)
            {
                listView1.Items.Add(xWerte[i] + " m = " + tiefe.Y_Werte[i]);
            }

            chart1.Series[cb_Fischart.Text].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            chart1.Series[cb_Fischart.Text].Points.DataBindY(tiefe.Y_Werte);

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 40;

            chart1.ChartAreas[0].AxisX.Title = Environment.NewLine + "Tiefe";
        }

        private void Größe()
        {
            Statistik.Größe größe = new Statistik.Größe(this.alleFänge, cb_Fischart.Text);

            bool keineWerte = true;
            int anzahl_derFäge = 0;

            for (int i = 0; i < größe.Y_Werte.Length; i++)
            {
                if (größe.Y_Werte[i] != 0)
                {
                    keineWerte = false;
                }

                if (größe.Y_Werte[i] != 0)
                {
                    anzahl_derFäge++;
                }
            }

            if (keineWerte)
            {
                MessageBox.Show("Keine Werte vorhanden.", "Information");
            }
            else
            {
                //if (anzahl_derFäge < 3)
                //{
                //    MessageBox.Show("Es sind zu wengige Werte vorhanden.", "Information");
                //}
            }

            string[] xWerte = new string[größe.Y_Werte.Length];

            listView1.Items.Clear();
            int sw = 0;

            for (int i = 0; i < xWerte.Length; i++)
            {
                xWerte[i] = sw.ToString();
                sw++;
            }

            for (int i = 0; i < xWerte.Length; i++)
            {
                listView1.Items.Add(xWerte[i] + " cm = " + größe.Y_Werte[i]);
            }

            chart1.Series[cb_Fischart.Text].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            chart1.Series[cb_Fischart.Text].Points.DataBindY(größe.Y_Werte);

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 150;

            chart1.ChartAreas[0].AxisX.Title = Environment.NewLine + "Größe";
        }

        private void Gewicht()
        {
            Statistik.Gewicht gewicht = new Statistik.Gewicht(this.alleFänge, cb_Fischart.Text);

            bool keineWerte = true;
            int anzahl_derFäge = 0;

            for (int i = 0; i < gewicht.Y_Werte.Length; i++)
            {
                if (gewicht.Y_Werte[i] != 0)
                {
                    keineWerte = false;
                }

                if (gewicht.Y_Werte[i] != 0)
                {
                    anzahl_derFäge++;
                }
            }

            if (keineWerte)
            {
                MessageBox.Show("Keine Werte vorhanden.", "Information");
            }
            else
            {
                //if (anzahl_derFäge < 3)
                //{
                //    MessageBox.Show("Es sind zu wengige Werte vorhanden.", "Information");
                //}
            }

            string[] xWerte = new string[gewicht.Y_Werte.Length];

            listView1.Items.Clear();
            int sw = 0;

            for (int i = 0; i < xWerte.Length; i++)
            {
                xWerte[i] = sw.ToString();
                sw++;
            }

            for (int i = 0; i < xWerte.Length; i++)
            {
                listView1.Items.Add(xWerte[i] + " kg = " + gewicht.Y_Werte[i]);
            }

            chart1.Series[cb_Fischart.Text].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            chart1.Series[cb_Fischart.Text].Points.DataBindY(gewicht.Y_Werte);

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 25;

            chart1.ChartAreas[0].AxisX.Title = Environment.NewLine + "Gewicht";
        }

        private void Wetter()
        {
            string[] _wetter = new string[WetterListeErstellen().Length];
            _wetter = WetterListeErstellen();

            int anzahl_wetter = _wetter.Length;

            Statistik.Wetter wetter = new Statistik.Wetter(this.alleFänge, cb_Fischart.Text, _wetter);

            bool keineWerte = true;
            int anzahl_derFäge = 0;

            for (int i = 0; i < wetter.Y_Werte.Length; i++)
            {
                if (wetter.Y_Werte[i] != 0)
                {
                    keineWerte = false;
                }

                if (wetter.Y_Werte[i] != 0)
                {
                    anzahl_derFäge++;
                }
            }

            if (keineWerte)
            {
                MessageBox.Show("Keine Werte vorhanden.", "Information");
            }
            else
            {
                //if (anzahl_derFäge < 3)
                //{
                //    MessageBox.Show("Es sind zu wengige Werte vorhanden.", "Information");
                //}
            }

            listView1.Items.Clear();

            for (int i = 0; i < _wetter.Length; i++)
            {
                listView1.Items.Add(_wetter[i] + " = " + wetter.Y_Werte[i]);
            }

            chart1.Series[cb_Fischart.Text].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            chart1.Series[cb_Fischart.Text].Points.DataBindXY(_wetter, wetter.Y_Werte);

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = wetter.Y_Werte.Length;

            chart1.ChartAreas[0].AxisX.Title = Environment.NewLine + "Wetter";
        }

        private string[] WetterListeErstellen()
        {
            bool exist_wetter = false;
            string[] _wetter = new string[this.alleFänge.Count];
            int zähler_wetter = 0;
            string[] wetter;

            for (int i = 0; i < this.alleFänge.Count; i++)
            {
                for (int a = 0; a < _wetter.GetLength(0); a++)
                {
                    if (_wetter[a] == this.alleFänge[i].Wetter)
                    {
                        exist_wetter = true;
                        break;
                    }

                    if (zähler_wetter == a)
                    {
                        break;
                    }
                }

                if (!exist_wetter)
                {
                    _wetter[i] = alleFänge[i].Wetter;

                }
                zähler_wetter++;
                exist_wetter = false;
            }

            int anzahl = 0;

            for (int i = 0; i < _wetter.GetLength(0); i++)
            {
                    if (_wetter[i] != null)
                {
                    anzahl++;
                }
            }

            wetter = new string[anzahl];

            int index = 0;

            for (int i = 0; i < _wetter.GetLength(0); i++)
            {
                if (_wetter[i] != null)
                {
                    wetter[index] = _wetter[i];
                    index++;
                }
            }

            return wetter;
        }

        #endregion
    }
}
