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
    public partial class Frm_FanglisteBearbeiten : Form
    {
        #region Variablen

        //List<Fangliste> alleFänge;
        List<Fangliste> alleFänge_Kopie;

        //List<Foto> alleFotos;
        bool fotoChanged = false;

        //int index = 0;

        bool änderung = false;
        bool button_speichern = false;
        //List<Fischarten> fischartenliste;

        //string selectedItem = "";

        #endregion

        #region Forms

        //Frm_Fang_bearbeiten frm_fangbearbeiten;

        #endregion

        #region Konstruktor

        public Frm_FanglisteBearbeiten()
        {
            InitializeComponent();
        }

        private void Frm_FanglisteBearbeiten_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fanglisteDBDataSet.FanglisteEdit' table. You can move, or remove it, as needed.
            this.fanglisteEditTableAdapter.Fill(this.fanglisteDBDataSet.FanglisteEdit);
            // TODO: This line of code loads data into the 'fanglisteDBDataSet.AlleFänge' table. You can move, or remove it, as needed.
            this.alleFängeTableAdapter.Fill(this.fanglisteDBDataSet.AlleFänge);
            //alleFänge_Kopie = Fangliste.Kopiere_ObjektarrayAslist(alleFänge);
            
            löschenToolStripMenuItem.Enabled = false;
            bearbeitenToolStripMenuItem.Enabled = false;

            //MacheGesamteListe();

            //this.alleFotos = Foto.LadenAsList(einstellungen.Pfad, einstellungen.Dateiname_Fotoliste);
        }

        #endregion

        #region Eigenschaften

        public List<Fangliste> Aktuelle_Fangliste
        {
            get
            {
                return this.alleFänge_Kopie;
            }
        }

        #endregion

        #region Methoden

        private void MacheGesamteListe()
        {
            /*this.WindowState = FormWindowState.Maximized;

            listAlle_fänge.Items.Clear();

            int zähler = 0;
            //create liste
            for (int i = 0; i < alleFänge_Kopie.Count; i++)
            {
                if (alleFänge_Kopie[i].Name != null)
                {
                    ListViewItem item = new ListViewItem(alleFänge_Kopie[i].GetListToDraw, i);

                    listAlle_fänge.Items.Add(item);
                    zähler++;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                listAlle_fänge.Columns[i].Width = -2;
            }*/

        }

        //private void WerteInDerFotolisteÄndern(int index)
        //{
        //    for (int i = 0; i < alleFotos.Length; i++)
        //    {
        //        if ((alleFotos[i].FischerName == alleFänge_Kopie[index].Name) ||
        //            (alleFotos[i].Fischart == alleFänge_Kopie[index].Name) ||
        //            (alleFotos[i].Größe == alleFänge_Kopie[index].Größe) ||
        //            (alleFotos[i].Gewicht == alleFänge_Kopie[index].Gewicht) ||
        //            (alleFotos[i].Gewässer == alleFänge_Kopie[index].Gewässer) ||
        //            (alleFotos[i].Datum == alleFänge_Kopie[index].Datum) ||
        //            (alleFotos[i].Uhrzeit == alleFänge_Kopie[index].Uhrzeit))
        //        {

        //        }
        //    }
        //}

        #endregion

        #region Buttons und Events

        private void listAlle_fänge_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /*if (listAlle_fänge.SelectedItems.Count > 0)
            {
                if (listAlle_fänge.SelectedItems[0].Text != "")
                {
                    //für den button löschen (Beschreibung: wenn der button gedrückt wird, geht das Selektierte Item verloren und es gibt keinen text).
                    selectedItem = listAlle_fänge.SelectedItems[0].Text;
                    löschenToolStripButton.Enabled = true;
                    löschenToolStripMenuItem.Enabled = true;
                    bearbeitenToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                löschenToolStripButton.Enabled = false;
                löschenToolStripMenuItem.Enabled = false;
                bearbeitenToolStripMenuItem.Enabled = false;
            }*/
        }

        private void listAlle_fänge_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            /*index = 0;

            if (this.listAlle_fänge.SelectedItems.Count > 0)
            {
                index = this.listAlle_fänge.SelectedIndices[0];
            }

            frm_fangbearbeiten = new Frm_Fang_bearbeiten(this.alleFänge_Kopie, this.index, this.fischartenliste, this.alleFotos);
            DialogResult ok = frm_fangbearbeiten.ShowDialog();

            if (ok == DialogResult.OK)
            {
                speichernToolStripButton.Enabled = true;
                änderung = true;

                alleFänge_Kopie = frm_fangbearbeiten.AlleFänge;
                alleFotos = frm_fangbearbeiten.AlleFotos;
                fotoChanged = true;

                MacheGesamteListe();
            }*/
        }

        private void speichernToolStripButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Sind Sie sicher, dass alle eingaben korrekt sind?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                if (fotoChanged)
                {
                    //Foto.Speichere_Fotoliste(this.alleFotos, einstellungen.Pfad, einstellungen.Dateiname_Fotoliste);
                }
                button_speichern = true;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void löschenToolStripButton_Click(object sender, EventArgs e)
        {
            /*if (DialogResult.Yes == MessageBox.Show("Soll dieser Eintrag gelöscht werden?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                index = 0;

                if (this.listAlle_fänge.SelectedItems.Count > 0)
                {
                    index = this.listAlle_fänge.SelectedIndices[0];
                }

                List<Fangliste> Kopie_von_der_Kopie = new List<Fangliste>();
                Kopie_von_der_Kopie = Fangliste.Kopiere_Objektarray_und_um_eins_verkleinern(this.alleFänge_Kopie, index);

                alleFänge_Kopie = Kopie_von_der_Kopie;

                MacheGesamteListe();

                speichernToolStripButton.Enabled = true;
                änderung = true;
            }*/
        }

        private void Frm_FanglisteBearbeiten_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (änderung)
            {
                if (!button_speichern)
                {
                    speichernToolStripButton_Click(sender, e);

                    //DialogResult sure = MessageBox.Show("Möchten Sie die Änderungen speichern?", "ACHTUNG", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //if (sure == DialogResult.Yes)
                    //{
                    //    if (fotoChanged)
                    //    {
                    //        Foto.Speichere_Fotoliste(this.alleFotos, einstellungen.Pfad, einstellungen.Dateiname_Fotoliste);
                    //    }
                    //    this.DialogResult = DialogResult.OK;
                    //}
                }
            }
        }

        private void bearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*index = 0;

            if (this.listAlle_fänge.SelectedItems.Count > 0)
            {
                index = this.listAlle_fänge.SelectedIndices[0];
            }

            frm_fangbearbeiten = new Frm_Fang_bearbeiten(this.alleFänge_Kopie, this.index, this.fischartenliste, this.alleFotos);
            DialogResult ok = frm_fangbearbeiten.ShowDialog();

            if (ok == DialogResult.OK)
            {
                speichernToolStripButton.Enabled = true;
                änderung = true;

                alleFänge_Kopie = frm_fangbearbeiten.AlleFänge;
                alleFotos = frm_fangbearbeiten.AlleFotos;
                fotoChanged = true;

                MacheGesamteListe();
            }*/
        }

        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //löschenToolStripButton.Enabled = false;
            löschenToolStripButton_Click(sender, e);
        }


        #endregion
    }
}
