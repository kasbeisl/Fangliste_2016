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
    public partial class Frm_NeueFischart : Form
    {
        #region Variablen

        List<Fischarten> fischartenliste;
        Fischarten neueFischart;

        bool bearbeiten = false;

        #endregion

        #region Form

        Frm_FischKalkulator frm_fischKalkulator;

        #endregion

        #region Konstruktor

        public Frm_NeueFischart(List<Fischarten> fischartenliste)
        {
            InitializeComponent();

            this.fischartenliste = fischartenliste;
        }

        public Frm_NeueFischart(List<Fischarten> fischartenliste, int index)
        {
            InitializeComponent();

            this.Text = "Fischart bearbeiten";
            this.bearbeiten = true;

            this.fischartenliste = fischartenliste;

            tbx_name.Text = this.fischartenliste[index].Name;
            tbx_korpulenzfaktor.Value = Convert.ToDecimal(this.fischartenliste[index].Korpulenzfaktor);

        }

        public Frm_NeueFischart()
        {
            InitializeComponent();
        }

        private void Frm_Fischarten_Load(object sender, EventArgs e)
        {
        }

        #endregion

        #region Events

        private void btn_fertig_Click(object sender, EventArgs e)
        {
            if (tbx_name.Text != "")
            {
                if (!PrüfenNamen(tbx_name.Text))
                {
                    //this.neueFischart = new Fischarten(tbx_name.Text, Convert.ToDouble(tbx_korpulenzfaktor.Value));

                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("Geben Sie einen Namen ein.", "Fehler");
            }
        }

        private void btn_berechnen_Click(object sender, EventArgs e)
        {
            frm_fischKalkulator = new Frm_FischKalkulator();
            frm_fischKalkulator.ShowDialog();

            if (frm_fischKalkulator.DialogResult == DialogResult.OK)
            {
            }
        }

        #endregion

        #region Eigenschaften

        public Fischarten NeueFischart
        {
            get { return this.neueFischart; }
        }

        #endregion

        #region Methoden

        private bool PrüfenNamen(string name)
        {
            bool exist = false;

            if (!this.bearbeiten)
            {
                if (this.fischartenliste != null)
                {
                    for (int i = 0; i < this.fischartenliste.Count; i++)
                    {
                        if (fischartenliste[i].Name == tbx_name.Text)
                        {
                            exist = true;
                            break;
                        }
                    }
                }
            }

            return exist;
        }

        #endregion
    }
}
