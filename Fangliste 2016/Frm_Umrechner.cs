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
    public partial class Frm_Umrechner : Form
    {
        #region Variablen

        #endregion

        #region Konstruktor

        public Frm_Umrechner()
        {
            InitializeComponent();
        }

        private void Frm_Umrechner_Load(object sender, EventArgs e)
        {
            tbx_gewichtVon.SelectedIndex = 3;
            tbx_gewichtIN.SelectedIndex = 2;

            tbx_wurfgVon.SelectedIndex = 0;
            tbx_wurfgIN.SelectedIndex = 1;

            tbx_leisungVon.SelectedIndex = 0;
            tbx_leistungIN.SelectedIndex = 1;
        }

        #endregion

        #region Events

        private void btn_gewicht_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tbx_gewichtVon.Text)
                {
                    case "Gramm":
                        #region gramm
                        switch (tbx_gewichtIN.Text)
                        {
                            case "Unze (oz)":
                                tbx_gewichtErgebnis.Value = Convert.ToDecimal(Umrechner.VonGramm_InUnze(Convert.ToDouble(tbx_gewicht.Value)));
                                break;
                            case "Kilogramm":
                                tbx_gewichtErgebnis.Value = Convert.ToDecimal(Umrechner.VonGramm_InKilogramm(Convert.ToDouble(tbx_gewicht.Value)));
                                break;
                            case "Pfund":
                                tbx_gewichtErgebnis.Value = Convert.ToDecimal(Umrechner.VonGramm_InPfund(Convert.ToDouble(tbx_gewicht.Value)));
                                break;
                            case "Gramm":
                                tbx_gewichtErgebnis.Value = tbx_gewicht.Value;
                                break;
                            default:
                                break;
                        }
                        #endregion
                        break;
                    case "Kilogramm":
                        #region kilogramm
                        switch (tbx_gewichtIN.Text)
                        {
                            case "Gramm":
                                tbx_gewichtErgebnis.Value = Convert.ToDecimal(Umrechner.VonKilogramm_InGramm(Convert.ToDouble(tbx_gewicht.Value)));
                                break;
                            case "Unze (oz)":
                                tbx_gewichtErgebnis.Value = Convert.ToDecimal(Umrechner.VonKilogramm_InUnze(Convert.ToDouble(tbx_gewicht.Value)));
                                break;
                            case "Pfund":
                                tbx_gewichtErgebnis.Value = Convert.ToDecimal(Umrechner.VonKilogramm_InPfund(Convert.ToDouble(tbx_gewicht.Value)));
                                break;
                            case "Kilogramm":
                                tbx_gewichtErgebnis.Value = tbx_gewicht.Value;
                                break;
                            default:
                                break;
                        }
                        #endregion
                        break;
                    case "Pfund":
                        #region pfund
                        switch (tbx_gewichtIN.Text)
                        {
                            case "Gramm":
                                tbx_gewichtErgebnis.Value = Convert.ToDecimal(Umrechner.VonPfund_InGramm(Convert.ToDouble(tbx_gewicht.Value)));
                                break;
                            case "Kilogramm":
                                tbx_gewichtErgebnis.Value = Convert.ToDecimal(Umrechner.VonPfund_InKilogramm(Convert.ToDouble(tbx_gewicht.Value)));
                                break;
                            case "Unze (oz)":
                                tbx_gewichtErgebnis.Value = Convert.ToDecimal(Umrechner.VonPfund_InUnze(Convert.ToDouble(tbx_gewicht.Value)));
                                break;
                            case "Pfund":
                                tbx_gewichtErgebnis.Value = tbx_gewicht.Value;
                                break;
                            default:
                                break;
                        }
                        #endregion
                        break;
                    case "Unze (oz)":
                        #region unze
                        switch (tbx_gewichtIN.Text)
                        {
                            case "Gramm":
                                tbx_gewichtErgebnis.Value = Convert.ToDecimal(Umrechner.VonUnze_InGramm(Convert.ToDouble(tbx_gewicht.Value)));
                                break;
                            case "Kilogramm":
                                tbx_gewichtErgebnis.Value = Convert.ToDecimal(Umrechner.VonUnze_InKilogramm(Convert.ToDouble(tbx_gewicht.Value)));
                                break;
                            case "Pfund":
                                tbx_gewichtErgebnis.Value = Convert.ToDecimal(Umrechner.VonUnze_InPfund(Convert.ToDouble(tbx_gewicht.Value)));
                                break;
                            case "Unze (oz)":
                                tbx_gewichtErgebnis.Value = tbx_gewicht.Value;
                                break;
                            default:
                                break;
                        }
                        #endregion
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fehler");
            }
        }

        private void btn_wurfgewicht_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cb_wurfgEmpfohlen.Checked)
                {
                    #region maximum
                    switch (tbx_wurfgVon.Text)
                    {
                        case "Pfund (lbs)":
                            switch (tbx_wurfgIN.Text)
                            {
                                case "Gramm":
                                    tbx_wurfgErgebnis.Value = Convert.ToDecimal(Umrechner.VonLBS_InGramm(Convert.ToDouble(tbx_wurfg.Value)));
                                    break;
                                case "Pfund (lbs)":
                                    tbx_wurfgErgebnis.Value = tbx_wurfg.Value;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Gramm":
                            switch (tbx_wurfgIN.Text)
                            {
                                case "Gramm":
                                    tbx_wurfgErgebnis.Value = tbx_wurfg.Value;
                                    break;
                                case "Pfund (lbs)":
                                    tbx_wurfgErgebnis.Value = Convert.ToDecimal(Umrechner.VonGramm_InLBS(Convert.ToDouble(tbx_wurfg.Value)));
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    #endregion
                }
                else
                {
                    #region empfohlen

                    switch (tbx_wurfgVon.Text)
                    {
                        case "Pfund (lbs)":
                            switch (tbx_wurfgIN.Text)
                            {
                                case "Gramm":
                                    tbx_wurfgErgebnis.Value = Convert.ToDecimal(Umrechner.VonLBS_InGrammEmpfohlen(Convert.ToDouble(tbx_wurfg.Value)));
                                    break;
                                case "Pfund (lbs)":
                                    tbx_wurfgErgebnis.Value = tbx_wurfg.Value;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Gramm":
                            switch (tbx_wurfgIN.Text)
                            {
                                case "Gramm":
                                    tbx_wurfgErgebnis.Value = tbx_wurfg.Value;
                                    break;
                                case "Pfund (lbs)":
                                    tbx_wurfgErgebnis.Value = Convert.ToDecimal(Umrechner.VonGramm_InLBS_Empfohlen(Convert.ToDouble(tbx_wurfg.Value)));
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fehler");
            }
        }

        //GG° MM' SS.ss''
        //GG.GGGGGG°
        //GG° MM.mmm'

        private void btn_leistung_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbx_leistung.Text != "")
                {
                    if (PrüfeEingabe(tbx_leistung.Text))
                    {
                        switch (tbx_leisungVon.Text)
                        {
                            case "PS":
                                switch (tbx_leistungIN.Text)
                                {
                                    case "Watt":
                                        tbx_leistungErgebnis.Text = Umrechner.PS_inWatt(Convert.ToDouble(tbx_leistung.Text)).ToString();
                                        break;
                                    case "KW":
                                        tbx_leistungErgebnis.Text = Umrechner.PS_inKW(Convert.ToDouble(tbx_leistung.Text)).ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "Watt":
                                switch (tbx_leistungIN.Text)
                                {
                                    case "PS":
                                        tbx_leistungErgebnis.Text = Umrechner.Watt_inPS(Convert.ToDouble(tbx_leistung.Text)).ToString();
                                        break;
                                    case "KW":
                                        tbx_leistungErgebnis.Text = Umrechner.Watt_inKW(Convert.ToDouble(tbx_leistung.Text)).ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "KW":
                                switch (tbx_leistungIN.Text)
                                {
                                    case "Watt":
                                        tbx_leistungErgebnis.Text = Umrechner.KW_inWatt(Convert.ToDouble(tbx_leistung.Text)).ToString();
                                        break;
                                    case "PS":
                                        tbx_leistungErgebnis.Text = Umrechner.KW_inPS(Convert.ToDouble(tbx_leistung.Text)).ToString();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falsche eingabe.\n\nNur Zahlen eingeben.", "Fehler");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fehler");
            }
        }

        #endregion

        #region Eigenschaften

        #endregion

        #region Methoden

        private bool PrüfeEingabe(string text)
        {
            string pat = "0123456789";
            foreach (char ch in text)
            {
                if (pat.IndexOf(ch) < 0)
                    return false;
            }
            return true;
        }

        #endregion
    }
}
