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
    public partial class Frm_Fotoliste : Form
    {
        #region Variablen

        List<Foto> alleFotos;
        int index = 0;

        int[] index_keinFoto;
        bool[] fotoChecked;
        int[] doppelFotos = null;
        bool import = false;
        bool fertig = false;
        string pfad;

        bool nurhinzufügenwennFotovorhanden = true;

        #endregion

        #region Forms

        Frm_FotosVonFang frm_fotoVonFang;

        #endregion

        #region Konstruktor

        public Frm_Fotoliste(List<Foto> alleFotos)
        {
            InitializeComponent();

            this.alleFotos = alleFotos;
            fotoAToolStripMenuItem.Visible = false;
            toolStripSeparator1.Visible = false;
            alleAuswählenToolStripMenuItem.Visible = false;
            keineAuswahlToolStripMenuItem.Visible = false;
        }

        public Frm_Fotoliste(List<Foto> alleFotos, int[] index_keinFoto, bool[] fotoChecked, bool nurhinzufügenwennFotovorhanden, string pfad)
        {
            InitializeComponent();

            this.alleFotos = alleFotos;
            this.index_keinFoto = index_keinFoto;
            this.fotoChecked = fotoChecked;
            this.nurhinzufügenwennFotovorhanden = nurhinzufügenwennFotovorhanden;
            this.pfad = pfad;
            this.import = true;
            listView1.CheckBoxes = true;
        }

        public Frm_Fotoliste(List<Foto> alleFotos, int[] index_keinFoto, bool[] fotoChecked, int[] doppelFotos, bool nurhinzufügenwennFotovorhanden, string pfad)
        {
            InitializeComponent();

            this.alleFotos = alleFotos;
            this.index_keinFoto = index_keinFoto;
            this.fotoChecked = fotoChecked;
            this.doppelFotos = doppelFotos;
            this.nurhinzufügenwennFotovorhanden = nurhinzufügenwennFotovorhanden;
            this.pfad = pfad;
            this.import = true;
            listView1.CheckBoxes = true;
        }

        private void Frm_Fotoliste_Load(object sender, EventArgs e)
        {
            if ((alleFotos == null) || (alleFotos.Count == 0))
            {
                fotoAToolStripMenuItem.Enabled = false;
            }

            try
            {
                listView1.Items.Clear();

                for (int i = 0; i < alleFotos.Count; i++)
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(i + 1), i);

                    item.SubItems.AddRange(alleFotos[i].GetList);

                    if (import)
                    {
                        if (fotoChecked[i])
                        {
                            item.Checked = true;
                        }
                        else
                        {
                            item.Checked = false;
                        }

                        if (doppelFotos != null)
                        {
                            for (int a = 0; a < doppelFotos.Length; a++)
                            {
                                if (i == doppelFotos[a])
                                {
                                    item.BackColor = Color.Yellow;
                                    break;
                                }
                            }
                        }

                        if ((index_keinFoto != null) || (index_keinFoto.Length != 0))
                        {
                            for (int j = 0; j < index_keinFoto.Length; j++)
                            {
                                if (i == index_keinFoto[j])
                                {
                                    item.ForeColor = Color.Red;
                                    //item.Checked = false;
                                    //item.Focused = true;
                                    //item.Text.ToUpper();
                                    break;
                                }
                            }
                        }
                    }

                    listView1.Items.Add(item);
                }

                fertig = true;
            }
            catch { }

            #region auswahl
            if (import)
            {
                int count = 0;

                for (int i = 0; i < fotoChecked.Length; i++)
                {
                    if (fotoChecked[i])
                    {
                        count++;
                    }
                }

                if (count == fotoChecked.Length)
                {
                    alleAuswählenToolStripMenuItem.Enabled = false;
                }
                else
                {
                    alleAuswählenToolStripMenuItem.Enabled = true;
                }

                if (count == 0)
                {
                    keineAuswahlToolStripMenuItem.Enabled = false;
                }
                else
                {
                    keineAuswahlToolStripMenuItem.Enabled = true;
                }
            }
            #endregion 
        }

        #endregion

        #region Eigenschaften

        public int Index
        {
            get
            {
                return this.index;
            }
        }

        public int[] Index_KeinFoto
        {
            get
            {
                return this.index_keinFoto;
            }
        }

        public bool[] FotoChecked
        {
            get
            {
                return this.fotoChecked;
            }
        }

        #endregion

        #region Methoden

        #endregion

        #region Events

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.listView1.SelectedItems.Count > 0)
                {
                    if (!import)
                    {
                        index = this.listView1.SelectedIndices[0];
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (fertig)
            {
                if (import)
                {
                    for (int i = 0; i < this.alleFotos.Count; i++)
                    {
                        if (listView1.Items[i].Checked)
                        {
                            bool ok = true;

                            if (nurhinzufügenwennFotovorhanden)
                            {
                                for (int j = 0; j < index_keinFoto.Length; j++)
                                {
                                    if (i == index_keinFoto[j])
                                    {
                                        ok = false;
                                        break;
                                    }
                                }
                            }

                            if (ok)
                            {
                                fotoChecked[i] = true;
                            }
                            else
                            {
                                listView1.Items[i].Checked = false;
                                fotoChecked[i] = false;
                            }
                        }
                        else
                        {
                            fotoChecked[i] = false;
                        }
                    }


                    int count = 0;

                    for (int i = 0; i < fotoChecked.Length; i++)
                    {
                        if (fotoChecked[i])
                        {
                            count++;
                        }
                    }

                    if (count == fotoChecked.Length)
                    {
                        alleAuswählenToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        alleAuswählenToolStripMenuItem.Enabled = true;
                    }

                    if (count == 0)
                    {
                        keineAuswahlToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        keineAuswahlToolStripMenuItem.Enabled = true;
                    }
                }
            }
        }

        private void fotoAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                index = this.listView1.SelectedIndices[0];

                if (import)
                {
                    frm_fotoVonFang = new Frm_FotosVonFang(this.alleFotos, index, this.pfad);
                    frm_fotoVonFang.ShowDialog();
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (listView1.SelectedItems[0].Text != "")
                {
                    fotoAToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                fotoAToolStripMenuItem.Enabled = false;
            }
        }

        private void alleAuswählenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();

            for (int i = 0; i < this.alleFotos.Count; i++)
            {
                listView1.Items[i].Checked = true;
            }

            keineAuswahlToolStripMenuItem.Enabled = true;
            alleAuswählenToolStripMenuItem.Enabled = false;
        }

        private void keineAuswahlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();

            for (int i = 0; i < this.alleFotos.Count; i++)
            {
                listView1.Items[i].Checked = false;
            }

            keineAuswahlToolStripMenuItem.Enabled = false;
            alleAuswählenToolStripMenuItem.Enabled = true;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (import)
                {
                    int count = 0;

                    for (int i = 0; i < fotoChecked.Length; i++)
                    {
                        if (fotoChecked[i])
                        {
                            count++;
                        }
                    }

                    if (count == fotoChecked.Length)
                    {
                        alleAuswählenToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        alleAuswählenToolStripMenuItem.Enabled = true;
                    }

                    if (count == 0)
                    {
                        keineAuswahlToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        keineAuswahlToolStripMenuItem.Enabled = true;
                    }
                }
            }
        }

        #endregion

        #region ToolTip

        private void listView1_MouseEnter(object sender, EventArgs e)
        {
            if (import)
            {
                toolTip1.Show("Rot = Das Foto ist existiert nicht.\nGelb = Das Foto ist eventuell doppelt.", listView1);
            }
        }

        private void listView1_MouseLeave(object sender, EventArgs e)
        {
            if (import)
            toolTip1.Hide(listView1);
        }

        #endregion
    }
}
