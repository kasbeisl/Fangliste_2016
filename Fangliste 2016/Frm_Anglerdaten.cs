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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Fangliste_2016
{
    public partial class Frm_Anglerdaten : Form
    {
        #region Variablen

        List<Angler> anglerliste;
        List<Fangliste> fangliste;

        Angler1 aktuellerFischer;
        Angler1 neuerFischerName;

        bool foto_löschen = false;
        bool foto_ändern = false;
        bool name_ändern = false;

        string name;

        DialogResult geändert = DialogResult.No;

        int file_max = 3000 * 1024;//Dateigröße in Kb (3000Kb)
        FileInfo dateiname_neuesFoto;

        int index = 0;

        #endregion

        #region Konstruktor

        public Frm_Anglerdaten(Angler1 aktuellerFischer)
        {
            InitializeComponent();

            this.aktuellerFischer = aktuellerFischer;
        }

        public Frm_Anglerdaten()
        {
            InitializeComponent();
        }

        private void Frm_Anglerdaten_Load(object sender, EventArgs e)
        {
            this.name = this.aktuellerFischer.Name;
            tbx_kürzel.Text = this.aktuellerFischer.Name;
            pic_Fischer.Image = this.aktuellerFischer.Bild;
            if (pic_Fischer.Image != null)
                btn_löschen.Enabled = true;

            this.index = 0;

            /*for (int i = 0; i < anglerliste.Count; i++)
            {
                if (anglerliste[i].Name == aktuellerFischer.Name)
                {
                    index = i;
                    break;
                }
            }

            if((anglerliste != null) && (anglerliste.Count != 0))
            {
                if (File.Exists(Frm_Hauptmenu.DatenOrdner + "\\" + anglerliste[index].FotoDateiname))
                {
                    try
                    {
                            pic_Fischer.ImageLocation = Frm_Hauptmenu.DatenOrdner + "\\" + anglerliste[index].FotoDateiname;
                            btn_löschen.Enabled = true;
                    }
                    catch
                    {
                        pic_Fischer.ImageLocation = Frm_Hauptmenu.DatenOrdner + "\\" + "error.png";
                        btn_löschen.Enabled = false;
                    }
                }
                else
                {
                    pic_Fischer.ImageLocation = Properties.Settings.Default.Data + "\\" + "error.png";
                }
            }
            else
            {
                pic_Fischer.ImageLocation = Properties.Settings.Default.Data + "\\" + "error.png";
            }*/

            btn_ok.Enabled = false;
        }

        #endregion

        #region Events

        private void btn_fischerBearbeiten_Click(object sender, EventArgs e)
        {
            if (tbx_kürzel.Text != "")
            {
                if (name_ändern)
                {
                    try
                    {
                        this.aktuellerFischer.Name = tbx_kürzel.Text;
                        

                        string connectionString = SQLCollection.GetConnectionString();

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "UPDATE Angler SET Name = @name WHERE Id = '" + aktuellerFischer.ID + "'";
                            command.Parameters.Add("name", SqlDbType.VarChar, 0).Value = tbx_kürzel.Text;

                            connection.Open();

                            command.ExecuteNonQuery();

                            connection.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                if (foto_ändern)
                {
                    try
                    {
                        Image imag = pic_Fischer.Image;
                        this.aktuellerFischer.Bild = pic_Fischer.Image;
                        string connectionString = SQLCollection.GetConnectionString();

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        using (SqlCommand command = connection.CreateCommand())
                        {
                         command.CommandText = "UPDATE Angler SET Bild = @Pic WHERE Id = '" + aktuellerFischer.ID + "'";
                        command.Parameters.Add("Pic", SqlDbType.Image, 0).Value = 
                        ConvertImageToByteArray(imag, ImageFormat.Jpeg);

                        connection.Open();

                        command.ExecuteNonQuery();

                        connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }



            if (foto_löschen)
            {
                try
                {
                    string connectionString = SQLCollection.GetConnectionString();
                    //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        this.aktuellerFischer.Bild = null;
                        command.CommandText = "UPDATE Angler SET Bild = @Pic WHERE Id = '" + aktuellerFischer.ID + "'";
                        command.Parameters.Add("Pic", SqlDbType.Image, 0).Value = DBNull.Value;

                        connection.Open();

                        command.ExecuteNonQuery();

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();

                /* bool ersterBuchstabGroß = ErsterBuchstabGroß_Prüfen();
                 bool textOK = PrüfeEingabe(tbx_kürzel.Text);
                 bool namenlänge = NamenLänge_Prüfen();
                 bool fischerexist = FischerExist_Prüfen();

                 if (ersterBuchstabGroß)
                 {
                     if (namenlänge)
                     {
                         if (textOK)
                         {
                             if ((fischerexist == false) || (this.name == tbx_kürzel.Text))
                             {
                                 if (this.name != tbx_kürzel.Text)
                                 {
                                     try
                                     {
                                         if (File.Exists(Frm_Hauptmenu.DatenOrdner + "\\" +this.anglerliste[index].FotoDateiname))
                                         {
                                             FileInfo f = new FileInfo(Frm_Hauptmenu.DatenOrdner + "\\" + this.anglerliste[index].FotoDateiname);
                                             this.neuerFischerName = new Angler1(tbx_kürzel.Text, tbx_kürzel.Text + f.Extension);
                                         }
                                         else
                                         {
                                             this.neuerFischerName = new Angler1(tbx_kürzel.Text, "");
                                         }

                                         if (File.Exists(Frm_Hauptmenu.DatenOrdner + "\\" + this.anglerliste[index].FotoDateiname))
                                             File.Copy(Frm_Hauptmenu.DatenOrdner + "\\" + this.anglerliste[index].FotoDateiname, Frm_Hauptmenu.DatenOrdner + "\\" + neuerFischerName.FotoDateiname, true);
                                     }
                                     catch (Exception ex)
                                     {
                                         MessageBox.Show(ex.ToString(), "Fehler");
                                     }

                                     this.anglerliste[index] = neuerFischerName;
                                     //name_ändern = true;
                                     Name_in_Liste_ändern();
                                 }

                                 if (foto_ändern)
                                 {
                                     if (File.Exists(pic_Fischer.ImageLocation))
                                     {
                                         FileInfo f = new FileInfo(pic_Fischer.ImageLocation);
                                         File.Copy(pic_Fischer.ImageLocation, Frm_Hauptmenu.DatenOrdner + "\\" + tbx_kürzel.Text + f.Extension, true);
                                         this.neuerFischerName = new Angler(tbx_kürzel.Text, tbx_kürzel.Text + f.Extension);
                                     }
                                     else
                                     {
                                         this.neuerFischerName = new Angler(tbx_kürzel.Text, "");
                                     }

                                     this.anglerliste[index] = neuerFischerName;
                                 }

                                 BenutzerDaten_speichern();
                                 this.geändert = DialogResult.OK;
                                 this.Close();
                             }
                             else
                             {
                                 MessageBox.Show("Der Name des Fischers existiert bereits.\n\nBitte geben Sie einen anderen Namen ein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                 this.tbx_kürzel.Text = this.name;
                             }
                         }
                         else
                         {
                             MessageBox.Show("Es sind nur Buchstaben und Zahlen erlaubt.", "Fehler");
                         }
                     }
                 }*/
            }
            else
            {
                MessageBox.Show("Geben Sie einen Namen ein.", "Fehler");
            }
        }

        private void btn_fischerPicLöschen_Click(object sender, EventArgs e)
        {
            DialogResult löschen = MessageBox.Show("Sind Sie sicher, dass Sie das Foto löschen möchten?", "Achtung", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (löschen == DialogResult.Yes)
            {
               /* try
                {
                    string connectionString = SQLCollection.GetConnectionString();
                    //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        this.aktuellerFischer.Bild = null;
                        command.CommandText = "UPDATE Angler SET Bild = @Pic WHERE Id = '" + aktuellerFischer.ID + "'";
                        command.Parameters.Add("Pic", SqlDbType.Image, 0).Value = DBNull.Value;
                            //ConvertImageToByteArray(img, ImageFormat.Jpeg);

                        connection.Open();

                        command.ExecuteNonQuery();

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }*/


                pic_Fischer.ImageLocation = Properties.Settings.Default.Data + "\\" + "error.png";
                /*this.anglerliste[index].FotoDateiname = "";
                 * btn_löschen.Enabled = false;*/
                this.foto_löschen = true;
                
                btn_ok.Enabled = true;
            }
        }

        private byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert,
                                       System.Drawing.Imaging.ImageFormat formatOfImage)
        {
            byte[] Ret;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception) { throw; }
            return Ret;
        }

        private void tbx_kürzel_TextChanged(object sender, EventArgs e)
        {
            this.name_ändern = true;
            btn_ok.Enabled = true;
        }

        private void btn_durchsuchen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JEPG Bild (*.jpg)|*.jpg";

            DialogResult ok = openFileDialog1.ShowDialog();

            if (ok == DialogResult.OK)
            {
                try
                {
                    Image imag = Image.FromFile(openFileDialog1.FileName);

                    //string connectionString = SQLCollection.GetConnectionString();
                    //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";

                    //using (SqlConnection connection = new SqlConnection(connectionString))
                    //using (SqlCommand command = connection.CreateCommand())
                    //{
                      //  command.CommandText = "UPDATE Angler SET Bild = @Pic WHERE Id = '" + aktuellerFischer.ID + "'";
                        //command.Parameters.Add("Pic", SqlDbType.Image, 0).Value = 
                        //ConvertImageToByteArray(imag, ImageFormat.Jpeg);

                        //connection.Open();

                        //command.ExecuteNonQuery();

                        //connection.Close();

                        pic_Fischer.Image = imag;
                    btn_ok.Enabled = true;
                    this.foto_ändern = true;
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                /*string _File = openFileDialog1.FileName;
                FileInfo fi = new FileInfo(_File);

                if (fi.Length > file_max)
                {
                    long file_size_in_kb = fi.Length / 1024;
                    MessageBox.Show("Die Maximale Fotogröße beträgt " + file_max + " Kb.\n\nGröße: " + Convert.ToString(file_size_in_kb) + "Kb", "Foto zu Groß");
                }
                else
                {
                    pic_Fischer.ImageLocation = fi.FullName;
                    this.dateiname_neuesFoto = fi;
                    this.foto_ändern = true;
                    this.foto_löschen = false;

                    btn_löschen.Enabled = true;
                    btn_ok.Enabled = true;
                }*/
            }
        }

        #endregion

        #region Eigenschaften

        public Angler1 AktuellerAngler
        {
            get
            {
                return this.aktuellerFischer;
            }
        }

        public Angler1 Neuer_FischerName
        {
            get
            {
                return this.neuerFischerName;
            }
        }

        public List<Fangliste> AlleFänge_geändert
        {
            get
            {
                return this.fangliste;
            }
        }

        public bool Namen_Ändern
        {
            get
            {
                return this.name_ändern;
            }
        }

        public DialogResult Geändert
        {
            get { return this.geändert; }
        }

        #endregion

        #region Methoden

        private void Name_in_Liste_ändern()
        {
            //Userliste ändern
            //for (int i = 0; i < this.anglerliste.Count; i++)
            //{
            //    if (this.anglerliste[i].Name == this.aktuellerFischer.Name)
            //    {
            //        this.anglerliste[i] = this.neuerFischerName;
            //        break;
            //    }
            //}

            //Fangliste ändern
            for (int i = 0; i < this.fangliste.Count; i++)
            {
                if (this.fangliste[i].Name == this.aktuellerFischer.Name)
                {
                    this.fangliste[i].Name = this.anglerliste[index].Name;
                }
            }
        }

        private void BenutzerDaten_speichern()
        {
            Angler.SpeichernAsList(Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Anglerliste + Properties.Settings.Default.Datentyp, this.anglerliste);

            if (this.name_ändern)
            {
                Fangliste.SpeichernAsList(this.fangliste, Frm_Hauptmenu.DatenOrdner, Properties.Settings.Default.Fangliste + Properties.Settings.Default.Datentyp);
            }

            if (foto_löschen)
            {
                try
                {
                    if (File.Exists(Frm_Hauptmenu.DatenOrdner + "\\" + anglerliste[index].FotoDateiname))
                    {
                        File.Delete(Frm_Hauptmenu.DatenOrdner + "\\" + anglerliste[index].FotoDateiname);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Das Benutzerfoto konnte nicht gelöscht werden\n\nInformation:\n" + ex.ToString(), "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RenameFile(string oldFileName, string newFileName)
        {
            try
            {
                if (oldFileName != newFileName)
                {
                    if (File.Exists(oldFileName))
                        File.Copy(oldFileName, newFileName);

                    if (File.Exists(newFileName))
                        File.Delete(oldFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datei konnte nicht unbenannt werden.\n\nInformationen:\nFilename:" + oldFileName + "\n\n" + ex.ToString(), "Fehler");
            }
        }

        private bool FischerExist_Prüfen()
        {
            bool fischerExist = false;

            try
            {
                for (int i = 0; i < anglerliste.Count; i++)
                {
                    if (anglerliste[i].Name == tbx_kürzel.Text)
                    {
                        fischerExist = true;
                        break;
                    }
                }
            }
            catch
            {
            }

            return fischerExist;
        }

        private bool ErsterBuchstabGroß_Prüfen()
        {
            bool ersterBuchstabGroß = false;

            if (!Char.IsLower(tbx_kürzel.Text[0]))
            {
                ersterBuchstabGroß = true;
            }
            else
            {
                MessageBox.Show("Der Erste Buchstabe muss groß sein.", "Großschreibung beachten.");
            }

            return ersterBuchstabGroß;
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

        private bool NamenLänge_Prüfen()
        {
            bool namenLänge = false;

            if (tbx_kürzel.TextLength <= 20)
            {
                namenLänge = true;
            }
            else
            {
                MessageBox.Show("Der Name ist zu lang.", "Fehler");
            }

            return namenLänge;
        }

        #endregion
    }
}
