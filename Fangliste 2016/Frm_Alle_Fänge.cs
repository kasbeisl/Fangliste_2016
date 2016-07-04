using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FanglisteLibrary;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;

namespace Fangliste_2016
{
    public partial class Frm_Alle_Fänge : Form
    {
        #region Variablen

        List<Fangliste> alleFänge;
        List<Fangliste> nurFängevonNamen;
        List<Foto> fotoliste;
        List<Angler> anglerliste;

        Frm_FotosVonFang frm_fotosVonFang;

        #endregion

        #region Konstruktor

        public Frm_Alle_Fänge()
        {
            InitializeComponent();
        }

        private void Frm_Alle_Fänge_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fanglisteDBDataSet.Foto' table. You can move, or remove it, as needed.
            this.fotoTableAdapter.Fill(this.fanglisteDBDataSet.Foto);
            // TODO: This line of code loads data into the 'fanglisteDBDataSet.AlleFänge' table. You can move, or remove it, as needed.
            this.alleFängeTableAdapter.Fill(this.fanglisteDBDataSet.AlleFänge);
            fotoAnzeigenToolStripMenuItem.Enabled = false;
            textBox_name.Enabled = false;
            //SpezifischeFotolisteErstellen();
            //MacheGesamteListe();
            //FischerNamensliste();
        }

        #endregion

        #region Methoden

        private void SpezifischeFotolisteErstellen()
        {
            try
            {
                imageList1.Images.Clear();
                bool bild = false;

                for (int i = 0; i < alleFänge.Count; i++)
                {
                    for (int a = 0; a < fotoliste.Count; a++)
                    {
                        if (alleFänge[i].ID == fotoliste[a].ID)
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

        private void MacheGesamteListe()
        {
           /* int zähler = 0;
            //create liste
            for (int i = 0; i < alleFänge.Count; i++)
            {
                ListViewItem item = new ListViewItem(alleFänge[i].GetListToDraw, i);

                listAlle_fänge.Items.Add(item);
                zähler++;
            }

            if (zähler == 1)
            {
                label_ges_anzahl.Text = "(" + zähler + " Eintrag)";
            }
            else
            {
                label_ges_anzahl.Text = "(" + zähler + " Einträge)";
            }
            */
        }

        private void FischerNamensliste()
        {
            /*bool exist = false;
            string[] _name = new string[this.alleFänge.Count];
            int zähler_name = 0;

            for (int i = 0; i < this.alleFänge.Count; i++)
            {
                for (int a = 0; a < _name.GetLength(0); a++)
                {
                    if (_name[a] == this.alleFänge[i].Name)
                    {
                        exist = true;
                        break;
                    }

                    if (zähler_name == a)
                    {
                        break;
                    }
                }

                if (!exist)
                {
                    _name[i] = alleFänge[i].Name;

                }
                zähler_name++;
                exist = false;
            }

            for (int i = 0; i < _name.GetLength(0); i++)
            {
                if (_name[i] != null)
                {
                    textBox_name.Items.Add(_name[i]);
                }
            }*/
        }

        #endregion

        #region Backgroundworker Fotos laden

        public void fotoLaden_DoWork(object sender, DoWorkEventArgs e)
        {
            //try
            //{
            //    this.fotoliste = Foto.LadenAsList(einstellungen.Pfad, this.einstellungen.Dateiname_Fotoliste);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Die Fotoliste konnten nicht nicht geladen werden.\n\nInformationen:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        #endregion

        #region Events

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
           /* if (checkBox1.Checked)
            {
                textBox_name.Enabled = true;
                textBox_name.Text = "Enter drücken";
            }

            if (!checkBox1.Checked)
            {
                textBox_name.Enabled = false;
                textBox_name.Text = "Name";

                listAlle_fänge.Items.Clear();

                MacheGesamteListe();
            }*/
        }

        private void textBox_name_Click(object sender, EventArgs e)
        {
            //textBox_name.Text = "";
        }

        private void textBox_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            //bool text_ok = false;
            //bool min_text = false;
            //bool max_text = false;
            //bool Buchstabe_groß = false;
            //bool name_vorhanden = false;

            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    #region Prüfen
            //    if (textBox_name.Text == "")
            //    {
            //        MessageBox.Show("Bitte geben Sie einen Namen ein.", "Fehler");
            //        text_ok = false;
            //    }
            //    else
            //    {
            //        text_ok = true;

            //        if (Char.IsLower(textBox_name.Text[0]))
            //        {
            //            MessageBox.Show("Der Erste Buchstabe muss groß sein.", "Fehler");
            //            Buchstabe_groß = false;
            //        }
            //        else
            //        {
            //            Buchstabe_groß = true;

            //            if (textBox_name.Text.Length < 4)
            //            {
            //                MessageBox.Show("Der Name ist zu kurz. (Minimum 4 Zeichen)", "Fehler");
            //                min_text = false;
            //            }
            //            else
            //            {
            //                min_text = true;

            //                if (textBox_name.Text.Length > 20)
            //                {
            //                    MessageBox.Show("Der Name ist zu lange. (Maximum 20 Zeichen)", "Fehler");
            //                    max_text = false;
            //                }
            //                else
            //                {
            //                    max_text = true;

            //                    for (int i = 0; i < alleFänge.Length; i++)
            //                    {
            //                        if (textBox_name.Text == alleFänge[i].Name)
            //                        {
            //                            name_vorhanden = true;
            //                        }
            //                    }

            //                    if (!name_vorhanden)
            //                    {
            //                        MessageBox.Show("Es wurde kein Eintrag unter dem Namen gefunden.", "Fehler");
            //                    }
            //                }
            //            }
            //        }
            //    }


            //    #endregion

            //    if (text_ok && min_text && max_text && Buchstabe_groß && name_vorhanden)
            //    {
            //        //create liste
            //        int zähler = 0;

            //        listAlle_fänge.Items.Clear();
            //        for (int i = 0; i < alleFänge.Length; i++)
            //        {
            //            if (textBox_name.Text == alleFänge[i].Name)
            //            {
            //                ListViewItem item = new ListViewItem(alleFänge[i].GetList, i);

            //                listAlle_fänge.Items.Add(item);

            //                zähler++;
            //            }
            //        }

            //        nurFängevonNamen = new Fangliste[zähler];

            //        int zähler2 = 0;

            //        for (int i = 0; i < alleFänge.Length; i++)
            //        {
            //            if (textBox_name.Text == alleFänge[i].Name)
            //            {
            //                nurFängevonNamen[zähler2] = alleFänge[i];
            //                zähler2++;
            //            }
            //        }

            //        if (zähler == 1)
            //        {
            //            label_ges_anzahl.Text = "(" + zähler + " Eintrag)";
            //        }
            //        else
            //        {
            //            label_ges_anzahl.Text = "(" + zähler + " Einträge)";
            //        }
            //    }
            //}
        }

        private void listAlle_fänge_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           /* if (e.Button == MouseButtons.Left)
            {
                int index = listAlle_fänge.SelectedIndices[0];
                List<Foto> fangFotos = new List<Foto>();

                for (int i = 0; i < fotoliste.Count; i++)
                {
                    if (fotoliste[i].ID == alleFänge[index].ID)
                        fangFotos.Add(fotoliste[i]);
                }

                if ((fangFotos != null) && (fangFotos.Count != 0))
                {
                    frm_fotosVonFang = new Frm_FotosVonFang(this.alleFänge, fangFotos, index);
                    frm_fotosVonFang.ShowDialog();
                }
            }*/
        }

        private void fotoAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
               /* int index = listAlle_fänge.SelectedIndices[0];
                List<Foto> fangFotos = new List<Foto>();

                for (int i = 0; i < fotoliste.Count; i++)
                {
                    if (fotoliste[i].ID == alleFänge[index].ID)
                        fangFotos.Add(fotoliste[i]);
                }

                if ((fangFotos != null) && (fangFotos.Count != 0))
                {
                    frm_fotosVonFang = new Frm_FotosVonFang(this.alleFänge, fangFotos, index);
                    frm_fotosVonFang.ShowDialog();
                }*/
        }

        private void textBox_name_SelectionChangeCommitted(object sender, EventArgs e)
        {
           /* bool text_ok = false;
            bool min_text = false;
            bool max_text = false;
            bool Buchstabe_groß = false;
            bool name_vorhanden = false;

            #region Prüfen
            if (textBox_name.Text == "")
            {
                MessageBox.Show("Bitte geben Sie einen Namen ein.", "Fehler");
                text_ok = false;
            }
            else
            {
                text_ok = true;

                if (Char.IsLower(textBox_name.Text[0]))
                {
                    MessageBox.Show("Der Erste Buchstabe muss groß sein.", "Fehler");
                    Buchstabe_groß = false;
                }
                else
                {
                    Buchstabe_groß = true;

                    if (textBox_name.Text.Length < 4)
                    {
                        MessageBox.Show("Der Name ist zu kurz. (Minimum 4 Zeichen)", "Fehler");
                        min_text = false;
                    }
                    else
                    {
                        min_text = true;

                        if (textBox_name.Text.Length > 20)
                        {
                            MessageBox.Show("Der Name ist zu lange. (Maximum 20 Zeichen)", "Fehler");
                            max_text = false;
                        }
                        else
                        {
                            max_text = true;

                            for (int i = 0; i < alleFänge.Count; i++)
                            {
                                if (textBox_name.Text == alleFänge[i].Name)
                                {
                                    name_vorhanden = true;
                                }
                            }

                            if (!name_vorhanden)
                            {
                                MessageBox.Show("Es wurde kein Eintrag unter dem Namen gefunden.", "Fehler");
                            }
                        }
                    }
                }
            }


            #endregion

            if (text_ok && min_text && max_text && Buchstabe_groß && name_vorhanden)
            {
                //create liste
                int zähler = 0;

                listAlle_fänge.Items.Clear();
                for (int i = 0; i < alleFänge.Count; i++)
                {
                    if (textBox_name.Text == alleFänge[i].Name)
                    {
                        ListViewItem item = new ListViewItem(alleFänge[i].GetListToDraw, i);

                        listAlle_fänge.Items.Add(item);

                        zähler++;
                    }
                }

                nurFängevonNamen = new List<Fangliste>();

                int zähler2 = 0;

                for (int i = 0; i < alleFänge.Count; i++)
                {
                    if (textBox_name.Text == alleFänge[i].Name)
                    {
                        nurFängevonNamen.Add(alleFänge[i]);
                        zähler2++;
                    }
                }

                if (zähler == 1)
                {
                    label_ges_anzahl.Text = "(" + zähler + " Eintrag)";
                }
                else
                {
                    label_ges_anzahl.Text = "(" + zähler + " Einträge)";
                }
            }*/
        }

        private void listAlle_fänge_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (listAlle_fänge.SelectedItems.Count > 0)
            {
                if (listAlle_fänge.SelectedItems[0].Text != "")
                {
                    fotoAnzeigenToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                fotoAnzeigenToolStripMenuItem.Enabled = false;
            }*/
        }

        #endregion

        private void alleFängeDataGridView_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var row = alleFängeDataGridView.SelectedRows[0];

            List<Foto1> fotoliste = new List<Foto1>();
            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();
            int id = 0;
            try
            {
                con.ConnectionString = ConnectionString;

                //string text = "SELECT COUNT(*) FROM Angler";

                id = Convert.ToInt16(row.Cells[15].Value);
                string strSQL = "SELECT * " +
                                "FROM Foto WHERE Fang_ID = '" + id + "'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine("{0,-35}{1}", reader["Id"], reader["Name"]);
                    try
                    {

                        byte[] picData = reader["Bild"] as byte[] ?? null;
                        Bitmap bmp = null;

                        if (picData != null)
                        {
                            using (MemoryStream ms = new MemoryStream(picData))
                            {
                                // Load the image from the memory stream. How you do it depends
                                // on whether you're using Windows Forms or WPF.
                                // For Windows Forms you could write:
                                bmp = new System.Drawing.Bitmap(ms);
                                //AddImageToImageList(imageList_Fischer, bmp, "", imageList_Fischer.ImageSize.Width, imageList_Fischer.ImageSize.Height);
                                //MessageBox.Show("Drücken Sie OK um das nächste Bild anzuzeigen.");
                            }
                        }
                        else
                        {
                            if (File.Exists(Properties.Settings.Default.Data + "\\" + "error.png"))
                            {
                                //this.imageList_Fischer.Images.Add(Image.FromFile(Properties.Settings.Default.Data + "\\" + "error.png"));
                                bmp = new Bitmap(Properties.Settings.Default.Data + "\\" + "error.png");
                                //imageList_Fischer.Images.Add(b);
                                //AddImageToImageList(imageList_Fischer, bmp, "", imageList_Fischer.ImageSize.Width, imageList_Fischer.ImageSize.Height);
                            }
                        }

                        fotoliste.Add(new Foto1(Convert.ToInt16(reader["Id"]), Convert.ToInt16(reader["Angler_ID"]), Convert.ToInt16(reader["Fang_ID"]), Convert.ToInt16(reader["Ordner_ID"]), reader["Kommentar"].ToString(), bmp));
                        //listView_Fischer.Items.Add(anglerliste[count].Name, count);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Fehler");
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

            if (fotoliste.Count != 0)
            {
                frm_fotosVonFang = new Frm_FotosVonFang(fotoliste, id);
                frm_fotosVonFang.ShowDialog();
            }
        }
    }
}