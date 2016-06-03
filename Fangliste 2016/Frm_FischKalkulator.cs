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
    public partial class Frm_FischKalkulator : Form
    {
        #region Variablen

        double gewicht;
        double länge;
        double k_Faktor;
        List<Fischarten> fischarten;

        #endregion

        #region Konstruktor

        public Frm_FischKalkulator(double länge)
        {
            InitializeComponent();

            this.länge = länge;
        }

        public Frm_FischKalkulator(double gewicht, double länge, double k_Faktor)
        {
            InitializeComponent();

            this.gewicht = gewicht;
            this.länge = länge;
            this.k_Faktor = k_Faktor;
        }

        public Frm_FischKalkulator()
        {
            InitializeComponent();
        }

        private void Frm_FischKalkulator_Load(object sender, EventArgs e)
        {
            FischartenInListeEintragen();
            try
            {
                cb_fischarten.SelectedIndex = 0;
                tbx_kFaktor.Text = this.fischarten[0].Korpulenzfaktor.ToString();
            }
            catch { }
        }

        #endregion

        #region Eigenschaften

        public double Gewicht
        {
            get { return this.gewicht; }
        }

        public double Länge
        {
            get { return this.länge; }
        }

        #endregion

        #region Methoden

        private double FischLängeBerechnen(double k, double gewicht)
        {
            double länge = 0;
            double länge_kopie = 0;

            //Länge[cm] = wurzel³ gewicht[g] * 100 / Korpulenzfaktor
            länge_kopie = (gewicht * 100) / k;
            länge = Math.Pow(länge_kopie, 1.0 / 3.0);

            return länge;
        }

        private double FischGewichtBerechnen(double k, double länge)
        {
            double gewicht = 0;

            //Gewicht[g] = (Länge[cm]³ * Korpulenzfaktor) / 100
            double länge_kopie = Math.Pow(länge, 3);
            gewicht = (länge_kopie * k) / 100;

            return gewicht;
        }

        private double K_FaktorBerechnen(double gewicht, double länge)
        {
            double k_Faktor = 0;
            double länge_kopie = Math.Pow(länge, 3);

            //K_Faktor = (gewicht[g] * 100 ) / länge [cm]³
            k_Faktor = (gewicht * 100) / länge_kopie;

            return k_Faktor;
        }

        private void FischartenInListeEintragen()
        {
            if (fischarten == null)
                this.fischarten = new List<Fischarten>();

            List<Fischarten> liste = new List<Fischarten>();

            cb_fischarten.Items.Clear();

            string ConnectionString =
             @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

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

            if (liste != null)
                this.fischarten = Fischarten.SortiereNachNamen(liste);

            if (fischarten != null)
            {
                for (int i = 0; i < this.fischarten.Count; i++)
                {
                    cb_fischarten.Items.Add(this.fischarten[i].Name);
                }
            }
        }

        #endregion

        #region Events

        private void btn_länge_Click(object sender, EventArgs e)
        {
            try
            {
                this.k_Faktor = Convert.ToDouble(tbx_kFaktor.Text);
                this.gewicht = Convert.ToDouble(tbx_gewicht.Text) * 1000;
                this.länge = FischLängeBerechnen(this.k_Faktor, this.gewicht);

                tbx_länge.Text = Convert.ToString(Math.Round(this.länge, 2));
            }
            catch
            {
                
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            tbx_gewicht.Text = "";
            tbx_länge.Text = "";
        }

        private void btn_gewicht_Click(object sender, EventArgs e)
        {
            try
            {
                this.länge = Convert.ToDouble(tbx_länge.Text);
                this.k_Faktor = Convert.ToDouble(tbx_kFaktor.Text);
                this.gewicht = FischGewichtBerechnen(this.k_Faktor, this.länge)  / 1000;

                tbx_gewicht.Text = Convert.ToString(Math.Round(this.gewicht, 2));
            }
            catch
            {
            }
        }

        private void btn_kFaktor_Click(object sender, EventArgs e)
        {
            try
            {
                this.gewicht = Convert.ToDouble(tbx_gewicht.Text) * 1000;
                this.länge = Convert.ToDouble(tbx_länge.Text);
                this.k_Faktor = K_FaktorBerechnen(this.gewicht, this.länge);

                tbx_kFaktor.Text = Convert.ToString(Math.Round(this.k_Faktor, 2));
            }
            catch
            {
            }
        }

        private void cb_fischarten_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string fischartName = this.cb_fischarten.Text;

                int index = 0;

                for (int i = 0; i < this.fischarten.Count; i++)
                {
                    if (fischarten[i].Name == fischartName)
                    {
                        index = i;
                    }
                } 

                tbx_kFaktor.Text = Convert.ToString(this.fischarten[index].Korpulenzfaktor);
            }
            catch
            {
            }
        }

        #endregion
    }
}
