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
    public partial class Frm_FischartHinzufügen : Form
    {
        #region Variablen

        List<Fischarten> fischartenListe;
        Fischarten neueFischart = null;

        #endregion

        #region Konstruktor

        public Frm_FischartHinzufügen(List<Fischarten> fischartenListe)
        {
            InitializeComponent();

            this.fischartenListe = fischartenListe;
        }

        private void Frm_FischartHinzufügen_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Eigenschaften

        public Fischarten Neue_Fischart
        {
            get
            {
                return this.neueFischart;
            }
        }

        #endregion

        #region Methoden

        private bool EinagePrüfen(string text)
        {
            string pat = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqerstuvwxyzßÄÜÖäüö- ";
            foreach (char ch in text)
            {
                if (pat.IndexOf(ch) < 0)
                    return false;
            }
            return true;
        }

        private bool IstFischartVorhanden()
        {
            bool fischartVorhanden = false;

            for (int i = 0; i < fischartenListe.Count; i++)
            {
                if (fischartenListe[i].Name == textBox1.Text)
                {
                    fischartVorhanden = true;
                }
            }

            return fischartVorhanden;
        }

        private bool IstTextVorhanden()
        {
            bool textVorhanden = false;

            if (textBox1.Text != "")
            {
                textVorhanden = true;
            }

            return textVorhanden;
        }

        #endregion

        #region Events

        private void textBox1_Validated(object sender, EventArgs e)
        {
            epFehlermeldungen.Clear();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == "")
            {

            }
            else if (Char.IsLower(textBox1.Text[0]))
            {
                epFehlermeldungen.SetError(textBox1, "Der Erster Buchstabe muss groß sein.");
                e.Cancel = true;
            }

            if (IstFischartVorhanden())
            {
                epFehlermeldungen.SetError(textBox1, "Fischart vorhanden!");
                e.Cancel = true;
            }

            if (!IstTextVorhanden())
            {
                epFehlermeldungen.SetError(textBox1, "Es wurde keine Fischart eingegeben.\n\nBitte geben Sie eine Fischart ein.");
                e.Cancel = true;
            }

            if (textBox1.Text == "")
            {

            }
            else if (!EinagePrüfen(textBox1.Text))
            {
                epFehlermeldungen.SetError(textBox1, "Die Eingabe darf nur Buchstaben enthalten.");
                e.Cancel = true;
            }

            if (textBox1.TextLength <= 2)
            {
                epFehlermeldungen.SetError(textBox1, "Die Eingabe ist zu kurz. (minimum 3 Buchstaben");
                e.Cancel = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                btn_ok.Enabled = true;
            }
            else
            {
                btn_ok.Enabled = false;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            neueFischart.Name = textBox1.Text;
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) && textBox1.Text != "")
            {
                btn_ok_Click(sender, e);
            }
        }

        #endregion
    }
}
