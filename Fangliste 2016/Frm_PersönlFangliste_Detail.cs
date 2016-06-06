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
        #region Variablen

        Angler1 angler;
        int[] jahre = null;

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

                //string text = "SELECT COUNT(*) FROM Angler";

                string strSQL = "SELECT Angler_ID, SUM(Gewicht) " +
                                "FROM Fang WHERE Angler_ID = '" + angler.ID + "' GROUP BY Angler_ID ";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                gewicht = Convert.ToDouble(cmd.ExecuteReader());
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

                //string text = "SELECT COUNT(*) FROM Angler";

                string strSQL = "SELECT SUM(Länge), Angler_ID " +
                                "FROM Fang WHERE Angler_ID = '" + angler.ID + "'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                länge = Convert.ToDouble(cmd.ExecuteReader());
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
            int fängeJahr = 0;
            int zähler2 = 0;
            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                //string text = "SELECT COUNT(*) FROM Angler";

                string strSQL = "SELECT COUNT(*) Angler_ID " +
                                "FROM Fang WHERE Angler_ID = '" + angler.ID + "'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                zähler2 = Convert.ToInt16(cmd.ExecuteReader());
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

                //string text = "SELECT COUNT(*) FROM Angler";

                string strSQL = "SELECT COUNT(*) Angler_ID " +
                                "FROM Fang WHERE Angler_ID = '" + angler.ID + "'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                fängeJahr = Convert.ToInt16(cmd.ExecuteReader());
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

            /*if ((persönlicheFangliste.Count == 0) || (persönlicheFangliste == null))
            {
            }
            else
            {
                int[] jahre_kopie = new int[this.persönlicheFangliste.Count];
                bool exist = false;
                int zähler = 0;

                for (int i = 0; i < this.persönlicheFangliste.Count; i++)
                {
                    for (int j = 0; j < jahre_kopie.Length; j++)
                    {
                        if (jahre_kopie[j] == persönlicheFangliste[i].Datum.Year)
                        {
                            exist = true;
                        }
                    }

                    if (!exist)
                    {
                        jahre_kopie[zähler] = persönlicheFangliste[i].Datum.Year;
                        zähler++;
                    }

                    exist = false;
                }

                int zähler2 = 0;

                for (int i = 0; i < jahre_kopie.Length; i++)
                {
                    if (jahre_kopie[i] != 0)
                    {
                        zähler2++;
                    }
                }

                jahre = new int[zähler2];
                int zähler3 = 0;

                for (int i = 0; i < jahre_kopie.Length; i++)
                {
                    if (jahre_kopie[i] != 0)
                    {
                        jahre[zähler3] = jahre_kopie[i];
                        zähler3++;
                    }
                }

                //Durschnittliche Fänge pro Jahr = Gesamtanzahler der Fänge / Die Anzahl der Jahre
                fängeJahr = this.persönlicheFangliste.Count / zähler2;

                lb_gesJahre.Text = zähler2.ToString();
            }*/

            //Durschnittliche Fänge pro Jahr = Gesamtanzahler der Fänge / Die Anzahl der Jahre

            if (fängeJahr != 0 && zähler2 != 0)
                fängeJahr = fängeJahr / zähler2;

            lb_gesJahre.Text = zähler2.ToString();

            lb_fängeJahr.Text = fängeJahr.ToString();
        }

        private void GesAnzahlFängeAktuell()
        {
            int anzahl = 0;

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT COUNT(*) Angler_ID " +
                                "FROM Fang WHERE Angler_ID = '" + angler.ID + "' AND Datum BETWEEN '201´6/01/01' and '2017/01/01'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                anzahl = Convert.ToInt16(cmd.ExecuteReader());
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
