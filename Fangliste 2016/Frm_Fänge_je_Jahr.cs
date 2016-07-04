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
using System.IO;

namespace Fangliste_2016
{
    public partial class Frm_Fänge_je_Jahr : Form
    {
        #region Variable

        List<Fangliste> alleFänge = null;
        List<Fangliste> heurige_Fänge;
        List<Foto> fotoliste;

        Frm_FotosVonFang frm_fotosVonFang;

        #endregion

        #region Konstruktor

        public Frm_Fänge_je_Jahr()
        {
            InitializeComponent();

        }

        private void Frm_Fänge_je_Jahr_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fanglisteDBDataSet.Fänge_Je_Jahr' table. You can move, or remove it, as needed.
            this.fänge_Je_JahrTableAdapter.Fill(this.fanglisteDBDataSet.Fänge_Je_Jahr);
            // TODO: This line of code loads data into the 'fanglisteDBDataSet.Fänge_Je_Jahr1' table. You can move, or remove it, as needed.
            //this.fänge_Je_Jahr1TableAdapter.Fill(this.fanglisteDBDataSet.Fänge_Je_Jahr1);
            fotoAnzeigenToolStripMenuItem.Enabled = false;
            this.WindowState = FormWindowState.Maximized;
            //this.heurige_Fänge = Fangliste.Fangliste_je_jahr(this.alleFänge);
            //SpezifischeFotolisteErstellen();

            //listAktJahr.Items.Clear();

            comboBox_jahr.Items.Add("Alle");

            /*if (alleFänge != null)
            {
                for (int i = 0; i < this.alleFänge.Count; i++)
                {
                    if (!comboBox_jahr.Items.Contains(this.alleFänge[i].Datum.Year))
                        comboBox_jahr.Items.Add(this.alleFänge[i].Datum.Year);
                }
            }*/

            /*if (heurige_Fänge != null)
            {
                for (int i = 0; i < heurige_Fänge.Count; i++)
                {
                    ListViewItem item = new ListViewItem(heurige_Fänge[i].GetListToDraw, i);

                    //listAktJahr.Items.Add(item);
                }
            }*/

            comboBox_jahr.Text = "Alle";

            int anzahl = 0;
            int jahr = DateTime.Now.Year;

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT COUNT(*) FROM Fang WHERE Datum BETWEEN '" + jahr + "/01/01' AND '" + (jahr + 1) + "/01/01'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                anzahl = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            label_gesanzahl.Text = anzahl.ToString();

            //this.Cursor = Cursors.WaitCursor;
        }

        #endregion

        #region Eigenschaften

        #endregion

        #region Methoden

        private string[,] MacheJahresListe(string[,] gesamtliste)
        {
            string[,] jahresliste;

            int heuer = DateTime.Today.Year;

            int zeilen = 0;

            for (int i = 0; i < gesamtliste.GetLength(0); i++)
            {
                if (Convert.ToDateTime(gesamtliste[i,5]).Year == heuer )
                {
                    zeilen++;
                }
            }

            jahresliste = new string[zeilen,gesamtliste.GetLength(1)];


            int zeile2 = 0;

            for (int i = 0; i < gesamtliste.GetLength(0); i++)
            {
                if (Convert.ToDateTime(gesamtliste[i,5]).Year == heuer )
                {
                    for (int j = 0; j < gesamtliste.GetLength(1); j++)
                    {
                        jahresliste[zeile2, j] = gesamtliste[i, j];
                    }
                    zeile2++;
                }
            }
            return jahresliste;
        }

        private void SpezifischeFotolisteErstellen()
        {
            try
            {
                imageList1.Images.Clear();
                bool bild = false;

                for (int i = 0; i < heurige_Fänge.Count; i++)
                {
                    for (int a = 0; a < fotoliste.Count; a++)
                    {
                        if (heurige_Fänge[i].ID == fotoliste[a].ID)
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

        #endregion

        #region Events

        private void listAktJahr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*if (e.Button == MouseButtons.Left)
            {
                int index = listAktJahr.SelectedIndices[0];
                List<Foto> fangFotos = new List<Foto>();

                for (int i = 0; i < fotoliste.Count; i++)
                {
                    if (fotoliste[i].ID == heurige_Fänge[index].ID)
                        fangFotos.Add(fotoliste[i]);
                }

                if ((fangFotos != null) && (fangFotos.Count != 0))
                {
                    frm_fotosVonFang = new Frm_FotosVonFang(this.heurige_Fänge, fangFotos, index);
                    frm_fotosVonFang.ShowDialog();
                }
            }*/
        }

        private void fotoAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* int index = listAktJahr.SelectedIndices[0];
                List<Foto> fangFotos = new List<Foto>();

                for (int i = 0; i < fotoliste.Count; i++)
                {
                    if (fotoliste[i].ID == heurige_Fänge[index].ID)
                        fangFotos.Add(fotoliste[i]);
                }

                if ((fangFotos != null) && (fangFotos.Count != 0))
                {
                    frm_fotosVonFang = new Frm_FotosVonFang(this.heurige_Fänge, fangFotos, index);
                    frm_fotosVonFang.ShowDialog();
                }*/
        }

        private void listAktJahr_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  if (listAktJahr.SelectedItems.Count > 0)
            {
                if (listAktJahr.SelectedItems[0].Text != "")
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

        private void comboBox_jahr_SelectionChangeCommitted(object sender, EventArgs e)
        {
            /*if (comboBox_jahr.Text != "Alle")
            {
                this.heurige_Fänge = Fangliste.Fangliste_je_jahr(this.alleFänge, Convert.ToInt16(comboBox_jahr.Text));

                SpezifischeFotolisteErstellen();
            }

                listAktJahr.Items.Clear();

                for (int i = 0; i < this.heurige_Fänge.Count; i++)
                {
                    ListViewItem item = new ListViewItem(this.heurige_Fänge[i].GetListToDraw, i);

                    listAktJahr.Items.Add(item);
                }

                label_gesanzahl.Text = Convert.ToString(this.heurige_Fänge.Count);*/
        }

        private void fänge_Je_JahrDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = fänge_Je_JahrDataGridView.SelectedRows[0];

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
