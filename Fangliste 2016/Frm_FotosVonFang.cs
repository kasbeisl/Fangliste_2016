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
    public partial class Frm_FotosVonFang : Form
    {
        #region Variablen

        string[] fotos;
        int foto_jetzt = 0;
        List<Foto> alleFotos;
        int index;
        List<Fangliste> fangliste;
        int position;

        #endregion

        #region Konstruktor

        public Frm_FotosVonFang(List<Foto> alleFotos, string[] fotos, int index)
        {
            InitializeComponent();

            this.alleFotos = alleFotos;
            this.fotos = fotos;
            this.index = index;

            pictureBox1.ImageLocation = Frm_Hauptmenu.FotoOrdner + "\\" + this.fotos[foto_jetzt];
        }

        public Frm_FotosVonFang(List<Foto> alleFotos, int index, string pfad)
        {
            InitializeComponent();

            this.alleFotos = alleFotos;
            this.index = index;
            //pictureBox1.ImageLocation = pfad + alleFotos[index].DateinameDest;
        }

        public Frm_FotosVonFang(List<Fangliste> fangliste, List<Foto> alleFotos, int index)
        {
            InitializeComponent();

            this.alleFotos = alleFotos;
            this.fangliste = fangliste;
            this.index = index;
            //pictureBox1.ImageLocation = pfad + alleFotos[index].DateinameDest;
        }

        public Frm_FotosVonFang(string titel, string bilddatei)
        {
            InitializeComponent();

            this.Text = titel;
            pictureBox1.ImageLocation = bilddatei;
            button_back.Visible = false;
            button_vor.Visible = false;
        }

        private void Frm_FotosVonFang_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.ImageLocation = Frm_Hauptmenu.FotoOrdner + "\\" + this.alleFotos[foto_jetzt].Dateiname;
            }
            catch { }

            position = foto_jetzt + 1;
            this.Text = "Gefangen von " + fangliste[index].Name + " am " + fangliste[index].Datum.ToShortDateString() + " um " + fangliste[index].Uhrzeit.ToShortTimeString() + " (Gewicht: " + fangliste[index].Gewicht + "kg, Größe: " + fangliste[index].Größe + "cm, Gewässer: " + fangliste[index].Gewässer + ") " + position + " von " + alleFotos.Count;

            button_back.Enabled = false;

            if (alleFotos != null)
            {
                if (alleFotos.Count == 1)
                {
                    button_vor.Enabled = false;
                }
            }
            else
            {
                button_vor.Enabled = false;
            }
        }

        #endregion

        #region Button

        private void button_vor_Click(object sender, EventArgs e)
        {
            int zahl;
            if (foto_jetzt < alleFotos.Count - 1)
            {
                zahl = foto_jetzt + 1;
                button_back.Enabled = true;
            }
            else
            {
                zahl = foto_jetzt;
            }
            if (zahl == alleFotos.Count - 1)
            {
                button_vor.Enabled = false;
            }

            foto_jetzt = zahl;
            pictureBox1.ImageLocation = Frm_Hauptmenu.FotoOrdner + "\\" + this.alleFotos[foto_jetzt].Dateiname;

            position = foto_jetzt + 1;
            this.Text = "Gefangen von " + fangliste[index].Name + " am " + fangliste[index].Datum.ToShortDateString() + " um " + fangliste[index].Uhrzeit.ToShortTimeString() + " (Gewicht: " + fangliste[index].Gewicht + "kg, Größe: " + fangliste[index].Größe + "cm, Gewässer: " + fangliste[index].Gewässer + ") " + position + " von " + alleFotos.Count;

        }

        private void button_back_Click(object sender, EventArgs e)
        {
            int zahl;
            if (foto_jetzt > 0)
            {
                zahl = foto_jetzt - 1;
                button_vor.Enabled = true;
            }
            else
            {
                zahl = foto_jetzt;
            }
            if (zahl == 0)
            {
                button_back.Enabled = false;
            }

            foto_jetzt = zahl;
            pictureBox1.ImageLocation = Frm_Hauptmenu.FotoOrdner + "\\" + this.alleFotos[foto_jetzt].Dateiname;

            position = foto_jetzt + 1;
            this.Text = "Gefangen von " + fangliste[index].Name + " am " + fangliste[index].Datum.ToShortDateString() + " um " + fangliste[index].Uhrzeit.ToShortTimeString() + " (Gewicht: " + fangliste[index].Gewicht + "kg, Größe: " + fangliste[index].Größe + "cm, Gewässer: " + fangliste[index].Gewässer + ") " + position + " von " + alleFotos.Count;
        }


        #endregion

        #region Methoden

        #endregion
    }
}
