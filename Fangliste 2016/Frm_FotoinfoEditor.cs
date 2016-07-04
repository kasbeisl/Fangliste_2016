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
using System.Data.SqlClient;

namespace Fangliste_2016
{
    public partial class Frm_FotoinfoEditor : Form
    {
        #region Variablen

        Foto1 eintrag = null;
        bool btn_löschen_enable = false;
        bool edit = false;
        Image bild;
        int fang_ID;
        List<Ordner> ordnerliste = null;

        #endregion

        #region Konstruktor
        
        public Frm_FotoinfoEditor(Image bild)
        {
            InitializeComponent();

            this.bild = bild;
        }

        public Frm_FotoinfoEditor(Foto1 eintrag)
        {
            InitializeComponent();

            this.bild = eintrag.Bild;
            this.eintrag = eintrag;

            richTextBox1.Text = "ID: " + eintrag.ID + "\n" +
                                     "Name: " + eintrag.Angler_ID + "\n";
        }

        #endregion

        #region Eigenschaften

        /// <summary>
        /// 
        /// </summary>
        public Foto1 NeuerEintrag
        {
            get { return this.eintrag; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Edit
        {
            get { return this.edit; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int Fang_ID
        {
            get { return fang_ID; }
        }

        #endregion

        #region Events

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_fangAuswählen_Click(object sender, EventArgs e)
        {
            Frm_alleFänge_nur_Liste frm_alleFänge = new Frm_alleFänge_nur_Liste();
            DialogResult r = frm_alleFänge.ShowDialog();

            if (r == DialogResult.OK)
            {
                eintrag = new Foto1(0, Convert.ToInt16(frm_alleFänge.Row.Cells[1].Value), Convert.ToInt16(frm_alleFänge.Row.Cells[0].Value), 1, textBox1.Text);
                richTextBox1.Text = "ID: " + frm_alleFänge.Row.Cells[1].Value.ToString() + "\n" +
                                     "Name: " + frm_alleFänge.Row.Cells[3].Value.ToString() + "\n" +
                                     "Fischart: " + frm_alleFänge.Row.Cells[4].Value.ToString() + "\n" +
                                     "Größe: " + frm_alleFänge.Row.Cells[5].Value.ToString() + " cm\n" +
                                     "Gewicht: " + frm_alleFänge.Row.Cells[6].Value.ToString() + " kg\n" +
                                     "Gewässer: " + frm_alleFänge.Row.Cells[7].Value.ToString() + "\n" +
                                     "Datum: " + frm_alleFänge.Row.Cells[8].Value.ToString() + "\n" +
                                     "Uhrzeit: " + frm_alleFänge.Row.Cells[9].Value.ToString(); //, , frm_alleFänge.Row.Cells[9].Value.ToString(), frm_alleFänge.Row.Cells[10].Value.ToString(), Convert.ToDouble(frm_alleFänge.Row.Cells[11].Value), Convert.ToDouble(frm_alleFänge.Row.Cells[12].Value), Convert.ToDouble(frm_alleFänge.Row.Cells[13].Value), frm_alleFänge.Row.Cells[14].Value.ToString(), Convert.ToBoolean(frm_alleFänge.Row.Cells[15].Value), frm_alleFänge.Row.Cells[16].Value.ToString());

                

                btn_entfernen.Enabled = true;
                
                //Zeichnen();
            }
        }

        private void btn_fertig_Click(object sender, EventArgs e)
        {
            if (ordnerliste != null)
                eintrag.Ordner_ID = ordnerliste[cb_ordner.SelectedIndex].ID;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

            bool textOK = PrüfeEingabe(textBox1.Text);

            if (textOK)
            {
                if (textBox1.Text != "")
                {
                    /*FileInfo fi = new FileInfo(this.dateiname);

                    DirectoryInfo di = new DirectoryInfo(fi.FullName);
                    string path = fi.Directory.ToString();
                    string[] o = path.Split('\\');
                    string filename = o[o.Length - 1] + "\\" + fi.Name;
                    if (fang != null)
                        eintrag = new Foto(fang.ID, filename, textBox1.Text);
                    else
                        eintrag = new Foto(-1, filename, textBox1.Text);
                        */
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Fehlerhafte eingabe.", "Fehler - Kommentar");
            }
        }

        private void Frm_FotoinfoEditor_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = bild;

            if (btn_löschen_enable)
            {
                btn_löschen.Enabled = true;
            }
            else
            {
                btn_löschen.Enabled = false;
            }

             this.ordnerliste = LeseOrdnerTabelleaus();

            for (int i = 0; i < ordnerliste.Count; i++)
            {
                cb_ordner.Items.Add(ordnerliste[i].Name);
            }

            /*if(fang != null)
                btn_entfernen.Enabled = true;
            else
                btn_entfernen.Enabled = false;
                */
            //Zeichnen();
        }

        #endregion

        #region Methoden

        private void Zeichnen()
        {
            /*if (fang != null)
            {
                richTextBox1.Text = "ID: " + fang.ID + "\n" +
                                     "Name: " + fang.Name + "\n" +
                                     "Fischart: " + fang.Fischart + "\n" +
                                     "Größe: " + fang.Größe + " cm\n" +
                                     "Gewicht: " + fang.Gewicht + " kg\n" +
                                     "Gewässer: " + fang.Gewässer + "\n" +
                                     "Datum: " + fang.Datum.ToShortDateString() + "\n" +
                                     "Uhrzeit: " + fang.Uhrzeit.ToShortTimeString();
            }

            if(edit)
                textBox1.Text = eintrag.Kommentar;*/
        }

        private List<Ordner> LeseOrdnerTabelleaus()
        {
            List<Ordner> ordnerliste = new List<Ordner>();

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT * " +
                                "FROM Ordner";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //cb_ordner.Items.Add(reader["Name"]);
                    ordnerliste.Add(new Ordner(Convert.ToInt16(reader["Id"]), reader["Name"].ToString()));
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

            return ordnerliste;
        }

        private bool PrüfeEingabe(string text)
        {
            string pat = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqerstuvwxyz.- ßüöäÜÖÄ#!/(){}[]?,:@<>";
            foreach (char ch in text)
            {
                if (pat.IndexOf(ch) < 0)
                    return false;
            }
            return true;
        }

        #endregion

        private void btn_löschen_Click(object sender, EventArgs e)
        {
            /*try
            {
                this.fotoliste.RemoveAt(index);
                Foto.Speichere_Fotoliste(this.fotoliste, Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Fotoliste + Properties.Settings.Default.Datentyp);
                this.Close();
            }
            catch { }*/
        }

        private void btn_entfernen_Click(object sender, EventArgs e)
        {
            try
            {
                //this.fang = null;
                richTextBox1.Text = "Kein Fang ausgewählt";
                btn_entfernen.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fehler");
            }
        }
    }
}
