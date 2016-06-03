using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Fangliste_2016
{
    public partial class Frm_Files : Form
    {
        #region Variablen

        string pfad;
        string[] filetyp;
        string[] filetypInfo;
        int index = 0;
        FileInfo datei = null;

        #endregion

        #region Konstruktor

        /// <summary>
        /// titel = Der Text vom Fenster
        /// pfad = Das Verzeichniss von dem die Daten angezeigt werden sollen (z.B. 'C:\pfad\')
        /// filetyp = z.B. 'Textdokument (*.txt)|*.txt|Alle Datein (*.*)|*.*'
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="pfad"></param>
        /// <param name="filetyp"></param>
        public Frm_Files(string titel, string pfad, string[] filetyp, string[] filetypInfo)
        {
            InitializeComponent();

            this.Text = titel;
            this.pfad = pfad;
            this.filetyp = filetyp;
            this.filetypInfo = filetypInfo;
        }

        private void Frm_Files_Load(object sender, EventArgs e)
        {
            btn_neueDatei.Enabled = false;
            btn_ok.Enabled = false;
            einfügentoolStripMenuItem.Enabled = false;

            MacheListeVonPfad();

            for (int i = 0; i < filetypInfo.Length; i++)
            {
                cb_filetyp.Items.Add(filetypInfo[i]);
            }

            cb_filetyp.Text = filetypInfo[this.index];
        }

        #endregion

        #region Events

        private void btn_neueDatei_Click(object sender, EventArgs e)
        {
            if (!File.Exists(pfad + tbx_neueDatei.Text))
            {
                File.WriteAllText(pfad + tbx_neueDatei.Text + filetyp[this.index], "");
                MacheListeVonPfad();
            }
            else
            {
                MessageBox.Show("Datei Existiert!", "Neue Datei");
            }

            btn_neueDatei.Enabled = false;
            tbx_neueDatei.Text = "";
            btn_ok.Enabled = false;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                if (listBox1.SelectedItems[0].ToString() != "")
                {
                    datei = new FileInfo(listBox1.SelectedItems[0].ToString());
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void cb_filetyp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.index = cb_filetyp.SelectedIndex;
            MacheListeVonPfad();
            btn_ok.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                btn_ok.Enabled = true;
            }
            else
            {
                btn_ok.Enabled = false;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                kopierenToolStripMenuItem.Enabled = true;
                löschenToolStripMenuItem.Enabled = true;
            }
            else
            {
                kopierenToolStripMenuItem.Enabled = false;
                löschenToolStripMenuItem.Enabled = false;
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                btn_ok_Click(sender, e);
            }
        }

        private void tbx_neueDatei_TextChanged(object sender, EventArgs e)
        {
            if (tbx_neueDatei.Text == "")
            {
                btn_neueDatei.Enabled = false;
            }
            else
            {
                btn_neueDatei.Enabled = true;
            }
        }

        #endregion

        #region Eigenschaften

        public FileInfo Datei
        {
            get { return this.datei; }
        }

        #endregion

        #region Context

        private void kopierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(listBox1.SelectedItems[0].ToString());

                einfügentoolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unerwarteter Fehler\n\nInformation:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btn_ok.Enabled = false;
        }

        private void einfügentoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string neueDateiname = pfad + Clipboard.GetText();

                if (filetyp[this.index] != "")
                {
                    string text = neueDateiname.Remove(neueDateiname.Length - 4);
                    neueDateiname = text + "_kopie" + filetyp[this.index];
                }

                File.Copy(pfad + Clipboard.GetText(), neueDateiname);
                MacheListeVonPfad();
                einfügentoolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unerwarteter Fehler\n\nInformation:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btn_ok.Enabled = false;
        }

        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult frage = MessageBox.Show("Sind Sie sicher?", "Datei löschen.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (frage == DialogResult.Yes)
            {
                try
                {
                    File.Delete(pfad + listBox1.SelectedItems[0].ToString());
                    MacheListeVonPfad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unerwarteter Fehler\n\nInformation:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            btn_ok.Enabled = false;
        }

        #endregion

        #region Methoden

        private void MacheListeVonPfad()
        {
            try
            {
                listBox1.Items.Clear();

                string[] f = Directory.GetFiles(this.pfad);
                string[] Files = new string[f.Length];
                int count = 0;

                foreach (string file in f)
                {
                    Files[count] = Path.GetFileName(file);
                    count++;
                }


                string[] _files = null;

                if (filetyp[this.index] == "")
                {
                    _files = new string[Files.Length];
                    _files = Files;
                }
                else
                {
                    int zähler = 0;

                    FileInfo file;

                    for (int i = 0; i < Files.Length; i++)
                    {
                        file = new FileInfo(Files[i]);

                        if (file.Extension == filetyp[this.index])
                        {
                            zähler++;
                        }
                    }

                    _files = new string[zähler];

                    int index = 0;

                    for (int i = 0; i < Files.Length; i++)
                    {
                        file = new FileInfo(Files[i]);

                        if (file.Extension == filetyp[this.index])
                        {
                            _files[index] = Files[i];
                            index++;
                        }
                    }
                }

                listBox1.Items.AddRange(_files);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unerwarteter Fehler\n\nInformation:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
