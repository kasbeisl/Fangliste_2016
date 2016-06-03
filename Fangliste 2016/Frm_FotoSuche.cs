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
    public partial class Frm_FotoSuche : Form
    {
        #region Variablen

        List<Fangliste> alleFänge;
        List<Foto> alleFotos;
        string suchText = "";
        string kategorie = "Name";

        #endregion

        #region Konstruktor

        public Frm_FotoSuche(List<Fangliste> alleFänge, List<Foto> alleFotos)
        {
            InitializeComponent();

            this.alleFänge = alleFänge;
            this.alleFotos = alleFotos;
        }

        private void Frm_FotoSuche_Load(object sender, EventArgs e)
        {
            cb_auswahl.Enabled = false;
            btn_sucheStarten.Enabled = false;
            //cb_fotosuche_nach.ValueMember = "Name";
        }

        #endregion

        #region Eigenschaften

        public string SuchText
        {
            get
            {
                return this.suchText;
            }
        }

        public string Kategorie
        {
            get
            {
                return this.kategorie;
            }
        }

        #endregion

        #region Methoden

        private bool Prüfen()
        {
            bool ok = false; ;

            return ok;
        }

        private void ComboBoxAuswahlFüllen()
        {
            switch (cb_fotosuche_nach.Text)
            {
                case "Gewässer":
                    GewässerlisteErstellen();
                    break;
                case "Name":
                    NamenslisteErstellen();
                    break;
                case "Gewicht (in kg)":
                    GewichtslisteErstellen();
                    break;
                case "Größe (in cm)":
                    GrößenlisteErstellen();
                    break;
                case "Fischart":
                    FischartenlisteErstellen();
                    break;
                case "Jahr":
                    JahreslisteErstellen();
                    break;
            }
        }

        private void GewässerlisteErstellen()
        {
            bool exist_gewässer = false;
            string[] _gewässer = new string[alleFänge.Count];
            int zähler_gewässer = 0;

            for (int i = 0; i < alleFänge.Count; i++)
            {
                for (int a = 0; a < _gewässer.GetLength(0); a++)
                {
                    if (_gewässer[a] == alleFänge[i].Gewässer)
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
                    _gewässer[i] = alleFänge[i].Gewässer;

                }
                zähler_gewässer++;
                exist_gewässer = false;
            }

            cb_auswahl.Items.Clear();

            for (int i = 0; i < _gewässer.GetLength(0); i++)
            {
                if (_gewässer[i] != null)
                {
                    cb_auswahl.Items.Add(_gewässer[i]);
                }
            }
        }

        private void NamenslisteErstellen()
        {
            bool exist = false;
            string[] _namen = new string[alleFänge.Count];
            int zähler = 0;

            for (int i = 0; i < alleFänge.Count; i++)
            {
                for (int a = 0; a < _namen.GetLength(0); a++)
                {
                    if (_namen[a] == alleFänge[i].Name)
                    {
                        exist = true;
                        break;
                    }

                    if (zähler == a)
                    {
                        break;
                    }
                }

                if (!exist)
                {
                    _namen[i] = alleFänge[i].Name;
                }
                zähler++;
                exist = false;
            }

            cb_auswahl.Items.Clear();

            for (int i = 0; i < _namen.GetLength(0); i++)
            {
                if (_namen[i] != null)
                {
                    cb_auswahl.Items.Add(_namen[i]);
                }
            }
        }

        private void GrößenlisteErstellen()
        {
            string[] _größe = new string[] { "0 bis 39", "40 bis 49", "50 bis 59", "60 bis 69", "70 bis 79", "80 bis 89", "90 bis 99", "alles ab 100" };

            cb_auswahl.Items.Clear();

            for (int i = 0; i < _größe.GetLength(0); i++)
            {
                if (_größe[i] != null)
                {
                    cb_auswahl.Items.Add(_größe[i].ToString());
                }
            }
        }

        private void GewichtslisteErstellen()
        {
            string[] _größe = new string[] { "0 bis 0,9", "1 bis 1,9", "2 bis 2,9", "3 bis 3,9", "4 bis 4,9", "5 bis 5,9", "6 bis 6,9", "alles ab 7" };

            cb_auswahl.Items.Clear();

            for (int i = 0; i < _größe.GetLength(0); i++)
            {
                if (_größe[i] != null)
                {
                    cb_auswahl.Items.Add(_größe[i].ToString());
                }
            }
        }

        private void FischartenlisteErstellen()
        {
            bool exist = false;
            string[] _fischart = new string[alleFänge.Count];
            int zähler = 0;

            for (int i = 0; i < alleFänge.Count; i++)
            {
                for (int a = 0; a < _fischart.GetLength(0); a++)
                {
                    if (_fischart[a] == alleFänge[i].Fischart)
                    {
                        exist = true;
                        break;
                    }

                    if (zähler == a)
                    {
                        break;
                    }
                }

                if (!exist)
                {
                    _fischart[i] = alleFänge[i].Fischart;
                }
                zähler++;
                exist = false;
            }

            cb_auswahl.Items.Clear();

            for (int i = 0; i < _fischart.GetLength(0); i++)
            {
                if (_fischart[i] != null)
                {
                    cb_auswahl.Items.Add(_fischart[i]);
                }
            }
        }

        private void JahreslisteErstellen()
        {
            bool exist = false;
            string[] _datum = new string[alleFänge.Count];
            int zähler = 0;

            for (int i = 0; i < alleFänge.Count; i++)
            {
                for (int a = 0; a < _datum.GetLength(0); a++)
                {
                    if (_datum[a] == alleFänge[i].Datum.Year.ToString())
                    {
                        exist = true;
                        break;
                    }

                    if (zähler == a)
                    {
                        break;
                    }
                }

                if (!exist)
                {
                    _datum[i] = alleFänge[i].Datum.Year.ToString();
                }
                zähler++;
                exist = false;
            }

            cb_auswahl.Items.Clear();

            for (int i = 0; i < _datum.GetLength(0); i++)
            {
                if (_datum[i] != null)
                {
                    cb_auswahl.Items.Add(_datum[i]);
                }
            }
        }

        #endregion

        #region Events

        private void btn_sucheStarten_Click(object sender, EventArgs e)
        {
            //bool eingabeOk = false;

            //if ((cb_fotosuche_nach.Text == "Gewicht") || (cb_fotosuche_nach.Text == "Größe"))
            //{
            //    string pat = "0123456789,";
            //    foreach (char ch in cb_auswahl.Text)
            //    {
            //        if (pat.IndexOf(ch) < 0)
            //        {
            //            eingabeOk = false;
            //            break;
            //        }
            //        else
            //        {
            //            eingabeOk = true;
            //        }
            //    }

            //    if (!eingabeOk)
            //    {
            //        MessageBox.Show("Nur Zahlen eingeben.", "Fehler");
            //    }
            //}

            //if ((cb_fotosuche_nach.Text == "Name") || (cb_fotosuche_nach.Text == "Gewässer"))
            //{
            //    string pat = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz -?";
            //    foreach (char ch in cb_auswahl.Text)
            //    {
            //        if (pat.IndexOf(ch) < 0)
            //        {
            //            //eingabeOk = false;
            //        }
            //        else
            //        {
            //            eingabeOk = true;
            //            break;
            //        }
            //    }

            //    if (!eingabeOk)
            //    {
            //        MessageBox.Show("Nur Buchstaben eingeben.", "Fehler");
            //    }
            //}

            //if (eingabeOk)
            //{
            //    suchText = cb_auswahl.Text;
            //    this.DialogResult = DialogResult.OK;
            //}

            suchText = cb_auswahl.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void cb_auswahl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((cb_auswahl.Text != "") && (cb_fotosuche_nach.Text != ""))
            {
                btn_sucheStarten.Enabled = true;
            }
            else
            {
                btn_sucheStarten.Enabled = false;
            }
        }

        private void cb_fotosuche_nach_TextChanged(object sender, EventArgs e)
        {
            if (cb_fotosuche_nach.Text != "")
            {
                cb_auswahl.Enabled = true;
            }
            else
            {
                cb_auswahl.Enabled = false;
                btn_sucheStarten.Enabled = false;
            }
        }

        private void cb_fotosuche_nach_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cb_fotosuche_nach.Text != "")
            {
                kategorie = cb_fotosuche_nach.Text;
                ComboBoxAuswahlFüllen();
                cb_auswahl.Enabled = true;
            }

        }

        #endregion
    }
}
