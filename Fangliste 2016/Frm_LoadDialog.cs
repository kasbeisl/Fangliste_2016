using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FanglisteLibrary;
using System.Threading;

namespace Fangliste_2016
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_LoadDialog : Form
    {
        #region Variablen

        List<Angler> anglerliste;
        List<Fischarten> fischartenliste;
        List<Fangliste> fangliste;
        List<Foto> fotoliste = null;

        #endregion

        #region Konstruktor

        /// <summary>
        /// 
        /// </summary>
        public Frm_LoadDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Frm_LoadDialog_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);

            Anglerliste_auslesen();
            FischartenListe_auslesen();
            Fangliste_auslesen();
            Fotoliste_auslesen();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        #region Eigenschaften

        public List<Angler> GetAnglerliste
        {
            get { return this.anglerliste; }
        }

        public List<Fischarten> GetFischartenliste
        {
            get { return this.fischartenliste; }
        }

        public List<Fangliste> GetFangliste
        {
            get { return this.fangliste; }
        }

        public List<Foto> GetFotoliste
        {
            get { return this.fotoliste; }
        }

        #endregion

        #region Methoden

        private void Anglerliste_auslesen()
        {
            try
            {
                this.anglerliste = Angler.LadenAsList(Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Anglerliste + Properties.Settings.Default.Datentyp);
            }
            catch
            {
                this.anglerliste = new List<Angler>();
            }
        }

        private void Fotoliste_auslesen()
        {
            try
            {
                this.fotoliste = Foto.LadenAsList(Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Fotoliste + Properties.Settings.Default.Datentyp);
            }
            catch
            {
                this.fotoliste = new List<Foto>();
            }
        }

        private void Fangliste_auslesen()
        {
            try
            {
                this.fangliste = Fangliste.LadenAsList(Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp);
            }
            catch
            {
                this.fangliste = new List<Fangliste>();
            }
        }

        private void FischartenListe_auslesen()
        {
            try
            {
                this.fischartenliste = Fischarten.Laden(Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Fischartenliste + Properties.Settings.Default.Datentyp);
            }
            catch
            {
                this.fischartenliste = new List<Fischarten>();
            }
        }

        #endregion
    }
}
