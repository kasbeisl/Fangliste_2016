using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FanglisteLibrary;
using System.Threading;

namespace Fangliste_2016
{
    public partial class Frm_Vollbild : Form
    {
        #region Variablen

        BackgroundWorker Diashow;
        int foto_index;
        List<string> images;
        List<Fangliste> fangliste;
        List<Foto> fotoliste;
        bool diashowrun = false;
        int diashowtime;
        bool shuffle;
        Random rnd = new Random();
        int foto_vorher = 0;

        bool fotoExtern = false;
        string dateiname = "";

        #endregion

        #region Konstruktor

        public Frm_Vollbild(List<string> images, List<Fangliste> fangliste, List<Foto> fotoliste, int foto_index, bool diashowrun, int diashowtime, bool shuffle)
        {
            InitializeComponent();

            this.images = images;
            this.fangliste = fangliste;
            this.fotoliste = fotoliste;
            this.foto_index = foto_index;
            this.diashowrun = diashowrun;
            this.diashowtime = diashowtime;
            this.shuffle = shuffle;
        }

        public Frm_Vollbild(string dateiname)
        {
            InitializeComponent();

            this.fotoExtern = true;
            this.dateiname = dateiname;
        }

        private void Frm_Vollbild_Load(object sender, EventArgs e)
        {
            //lb_fotoInfo.Location = new Point(100, this.Height - 90);
            lb_fotoInfo.Text = "";
            label_kommentar.Text = "";

            if (!fotoExtern)
            {
                #region Diashow background
                Diashow = new BackgroundWorker();
                Diashow.WorkerReportsProgress = true;
                Diashow.WorkerSupportsCancellation = true;
                Diashow.DoWork += new DoWorkEventHandler(Diashow_DoWork);
                Diashow.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Diashow_RunWorkerCompleted);
                #endregion

                if (!DiashowRun)
                {
                    try
                    {
                        pictureBox1.ImageLocation = images[foto_index];
                    }
                    catch
                    {
                        //MessageBox.Show("", "Fehler");
                    }
                }
                else
                {
                    Diashow.RunWorkerAsync();
                }
            }
            else
            {
                pictureBox1.ImageLocation = this.dateiname;
            }
        }

        #endregion

        #region Events

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (diashowrun)
            {
                Diashow.CancelAsync();
            }

            this.Close();
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            FotoInfos_Set();
        }

        private void Frm_Vollbild_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (diashowrun)
                {
                    Diashow.CancelAsync();
                }

                this.Close();
            }
        }

        #endregion

        #region Eigenschaften

        public int FotoIndex
        {
            get
            {
                return this.foto_index;
            }
            set
            {
                this.foto_index = value;
            }
        }

        public bool DiashowRun
        {
            get
            {
                return this.diashowrun;
            }
            set
            {
                this.diashowrun = value;
            }
        }

        public int DiashowTime
        {
            get
            {
                return this.diashowtime;
            }
            set
            {
                this.diashowtime = value;
            }
        }

        #endregion

        #region Backgroundworker Diashow

        public void Diashow_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = foto_index; i <= this.images.Count; i++)
                {
                    if (diashowrun)
                    {
                        if (shuffle)
                        {
                            i = rnd.Next(0, this.images.Count);

                            if (foto_vorher == i)
                            {
                                bool exist = true;
                                while (exist)
                                {
                                    i = rnd.Next(0, this.images.Count);

                                    if (foto_vorher != i)
                                    {
                                        exist = false;
                                    }
                                }
                            }
                        }

                        foto_index = i;
                        foto_vorher = i;
                        pictureBox1.ImageLocation = images[foto_index];
                        Thread.Sleep(diashowtime);

                        if (i == this.images.Count - 1)
                        {
                            //Thread.Sleep(diashowtime);
                            i = -1;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch
            {
                //MessageBox.Show("Bild konnte nicht geladen werden.", "Fehler");
            }
        }

        public void Diashow_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        #endregion

        #region Methoden

        private void FotoInfos_Set()
        {
            lb_fotoInfo.Text = "";
            label_kommentar.Text = "";

            try
            {
                if ((fotoliste != null) || (fotoliste.Count != 0))
                {
                    for (int j = 0; j < fotoliste.Count; j++)
                    {
                        string file = Frm_Hauptmenu.FotoOrdner + fotoliste[j].Dateiname;
                        if (file == images[foto_index])
                        {
                            label_kommentar.Text = fotoliste[j].Kommentar;
                            for (int i = 0; i < fangliste.Count; i++)
                            {
                                if (fangliste[i].ID == fotoliste[j].ID)
                                {
                                    lb_fotoInfo.Text = "Name: " + this.fangliste[i].Name + ", Fischart: " + this.fangliste[i].Fischart + ", gefangen am: " + this.fangliste[i].Datum.ToShortDateString() + " um " + this.fangliste[i].Uhrzeit.ToShortTimeString() + ", Größe: " + this.fangliste[i].Größe + "cm und einem Gewicht von: " + this.fangliste[i].Gewicht + "kg.";
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            catch { }
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
