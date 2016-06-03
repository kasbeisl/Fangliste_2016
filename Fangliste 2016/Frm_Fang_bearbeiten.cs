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

namespace Fangliste_2016
{
    public partial class Frm_Fang_bearbeiten : Form
    {
        #region Variablen

        string name;
        string fischart;
        double größe;
        double gewicht;
        string gewässer;
        string platzBeschreibung;
        string köderBeschreibung;
        double temperatur;
        double tiefe;
        DateTime datum;
        DateTime uhrzeit;
        string wetter;
        bool zurückgesetzt;

        List<Fangliste> fangliste;
        int index;
        List<Fischarten> fischartenliste;

        Wetter _wetter;

        List<Foto> fotoliste;

        #endregion

        #region Konstruktor

        public Frm_Fang_bearbeiten(List<Fangliste> fangliste, int index, List<Fischarten> fischartenliste, List<Foto> fotoliste)
        {
            InitializeComponent();

            this.fangliste = fangliste;
            this.index = index;
            this.fischartenliste = fischartenliste;
            this.fotoliste = fotoliste;
        }

        private void Frm_Fang_bearbeiten_Load(object sender, EventArgs e)
        {
            WerteZuOrdnen();

            ErstelleWetterliste();

            DatenInComboBoxHinzufügen();

            try
            {
                comboBox_Name.Text = this.name;
                tbx_Fischart.Text = this.fischart;
                tbx_Größe.Value = Convert.ToDecimal(this.größe);
                tbx_Gewicht.Value = Convert.ToDecimal(this.gewicht);
                tbx_Gewässer.Text = this.gewässer;
                tbx_Platzbeschreibung.Text = this.platzBeschreibung;
                tbx_Köderbeschreibung.Text = this.köderBeschreibung;
                tbx_Temperatur.Value = Convert.ToDecimal(this.temperatur);
                tbx_Tiefe.Value = Convert.ToDecimal(this.tiefe);
                tbx_Datum.Value = this.datum;
                tbx_Uhrzeit.Value = this.uhrzeit;
                tbx_Wetter.Text = this.wetter;
                tbx_zurückgesetzt.Checked = this.zurückgesetzt;
            }
            catch
            {
            }

            //btn_fertig.Enabled = false;
        }

        #endregion

        #region Eigenschaften

        public List<Fangliste> AlleFänge
        {
            get
            {
                return this.fangliste;
            }
        }

        public List<Foto> AlleFotos
        {
            get
            {
                return this.fotoliste;
            }
        }

        #endregion

        #region Methoden

        private void WerteZuOrdnen()
        {
            this.name = fangliste[index].Name;
            this.fischart = fangliste[index].Fischart;
            this.größe = fangliste[index].Größe;
            this.gewicht = fangliste[index].Gewicht;
            this.gewässer = fangliste[index].Gewässer;
            this.datum = fangliste[index].Datum;
            this.uhrzeit = fangliste[index].Uhrzeit;
            this.platzBeschreibung = fangliste[index].Platzbesch;
            this.köderBeschreibung = fangliste[index].Köderbeschr;
            this.tiefe = fangliste[index].Tiefe;
            this.temperatur = fangliste[index].Lufttemperatur;
            this.wetter = fangliste[index].Wetter;
            this.zurückgesetzt = fangliste[index].Zurückgesetzt;
        }

        private void ErstelleWetterliste()
        {
            tbx_Wetter.Items.Clear();

            _wetter = new Wetter();

            for (int i = 0; i < _wetter.Wetterliste.Length; i++)
            {
                tbx_Wetter.Items.Add(_wetter.Wetterliste[i]);
            }
        }

        private void DatenInComboBoxHinzufügen()
        {
            //Namen
            #region Namen
            bool exist = false;
            string[] _namen = new string[fangliste.Count];
            int zähler = 0;

            for (int i = 0; i < fangliste.Count; i++)
            {
                for (int a = 0; a < _namen.GetLength(0); a++)
                {
                    if (_namen[a] == fangliste[i].Name)
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
                    _namen[i] = fangliste[i].Name;

                }
                zähler++;
                exist = false;
            }

            for (int i = 0; i < _namen.GetLength(0); i++)
            {
                if (_namen[i] != null)
                {
                    comboBox_Name.Items.Add(_namen[i]);
                }
            }

            #endregion

            //Gewässer
            #region Gewässer

            bool exist_gewässer = false;
            string[] _gewässer = new string[fangliste.Count];
            int zähler_gewässer = 0;

            for (int i = 0; i < fangliste.Count; i++)
            {
                for (int a = 0; a < _gewässer.GetLength(0); a++)
                {
                    if (_gewässer[a] == fangliste[i].Gewässer)
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
            }
            #endregion

            #region Fischarten

            for (int i = 0; i < this.fischartenliste.Count; i++)
            {
                tbx_Fischart.Items.Add(fischartenliste[i].Name);
            }

            #endregion
        }

        #endregion

        #region Button

        private void btn_fertig_Click(object sender, EventArgs e)
        {
            DialogResult edit = MessageBox.Show("Soll dieser Eintrag geändert werden?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            
            if (edit == DialogResult.Yes)
            {
                //for (int i = 0; i < this.alleFotos.Count; i++)
                //{
                //    if ((alleFotos[i].FischerName == alleFänge[index].Name) &&
                //        (alleFotos[i].Fischart == alleFänge[index].Fischart) &&
                //        (alleFotos[i].Gewässer == alleFänge[index].Gewässer) &&
                //        (alleFotos[i].Größe == alleFänge[index].Größe) &&
                //        (alleFotos[i].Gewicht == alleFänge[index].Gewicht) &&
                //        (alleFotos[i].Datum == alleFänge[index].Datum) &&
                //        (alleFotos[i].Uhrzeit == alleFänge[index].Uhrzeit))
                //    {
                //        alleFotos[i].FischerName = comboBox_Name.Text;
                //        alleFotos[i].Fischart = tbx_Fischart.Text;
                //        alleFotos[i].Größe = Convert.ToDouble(tbx_Größe.Value);
                //        alleFotos[i].Gewicht = Convert.ToDouble(tbx_Gewicht.Value);
                //        alleFotos[i].Gewässer = tbx_Gewässer.Text;
                //        alleFotos[i].Datum = tbx_Datum.Value;
                //        alleFotos[i].Uhrzeit = tbx_Uhrzeit.Value;
                //    }
                //}

                fangliste[index].Name = comboBox_Name.Text;
                fangliste[index].Fischart = tbx_Fischart.Text;
                fangliste[index].Größe = Convert.ToDouble(tbx_Größe.Value);
                fangliste[index].Gewicht = Convert.ToDouble(tbx_Gewicht.Value);
                fangliste[index].Gewässer = tbx_Gewässer.Text;
                fangliste[index].Datum = tbx_Datum.Value;
                fangliste[index].Uhrzeit = tbx_Uhrzeit.Value;
                fangliste[index].Platzbesch = tbx_Platzbeschreibung.Text;
                fangliste[index].Köderbeschr = tbx_Köderbeschreibung.Text;
                fangliste[index].Tiefe = Convert.ToDouble(tbx_Tiefe.Value);
                fangliste[index].Lufttemperatur = Convert.ToDouble(tbx_Temperatur.Value);
                fangliste[index].Wetter = tbx_Wetter.Text;
                fangliste[index].Zurückgesetzt = tbx_zurückgesetzt.Checked;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }

            if (edit == DialogResult.No)
            {
                this.Close();
            }
        }

        #endregion

        #region Event TextChanged

        private void tbx_Fischart_TextChanged(object sender, EventArgs e)
        {
            btn_fertig.Enabled = true;
        }

        private void tbx_Größe_ValueChanged(object sender, EventArgs e)
        {
            btn_fertig.Enabled = true;
            //try
            //{
            //    double gewicht = FischKalkulator.FischGewichtBerechnen(Fischarten.GetK_FaktorFromFischart(this.fischartenliste, tbx_Fischart.Text), Convert.ToDouble(tbx_Größe.Value));
            //    tbx_Gewicht.Value = Math.Round(Convert.ToDecimal(gewicht / 1000), 2);
            //}
            //catch { }
        }

        private void tbx_Gewicht_ValueChanged(object sender, EventArgs e)
        {
            btn_fertig.Enabled = true;
        }

        private void tbx_Gewässer_TextChanged(object sender, EventArgs e)
        {
            btn_fertig.Enabled = true;
        }

        private void tbx_Platzbeschreibung_TextChanged(object sender, EventArgs e)
        {
            btn_fertig.Enabled = true;
        }

        private void tbx_Köderbeschreibung_TextChanged(object sender, EventArgs e)
        {
            btn_fertig.Enabled = true;
        }

        private void comboBox_Name_TextChanged(object sender, EventArgs e)
        {
            btn_fertig.Enabled = true;
        }

        private void tbx_Temperatur_ValueChanged(object sender, EventArgs e)
        {
            btn_fertig.Enabled = true;
        }

        private void tbx_Tiefe_ValueChanged(object sender, EventArgs e)
        {
            btn_fertig.Enabled = true;
        }

        private void tbx_Datum_ValueChanged(object sender, EventArgs e)
        {
            btn_fertig.Enabled = true;
        }

        private void tbx_Uhrzeit_ValueChanged(object sender, EventArgs e)
        {
            btn_fertig.Enabled = true;
        }

        private void tbx_Wetter_TextChanged(object sender, EventArgs e)
        {
            btn_fertig.Enabled = true;
        }

        #endregion

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
    }
}
