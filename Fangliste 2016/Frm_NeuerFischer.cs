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
using System.Drawing.Imaging;

namespace Fangliste_2016
{
    public partial class Frm_NeuerFischer : Form
    {
        #region Variablen

        private List<Angler1> allUser_list;

        #endregion

        #region Konstruktor

        public Frm_NeuerFischer(List<Angler1> allUser_list)
        {
            InitializeComponent();

            this.allUser_list = allUser_list;
        }

        private void Frm_NeuerName_Load(object sender, EventArgs e)
        {
            btn_ok.Enabled = false;
        }

        #endregion

        #region Eigenschaften


        #endregion

        #region Button usw..

        private void btn_ok_Click(object sender, EventArgs e)
        {
            FischerHinzufügen();
        }

        private void tb_neuername_MouseClick(object sender, MouseEventArgs e)
        {
            tbx_kürzel.Text = "";
        }

        private void tb_neuername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FischerHinzufügen();
            }
        }

        #endregion

        #region Methoden

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

        private void FischerHinzufügen()
        {
            if (tbx_kürzel.Text != "")
            {
                bool ersterBuchstabGroß = ErsterBuchstabGroß_Prüfen();
                bool fischerExist = FischerExist_Prüfen();
                bool namenlänge = NamenLänge_Prüfen();

                if (ersterBuchstabGroß)
                {
                    if (namenlänge)
                    {
                        if (!SQLCollection.AnglerExist(tbx_kürzel.Text))
                        {
                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = SQLCollection.GetConnectionString();
                            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";

                            openFileDialog1.FileName = "Dein Foto";
                            DialogResult r = openFileDialog1.ShowDialog();
                            Image imag = null;

                            if (r == DialogResult.OK)
                            {
                                imag = Image.FromFile(openFileDialog1.FileName);

                                try
                                {
                                    con.Open();
                                    SqlCommand insertCommand = new SqlCommand(
                                "Insert into Angler (Name, Bild) Values ('" + tbx_kürzel.Text + "', @Pic)", con);
                                    insertCommand.Parameters.Add("Pic", SqlDbType.Image, 0).Value =
                                        ConvertImageToByteArray(imag, ImageFormat.Jpeg);
                                    int queryResult = insertCommand.ExecuteNonQuery();
                                    if (queryResult == 1)
                                        Console.WriteLine("Erfolgreich aktualisiert.");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed to connect to data source" + ex.ToString());
                                }
                                finally
                                {
                                    con.Close();
                                }
                            }
                            else
                            {
                                try
                                {
                                    con.Open();
                                    SqlCommand insertCommand = new SqlCommand(
                                "Insert into Angler (Name) Values ('" + tbx_kürzel.Text + "')", con);
                                    int queryResult = insertCommand.ExecuteNonQuery();
                                    if (queryResult == 1)
                                        Console.WriteLine("Erfolgreich aktualisiert.");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Failed to connect to data source" + ex.ToString());
                                }
                                finally
                                {
                                    con.Close();
                                }
                            }

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            /*if (fischerExist == false)
                            {
                                fischerEintragen = true;
                                neuerFischer = new Angler();

                                neuerFischer.Name = tbx_kürzel.Text;

                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Der Name des Fischers existiert bereits.\n\nBitte geben Sie einen anderen Namen ein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }*/
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Es existiert bereits ein Angler mit dem Name '{0}'.\nBitte versuchen Sie einen anderen Namen.", tbx_kürzel.Text), "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Geben Sie einen Namen ein.", "Fehler");
            }
        }

        private bool FischerExist_Prüfen()
        {
            bool fischerExist = false;

            try
            {
                for (int i = 0; i < allUser_list.Count; i++)
                {
                    if (allUser_list[i].Name == tbx_kürzel.Text)
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

        #region Events

        private void tbx_kürzel_TextChanged(object sender, EventArgs e)
        {
            if (tbx_kürzel.Text != "")
            {
                btn_ok.Enabled = true;
            }
            else
            {
                btn_ok.Enabled = false;
            }
        }

        private void tbx_kürzel_Validated(object sender, EventArgs e)
        {
            epFehlermeldungen.Clear();
        }

        private void tbx_kürzel_Validating(object sender, CancelEventArgs e)
        {
            if (tbx_kürzel.Text == "")
            {

            }
            else if (!PrüfeEingabe(tbx_kürzel.Text))
            {
                epFehlermeldungen.SetError(tbx_kürzel, "Die Eingabe darf nur Buchstaben und Zahlen enthalten.");
                e.Cancel = true;
            }
        }

        #endregion
    }
}
