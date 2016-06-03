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
    public partial class Frm_alleFänge_nur_Liste : Form
    {
        #region Variablen

        List<Fangliste> alleFänge;

        int index = 0;

        List<int> indexDoppelt = null;
        bool import = false;
        bool export = false;
        bool fertig = false;

        List<bool> fangChecked;
        bool nurhinzufügenwennFotovorhanden = true;

        DialogResult ausgewählt = DialogResult.Cancel;

        #endregion

        #region Konstruktor

        public Frm_alleFänge_nur_Liste(List<Fangliste> alleFänge)
        {
            InitializeComponent();

            this.alleFänge = alleFänge;
            alleAuswählenToolStripMenuItem.Visible = false;
            alleAufhebenToolStripMenuItem.Visible = false;
        }

        public Frm_alleFänge_nur_Liste(List<Fangliste> alleFänge, List<int> indexDoppelt, List<bool> fotoChecked, bool nurhinzufügenwennFotovorhanden)
        {
            InitializeComponent();

            this.alleFänge = alleFänge;
            this.indexDoppelt = indexDoppelt;
            this.fangChecked = fotoChecked;
            this.nurhinzufügenwennFotovorhanden = nurhinzufügenwennFotovorhanden;
            listAlle_fänge.CheckBoxes = true;

            this.Text = "Import Fangliste";
            this.import = true;
        }

        public Frm_alleFänge_nur_Liste(List<Fangliste> alleFänge, bool checkBoxes)
        {
            InitializeComponent();

            this.alleFänge = alleFänge;
            listAlle_fänge.CheckBoxes = checkBoxes;

            this.Text = "Fang auswahl exportieren.";
            this.export = true;

            this.fangChecked = new List<bool>();

            statusStrip1.Visible = true;
            label_exportieren.Enabled = false;
        }

        private void Frm_alleFänge_nur_Liste_Load(object sender, EventArgs e)
        {
            ZeichneGesamteListe();

            if (!import)
            {
                try
                {
                    listAlle_fänge.EnsureVisible(listAlle_fänge.Items.Count - 1);
                }
                catch { }
            }

            if (import)
            {
                int count = 0;

                for (int i = 0; i < fangChecked.Count; i++)
                {
                    if (fangChecked[i])
                    {
                        count++;
                    }
                }

                if (count == fangChecked.Count)
                {
                    alleAuswählenToolStripMenuItem.Enabled = false;
                }
                else
                {
                    alleAuswählenToolStripMenuItem.Enabled = true;
                }

                if (count == 0)
                {
                    alleAufhebenToolStripMenuItem.Enabled = false;
                }
                else
                {
                    alleAufhebenToolStripMenuItem.Enabled = true;
                }
            }
        }

        #endregion

        #region Events

        private void listAlle_fänge_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listAlle_fänge.SelectedItems.Count > 0)
            {
                index = this.listAlle_fänge.SelectedIndices[0];
            }

            if (!import && !export)
            {
                this.ausgewählt = DialogResult.OK;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void listAlle_fänge_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (fertig)
            {
                #region import
                if (import)
                {
                    for (int i = 0; i < this.alleFänge.Count; i++)
                    {
                        if (listAlle_fänge.Items[i].Checked)
                        {
                            bool ok = true;

                            if (nurhinzufügenwennFotovorhanden)
                            {
                                for (int j = 0; j < indexDoppelt.Count; j++)
                                {
                                    if (i == indexDoppelt[j])
                                    {
                                        ok = false;
                                        break;
                                    }
                                }
                            }

                            if (ok)
                            {
                                if(fangChecked != null && fangChecked.Count != 0)
                                    fangChecked[i] = true;
                            }
                            else
                            {
                                listAlle_fänge.Items[i].Checked = false;
                                if (fangChecked != null && fangChecked.Count != 0)
                                    fangChecked[i] = false;
                            }
                        }
                        else
                        {
                            if (fangChecked != null && fangChecked.Count != 0)
                                fangChecked[i] = false;
                        }
                    }


                    int count = 0;

                    for (int i = 0; i < fangChecked.Count; i++)
                    {
                        if (fangChecked[i])
                        {
                            count++;
                        }
                    }

                    if (count == fangChecked.Count)
                    {
                        alleAuswählenToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        alleAuswählenToolStripMenuItem.Enabled = true;
                    }

                    if (count == 0)
                    {
                        alleAufhebenToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        alleAufhebenToolStripMenuItem.Enabled = true;
                    }
                }
                #endregion

                #region export

                if (export)
                {
                    for (int i = 0; i < listAlle_fänge.Items.Count; i++)
                    {
                        if (listAlle_fänge.Items[i].Checked)
                        {
                            fangChecked[i] = true;
                        }
                        else
                        {
                            fangChecked[i] = false;
                        }
                    }


                    int count = 0;

                    for (int i = 0; i < fangChecked.Count; i++)
                    {
                        if (fangChecked[i])
                        {
                            count++;
                        }
                    }

                    if (count == fangChecked.Count)
                    {
                        alleAuswählenToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        alleAuswählenToolStripMenuItem.Enabled = true;
                    }

                    if (count == 0)
                    {
                        alleAufhebenToolStripMenuItem.Enabled = false;
                        label_exportieren.Enabled = false;
                    }
                    else
                    {
                        alleAufhebenToolStripMenuItem.Enabled = true;
                        label_exportieren.Enabled = true;
                    }
                }

                #endregion
            }          
        }

        private void listAlle_fänge_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (import)
                {
                    if (this.listAlle_fänge.SelectedItems.Count > 0)
                    {
                        int count = 0;

                        for (int i = 0; i < fangChecked.Count; i++)
                        {
                            if (fangChecked[i])
                            {
                                count++;
                            }
                        }

                        if (count == fangChecked.Count)
                        {
                            alleAuswählenToolStripMenuItem.Enabled = false;
                        }
                        else
                        {
                            alleAuswählenToolStripMenuItem.Enabled = true;
                        }

                        if (count == 0)
                        {
                            alleAufhebenToolStripMenuItem.Enabled = false;
                        }
                        else
                        {
                            alleAufhebenToolStripMenuItem.Enabled = true;
                        }
                    }
                }
            }
        }

        private void alleAuswählenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();

            for (int i = 0; i < this.alleFänge.Count; i++)
            {
                listAlle_fänge.Items[i].Checked = true;
            }

            alleAufhebenToolStripMenuItem.Enabled = true;
            alleAuswählenToolStripMenuItem.Enabled = false;
        }

        private void alleAufhebenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();

            for (int i = 0; i < this.alleFänge.Count; i++)
            {
                listAlle_fänge.Items[i].Checked = false;
            }

            alleAufhebenToolStripMenuItem.Enabled = false;
            alleAuswählenToolStripMenuItem.Enabled = true;
        }

        private void listAlle_fänge_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //if (!import && !export)
            //{
            //    int indexCol = e.Column;

            //    switch (indexCol)
            //    {
            //        case 0:
            //            this.alleFänge = Fangliste.SortiereNachNamen(this.alleFänge);
            //            ZeichneGesamteListe();
            //            break;
            //        case 1:
            //            this.alleFänge = Fangliste.SortiereNachFischart(this.alleFänge);
            //            ZeichneGesamteListe();
            //            break;
            //        case 2:
            //            this.alleFänge = Fangliste.SortiereNachLänge(this.alleFänge);
            //            ZeichneGesamteListe();
            //            break;
            //        case 3:
            //            this.alleFänge = Fangliste.SortiereNachGewicht(this.alleFänge);
            //            ZeichneGesamteListe();
            //            break;
            //        case 4:
            //            this.alleFänge = Fangliste.SortiereNachGewässer(this.alleFänge);
            //            ZeichneGesamteListe();
            //            break;
            //        case 5:
            //            this.alleFänge = Fangliste.SortiereNachDatum(this.alleFänge);
            //            ZeichneGesamteListe();
            //            break;
            //        case 6:
            //            this.alleFänge = Fangliste.SortiereNachUhrzeit(this.alleFänge);
            //            ZeichneGesamteListe();
            //            break;
            //        case 7:
            //            this.alleFänge = Fangliste.SortiereNachPlatzbeschreibung(this.alleFänge);
            //            ZeichneGesamteListe();
            //            break;
            //        case 8:
            //            this.alleFänge = Fangliste.SortiereNachKöderbeschreibung(this.alleFänge);
            //            ZeichneGesamteListe();
            //            break;
            //        case 9:
            //            this.alleFänge = Fangliste.SortiereNachTiefe(this.alleFänge);
            //            ZeichneGesamteListe();
            //            break;
            //        case 10:
            //            this.alleFänge = Fangliste.SortiereNachTemperatur(this.alleFänge);
            //            ZeichneGesamteListe();
            //            break;
            //        case 11:
            //            this.alleFänge = Fangliste.SortiereNachWetter(this.alleFänge);
            //            ZeichneGesamteListe();
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }

        private void label_exportieren_Click(object sender, EventArgs e)
        {
            if (export)
            {
                ausgewählt = DialogResult.OK;
                this.Close();
            }
        }

        #endregion

        #region Eigenschaften

        public int SelectedIndex
        {
            get
            {
                return this.index;
            }
        }

        public List<bool> FangChecked
        {
            get
            {
                return this.fangChecked;
            }
        }

        public DialogResult Ausgewählt
        {
            get
            {
                return this.ausgewählt;
            }
        }

        public List<Fangliste> AlleFänge
        {
            get
            {
                return this.alleFänge;
            }
        }

        #endregion

        #region Methoden

        private void ZeichneGesamteListe()
        {
            listAlle_fänge.Items.Clear();
            //create liste
            /*for (int i = 0; i < alleFänge.Count; i++)
            {
                ListViewItem item = new ListViewItem(alleFänge[i].GetListToDraw, i);

                if (import)
                {
                    if ((fangChecked != null) && (fangChecked.Count != 0))
                    {
                        if (fangChecked[i])
                        {
                            item.Checked = true;
                        }
                        else
                        {
                            item.Checked = false;
                        }
                    }

                    for (int j = 0; j < indexDoppelt.Count; j++)
                    {
                        if (i == indexDoppelt[j])
                        {
                            item.BackColor = Color.Red;
                            //item.Checked = false;
                            break;
                            //item.Focused = true;
                            //item.Text.ToUpper();
                        }
                    }
                }

                listAlle_fänge.Items.Add(item);
            }
            */
            fertig = true;
        }

        #endregion
    }
}
