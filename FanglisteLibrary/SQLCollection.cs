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
        /// <summary>
        /// Gibt den ConnectionString der Datenbank zurück.
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+path+@"\GitHub\Fangliste_2016\Fangliste 2016\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
        }

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

        public static void DeleteTabel(string tabelle, string id)
        {
            try
            {
                string ConnectionString = SQLCollection.GetConnectionString();
                //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+System.IO.Directory.GetCurrentDirectory()+@"\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";

                using (var sc = new SqlConnection(ConnectionString))
                using (var cmd = sc.CreateCommand())
                {
                    sc.Open();
                    cmd.CommandText = "DELETE FROM @tabelle WHERE @id" ;
                    cmd.Parameters.AddWithValue("@tabelle", tabelle);
                    cmd.Parameters.AddWithValue("@id", id);
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
    }
}
