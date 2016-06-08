using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using FanglisteLibrary;
using System.IO;

namespace Fangliste_2016
{
    public partial class Frm_Hit_Parade : Form
    {
        #region Variable

        List<Fangliste> fangliste;
        List<Fangliste> spezialliste;
        List<Foto> fotoliste;

        Frm_FotosVonFang frm_fotosVonFang;
        SoundPlayer simpleSound_Hitparade;

        string[] fischAuswahl;

        #endregion

        #region Konstruktor

        public Frm_Hit_Parade()
        {
            InitializeComponent();

            simpleSound_Hitparade = new SoundPlayer(Properties.Settings.Default.Data + "\\" + Properties.Settings.Default.HitparadeSound);
        }

        private void Frm_Hit_Parade_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fanglisteDBDataSet.Hitparade_Andere' table. You can move, or remove it, as needed.
            //this.hitparade_AndereTableAdapter.Fill(this.fanglisteDBDataSet.Hitparade_Andere);
            // TODO: This line of code loads data into the 'fanglisteDBDataSet.Hitparade_Hecht' table. You can move, or remove it, as needed.
            this.hitparade_HechtTableAdapter.Fill(this.fanglisteDBDataSet.Hitparade_Hecht);
            this.hitparade_BarschTableAdapter.Fill(this.fanglisteDBDataSet.Hitparade_Barsch);
            this.hitparade_ZanderTableAdapter1.Fill(this.fanglisteDBDataSet.Hitparade_Zander);
            this.hitparade_AndereTableAdapter.Fill(this.fanglisteDBDataSet.Hitparade_Andere);

            SetFischAuswahl();

            try
            {
                if (Properties.Settings.Default.PlaySound == true)
                    simpleSound_Hitparade.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Die Audiodatei konnte nicht abgespielt werden\n\nInformation:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tbx_fischart.SelectedIndex = 0;
            tbx_fischart.Focus();
        }

        #endregion

        private void ZeichneListe()
        {
            /*listHecht.Items.Clear();

            for (int i = 0; i < 10; i++)
            {

                if (i == this.spezialliste.Count)
                {
                    break;
                }

                ListViewItem item = new ListViewItem("", i);

                if (tbx_fischart.Text == "Andere")
                {
                    string[] item1 = new string[this.spezialliste[i].Get_Hitparaden_List_Andere.Length + 1];
                    item1[0] = Convert.ToString(i + 1);
                    for (int a = 0; a < this.spezialliste[i].Get_Hitparaden_List_Andere.Length; a++)
                    {
                        item1[a + 1] = this.spezialliste[i].Get_Hitparaden_List_Andere[a];
                    }
                    
                    item.SubItems.AddRange(item1);

                    if (listHecht.Columns.Count < 8)
                        listHecht.Columns.Add("Fischart", 100);
                }
                else
                {
                    string[] item1 = new string[this.spezialliste[i].Get_Hitparaden_List_Hecht_Zander_Barsch.Length + 1];
                    item1[0] = Convert.ToString(i + 1);
                    for (int a = 0; a < this.spezialliste[i].Get_Hitparaden_List_Hecht_Zander_Barsch.Length; a++)
                    {
                        item1[a + 1] = this.spezialliste[i].Get_Hitparaden_List_Hecht_Zander_Barsch[a];
                    }

                    item.SubItems.AddRange(item1);

                    //item.SubItems.AddRange(this.hechtListe[i].Get_Hitparaden_List_Hecht_Zander_Barsch);
                    if(listHecht.Columns.Count == 8)
                        listHecht.Columns.RemoveAt(listHecht.Columns.Count - 1);
                }
                
                if (i == 0)
                {
                    item.BackColor = Color.Gold;
                    item.Focused = true;
                    item.Text.ToUpper();
                }
                if (i == 1)
                {
                    item.BackColor = Color.Silver;
                    item.Focused = true;
                    item.Text.ToUpper();
                }
                if (i == 2)
                {
                    item.BackColor = Color.RosyBrown;
                    item.Focused = true;
                    item.Text.ToUpper();
                }
                listHecht.Items.Add(item);
            }*/
        }

        #region Events

        private void Frm_Hit_Parade_FormClosed(object sender, FormClosedEventArgs e)
        {
            //wmp.controls.stop();
            simpleSound_Hitparade.Stop();
        }

        private void listHecht_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {


                /*int index = listHecht.SelectedIndices[0];
                List<Foto> fangFotos = new List<Foto>();

                for (int i = 0; i < fotoliste.Count; i++)
                {
                    if (fotoliste[i].ID == spezialliste[index].ID)
                        fangFotos.Add(fotoliste[i]);
                }

                if ((fangFotos != null) && (fangFotos.Count != 0))
                {
                    frm_fotosVonFang = new Frm_FotosVonFang(0);
                    frm_fotosVonFang.ShowDialog();
                }*/
            }
        }

        #endregion

        private void SpezifischeFotolisteErstellen()
        {
            try
            {
                imageList1.Images.Clear();
                bool bild = false;

                for (int i = 0; i < 10; i++)
                {
                    for (int a = 0; a < fotoliste.Count; a++)
                    {
                        if (spezialliste[i].ID == fotoliste[a].ID)
                        {
                            Bitmap b = new Bitmap(Frm_Hauptmenu.FotoOrdner + "\\" + fotoliste[a].Dateiname);
                            imageList1.Images.Add(b);
                            bild = true;
                            break;
                        }
                    }

                    if (!bild)
                    {
                        Bitmap b = new Bitmap(Properties.Settings.Default.Data + "\\" + "error.png");
                        imageList1.Images.Add(b);
                        
                    }

                    bild = false;
                }
            }
            catch { }
        }

        public static List<Fangliste> GetFanglisteNachFischart(List<Fangliste> fangliste, string fischart)
        {
            List<Fangliste> liste = new List<Fangliste>();

            if ((fangliste != null) && (fangliste.Count != 0))
            {
                for (int i = 0; i < fangliste.Count; i++)
                {
                    if (fangliste[i].Fischart == fischart)
                        liste.Add(fangliste[i]);
                }
            }

            return liste;
        }

        private void tbx_fischart_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                /*if(tbx_fischart.Text == "Andere")
                    spezialliste = Fangliste.Andere_Fischarten_Liste(this.fangliste, fischAuswahl);
                else
                    spezialliste = Fangliste.Spezifische_Fischart_Liste(tbx_fischart.Text, GetFanglisteNachFischart(this.fangliste, tbx_fischart.Text));
                    */
                switch (tbx_fischart.Text)
                {
                    case "Hecht":
                        this.hitparade_HechtDataGridView.DataSource = this.hitparade_HechtBindingSource;
                        this.hitparade_HechtDataGridView.Update();
                        break;
                    case "Zander":
                        this.hitparade_HechtDataGridView.DataSource = this.hitparade_ZanderBindingSource;
                        this.hitparade_HechtDataGridView.Update();
                        break;
                    case "Barsch":
                        this.hitparade_HechtDataGridView.DataSource = this.hitparade_BarschBindingSource;
                        this.hitparade_HechtDataGridView.Update();
                        break;
                    case "Andere":
                        this.hitparade_HechtDataGridView.DataSource = this.hitparade_AndereBindingSource;
                        this.hitparade_HechtDataGridView.Update();
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Spezifische Fanglisten konnten nicht geladen werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            //SpezifischeFotolisteErstellen();
            //ZeichneListe();*/
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetFischAuswahl()
        {
            tbx_fischart.Items.Clear();
            
            switch (Properties.Settings.Default.HitparadeFischAuswahl)
            {
                case "Best of Three":
                    fischAuswahl = new string[] { "Hecht", "Zander", "Barsch", "Andere" };
                    break;
                case "Karpfen Freaks":
                    fischAuswahl = new string[] { "Karpfen", "Amur", "Stör", "Andere" };
                    break;
                case "Salmoniden Profis":
                    fischAuswahl = new string[] { "Regenbogenforelle", "Bachforelle", "Seeforelle", "Andere" };
                    break;
                default:
                    fischAuswahl = new string[] { "Hecht", "Zander", "Barsch", "Andere" };
                    break;
            }

            tbx_fischart.Items.AddRange(fischAuswahl);
        }

        private void hitparade_HechtDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            frm_fotosVonFang = new Frm_FotosVonFang(1);
            frm_fotosVonFang.ShowDialog();
        }

        private void hitparade_HechtDataGridView_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void hitparade_HechtDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = hitparade_HechtDataGridView.SelectedRows[0];
            //string a = "Cell Value" + row.Cells[7].Value + "";

            frm_fotosVonFang = new Frm_FotosVonFang(Convert.ToInt16(row.Cells[7].Value));
            frm_fotosVonFang.ShowDialog();
        }
    }
}
