using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FanglisteLibrary;
using System.Data.SqlClient;

namespace Fangliste_2016
{
    public partial class Frm_PersönlFangliste_Detail : Form
    {
        #region Membervariablen

        Angler1 angler;

        #endregion

        #region Konstruktor

        public Frm_PersönlFangliste_Detail(Angler1 angler)
        {
            InitializeComponent();

            this.angler = angler;
        }

        private void Frm_PersönlFangliste_Detail_Load(object sender, EventArgs e)
        {
            lb_gesAnzahlAktuell_Info.Text = "Gesamtanzahl der gefangenen Fische (" + DateTime.Now.Year + ")";

            GesAnzahlFänge();
            GesGewichtFänge();
            GesLängeFänge();
            FängeProJahr();
            GesAnzahlFängeAktuell();
            BesteJahr();
        }

        #endregion

        #region Methoden

        private void GesAnzahlFänge()
        {
            int anzahl = 0;

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT COUNT(*) Angler_ID FROM Fang WHERE Angler_ID = '" + angler.ID + "'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                anzahl = Convert.ToInt32(cmd.ExecuteScalar());

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
                anzahl = this.persönlicheFangliste.Count;
            }
            catch { }*/

            lb_gesAnzahl.Text = anzahl.ToString();
        }

        private void GesGewichtFänge()
        {
            double gewicht = 0;

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT SUM(Gewicht) AS Gewicht, Angler_ID FROM Fang WHERE Angler_ID = '" + angler.ID + "' GROUP BY Angler_ID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine("{0,-35}{1}", reader["Id"], reader["Name"]);
                    gewicht = Convert.ToDouble(reader["Gewicht"]);
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

            /* try
             {
                 for (int i = 0; i < this.persönlicheFangliste.Count; i++)
                 {
                     gewicht += this.persönlicheFangliste[i].Gewicht;
                 }
             }
             catch { }*/

            gewicht = Math.Round(gewicht, 2);
            lb_gesGewicht.Text = gewicht.ToString() + " kg";
        }

        private void GesLängeFänge()
        {
            double länge = 0;

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT SUM(Länge) AS Länge, Angler_ID FROM Fang WHERE Angler_ID = '" + angler.ID + "' GROUP BY Angler_ID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine("{0,-35}{1}", reader["Id"], reader["Name"]);
                    länge = Convert.ToDouble(reader["Länge"]);
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
                for (int i = 0; i < this.persönlicheFangliste.Count; i++)
                {
                    länge += this.persönlicheFangliste[i].Größe;
                }
            }
            catch { }*/

            lb_gesLänge.Text = länge.ToString() + " cm";
        }

        private void FängeProJahr()
        {
            int fängeInsgesamt = 0;
            int jahreCount = 0;
            int durchschnitt = 0;

            string ConnectionString = SQLCollection.GetConnectionString();
            SqlConnection con = new SqlConnection();

            List<int> a = new List<int>();

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT DISTINCT YEAR(Datum) AS Datum " +
                                "FROM Fang WHERE Angler_ID = '" + angler.ID + "' GROUP BY Datum";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine("{0,-35}{1}", reader["Id"], reader["Name"]);
                    a.Add(Convert.ToInt16(reader["Datum"]));
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

            jahreCount = a.Count;

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT COUNT(*) Angler_ID FROM Fang WHERE Angler_ID = '" + angler.ID + "'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                fängeInsgesamt = Convert.ToInt32(cmd.ExecuteScalar());
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

            //Durschnittliche Fänge pro Jahr = Gesamtanzahler der Fänge / Die Anzahl der Jahre

            if (fängeInsgesamt != 0 && jahreCount != 0)
                durchschnitt = fängeInsgesamt / jahreCount;

            lb_gesJahre.Text = jahreCount.ToString();

            lb_fängeJahr.Text = durchschnitt.ToString();
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

            /* try
             {
                 for (int i = 0; i < this.persönlicheFangliste.Count; i++)
                 {
                     if (this.persönlicheFangliste[i].Datum.Year == DateTime.Now.Year)
                     {
                         anzahl++;
                     }
                 }
             }
             catch { }*/

            lb_gesAnzahlAktuell.Text = anzahl.ToString();
        }

        private void BesteJahr()
        {
            List<int> a = new List<int>();
            List<int> anzahl = new List<int>();

            string ConnectionString = SQLCollection.GetConnectionString();
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT DISTINCT YEAR(Datum) AS Datum " +
                                "FROM Fang WHERE Angler_ID = '" + angler.ID + "' GROUP BY Datum";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine("{0,-35}{1}", reader["Id"], reader["Name"]);
                    a.Add(Convert.ToInt16(reader["Datum"]));
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


            for (int i = 0; i < a.Count; i++)
            {
                try
                {
                    con.ConnectionString = ConnectionString;

                    string strSQL = "SELECT Count(*) AS Zähler " +
                                    "FROM Fang WHERE Angler_ID = '" + angler.ID + "' AND Datum BETWEEN '" + a[i] + "/01/01' AND '" + (a[i] + 1) + "/01/01'";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //Console.WriteLine("{0,-35}{1}", reader["Id"], reader["Name"]);
                        anzahl.Add(Convert.ToInt16(reader["Zähler"]));
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

            int mehr = 0;
            int _jahr = a[0];

            for (int i = 0; i < a.Count; i++)
            {
                if (anzahl[i] > mehr)
                {
                    mehr = anzahl[i];
                    _jahr = a[i];
                }
            }

            lb_besteJahr.Text = _jahr.ToString() + " (" + mehr.ToString() + ")";

            /*try
            {
                int[] anzahlJahr = new int[jahre.Length];;
                int anzahl = 0;

                for (int j = 0; j < jahre.Length; j++)
                {
                    anzahl = 0;

                    for (int i = 0; i < this.persönlicheFangliste.Count; i++)
                    {
                        if (this.persönlicheFangliste[i].Datum.Year == jahre[j])
                        {
                            anzahl++;
                        }
                    }

                    anzahlJahr[j] = anzahl;
                }
                
                int mehr = 0;
                int _jahr = jahre[0];

                for (int i = 0; i < jahre.Length; i++)
                {
                    if (anzahlJahr[i] > mehr)
                    {
                        mehr = anzahlJahr[i];
                        _jahr = jahre[i];
                    }
                }

                lb_besteJahr.Text = _jahr.ToString() + " (" + mehr.ToString() + ")";
            }
            catch { }*/
        }

        #endregion
    }
}
