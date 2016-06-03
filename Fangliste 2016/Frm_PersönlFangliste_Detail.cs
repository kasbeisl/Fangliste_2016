using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FanglisteLibrary;

namespace Fangliste_2016
{
    public partial class Frm_PersönlFangliste_Detail : Form
    {
        #region Variablen

        List<Fangliste> persönlicheFangliste;
        int[] jahre = null;

        #endregion

        #region Konstruktor

        public Frm_PersönlFangliste_Detail(List<Fangliste> persönlicheFangliste)
        {
            InitializeComponent();

            this.persönlicheFangliste = persönlicheFangliste;
        }

        private void Frm_PersönlFangliste_Detail_Load(object sender, EventArgs e)
        {
            lb_gesAnzahlAktuell_Info.Text = "Gesamtanzahl der gefangenen Fische (" + DateTime.Now.Year + ")";

            /*GesAnzahlFänge();
            GesGewichtFänge();
            GesLängeFänge();
            FängeProJahr();
            GesAnzahlFängeAktuell();
            BesteJahr();*/
        }

        #endregion

        #region Methoden

        private void GesAnzahlFänge()
        {
            int anzahl = 0;

            try
            {
                anzahl = this.persönlicheFangliste.Count;
            }
            catch { }

            lb_gesAnzahl.Text = anzahl.ToString();
        }

        private void GesGewichtFänge()
        {
            double gewicht = 0;

            try
            {
                for (int i = 0; i < this.persönlicheFangliste.Count; i++)
                {
                    gewicht += this.persönlicheFangliste[i].Gewicht;
                }
            }
            catch { }

            gewicht = Math.Round(gewicht, 2);
            lb_gesGewicht.Text = gewicht.ToString() + " kg";
        }

        private void GesLängeFänge()
        {
            double länge = 0;

            try
            {
                for (int i = 0; i < this.persönlicheFangliste.Count; i++)
                {
                    länge += this.persönlicheFangliste[i].Größe;
                }
            }
            catch { }

            lb_gesLänge.Text = länge.ToString() + " cm";
        }

        private void FängeProJahr()
        {
            int fängeJahr = 0;

            if ((persönlicheFangliste.Count == 0) || (persönlicheFangliste == null))
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
            }

            lb_fängeJahr.Text = fängeJahr.ToString();
        }

        private void GesAnzahlFängeAktuell()
        {
            int anzahl = 0;

            try
            {
                for (int i = 0; i < this.persönlicheFangliste.Count; i++)
                {
                    if (this.persönlicheFangliste[i].Datum.Year == DateTime.Now.Year)
                    {
                        anzahl++;
                    }
                }
            }
            catch { }

            lb_gesAnzahlAktuell.Text = anzahl.ToString();
        }

        private void BesteJahr()
        {
            try
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
            catch { }
        }

        #endregion
    }
}
