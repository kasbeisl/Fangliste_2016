using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FanglisteLibrary;
using System.IO;

namespace Fangliste_2016
{
    public partial class Frm_DoppelteFotos : Form
    {
        #region Variablen

        List<List<string>> liste;
        int index;

        #endregion

        #region Konstruktor

        public Frm_DoppelteFotos()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Frm_DoppelteFotos_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            label1.Text = "";
            label2.Text = "";

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                liste = FanglisteLibrary.Foto.Vergleichen(Frm_Hauptmenu.FotoOrdner, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fehler");
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Zeichnen();

            this.Cursor = Cursors.Default;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndices.Count > 0)
            {
                try
                {
                    index = listBox1.SelectedIndices[0];

                    pictureBox1.ImageLocation = liste[index][0];
                    label1.Text = liste[index][0];
                    pictureBox2.ImageLocation = liste[index][1];
                    label2.Text = liste[index][1];

                    btn_löschenLinks.Enabled = true;
                    btn_löschenRechts.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Fehler");
                }
            }
        }

        private void btn_löschenLinks_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Wollen Sie das Foto löschen?", "Löschen", MessageBoxButtons.YesNo);

            if (r == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    if (File.Exists(label1.Text))
                        File.Delete(label1.Text);

                    listBox1.Items.RemoveAt(index);
                    pictureBox1.ImageLocation = "";
                    label1.Text = "";
                    btn_löschenLinks.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Fehler");
                }
            }
        }

        private void btn_löschenRechts_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Wollen Sie das Foto löschen?", "Löschen", MessageBoxButtons.YesNo);

            if (r == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    if (File.Exists(label2.Text))
                        File.Delete(label2.Text);

                    listBox1.Items.RemoveAt(index);
                    pictureBox2.ImageLocation = "";
                    label2.Text = "";
                    btn_löschenRechts.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Fehler");
                }
            }
        }

        #endregion

        #region Methoden

        /// <summary>
        /// Trägt alle doppelten Bilder in die ListBox ein.
        /// </summary>
        private void Zeichnen()
        {
            if (liste != null && liste.Count != 0)
            {
                for (int i = 0; i < liste.Count; i++)
                {
                    string file1 = liste[i][0].ToString();
                    string file2 = liste[i][1].ToString();
                    FileInfo f1 = new FileInfo(file1);
                    FileInfo f2 = new FileInfo(file2);
                    string text = "Foto 1: " + f1.Name + " << Foto 2: " + f2.Name;
                    listBox1.Items.Add(text);
                }
            }
        }

        #endregion
    }
}
