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
    public partial class Frm_Fangliste_Backup : Form
    {
        #region variablen

        #endregion

        #region konstruktor

        public Frm_Fangliste_Backup()
        {
            InitializeComponent();
        }

        private void Frm_Fangliste_Backup_Load(object sender, EventArgs e)
        {
            btn_wiederherstellen.Enabled = false;
            btn_anzeigen.Enabled = false;

            string[] files = Directory.GetFiles(Frm_Hauptmenu.DatenOrdner + "Backup", "*.csv", SearchOption.AllDirectories);
            string[] _files1 = new string[files.Length];
            List<string> files1 = new List<string>();

            if (files != null)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    _files1[i] = Path.GetFileNameWithoutExtension(files[i]);
                }
            }

            if(_files1 != null)
            {
                for (int i = 0; i < _files1.Length; i++)
                {
                    string[] a = _files1[i].Split('_');
                    if(a[0] == "Fangliste")
                        files1.Add(a[1]);
                }

                listBox1.Items.Clear();

                for (int i = 0; i < files1.Count; i++)
                {
                    listBox1.Items.Add(files1[i]);
                }
            }
        }

        #endregion

        private void btn_wiederherstellen_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Möchten Sie die Fangliste wieder herstellen?", "Backup", MessageBoxButtons.YesNo);

            if (r == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    File.Copy(Frm_Hauptmenu.DatenOrdner + "Backup\\Fangliste_" + listBox1.SelectedItems[0].ToString() + Properties.Settings.Default.Datentyp, Frm_Hauptmenu.DatenOrdner + Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp, true);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Fehler");
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                btn_wiederherstellen.Enabled = false;
                btn_anzeigen.Enabled = false;
            }
            else
            {
                btn_wiederherstellen.Enabled = true;
                btn_anzeigen.Enabled = true;
            }
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void btn_anzeigen_Click(object sender, EventArgs e)
        {
            List<Fangliste> fanglisteBackup = Fangliste.LadenAsList(Frm_Hauptmenu.DatenOrdner + "\\Backup\\", "Fangliste_" + listBox1.SelectedItems[0].ToString() + Properties.Settings.Default.Datentyp);
            Frm_alleFänge_nur_Liste frm_backup = new Frm_alleFänge_nur_Liste(fanglisteBackup);
            frm_backup.ShowDialog();
        }

        #region Events

        #endregion
    }
}
