using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FanglisteLibrary;
using System.Data.SqlClient;

namespace Fangliste_2016
{
    public partial class Frm_Fischartenliste : Form
    {
        #region Variablen

        List<Fischarten> fischartenliste = null;
        bool save = false;
        int index = 0;

        #endregion

        #region Form

        Frm_NeueFischart frm_neuerFischart;
        //Frm_FotosVonFang frm_fotoVonFang;

        #endregion

        #region Konstruktor

        public Frm_Fischartenliste(List<Fischarten> fischarten)
        {
            InitializeComponent();

            if (fischarten == null)
                this.fischartenliste = new List<Fischarten>();
            else
            {
                this.fischartenliste = Fischarten.SortiereNachNamen(fischarten);
            }
        }

        public Frm_Fischartenliste()
        {
            InitializeComponent();
            GetFischartenlisteFromDB();
        }

        private void GetFischartenlisteFromDB()
        {
            List<Fischarten> liste = new List<Fischarten>();

            string ConnectionString =
             @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                //string text = "SELECT COUNT(*) FROM Angler";

                string strSQL = "SELECT Id, Name, KF " +
                                "FROM Fisch";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    try
                    {
                        liste.Add(new Fischarten(Convert.ToInt16(reader["Id"]), reader["Name"].ToString(), Convert.ToDouble(reader["KF"])));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            if (liste == null)
                this.fischartenliste = new List<Fischarten>();
            else
            {
                this.fischartenliste = Fischarten.SortiereNachNamen(liste);
            }
        }

        private void Frm_Fischartenliste_Load(object sender, EventArgs e)
        {
            FischartenlisteZeichnen();
        }

        #endregion

        #region Events

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_neuerFischart = new Frm_NeueFischart(this.fischartenliste);
            frm_neuerFischart.ShowDialog();


            if (frm_neuerFischart.DialogResult == DialogResult.OK)
            {
                if ((fischartenliste == null) || (fischartenliste.Count == 0))
                {
                    this.fischartenliste = new List<Fischarten>();
                    this.fischartenliste.Add(frm_neuerFischart.NeueFischart);
                }
                else
                {
                    this.fischartenliste.Add(frm_neuerFischart.NeueFischart);
                }

                FischartenlisteZeichnen();
                speichernToolStripMenuItem.Enabled = true;
                löschenToolStripMenuItem.Enabled = false;
                bearbeitenToolStripMenuItem.Enabled = false;
            }
        }

        private void bearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.index = this.listView1.SelectedIndices[0];

                frm_neuerFischart = new Frm_NeueFischart(this.fischartenliste, this.index);
                frm_neuerFischart.ShowDialog();

                if (frm_neuerFischart.DialogResult == DialogResult.OK)
                {
                    this.fischartenliste[index] = frm_neuerFischart.NeueFischart;

                    FischartenlisteZeichnen();
                    bearbeitenToolStripMenuItem.Enabled = false;
                    löschenToolStripMenuItem.Enabled = false;
                    speichernToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.index = this.listView1.SelectedIndices[0];

                this.fischartenliste.RemoveAt(index);

                FischartenlisteZeichnen();
                löschenToolStripMenuItem.Enabled = false;
                bearbeitenToolStripMenuItem.Enabled = false;
                speichernToolStripMenuItem.Enabled = true;
            }
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Fischarten.Speichern(this.fischartenliste, Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Fischartenliste + Properties.Settings.Default.Datentyp);

                speichernToolStripMenuItem.Enabled = false;
                save = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.index = this.listView1.SelectedIndices[0];

                frm_neuerFischart = new Frm_NeueFischart(this.fischartenliste, this.index);
                frm_neuerFischart.ShowDialog();

                if (frm_neuerFischart.DialogResult == DialogResult.OK)
                {
                    this.fischartenliste[index] = frm_neuerFischart.NeueFischart;

                    FischartenlisteZeichnen();
                    bearbeitenToolStripMenuItem.Enabled = false;
                    löschenToolStripMenuItem.Enabled = false;
                    speichernToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.index = this.listView1.SelectedIndices[0];

                löschenToolStripMenuItem.Enabled = true;
                bearbeitenToolStripMenuItem.Enabled = true;
                bearbeitenToolStripMenuItem1.Enabled = true;
                löschenToolStripMenuItem1.Enabled = true;
            }
            else
            {
                löschenToolStripMenuItem.Enabled = false;
                bearbeitenToolStripMenuItem.Enabled = false;
                bearbeitenToolStripMenuItem1.Enabled = false;
                löschenToolStripMenuItem1.Enabled = false;
            }
        }

        #endregion

        #region Eigenschaften

        public List<Fischarten> Fischartenliste
        {
            get { return this.fischartenliste; }
        }

        public bool EsWurdeGespeichert
        {
            get { return this.save; }
        }

        #endregion

        #region Methoden

        private void FischartenlisteZeichnen()
        {
            listView1.Items.Clear();

            if (fischartenliste != null)
            {
                for (int i = 0; i < this.fischartenliste.Count; i++)
                {
                    ListViewItem item = new ListViewItem(this.fischartenliste[i].GetListToDraw, i);

                    listView1.Items.Add(item);
                }
            }
        }

        #endregion

        private void bearbeitenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.index = this.listView1.SelectedIndices[0];

                frm_neuerFischart = new Frm_NeueFischart(this.fischartenliste, this.index);
                frm_neuerFischart.ShowDialog();

                if (frm_neuerFischart.DialogResult == DialogResult.OK)
                {
                    this.fischartenliste[index] = frm_neuerFischart.NeueFischart;

                    FischartenlisteZeichnen();
                    bearbeitenToolStripMenuItem.Enabled = false;
                    löschenToolStripMenuItem.Enabled = false;
                    speichernToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void löschenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.index = this.listView1.SelectedIndices[0];

                this.fischartenliste.RemoveAt(index);

                FischartenlisteZeichnen();
                löschenToolStripMenuItem.Enabled = false;
                bearbeitenToolStripMenuItem.Enabled = false;
                speichernToolStripMenuItem.Enabled = true;
            }
        }
    }
}
