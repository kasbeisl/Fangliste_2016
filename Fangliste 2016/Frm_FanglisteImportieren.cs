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
    public partial class Frm_FanglisteImportieren : Form
    {
        #region Variablen

        List<Fangliste> alleFänge;
        List<Fangliste> alleFänge_kopie;
        List<Fangliste> importListe;

        List<int> index_doppelEintrag;
        List<int> index_doppelEintrag_kopie;

        List<bool> fangChecked;

        #endregion

        #region Forms

        Frm_alleFänge_nur_Liste frm_fanglisteAnsehen;

        #endregion

        #region Konstruktor

        public Frm_FanglisteImportieren()
        {
            InitializeComponent();
        }

        private void Frm_Importieren_Load(object sender, EventArgs e)
        {
            groupBox_analyse.Enabled = false;
            groupBox_ergebnis.Enabled = false;
            btn_importieren.Enabled = false;
        }

        #endregion

        #region Methoden

        private void FanglistePrüfen()
        {
            try
            {
                //Set progress value
                progressBar1.Maximum = importListe.Count;

                index_doppelEintrag = new List<int>();
                //int zähler = 0;

                for (int i = 0; i < importListe.Count; i++)
                {
                    for (int j = 0; j < alleFänge.Count; j++)
                    {
                        if ((importListe[i].Name == alleFänge[j].Name) &&
                            (importListe[i].Fischart == alleFänge[j].Fischart) &&
                            (importListe[i].Größe == alleFänge[j].Größe) &&
                            (importListe[i].Gewicht == alleFänge[j].Gewicht) &&
                            (importListe[i].Gewässer == alleFänge[j].Gewässer) &&
                            (importListe[i].Platzbesch == alleFänge[j].Platzbesch) &&
                            (importListe[i].Köderbeschr == alleFänge[j].Köderbeschr) &&
                            (importListe[i].Lufttemperatur == alleFänge[j].Lufttemperatur) &&
                            (importListe[i].Tiefe == alleFänge[j].Tiefe) &&
                            (importListe[i].Datum == alleFänge[j].Datum) &&
                            (importListe[i].Uhrzeit == alleFänge[j].Uhrzeit) &&
                            (importListe[i].Wetter == alleFänge[j].Wetter) &&
                            (importListe[i].Zurückgesetzt == alleFänge[j].Zurückgesetzt))
                        {
                            index_doppelEintrag.Add(i);
                            break;
                        }
                    }
                    progressBar1.Value += 1;
                }

                try
                {
                    index_doppelEintrag_kopie = new List<int>();

                    for (int i = 0; i < index_doppelEintrag.Count; i++)
                    {
                        if (index_doppelEintrag != null)
                        {
                            bool exist = false;

                            if (i > 0)
                            {
                                for (int j = 0; j < index_doppelEintrag.Count; j++)
                                {
                                    if (index_doppelEintrag != null)
                                    {
                                        if (i != j)
                                        {
                                            if (index_doppelEintrag[i] == index_doppelEintrag[j])
                                            {
                                                exist = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                            if (!exist)
                            {
                                index_doppelEintrag_kopie.Add(i);
                            }

                            exist = false;
                        }
                    }


                    //index_doppelEintrag = new List<int>();
                    int zähler3 = 0;

                    for (int i = 0; i < index_doppelEintrag_kopie.Count; i++)
                    {
                        if (index_doppelEintrag_kopie != null)
                        {
                            index_doppelEintrag[zähler3] = Convert.ToInt16(index_doppelEintrag_kopie[i]);
                            zähler3++;
                        }
                    }
                }
                catch { }

                fangChecked = new List<bool>();

                for (int i = 0; i < importListe.Count; i++)
                {
                    if (index_doppelEintrag.Contains(i))
                    {
                        fangChecked.Add(false);
                    }
                    else
                    {
                        fangChecked.Add(true);
                    }
                }

                lb_gesImportList.Text = importListe.Count.ToString();
                lb_anzahlDoppelterEinträge.Text = index_doppelEintrag.Count.ToString();

                if (this.index_doppelEintrag_kopie.Count > 0)
                {
                    lb_anzahlDoppelterEinträge.ForeColor = Color.Red;
                }

                groupBox_ergebnis.Enabled = true;

                if ((importListe == null) || (importListe.Count == 0))
                {
                    btn_importieren.Enabled = false;
                    cb_keinedoppeltenEinträge.Enabled = false;
                    MessageBox.Show("Keine Einträge vorhanden.", "Import Fangliste");
                }
                else
                {
                    if (importListe.Count == index_doppelEintrag.Count)
                    {
                        cb_keinedoppeltenEinträge.Enabled = true;
                        cb_keinedoppeltenEinträge.Checked = true;
                        btn_importieren.Enabled = false;
                    }
                    else
                    {
                        cb_keinedoppeltenEinträge.Enabled = true;
                        cb_keinedoppeltenEinträge.Checked = true;
                        btn_importieren.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eigenschaften

        public List<Fangliste> AlleFänge
        {
            get
            {
                return this.alleFänge_kopie;
            }
        }

        #endregion

        #region Events

        private void btn_durchsuchen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Wähle eine Fangliste aus.";
            openFileDialog1.FileName = "Fangliste.csv";
            openFileDialog1.Filter = "Fangliste (*.csv)|*.csv";

            DialogResult open = openFileDialog1.ShowDialog();

            if (open == DialogResult.OK)
            {
                groupBox_analyse.Enabled = false;
                groupBox_ergebnis.Enabled = false;
                btn_importieren.Enabled = false;

                string pfad = Path.GetDirectoryName(openFileDialog1.FileName) + "\\";

                groupBox_analyse.Enabled = true;
                btn_analysieren.Enabled = true;
                progressBar1.Value = 0;

                try
                {
                    importListe = Fangliste.LadenAsList(pfad, Path.GetFileName(openFileDialog1.FileName));

                    textBox1.Text = Path.GetFileName(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    groupBox_analyse.Enabled = false;
                }
            }
        }

        private void btn_analysieren_Click(object sender, EventArgs e)
        {
            btn_analysieren.Enabled = false;

            FanglistePrüfen();
        }

        private void btn_fanglisteAnsehen_Click(object sender, EventArgs e)
        {
            frm_fanglisteAnsehen = new Frm_alleFänge_nur_Liste(this.importListe, this.index_doppelEintrag, fangChecked, cb_keinedoppeltenEinträge.Checked);
            frm_fanglisteAnsehen.ShowDialog();

            this.fangChecked = frm_fanglisteAnsehen.FangChecked;

            int wieVielnichtkopieren = 0;

            for (int i = 0; i < fangChecked.Count; i++)
            {
                if (!fangChecked[i])
                {
                    wieVielnichtkopieren++;
                }
            }

            if (wieVielnichtkopieren == this.importListe.Count)
            {
                btn_importieren.Enabled = false;
            }
            else
            {
                if (cb_keinedoppeltenEinträge.Checked)
                {
                    if (importListe.Count == index_doppelEintrag.Count)
                    {
                        btn_importieren.Enabled = false;
                    }
                    else
                    {
                        btn_importieren.Enabled = true;
                    }
                }
                else
                {
                    btn_importieren.Enabled = true;
                }
            }
        }

        private void cb_keinedoppeltenEinträge_Click(object sender, EventArgs e)
        {
            if ((importListe != null) && (importListe.Count != 0))
            {
                if (cb_keinedoppeltenEinträge.Checked)
                {
                    if (importListe.Count == index_doppelEintrag.Count)
                    {
                        btn_importieren.Enabled = false;
                    }
                    else
                    {
                        btn_importieren.Enabled = true;
                        //for (int i = 0; i < index_doppelEintrag.Length; i++)
                        //{
                        //    fangChecked[index_doppelEintrag[i]] = false;
                        //}

                        int wieVielnichtkopieren = 0;

                        for (int i = 0; i < fangChecked.Count; i++)
                        {
                            if (!fangChecked[i])
                            {
                                wieVielnichtkopieren++;
                            }
                        }
                        
                        if (wieVielnichtkopieren == this.importListe.Count)
                        {
                            btn_importieren.Enabled = false;
                        }
                    }

                    try
                    {
                        for (int i = 0; i < index_doppelEintrag.Count; i++)
                        {
                            fangChecked[index_doppelEintrag[i]] = false;
                        }
                    }
                    catch { }
                }
                else
                {
                    btn_importieren.Enabled = true;

                    try
                    {
                        for (int i = 0; i < index_doppelEintrag.Count; i++)
                        {
                            fangChecked[index_doppelEintrag[i]] = true;
                        }
                    }
                    catch {}
                }
            }
            else
            {
                btn_importieren.Enabled = false;
            }
        }

        private void btn_importieren_Click(object sender, EventArgs e)
        {
            if (index_doppelEintrag.Count > 0)
            {
                if (!cb_keinedoppeltenEinträge.Checked)
                {
                    DialogResult frage = MessageBox.Show("Doppelte einträge können zu fehlern führen.\n\nSoll der Vorgang durchgeführt werden.", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (frage == DialogResult.No)
                    {
                        for (int i = 0; i < index_doppelEintrag.Count; i++)
                        {
                            fangChecked[index_doppelEintrag[i]] = false;
                        }
                    }
                }
            }

            int wieVielnichtkopieren = 0;

            for (int i = 0; i < fangChecked.Count; i++)
            {
                if (!fangChecked[i])
                {
                    wieVielnichtkopieren++;
                }
            }

            //sicherheitkopie
            try
            {
                File.Copy(Frm_Hauptmenu.DatenOrdner + "\\" + Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp, Frm_Hauptmenu.DatenOrdner + "\\" + "sicherheitskopie", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Die Sicherheitskopie konnte nicht erstellt werden.\n\nInformationen:\n" + ex.ToString(), "Fehler.");
            }


            try
            {
                this.alleFänge_kopie = new List<Fangliste>();
                //this.alleFänge_kopie = new Fangliste[this.alleFänge.Length + this.importListe.Length];

                for (int i = 0; i < this.alleFänge.Count; i++)
                {
                    this.alleFänge_kopie.Add(this.alleFänge[i]);
                }

                int zähler = this.alleFänge.Count;

                for (int i = 0; i < this.importListe.Count; i++)
                {
                    if (fangChecked[i])
                    {
                        this.importListe[i].ID = Fangliste.GetNewID(this.alleFänge_kopie);
                        this.alleFänge_kopie.Add(this.importListe[i]);
                        zähler++;
                    }
                }

                Fangliste.SpeichernAsList(this.alleFänge_kopie, Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp);

                groupBox_fangliste.Enabled = true;
                textBox1.Text = "";
                groupBox_analyse.Enabled = false;
                progressBar1.Value = 0;
                groupBox_ergebnis.Enabled = false;
                btn_importieren.Enabled = false;
                MessageBox.Show("Fangliste wurde erfolgreich importiert.", "Import");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fangliste konnte nicht importiert werden.\n\nInformationen:\n" + ex.ToString(), "Fehler.");
            }

            //Lösche Sicherheitskopie
            try
            {
                File.Delete(Frm_Hauptmenu.DatenOrdner + "\\" + "sicherheitskopie");
            }
            catch { }
        }

        private void importAlt()
        {
            bool doppelok = false;

            if (index_doppelEintrag.Count > 0)
            {
                if (!cb_keinedoppeltenEinträge.Checked)
                {
                    DialogResult frage = MessageBox.Show("Doppelte einträge können zu fehlern führen.\n\nSoll der Vorgang durchgeführt werden.", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (frage == DialogResult.Yes)
                    {
                        doppelok = true;
                    }
                }
            }


            //sicherheitkopie
            try
            {
                File.Copy(Frm_Hauptmenu.DatenOrdner + "\\" + Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp, Frm_Hauptmenu.DatenOrdner + "sicherheitskopie", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Die Sicherheitskopie konnte nicht erstellt werden.\n\nInformationen:\n" + ex.ToString(), "Fehler.");
            }


            try
            {
                if (doppelok)
                {
                    this.alleFänge_kopie = new List<Fangliste>();

                    for (int i = 0; i < this.alleFänge.Count; i++)
                    {
                        this.alleFänge_kopie[i] = this.alleFänge[i];
                    }

                    int zähler = this.alleFänge.Count;

                    for (int i = 0; i < this.importListe.Count; i++)
                    {
                        this.alleFänge_kopie[zähler] = this.importListe[i];
                        zähler++;
                    }
                }
                else
                {
                    this.alleFänge_kopie = new List<Fangliste>();

                    for (int i = 0; i < this.alleFänge.Count; i++)
                    {
                        this.alleFänge_kopie[i] = this.alleFänge[i];
                    }

                    int zähler = this.alleFänge.Count;

                    for (int i = 0; i < this.importListe.Count; i++)
                    {
                        bool ok = true;

                        if (this.index_doppelEintrag.Count > 0)
                        {
                            for (int j = 0; j < this.index_doppelEintrag.Count; j++)
                            {
                                if (i == index_doppelEintrag[j])
                                {
                                    ok = false;
                                    break;
                                }
                            }
                        }

                        if (ok)
                        {
                            this.alleFänge_kopie[zähler] = this.importListe[i];
                            zähler++;
                        }
                    }
                }

                Fangliste.SpeichernAsList(this.alleFänge_kopie, Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp);

                groupBox_fangliste.Enabled = true;
                textBox1.Text = "";
                groupBox_analyse.Enabled = false;
                progressBar1.Value = 0;
                groupBox_ergebnis.Enabled = false;
                btn_importieren.Enabled = false;
                MessageBox.Show("Fangliste wurde erfolgreich importiert.", "Import");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fangliste konnte nicht importiert werden.\n\nInformationen:\n" + ex.ToString(), "Fehler.");
            }

            //Lösche Sicherheitskopie
            try
            {
                File.Delete(Frm_Hauptmenu.DatenOrdner + "sicherheitskopie");
            }
            catch { }
        }

        private void import()
        {
            //if (index_keinFoto.Length > 0)
            //{
            //    if (!cb_keinFoto.Checked)
            //    {
            //        DialogResult frage = MessageBox.Show("Kein Foto vorhanden, soll denoch der Eintrag importiert werden?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //        if (frage == DialogResult.No)
            //        {
            //            for (int i = 0; i < index_keinFoto.Length; i++)
            //            {
            //                fotoChecked[index_keinFoto[i]] = false;
            //            }
            //        }
            //    }
            //}

            //int wieVielnichtkopieren = 0;

            //for (int i = 0; i < fotoChecked.Length; i++)
            //{
            //    if (!fotoChecked[i])
            //    {
            //        wieVielnichtkopieren++;
            //    }
            //}

            ////sicherheitkopie
            //try
            //{
            //    File.Copy(einstellung.Pfad + einstellung.Dateiname_Fangliste, einstellung.Pfad + "sicherheitskopieFOTO", true);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Die Sicherheitskopie konnte nicht erstellt werden.\n\nInformationen:\n" + ex.ToString(), "Fehler.");
            //}


            //try
            //{
            //    this.alleFotos_kopie = new Foto[this.alleFotos.Length + this.importListe_kopie.Length - wieVielnichtkopieren];

            //    for (int i = 0; i < this.alleFotos.Length; i++)
            //    {
            //        this.alleFotos_kopie[i] = this.alleFotos[i];
            //    }

            //    int zähler = this.alleFotos.Length;

            //    for (int i = 0; i < this.importListe_kopie.Length; i++)
            //    {
            //        if (fotoChecked[i])
            //        {
            //            this.alleFotos_kopie[zähler] = this.importListe_kopie[i];
            //            zähler++;
            //        }
            //    }

            //    for (int i = 0; i < this.importListe_kopie.Length; i++)
            //    {
            //        try
            //        {
            //            if (fotoChecked[i])
            //            {
            //                if (File.Exists(textBox1.Text + "\\" + importListe[i].DateinameDest))
            //                {
            //                    File.Copy(textBox1.Text + "\\" + importListe[i].DateinameDest, einstellung.FotoOrdner + importListe_kopie[i].DateinameDest);
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Unerwarteter Fehler.\n\nInformationen:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }

            //    Foto.Speichere_Fotoliste(this.alleFotos_kopie, einstellung.Pfad, einstellung.Dateiname_Fotoliste);

            //    groupBox_fotoliste.Enabled = true;
            //    textBox1.Text = "";
            //    groupBox_analyse.Enabled = false;
            //    progressBar1.Value = 0;
            //    groupBox_ergebnis.Enabled = false;
            //    btn_importieren.Enabled = false;
            //    MessageBox.Show("Fotos wurde erfolgreich importiert.", "Import");
            //    this.DialogResult = DialogResult.OK;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Die Fotos konnten nicht importiert werden.\n\nInformationen:\n" + ex.ToString(), "Fehler.");
            //}

            ////Lösche Sicherheitskopie
            //try
            //{
            //    File.Delete(einstellung.Pfad + "sicherheitskopieFOTO");
            //}
            //catch { }
        }

        #endregion
    }
}
