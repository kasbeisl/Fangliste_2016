using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FanglisteLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Angler
    {
        #region Variablen

        string name;
        string fotoDateiname;

        #endregion

        #region Konstruktor

       /// <summary>
       /// 
       /// </summary>
       /// <param name="name"></param>
       /// <param name="fotoDateiname"></param>
        public Angler(string name, string fotoDateiname)
        {
            this.name = name;
            this.fotoDateiname = fotoDateiname;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="liste"></param>
        public Angler(Angler liste)
        {
            this.name = liste.Name;
            this.fotoDateiname = liste.fotoDateiname;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="csvZeile"></param>
        public Angler(string csvZeile)
        {
            string[] array = csvZeile.Split(';');

            this.name = array[0];
            this.fotoDateiname = array[1];
        }

        /// <summary>
        /// 
        /// </summary>
        public Angler()
        {
        }

        #endregion

        #region Eigenschaften

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
        public string FotoDateiname
        {
            get{ return this.fotoDateiname; }
            set{ this.fotoDateiname = value; }
        }

        /// <summary>
        /// Gibt ein StringArray des Angler-Objekt zurück.
        /// </summary>
        public string[] GetList
        {
            get
            {
                string[] liste = new string[2];

                liste[0] = this.name;
                liste[1] = this.fotoDateiname;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="csv_Zeile"></param>
        public static Angler Parse(string csv_Zeile)
        {
            string[] array = csv_Zeile.Split(';');

            Angler angler = new Angler(array[0]);

            return angler;
        }

        public static Angler[] Kopiere_Objektarray(Angler[] alleFischer)
        {
            Angler[] objekte = new Angler[alleFischer.Length];

            for (int i = 0; i < alleFischer.Length; i++)
            {
                objekte[i] = alleFischer[i];
            }

            return objekte;
        }

        public static List<Angler> Kopiere_Objektarray(List<Angler> alleFischer)
        {
            List<Angler> objekte = new List<Angler>();

            for (int i = 0; i < alleFischer.Count; i++)
            {
                objekte.Add(alleFischer[i]);
            }

            return objekte;
        }

        public static List<Angler> Kopiere_Objektarray_und_um_eins_vergrößern(List<Angler> alleFischer)
        {
            List<Angler> objekte = new List<Angler>();

            for (int i = 0; i < alleFischer.Count; i++)
            {
                objekte.Add(alleFischer[i]);
            }

            return objekte;
        }

        public static List<Angler> Kopiere_Objektarray_und_um_eins_verkleinern(List<Angler> alleFischer, int index)
        {
            List<Angler> objekte = new List<Angler>();

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

        public static Angler[] LeseAlleFischerNamenAus(string pfad, string dateiname)
        {
            Angler[] angler;
            StreamReader leser1 = new StreamReader(pfad + dateiname);
            StreamReader leser2 = new StreamReader(pfad + dateiname);
            int zeilen = 0;


            while (leser1.Peek() >= 0)
            {
                leser1.ReadLine();
                zeilen++;
            }

            leser1.Close();

            angler = new Angler[zeilen];

            for (int i = 0; i < zeilen; i++)
            {
                angler[i] = new Angler(leser2.ReadLine());
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
        public static List<Angler> LadenAsList(string pfad, string dateiname)
        {
            List<Angler> anglerliste;
            StreamReader leser1 = new StreamReader(pfad + dateiname);
            anglerliste = new List<Angler>();

            while (leser1.Peek() >= 0)
            {
                anglerliste.Add(new Angler(leser1.ReadLine()));
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
        public static void SpeichernAsList(string pfad, string dateiname, List<Angler> anglerliste)
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

        public static void Speichern(string pfad, string dateiname, Angler[] alleFischer)
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
