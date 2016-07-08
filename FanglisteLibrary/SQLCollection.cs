using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using FanglisteLibrary;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace FanglisteLibrary
{
    public class SQLCollection
    {
        #region Allgemein

        /// <summary>
        /// Gibt den ConnectionString der Datenbank zurück.
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\GitHub\Fangliste_2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DeleteTabel()
        {
            try
            {
                string ConnectionString = SQLCollection.GetConnectionString();
                //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+System.IO.Directory.GetCurrentDirectory()+@"\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";

                using (var sc = new SqlConnection(ConnectionString))
                using (var cmd = sc.CreateCommand())
                {
                    sc.Open();
                    cmd.CommandText = "DELETE FROM Fang";
                    //cmd.Parameters.AddWithValue("@tabelle", tabelle);
                    cmd.ExecuteNonQuery();
                    sc.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Der Angler konnte nicht von der Datenbank gelöscht werden.\n\nFolgende Fehler wurden erkannt:\n" + ex.ToString());
            }

        }

        #endregion

        #region Angler

        /// <summary>
        /// Gibt die Liste aller Angler zurück.
        /// </summary>
        /// <returns></returns>
        public static List<Angler1> GetAnglerliste()
        {
            List<Angler1> anglerliste = new List<Angler1>();

            string ConnectionString = SQLCollection.GetConnectionString();
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT Id, Name, Bild " +
                                "FROM Angler";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
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
                            }
                        }
                        else
                        {
                            /*if (File.Exists(Properties.Settings.Default.Data + "\\" + "error.png"))
                            {
                                //this.imageList_Fischer.Images.Add(Image.FromFile(Properties.Settings.Default.Data + "\\" + "error.png"));
                                bmp = new Bitmap(Properties.Settings.Default.Data + "\\" + "error.png");
                                //imageList_Fischer.Images.Add(b);
                                //AddImageToImageList(imageList_Fischer, bmp, "", imageList_Fischer.ImageSize.Width, imageList_Fischer.ImageSize.Height);
                            }*/
                        }

                        anglerliste.Add(new Angler1(Convert.ToInt16(reader["Id"]), reader["Name"].ToString(), bmp));
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

            return anglerliste;
        }

        /// <summary>
        /// Löscht den Angler mit dem angegebenen Namen.
        /// </summary>
        /// <param name="name">Der Name des Anglers der gelöscht werden soll.</param>
        public static void DeleteAngler(string name)
        {
            try
            {
                string ConnectionString = SQLCollection.GetConnectionString();
                //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+System.IO.Directory.GetCurrentDirectory()+@"\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";

                using (var sc = new SqlConnection(ConnectionString))
                using (var cmd = sc.CreateCommand())
                {
                    sc.Open();
                    cmd.CommandText = "DELETE FROM Angler WHERE Name = @name";
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                    sc.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Der Angler konnte nicht von der Datenbank gelöscht werden.\n\nFolgende Fehler wurden erkannt:\n" + ex.ToString());
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anglername"></param>
        /// <returns></returns>
        public static bool AnglerExist(string anglername)
        {
            SqlConnection conn = new SqlConnection(SQLCollection.GetConnectionString());
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM Angler WHERE ([Name] = @user)", conn);
            check_User_Name.Parameters.AddWithValue("@user", anglername);
            conn.Open();
            int UserExist = (int)check_User_Name.ExecuteScalar();
            conn.Close();

            if (UserExist > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Ändert den Namen des Anglers in der Datenbank.
        /// </summary>
        /// <param name="angler_ID">Die ID des Anglers, dessen Name geändert werden soll.</param>
        /// <param name="name">Der Neue Name des Anglers.</param>
        public static void UpdateAnglerName(int angler_ID, string name)
        {
            try
            {
                string connectionString = SQLCollection.GetConnectionString();
                //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Angler SET Name = @Name WHERE Id = '" + angler_ID + "'";
                    command.Parameters.Add("Name", SqlDbType.VarChar, 0).Value = name;

                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// Setzt das Bild, des Anglers auf den Wert 'null'.
        /// </summary>
        /// <param name="angler_ID">Die ID des Anglers, dessen Bild geändert werden soll.</param>
        public static void SetAnglerBildNull(int angler_ID)
        {
            try
            {
                string connectionString = SQLCollection.GetConnectionString();
                //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Angler SET Bild = @Pic WHERE Id = '" + angler_ID + "'";
                    command.Parameters.Add("Pic", SqlDbType.Image, 0).Value = DBNull.Value;

                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        #endregion

        #region Fang

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fangliste"></param>
        /// <param name="connectionString"></param>
        public static void FillDatabaseWithDATAFromAFangliste(List<Fangliste1> fangliste, string connectionString)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;

            try
            {
                con.Open();

                Console.WriteLine("Fänge werden in die Datenbank geschrieben...");

                for (int i = 0; i < fangliste.Count; i++)
                {
                    SqlCommand insertCommand = new SqlCommand(
                "Insert into Fang (Angler_ID, Fischart_ID, Länge, Gewicht, Gewässer_ID, Köder, Angelplatz, Tiefe, Lufttemperatur, Wassertemperatur, Datum, Uhrzeit, Zurückgesetzt, Wetter, Kommentar) Values (@Angler_ID, @Fischart_ID, @Länge, @Gewicht, @Gewässer_ID, @Köder, @Angelplatz, @Tiefe, @Lufttemperatur, @Wassertemperatur, @Datum, @Uhrzeit, @Zurückgesetzt, @Wetter, @Kommentar)", con);
                    insertCommand.Parameters.Add("Angler_ID", SqlDbType.Int, 0).Value = fangliste[i].Angler_ID;
                    insertCommand.Parameters.Add("Fischart_ID", SqlDbType.Int, 0).Value = fangliste[i].Fischart_ID;
                    insertCommand.Parameters.Add("Länge", SqlDbType.Float).Value = fangliste[i].Größe;
                    insertCommand.Parameters.Add("Gewicht", SqlDbType.Float).Value = fangliste[i].Gewicht;
                    insertCommand.Parameters.Add("Gewässer_ID", SqlDbType.Int, 0).Value = fangliste[i].Gewässer_ID;
                    insertCommand.Parameters.Add("Köder", SqlDbType.Text, 0).Value = fangliste[i].Köderbeschr;
                    insertCommand.Parameters.Add("Angelplatz", SqlDbType.Text, 0).Value = fangliste[i].Platzbesch;
                    insertCommand.Parameters.Add("Tiefe", SqlDbType.Float).Value = fangliste[i].Tiefe;
                    insertCommand.Parameters.Add("Lufttemperatur", SqlDbType.Float).Value = fangliste[i].Lufttemperatur;
                    insertCommand.Parameters.Add("Wassertemperatur", SqlDbType.Float).Value = fangliste[i].Wassertemperatur;
                    insertCommand.Parameters.Add("Datum", SqlDbType.Date, 0).Value = fangliste[i].Datum;
                    insertCommand.Parameters.Add("Uhrzeit", SqlDbType.DateTime, 0).Value = fangliste[i].Uhrzeit;
                    insertCommand.Parameters.Add("Zurückgesetzt", SqlDbType.Bit, 0).Value = fangliste[i].Zurückgesetzt;
                    insertCommand.Parameters.Add("Wetter", SqlDbType.VarChar, 0).Value = fangliste[i].Wetter;
                    insertCommand.Parameters.Add("Kommentar", SqlDbType.Text, 0).Value = fangliste[i].Kommentar;

                    int queryResult = insertCommand.ExecuteNonQuery();
                    if (queryResult == 1)
                        Console.WriteLine("Erfolgreich eingetragen. ({0})", i);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Foto
        #endregion

        #region FotoOrdner

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordnername"></param>
        /// <returns></returns>
        public static bool OrdnerExist(string ordnername)
        {
            SqlConnection conn = new SqlConnection(SQLCollection.GetConnectionString());
            SqlCommand check_Ordner_Name = new SqlCommand("SELECT COUNT(*) FROM Ordner WHERE ([Name] = @name)", conn);
            check_Ordner_Name.Parameters.AddWithValue("@name", ordnername);
            conn.Open();
            int UserExist = (int)check_Ordner_Name.ExecuteScalar();
            conn.Close();

            if (UserExist > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Link

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Link> GetLinks()
        {
            List<Link> liste = new List<Link>();

            string ConnectionString = SQLCollection.GetConnectionString();
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT * " +
                                "FROM Link";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 1;
                Font stringFont = new Font("Segoe UI", 9);

                while (reader.Read())
                {
                    ToolStripButton links = new ToolStripButton();
                    liste.Add(new Link(Convert.ToInt16(reader["Id"]), reader["Name"].ToString(), reader["Link"].ToString()));
                    count++;
                }
                reader.Close();
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

            return liste;
        }

        #endregion

        #region Gewässer

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Gewässer> GetGewässerListe()
        {
            List<Gewässer> gewässerliste = new List<Gewässer>();

            string ConnectionString = SQLCollection.GetConnectionString();
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT Id, Name " +
                                "FROM Gewässer";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        gewässerliste.Add(new Gewässer(Convert.ToInt16(reader["Id"]), reader["Name"].ToString()));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
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

            return gewässerliste;
        }

        #endregion

        #region Fisch

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Fischarten> GetFischartenliste()
        {
            List<Fischarten> fischartenliste = new List<Fischarten>();

            string ConnectionString = SQLCollection.GetConnectionString();
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT Id, Name, KF " +
                                "FROM Fisch";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        fischartenliste.Add(new Fischarten(Convert.ToInt16(reader["Id"]), reader["Name"].ToString(), Convert.ToDouble(reader["KF"])));
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

            return fischartenliste;
        }

        #endregion

        #region PersönlicheFängeDetails

        /// <summary>
        /// Gibt die Anzahl aller gefangenen Fische, des angegebenen Angler zurück.
        /// </summary>
        /// <param name="angler">Der Angler, dessen anzahl der gefangen Fische ermittelt werden soll.</param>
        /// <returns></returns>
        public static int GesamtAnzahlDerFänge(Angler1 angler)
        {
            int anzahl = 0;

            string ConnectionString = SQLCollection.GetConnectionString();
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT COUNT(*) Angler_ID FROM Fang WHERE Angler_ID = '" + angler.ID + "'";
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

            return anzahl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static double GesamtGewichtDerFänge(Angler1 angler)
        {
            double gewicht = 0;

            string ConnectionString = SQLCollection.GetConnectionString();
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT SUM(Gewicht) AS Gewicht, Angler_ID FROM Fang WHERE Angler_ID = '" + angler.ID + "' GROUP BY Angler_ID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gewicht = Convert.ToDouble(reader["Gewicht"]);
                }
                reader.Close();
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

            gewicht = Math.Round(gewicht, 2);
            return gewicht;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angler"></param>
        /// <returns></returns>
        public static double GesamtLängeDerFänge(Angler1 angler)
        {
            double länge = 0;

            string ConnectionString = SQLCollection.GetConnectionString();
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT SUM(Länge) AS Länge, Angler_ID FROM Fang WHERE Angler_ID = '" + angler.ID + "' GROUP BY Angler_ID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    länge = Convert.ToDouble(reader["Länge"]);
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

            return länge;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angler"></param>
        /// <returns>Gibt ein Array zurück, mit den werten jahrCount & durchschnitt ([0] = jahrCount | [1] = durchschnitt)</returns>
        public static int[] FängeProJahr(Angler1 angler)
        {
            int fängeInsgesamt = 0;
            int jahreCount = 0;
            int durchschnitt = 0;

            string ConnectionString = SQLCollection.GetConnectionString();
            SqlConnection con = new SqlConnection();

            List<int> a = new List<int>();

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT DISTINCT YEAR(Datum) AS Datum " +
                                "FROM Fang WHERE Angler_ID = '" + angler.ID + "' GROUP BY Datum";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    a.Add(Convert.ToInt16(reader["Datum"]));
                }
                reader.Close();
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

            jahreCount = a.Count;

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT COUNT(*) Angler_ID FROM Fang WHERE Angler_ID = '" + angler.ID + "'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                fängeInsgesamt = Convert.ToInt32(cmd.ExecuteScalar());
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

            //Durschnittliche Fänge pro Jahr = Gesamtanzahler der Fänge / Die Anzahl der Jahre

            if (fängeInsgesamt != 0 && jahreCount != 0)
                durchschnitt = fängeInsgesamt / jahreCount;

            int[] array = new int[2];

            array[0] = jahreCount;
            array[1] = durchschnitt;

            return array;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angler"></param>
        /// <returns></returns>
        public static int GesamtAnzahlFängeAktuell(Angler1 angler)
        {
            int anzahl = 0;
            int jahr = DateTime.Now.Year;

            string ConnectionString = SQLCollection.GetConnectionString();
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT COUNT(*) FROM Fang WHERE Angler_ID = '" + angler.ID + "' AND Datum BETWEEN '" + jahr + "/01/01' AND '" + (jahr + 1) + "/01/01'";
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

            return anzahl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angler"></param>
        /// <returns></returns>
        public static string BestesJahr(Angler1 angler)
        {
            List<int> a = new List<int>();
            List<int> anzahl = new List<int>();

            string ConnectionString = SQLCollection.GetConnectionString();
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;

                string strSQL = "SELECT DISTINCT YEAR(Datum) AS Datum " +
                                "FROM Fang WHERE Angler_ID = '" + angler.ID + "' GROUP BY Datum";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine("{0,-35}{1}", reader["Id"], reader["Name"]);
                    a.Add(Convert.ToInt16(reader["Datum"]));
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


            for (int i = 0; i < a.Count; i++)
            {
                try
                {
                    con.ConnectionString = ConnectionString;

                    string strSQL = "SELECT Count(*) AS Zähler " +
                                    "FROM Fang WHERE Angler_ID = '" + angler.ID + "' AND Datum BETWEEN '" + a[i] + "/01/01' AND '" + (a[i] + 1) + "/01/01'";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        anzahl.Add(Convert.ToInt16(reader["Zähler"]));
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
            }

            int mehr = 0;
            int _jahr = a[0];

            for (int i = 0; i < a.Count; i++)
            {
                if (anzahl[i] > mehr)
                {
                    mehr = anzahl[i];
                    _jahr = a[i];
                }
            }

            return _jahr.ToString() + " (" + mehr.ToString() + ")";
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ausgewähltesJahr"></param>
        /// <returns></returns>
        public static List<TrophyTeilnehmer> GetLakeTrophy(int ausgewähltesJahr)
        {
            List<TrophyTeilnehmer>liste = new List<TrophyTeilnehmer>();

            string ConnectionString = SQLCollection.GetConnectionString();
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT Angler_ID, SUM(Fang.Gewicht) AS Gewicht " +
                                "FROM Fang " +
                                "WHERE Datum >= '" + ausgewähltesJahr + "-01-01 00:00:00' AND Datum < '" + (ausgewähltesJahr + 1) + "-01-01 00:00:00'AND (Fischart_ID = '2' OR Fischart_ID = '3' OR Fischart_ID = '4') " +
                                "GROUP BY Angler_ID " +
                                "ORDER BY Gewicht DESC";

                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    try
                    {
                        liste.Add(new TrophyTeilnehmer(Convert.ToInt16(reader["Angler_ID"]), Convert.ToDouble(reader["Gewicht"])));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return liste;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angler_id"></param>
        /// <param name="fischart_id"></param>
        /// <returns></returns>
        public static int AnzahlDerFängeNachNameUndFischart(int angler_id, int fischart_id)
        {
            int count = 0;

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT COUNT(*) Angler_ID FROM Fang WHERE Angler_ID = '" + angler_id + "' AND Fischart_ID = '" + fischart_id + "'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                count = Convert.ToInt32(cmd.ExecuteScalar());

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

            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angler_id"></param>
        /// <returns></returns>
        public static int AnzahlDerFängeNachNameUndFischart_AusHechtZanderBarsch(int angler_id)
        {
            int count = 0;

            string ConnectionString = SQLCollection.GetConnectionString();
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\kasi\documents\visual studio 2015\Projects\Fangliste 2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = ConnectionString;
                string strSQL = "SELECT COUNT(*) Angler_ID FROM Fang WHERE Angler_ID = '" + angler_id + "' AND NOT Fischart_ID = '2' AND NOT Fischart_ID = '3' AND NOT Fischart_ID = '4'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                con.Open();
                count = Convert.ToInt32(cmd.ExecuteScalar());

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

            return count;
        }

    }
}
