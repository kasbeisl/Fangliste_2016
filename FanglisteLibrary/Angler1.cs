using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace FanglisteLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Angler1
    {
        #region Variablen

        int id;
        string name;
        Image bild;

        #endregion

        #region Konstruktor

       /// <summary>
       /// 
       /// </summary>
       /// <param name="id">Die ID des Anglers.</param>
       /// <param name="name">Name des Anglers.</param>
       /// <param name="bild">Das Bild des Anglers.</param>
        public Angler1(int id, string name, Image bild)
        {
            this.id = id;
            this.name = name;
            this.bild = bild;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="liste"></param>
        public Angler1(Angler1 liste)
        {
            this.id = liste.ID;
            this.name = liste.Name;
            this.bild = liste.bild;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="csvZeile"></param>
        public Angler1(string csvZeile)
        {
            string[] array = csvZeile.Split(';');

            this.id = Convert.ToInt16(array[0]);
            this.name = array[1];
            this.bild = null;//array[2];
        }

        /// <summary>
        /// 
        /// </summary>
        public Angler1()
        {
            this.id = 0;
            this.name = "Unbekannt";
            this.bild = null;
        }

        #endregion

        #region Eigenschaften

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            get { return this.id; }
        }

        /// <summary>
        /// Gibt den Name des Anglers zurück, oder setzt den Wert.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Image Bild
        {
            get{ return this.bild; }
            set{ this.bild = value; }
        }

        /// <summary>
        /// Gibt ein StringArray des Angler-Objekt zurück.
        /// </summary>
        public string[] GetList
        {
            get
            {
                string[] liste = new string[3];

                liste[0] = Convert.ToString(this.id);
                liste[0] = this.name;
                liste[1] = this.bild.ToString();

                return liste;
            }
        }

        #endregion

        #region Methoden

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string tr = ";";
            string text = "";

            string[] liste = this.GetList;

            for (int i = 0; i < liste.Length; i++)
            {
                text += liste[i];

                if (i < liste.Length - 1)
                {
                    text += tr;
                }
            }

            return text;
        }

        public static int Get_ID(List<Angler1> anglerliste, string angler)
        {
            int id = 0;

            for (int i = 0; i < anglerliste.Count; i++)
            {
                if (anglerliste[i].Name == angler)
                {
                    id = anglerliste[i].id;
                    break;
                }
            }

            return id;
        }

        public static string Get_Name(List<Angler1> anglerliste, int id)
        {
            string name = "Unbekannt";

            for (int i = 0; i < anglerliste.Count; i++)
            {
                if (anglerliste[i].id == id)
                {
                    name = anglerliste[i].Name;
                    break;
                }
            }

            return name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="csv_Zeile"></param>
        public static Angler1 Parse(string csv_Zeile)
        {
            string[] array = csv_Zeile.Split(';');

            Angler1 angler = new Angler1(array[0]);

            return angler;
        }

        public static Angler1[] Kopiere_Objektarray(Angler1[] alleFischer)
        {
            Angler1[] objekte = new Angler1[alleFischer.Length];

            for (int i = 0; i < alleFischer.Length; i++)
            {
                objekte[i] = alleFischer[i];
            }

            return objekte;
        }

        public static List<Angler1> Kopiere_Objektarray(List<Angler1> alleFischer)
        {
            List<Angler1> objekte = new List<Angler1>();

            for (int i = 0; i < alleFischer.Count; i++)
            {
                objekte.Add(alleFischer[i]);
            }

            return objekte;
        }

        public static List<Angler1> Kopiere_Objektarray_und_um_eins_vergrößern(List<Angler1> alleFischer)
        {
            List<Angler1> objekte = new List<Angler1>();

            for (int i = 0; i < alleFischer.Count; i++)
            {
                objekte.Add(alleFischer[i]);
            }

            return objekte;
        }

        public static List<Angler1> Kopiere_Objektarray_und_um_eins_verkleinern(List<Angler1> alleFischer, int index)
        {
            List<Angler1> objekte = new List<Angler1>();

            int objekt_zahl = 0;

            for (int i = 0; i < alleFischer.Count; i++)
            {
                if (i != index)
                {
                    objekte[objekt_zahl] = alleFischer[i];
                    objekt_zahl++;
                }
            }

            return objekte;
        }

        public static void FischerListeDownload(string http_Adresse, string pfad, string dateiname)
        {
            Network network = new Network();
            Network.Download(http_Adresse, pfad, dateiname);
        }

        public static void FischerListeUpload(string ftp_Adresse, string servername, string passwort, string pfad, string dateiname)
        {
            Network network = new Network(servername, passwort);
            network.Upload(ftp_Adresse, pfad, dateiname);
        }

        public static Angler1[] LeseAlleFischerNamenAus(string pfad, string dateiname)
        {
            Angler1[] angler;
            StreamReader leser1 = new StreamReader(pfad + dateiname);
            StreamReader leser2 = new StreamReader(pfad + dateiname);
            int zeilen = 0;


            while (leser1.Peek() >= 0)
            {
                leser1.ReadLine();
                zeilen++;
            }

            leser1.Close();

            angler = new Angler1[zeilen];

            for (int i = 0; i < zeilen; i++)
            {
                angler[i] = new Angler1(leser2.ReadLine());
            }

            leser2.Close();

            return angler;
        }

        /// <summary>
        /// Lest eine Anglerliste-Datei aus und gibt sie zurück.
        /// </summary>
        /// <param name="pfad"></param>
        /// <param name="dateiname"></param>
        /// <returns></returns>
        public static List<Angler1> LadenAsList(string pfad, string dateiname)
        {
            List<Angler1> anglerliste;
            StreamReader leser1 = new StreamReader(pfad + dateiname);
            anglerliste = new List<Angler1>();

            while (leser1.Peek() >= 0)
            {
                anglerliste.Add(new Angler1(leser1.ReadLine()));
            }

            leser1.Close();

            return anglerliste;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pfad"></param>
        /// <param name="dateiname"></param>
        /// <param name="angler"></param>
        public static void SpeichernAsList(string pfad, string dateiname, List<Angler1> anglerliste)
        {
            //Schreiber-Objekt wird erstellt.
            StreamWriter schreiber = new StreamWriter(pfad + dateiname);

            //Schleife um alle einträge in die Datei zu schreiben.
            for (int i = 0; i < anglerliste.Count; i++)
            {
                //Objekt wird in einen String konvertiert und dann in eine Zeile geschrieben.
                schreiber.WriteLine(anglerliste[i].ToString());
            }

            schreiber.Flush(); //Puffer löschen
            schreiber.Close(); //Schreiber-Objekt schließen
        }

        public static void Speichern(string pfad, string dateiname, Angler1[] alleFischer)
        {
            StreamWriter schreiber = new StreamWriter(pfad + dateiname, false);

            string zeile = "";

            for (int i = 0; i < alleFischer.Length; i++)
            {
                if (alleFischer[i] != null)
                {
                    if (i < alleFischer.Length - 1)
                    {
                        //string vTxt = sicherheit.StringVerschlüsseln(alleFischer[i].Name);
                        //zeile += vTxt + ";";
                        ////Alter Code
                        zeile += alleFischer[i].Name + ";";
                    }
                    else
                    {
                        //string vTxt = sicherheit.StringVerschlüsseln(alleFischer[i].Name);
                        //zeile += vTxt;
                        ////Alter Code
                        zeile += alleFischer[i].Name;
                    }
                }
            }

            schreiber.WriteLine(zeile);

            schreiber.Flush();
            schreiber.Close();
        }

        #endregion
    }
}
