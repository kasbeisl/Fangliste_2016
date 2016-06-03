using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Fangliste_2016
{
    public partial class Frm_FotoOrdnerDialog : Form
    {
        #region Variablen

        string[] ordner;
        string selectedFolder;

        #endregion

        #region Konstruktor

        public Frm_FotoOrdnerDialog()
        {
            InitializeComponent();
        }

        private void Frm_FotoOrdnerDialog_Load(object sender, EventArgs e)
        {
            btn_wählen.Enabled = false;

            string[] d = Directory.GetDirectories(Frm_Hauptmenu.FotoOrdner);
            ordner = new string[d.Length];

            for (int i = 0; i < d.Length; i++)
            {
                DirectoryInfo di = new DirectoryInfo(d[i]);
                ordner[i] = di.Name;
            }

            Zeichnen();
        }

        #endregion

        public string Ordner
        {
            get { return selectedFolder; }
        }

        private void Zeichnen()
        {
            if ((ordner != null) || (ordner.Length != 0))
            {
                listView1.Items.Clear();

                for (int i = 0; i < ordner.Length; i++)
                {
                    listView1.Items.Add(ordner[i], 0);
                }
            }
        }

        private void btn_wählen_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                this.selectedFolder = listView1.SelectedItems[0].Text;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_abbrechen_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btn_neuerOrdner_Click(object sender, EventArgs e)
        {
            try
            {  
                Directory.CreateDirectory(Frm_Hauptmenu.FotoOrdner + "\\" + "NeuerOrdner");

                string[] d = Directory.GetDirectories(Frm_Hauptmenu.FotoOrdner);
                ordner = new string[d.Length];

                for (int i = 0; i < d.Length; i++)
                {
                    DirectoryInfo di = new DirectoryInfo(d[i]);
                    ordner[i] = di.Name;
                }

                Zeichnen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fehler");
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btn_wählen_Click(sender, e);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                btn_wählen.Enabled = true;
            }
            else
            {
                btn_wählen.Enabled = false;
            }
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                if(Directory.Exists(Frm_Hauptmenu.FotoOrdner + "\\" + listView1.SelectedItems[0].Text))
                        Directory.Move(Frm_Hauptmenu.FotoOrdner + "\\" + listView1.SelectedItems[0].Text, Frm_Hauptmenu.FotoOrdner + "\\" + e.Label.ToString());// listView1.SelectedItems[0].Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fehler");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(Frm_Hauptmenu.FotoOrdner))
                Process.Start("explorer.exe", Frm_Hauptmenu.FotoOrdner);
        }
    }
}
