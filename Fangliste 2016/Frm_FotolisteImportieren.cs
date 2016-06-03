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
using System.IO.Compression;

namespace Fangliste_2016
{
    public partial class Frm_FotolisteImportieren : Form
    {
        #region Variablen

        List<Foto> alleFotos;
        List<Foto> alleFotos_kopie;
        List<Foto> importListe = null;
        List<Foto> importListe_kopie = null;

        int[] index_keinFoto = null;
        bool[] fotoChecked;
        int[] doppelteFotos = null;

        //Einstellungen einstellung;

        #endregion

        #region Forms

        Frm_Fotoliste frm_fotoliste;

        #endregion

        #region Konstruktor

        public Frm_FotolisteImportieren(List<Foto> alleFotos)
        {
            InitializeComponent();

            this.alleFotos = alleFotos;
        }

        private void Frm_FotolisteImportieren_Load(object sender, EventArgs e)
        {
            groupBox_analyse.Enabled = false;
            groupBox_ergebnis.Enabled = false;
            btn_importieren.Enabled = false;
        }

        #endregion

        #region Methoden

        private void FotolistePrüfen()
        {
            //try
            //{
            //    importListe_kopie = new List<Foto>();
            //    importListe_kopie = Foto.Kopiere_Objektarray(this.importListe);

            //    //Set progress value
            //    progressBar1.Maximum = (importListe.Count * alleFotos.Count) + importListe.Count;

            //    string[] index_keinFotos_kopie = new string[alleFotos.Count * importListe.Count];
            //    if (index_keinFotos_kopie.Length == 0)
            //    {
            //        index_keinFotos_kopie = new string[importListe.Count];
            //    }

            //    int zähler = 0;

            //    //prüfe ob fotodatei vorhaden ist.
            //    for (int i = 0; i < importListe.Count; i++)
            //    {
            //        if (!File.Exists(textBox1.Text + "\\" + this.importListe[i].DateinameDest))
            //        {
            //            index_keinFotos_kopie[zähler] = i.ToString();
            //            zähler++;
            //        }

            //        progressBar1.Value += 1;
            //    }

            //    int count = 0;
            //    for (int i = 0; i < index_keinFotos_kopie.Length; i++)
            //    {
            //        if (index_keinFotos_kopie[i] != null)
            //        {
            //            count++;
            //        }
            //    }

            //    index_keinFoto = new int[count];
            //    for (int i = 0; i < index_keinFotos_kopie.Length; i++)
            //    {
            //        if (index_keinFotos_kopie[i] != null)
            //        {
            //            index_keinFoto[i] = Convert.ToInt16(index_keinFotos_kopie[i]);
            //        }
            //    }

            //    //prüfe ob in der fotoliste die dateinamen nicht doppelt sind, wenn schon dann wird der dateiname geändert.
            //    int zähler1 = 0;

            //    for (int i = 0; i < importListe_kopie.Count; i++)
            //    {
            //        zähler1 = 0;

            //        for (int j = 0; j < alleFotos.Count; j++)
            //        {
            //            string file = importListe[i].FischerName + "_" + importListe[i].Datum.ToShortDateString() + "_" + importListe[i].Gewässer + "_" + importListe[i].Größe + "_" + importListe[i].Gewicht + "_" + zähler1 + ".jpg";

            //            for (int a = 0; a < alleFotos.Count; a++)
            //            {
            //                if (file == alleFotos[a].DateinameDest)
            //                {
            //                    zähler1++;
            //                    break;
            //                }
            //            }

            //            progressBar1.Value += 1;
            //        }

            //        importListe_kopie[i].DateinameDest = importListe[i].FischerName + "_" + importListe[i].Datum.ToShortDateString() + "_" + importListe[i].Gewässer + "_" + importListe[i].Größe + "_" + importListe[i].Gewicht + "_" + zähler1 + ".jpg";

            //        for (int l = 0; l < importListe_kopie.Count; l++)
            //        {
            //            for (int j = 0; j < importListe_kopie.Count; j++)
            //            {
            //                for (int a = 0; a < importListe_kopie.Count; a++)
            //                {
            //                    if (importListe_kopie[l].DateinameDest == importListe_kopie[a].DateinameDest)
            //                    {
            //                        if (l != a)
            //                        {
            //                            zähler1++;
            //                            importListe_kopie[a].DateinameDest = importListe[a].FischerName + "_" + importListe[a].Datum.ToShortDateString() + "_" + importListe[a].Gewässer + "_" + importListe[a].Größe + "_" + importListe[a].Gewicht + "_" + zähler1 + ".jpg";
            //                        }
            //                    }
            //                }
            //            }


            //        }
            //    }

            //    doppelteFotos = DoppelteFotosPrüfen();

            //    fotoChecked = new bool[this.importListe.Count];
            //    for (int i = 0; i < fotoChecked.Length; i++)
            //    {
            //        bool none = false;

            //        for (int j = 0; j < index_keinFoto.Length; j++)
            //        {
            //            if (i == index_keinFoto[j])
            //            {
            //                none = true;
            //            }
            //        }

            //        if (!none)
            //        {
            //            fotoChecked[i] = true;
            //        }
            //        else
            //        {
            //            fotoChecked[i] = false;
            //        }
            //    }

            //    if (importListe != null)
            //    {
            //        lb_gesImportList.Text = importListe.Count.ToString();
            //    }

            //    if (index_keinFoto != null)
            //    {
            //        lb_anzahlKeinFoto.Text = index_keinFoto.Length.ToString();
            //    }
                
            //    if (zähler > 0)
            //    {
            //        lb_anzahlKeinFoto.ForeColor = Color.Red;
            //    }

            //    groupBox_ergebnis.Enabled = true;

            //    if ((importListe == null) || (importListe.Count == 0))
            //    {
            //        btn_importieren.Enabled = false;
            //        cb_keinFoto.Enabled = false;
            //        MessageBox.Show("Keine Fotos vorhanden.", "Import Fotoliste");
            //    }
            //    else
            //    {
            //        if (importListe.Count == index_keinFoto.Length)
            //        {
            //            cb_keinFoto.Enabled = true;
            //            cb_keinFoto.Checked = true;
            //            btn_importieren.Enabled = false;
            //        }
            //        else
            //        {
            //            cb_keinFoto.Enabled = true;
            //            cb_keinFoto.Checked = true;
            //            btn_importieren.Enabled = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Unerwarteter Fehler.\n\nInformation:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        /// <summary>
        /// Gibt den Index der Fotoliste zurück die Doppelt sind.
        /// </summary>
        /// <returns></returns>
        private int[] DoppelteFotosPrüfen()
        {
            int[] index_doppel = null;
            string[] index_doppel_kopie = new string[this.alleFotos.Count];
            int zähler = 0;

            for (int i = 0; i < this.alleFotos.Count; i++)
            {
                //for (int j = 0; j < this.importListe.Count; j++)
                //{
                //    if (alleFotos[i].DateinameDest == importListe[j].DateinameDest)
                //    {
                //        index_doppel_kopie[zähler] = Convert.ToString(j);
                //        zähler++;
                //        //break;
                //    }
                //}
            }

            index_doppel = new int[zähler];
            for (int i = 0; i < index_doppel_kopie.Length; i++)
            {
                if (index_doppel_kopie[i] != null)
                {
                    index_doppel[i] = Convert.ToInt16(index_doppel_kopie[i]);
                }
            }

            return index_doppel;
        }

        #endregion

        #region Eigenschaften

        public List<Foto> AlleFotos
        {
            get
            {
                return this.alleFotos_kopie;
            }
        }

        #endregion

        #region Events

        private void btn_durchsuchen_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Wähle einen Ordner aus. (wo die Fotoliste u. Fotos enthalten sind.)";

            DialogResult open = folderBrowserDialog1.ShowDialog();

            if (open == DialogResult.OK)
            {
                groupBox_analyse.Enabled = false;
                groupBox_ergebnis.Enabled = false;
                btn_importieren.Enabled = false;

                string pfad = folderBrowserDialog1.SelectedPath;

                textBox1.Text = pfad;

                string[] files = Directory.GetFiles(pfad);

                string dateiname = "fotoliste.csv";

                if (File.Exists(pfad + "\\" + dateiname))
                {
                    groupBox_analyse.Enabled = true;

                    try
                    {
                        //importListe = Foto.Lese_Fotoliste_aus(pfad + "\\", dateiname);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unerwarteter Fehler.\n\nInformation:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        groupBox_analyse.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Der Ordner enthält keine Fotoliste.", "Information.");
                }
            }
        }

        private void btn_analysieren_Click(object sender, EventArgs e)
        {
            btn_analysieren.Enabled = false;

            FotolistePrüfen();
        }

        private void btn_fotolisteAnsehen_Click(object sender, EventArgs e)
        {
            frm_fotoliste = new Frm_Fotoliste(this.importListe, this.index_keinFoto, this.fotoChecked, this.doppelteFotos, cb_keinFoto.Checked,textBox1.Text + "\\");
            frm_fotoliste.ShowDialog();

            this.fotoChecked = frm_fotoliste.FotoChecked;

            int wieVielnichtkopieren = 0;

            for (int i = 0; i < fotoChecked.Length; i++)
            {
                if (!fotoChecked[i])
                {
                    wieVielnichtkopieren++;
                }
            }

            if (wieVielnichtkopieren == this.importListe_kopie.Count)
            {
                btn_importieren.Enabled = false;
            }
            else
            {
                if (cb_keinFoto.Checked)
                {
                    if (importListe.Count == index_keinFoto.Length)
                    {
                        btn_importieren.Enabled = false;
                    }
                    else
                    {
                        btn_importieren.Enabled = true;
                        //for (int i = 0; i < index_keinFoto.Length; i++)
                        //{
                        //    fotoChecked[index_keinFoto[i]] = false;
                        //}
                    }
                }
                else
                {
                    btn_importieren.Enabled = true;

                    //for (int i = 0; i < index_keinFoto.Length; i++)
                    //{
                    //    fotoChecked[index_keinFoto[i]] = true;
                    //}
                }
            }
        }

        private void btn_importieren_Click(object sender, EventArgs e)
        {
            if (index_keinFoto.Length > 0)
            {
                if (!cb_keinFoto.Checked)
                {
                    DialogResult frage = MessageBox.Show("'Nur hinzufügen wenn Foto vorhanden' wurde deaktiviert, soll denoch der Eintrag importiert werden?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (frage == DialogResult.No)
                    {
                        for (int i = 0; i < index_keinFoto.Length; i++)
                        {
                            fotoChecked[index_keinFoto[i]] = false;
                        }
                    }
                }
            }

            int wieVielnichtkopieren = 0;

            for (int i = 0; i < fotoChecked.Length; i++)
            {
                if (!fotoChecked[i])
                {
                    wieVielnichtkopieren++;
                }
            }

            //sicherheitkopie
            try
            {
                //File.Copy(einstellung.Pfad + einstellung.Dateiname_Fangliste, einstellung.Pfad + "sicherheitskopieFOTO", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Die Sicherheitskopie konnte nicht erstellt werden.\n\nInformationen:\n" + ex.ToString(), "Fehler.");
            }


            try
            {
                this.alleFotos_kopie = new List<Foto>();

                for (int i = 0; i < this.alleFotos.Count; i++)
                {
                    this.alleFotos_kopie[i] = this.alleFotos[i];
                }

                int zähler = this.alleFotos.Count;

                for (int i = 0; i < this.importListe_kopie.Count; i++)
                {
                    if (fotoChecked[i])
                    {
                        this.alleFotos_kopie[zähler] = this.importListe_kopie[i];
                        zähler++;
                    }
                }

                for (int i = 0; i < this.importListe_kopie.Count; i++)
                {
                    try
                    {
                        if (fotoChecked[i])
                        {
                            //if (File.Exists(textBox1.Text + "\\" + importListe[i].DateinameDest))
                            //{
                            //    File.Copy(textBox1.Text + "\\" + importListe[i].DateinameDest, einstellung.FotoOrdner + importListe_kopie[i].DateinameDest);
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unerwarteter Fehler.\n\nInformationen:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //Foto.Speichere_Fotoliste(this.alleFotos_kopie, einstellung.Pfad, einstellung.Dateiname_Fotoliste);

                groupBox_fotoliste.Enabled = true;
                textBox1.Text = "";
                groupBox_analyse.Enabled = false;
                progressBar1.Value = 0;
                groupBox_ergebnis.Enabled = false;
                btn_importieren.Enabled = false;
                MessageBox.Show("Fotos wurde erfolgreich importiert.", "Import");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Die Fotos konnten nicht importiert werden.\n\nInformationen:\n" + ex.ToString(), "Fehler.");
            }

            //Lösche Sicherheitskopie
            try
            {
                //File.Delete(einstellung.Pfad + "sicherheitskopieFOTO");
            }
            catch { }
        }

        private void cb_keinFoto_Click(object sender, EventArgs e)
        {
            if ((importListe != null) || (importListe.Count != 0))
            {
                if (cb_keinFoto.Checked)
                {
                    if (importListe.Count == index_keinFoto.Length)
                    {
                        btn_importieren.Enabled = false;
                    }
                    else
                    {
                        btn_importieren.Enabled = true;
                        for (int i = 0; i < index_keinFoto.Length; i++)
                        {
                            fotoChecked[index_keinFoto[i]] = false;
                        }

                        int wieVielnichtkopieren = 0;

                        for (int i = 0; i < fotoChecked.Length; i++)
                        {
                            if (!fotoChecked[i])
                            {
                                wieVielnichtkopieren++;
                            }
                        }

                        if (wieVielnichtkopieren == this.importListe_kopie.Count)
                        {
                            btn_importieren.Enabled = false;
                        }
                    }
                }
                else
                {
                    btn_importieren.Enabled = true;

                    for (int i = 0; i < index_keinFoto.Length; i++)
                    {
                        fotoChecked[index_keinFoto[i]] = true;
                    }
                }
            }
            else
            {
                btn_importieren.Enabled = false;
            }
        }

        #endregion
    }
}
