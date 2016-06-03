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
    public partial class Frm_Download : Form
    {
        #region Variablen

        string downloadFile;
        bool close = false;
        bool error = false;

        #endregion

        #region Konstruktor

        public Frm_Download()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Frm_Download_Load(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Fangliste.csv";
            saveFileDialog1.Filter = "CSV Datei (*.csv)|*.csv";

            DialogResult r = saveFileDialog1.ShowDialog();

            if (r == System.Windows.Forms.DialogResult.OK)
            {
                label_status.Text = "Datei wird Heruntergeladen.";
                this.Cursor = Cursors.WaitCursor;
                downloadFile = saveFileDialog1.FileName;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                this.Close();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(500);

            try
            {
                    Network.ftp ftp = new Network.ftp(Properties.Settings.Default.Hostname, Properties.Settings.Default.Username, Properties.Settings.Default.Passwort);

                    ftp.download("Fangliste.csv", downloadFile);
            }
            catch
            {
                error = true;
                this.Invoke(new MethodInvoker(delegate { label_status.Text = "Fehler\nDatei konnte nich Heruntergeladen werden."; }));
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.CancelAsync();
            this.Cursor = Cursors.Default;
            btn_cancel.Text = "schließen";
            close = true;
            if(error == false)
                label_status.Text = "Datei wurde erfolgreich Heruntergeladen.";
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (close)
                this.Close();
            else
                backgroundWorker1.CancelAsync();
        }

        #endregion
    }
}
