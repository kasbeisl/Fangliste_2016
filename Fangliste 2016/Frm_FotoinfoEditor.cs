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
    public partial class Frm_FotoinfoEditor : Form
    {
        #region Variablen

        List<Fangliste> fangliste;
        List<Foto> fotoliste;
        Foto eintrag = null;
        Fangliste fang;
        string dateiname;
        int index;
        bool btn_löschen_enable = false;
        bool edit = false;

        #endregion

        #region Konstruktor
        
        public Frm_FotoinfoEditor(List<Fangliste> fangliste, Foto eintrag, string dateiname)
        {
            InitializeComponent();

            this.fangliste = fangliste;
            this.eintrag = eintrag;
            this.dateiname = dateiname;

            for (int i = 0; i < fangliste.Count; i++)
            {
                if (fangliste[i].ID == eintrag.ID)
                    fang = fangliste[i];
            }

            Zeichnen();
        }

        public Frm_FotoinfoEditor(List<Fangliste> fangliste, string dateiname)
        {
            InitializeComponent();

            this.fangliste = fangliste;
            this.dateiname = dateiname;
        }

        public Frm_FotoinfoEditor(List<Fangliste> fangliste, List<Foto> fotoliste, string dateiname)
        {
            InitializeComponent();

            this.fangliste = fangliste;
            this.fotoliste = fotoliste;
            this.dateiname = dateiname;

            try
            {
                if ((fotoliste != null) || (fotoliste.Count != 0))
                {
                    for (int j = 0; j < fotoliste.Count; j++)
                    {
                        string file = Frm_Hauptmenu.FotoOrdner + fotoliste[j].Dateiname;
                        if (file == dateiname)
                        {
                            index = j;
                            for (int i = 0; i < this.fangliste.Count; i++)
                            {
                                if (fangliste[i].ID == fotoliste[j].ID)
                                    fang = fangliste[i];
                            }
                            btn_löschen_enable = true;
                            edit = true;
                            break;
                        }
                    }
                }
            }
            catch { }
        }

        #endregion

        #region Eigenschaften

        /// <summary>
        /// 
        /// </summary>
        public Foto NeuerEintrag
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
        public int GetIndex
        {
            get { return this.index; }
        }

        #endregion

        #region Events

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_fangAuswählen_Click(object sender, EventArgs e)
        {
            Frm_alleFänge_nur_Liste frm_alleFänge = new Frm_alleFänge_nur_Liste(this.fangliste);
            DialogResult r = frm_alleFänge.ShowDialog();

            if (r == DialogResult.OK)
            {
                fang = fangliste[frm_alleFänge.SelectedIndex];
                btn_entfernen.Enabled = true;

                Zeichnen();
            }
        }

        private void btn_fertig_Click(object sender, EventArgs e)
        {
            bool textOK = PrüfeEingabe(textBox1.Text);

            if (textOK)
            {
                if (textBox1.Text != "")
                {
                    FileInfo fi = new FileInfo(this.dateiname);

                    DirectoryInfo di = new DirectoryInfo(fi.FullName);
                    string path = fi.Directory.ToString();
                    string[] o = path.Split('\\');
                    string filename = o[o.Length - 1] + "\\" + fi.Name;
                    if (fang != null)
                        eintrag = new Foto(fang.ID, filename, textBox1.Text);
                    else
                        eintrag = new Foto(-1, filename, textBox1.Text);

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
            if (btn_löschen_enable)
            {
                btn_löschen.Enabled = true;
            }
            else
            {
                btn_löschen.Enabled = false;
            }

            if(fang != null)
                btn_entfernen.Enabled = true;
            else
                btn_entfernen.Enabled = false;

            Zeichnen();
        }

        #endregion

        #region Methoden

        private void Zeichnen()
        {
            if (fang != null)
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
                textBox1.Text = fotoliste[index].Kommentar;
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
            try
            {
                this.fotoliste.RemoveAt(index);
                Foto.Speichere_Fotoliste(this.fotoliste, Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Fotoliste + Properties.Settings.Default.Datentyp);
                this.Close();
            }
            catch { }
        }

        private void btn_entfernen_Click(object sender, EventArgs e)
        {
            try
            {
                this.fang = null;
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
