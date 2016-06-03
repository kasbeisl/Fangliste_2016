using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FanglisteLibrary;

namespace Fangliste_2016
{
    public partial class Frm_FotolisteExportieren : Form
    {
        #region Variablen

        Foto[] alleFotos;
        Einstellungen einstellungen;
        string destPath;

        bool fertig = true;

        #endregion

        #region Konstruktor

        public Frm_FotolisteExportieren(Foto[] alleFotos, Einstellungen einstellungen, string destPath)
        {
            InitializeComponent();

            this.alleFotos = alleFotos;
            this.einstellungen = einstellungen;
            this.destPath = destPath + "\\" +Path.GetFileNameWithoutExtension(einstellungen.Pfad + einstellungen.Dateiname_Fotoliste);
        }

        private void Frm_FotolisteExportieren_Load(object sender, EventArgs e)
        {
            Kopieren();
        }

        #endregion

        #region Methoden

        private void Kopieren()
        {
            //try
            //{
            //    string[] fotos = Directory.GetFiles(einstellungen.FotoOrdner);

            //    progressBar1.Maximum = fotos.Length + 2;

            //    if (!Directory.Exists(destPath))
            //    {
            //        Directory.CreateDirectory(destPath);
            //    }

            //    progressBar1.Value += 1;

            //    try
            //    {
            //        File.Copy(einstellungen.Pfad + einstellungen.Dateiname_Fotoliste, destPath + "\\" + "fotoliste.fzp", true);

            //        progressBar1.Value += 1;

            //        for (int i = 0; i < fotos.Length; i++)
            //        {
            //            bool exist = false;

            //            for (int j = 0; j < this.alleFotos.Length; j++)
            //            {
            //                if (this.alleFotos[j].DateinameDest == Path.GetFileName(fotos[i]))
            //                {
            //                    exist = true;
            //                    break;
            //                }
            //            }

            //            if (exist)
            //            {
            //                File.Copy(fotos[i], destPath + "\\" + Path.GetFileName(fotos[i]), true);
            //            }

            //            fertig = true;

            //            progressBar1.Value += 1;
            //        }

            //        btn_abbrechen.Text = "fertig";
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Datei konnte nicht kopiert werden.\n\nInformationen:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Unerwarteter Fehler.\n\nInformationen:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        #endregion

        #region Eigenschaften

        #endregion

        #region Events

        private void btn_abbrechen_Click(object sender, EventArgs e)
        {
            if (!fertig)
            {
                DialogResult frage = MessageBox.Show("Sind Sie sicher?", "Abbrechen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (frage == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        #endregion
    }
}
