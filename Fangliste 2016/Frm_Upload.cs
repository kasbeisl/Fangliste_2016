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
    public partial class Frm_Upload : Form
    {
        #region Variablen

        bool close = false;
        bool error = false;

        #endregion

        #region Konstrktor

        public Frm_Upload()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Frm_Upload_Load(object sender, EventArgs e)
        {
            label_status.Text = "Datei wird hochgeladen.";
            this.Cursor = Cursors.WaitCursor;
            backgroundWorker1.RunWorkerAsync();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (close)
                this.Close();
            else
                backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(500);

            try
            {
                Network.ftp ftp = new Network.ftp(Properties.Settings.Default.Hostname/* + ":" + Properties.Settings.Default.Port*/, Properties.Settings.Default.Username, Properties.Settings.Default.Passwort);
                ftp.upload("Fangliste.csv", Frm_Hauptmenu.DatenOrdner + "\\" + Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp);
            }
            catch
            {
                error = true;
                this.Invoke(new MethodInvoker(delegate { label_status.Text = "Fehler\nDatei konnte nich Hochgeladen werden."; }));
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.CancelAsync();
            this.Cursor = Cursors.Default;
            btn_cancel.Text = "schließen";
            close = true;
            if(error == false)
                label_status.Text = "Datei wurde erfolgreich Hochgeladen.";
        }

        #endregion
    }
}
