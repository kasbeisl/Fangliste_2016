using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace FanglisteLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Gewässer
    {
        #region Variablen

        int id;
        string name;

        #endregion

        #region Konstruktor

       public Gewässer(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Gewässer(string csv_Zeile)
        {
            string[] array = csv_Zeile.Split(';');

            this.id = Convert.ToInt16(array[0]);
            this.name = array[1];
            /*this.land = array[1];
            this.bundesland = array[2];
            this.ort = array[3];
            this.plz = Convert.ToInt16(array[4]);
            this.gps = array[5];
            this.fischerverein = array[6];
            this.fischervereinWebseite = array[7];
            this.gewässerWiki = array[8];
            this.maximaletiefe = Convert.ToDouble(array[9]);
            this.fläche = Convert.ToDouble(array[10]);
            this.saison = array[11];
            this.schleppen = array[12];
            this.angelkarten = array[13];
            this.beschreibung = array[14];
            this.bilddatei = array[15];*/
        }

        public Gewässer(Gewässer liste)
        {
            this.id = liste.ID;
            this.name = liste.Name;
            /*this.land = liste.Land;
            this.bundesland = liste.Bundesland;
            this.ort = liste.Ort;
            this.plz = liste.PLZ;
            this.gps = liste.GPS;
            this.fischerverein = liste.Fischerverein;
            this.fischervereinWebseite = liste.FischervereinWebseite;
            this.gewässerWiki = liste.GewässerWiki;
            this.maximaletiefe = liste.Maximaletiefe;
            this.fläche = liste.Fläche;
            this.saison = liste.Saison;
            this.schleppen = liste.Schleppen;
            this.angelkarten = liste._Angelkarten;
            this.beschreibung = liste.Beschreibung;
            this.bilddatei = liste.Bilddatei;*/
        }

        public Gewässer()
        {
            this.id = 0;
            this.name = "";
        }

        #endregion

        #region Eigenschaften

        public int ID
        {
            get { return id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

       /* public string Land
        {
            get { return this.land; }
            set { this.land = value; }
        }

        public string Bundesland
        {
            get { return this.bundesland; }
            set { this.bundesland = value; }
        }

        public string Ort
        {
            get { return this.ort; }
            set { this.ort = value; }
        }

        public int PLZ
        {
            get { return this.plz; }
            set { this.plz = value; }
        }

        public string GPS
        {
            get { return this.gps; }
            set { this.gps = value; }
        }

        public string Fischerverein
        {
            get { return this.fischerverein; }
            set { this.fischerverein = value; }
        }

        public string FischervereinWebseite
        {
            get { return this.fischervereinWebseite; }
            set { this.fischervereinWebseite = value; }
        }

        public string GewässerWiki
        {
            get { return this.gewässerWiki; }
            set { this.gewässerWiki = value; }
        }

        public double Maximaletiefe
        {
            get { return this.maximaletiefe; }
            set { this.maximaletiefe = value; }
        }

        public double Fläche
        {
            get { return this.fläche; }
            set { this.fläche = value; }
        }

        public string Saison
        {
            get { return this.saison; }
            set { this.saison = value; }
        }

        public string Schleppen
        {
            get { return this.schleppen; }
            set { this.schleppen = value; }
        }

        public string _Angelkarten
        {
            get { return this.angelkarten; }
            set { this.angelkarten = value; }
        }

        public string Bilddatei
        {
            get { return this.bilddatei; }
            set { this.bilddatei = value; }
        }*/

        public string[] GetList
        {
            get
            {
                string[] liste = new string[2];

                liste[0] = Convert.ToString(this.id);
                liste[1] = this.name;
                //liste[1] = this.beschreibung;
                /*liste[1] = this.land;
                liste[2] = this.bundesland;
                liste[3] = this.ort;
                liste[4] = Convert.ToString(this.plz);
                liste[5] = this.gps;
                liste[6] = this.fischerverein;
                liste[7] = this.fischervereinWebseite;
                liste[8] = this.gewässerWiki;
                liste[9] = Convert.ToString(this.maximaletiefe);
                liste[10] = Convert.ToString(this.fläche);
                liste[11] = this.saison;
                liste[12] = this.schleppen;
                liste[13] = this.angelkarten;
                
                liste[15] = this.bilddatei;*/

                return liste;
            }
        }

        #endregion

        #region Methoden

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

        public static int Get_ID(List<Gewässer> gewässerliste, string gewässer)
        {
            int id = 0;

            for (int i = 0; i < gewässerliste.Count; i++)
            {
                if (gewässerliste[i].Name == gewässer)
                {
                    id = gewässerliste[i].id;
                    break;
                }
            }

            return id;
        }

        public static string Get_Name(List<Gewässer> gewässerliste, int id)
        {
            string name = "";

            for (int i = 0; i < gewässerliste.Count; i++)
            {
                if (gewässerliste[i].id == id)
                {
                    name = gewässerliste[i].Name;
                    break;
                }
            }

            return name;
        }

        public static void Speichere_Gewässerliste(List<Gewässer> gewässerliste, string pfad, string dateiname)
        {
            StreamWriter schreiber = new StreamWriter(pfad + dateiname);

            for (int i = 0; i < gewässerliste.Count; i++)
            {
                schreiber.WriteLine(gewässerliste[i].ToString());
            }

            schreiber.Flush();
            schreiber.Close();
        }

        public static List<Gewässer> Lese_Gewässerliste_aus(string pfad, string dateiname)
        {
            List<Gewässer> gewässerliste = new List<Gewässer>();
            StreamReader leser = new StreamReader(pfad + dateiname);

            while (leser.Peek() >= 0)
            {
                gewässerliste.Add(new Gewässer(leser.ReadLine()));
            }

            leser.Close();

            return gewässerliste;

        }

        public static List<Gewässer> Kopiere_Objektarray(List<Gewässer> gewässerliste)
        {
            List<Gewässer> objekte = new List<Gewässer>();

            for (int i = 0; i < gewässerliste.Count; i++)
            {
                objekte.Add(new Gewässer(gewässerliste[i]));
            }

            return objekte;
        }

        public static List<Gewässer> Kopiere_Objektarray_und_um_eins_vergrößern(List<Gewässer> gewässerliste)
        {
            List<Gewässer> objekte = new List<Gewässer>();

            for (int i = 0; i < gewässerliste.Count; i++)
            {
                objekte.Add(new Gewässer(gewässerliste[i]));
            }

            return objekte;
        }

        public static List<Gewässer> Kopiere_Objektarray_und_um_eins_verkleinern(List<Gewässer> gewässerliste, int index)
        {
            List<Gewässer> objekte = new List<Gewässer>();

            for (int i = 0; i < gewässerliste.Count; i++)
            {
                if (i != index)
                {
                    objekte.Add(new Gewässer(gewässerliste[i]));
                }
            }

            return objekte;
        }

        #endregion
    }
}
