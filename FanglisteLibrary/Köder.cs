using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FanglisteLibrary
{
    public class Köder
    {
        #region Variablen

        string name;
        string art;
        string typ;
        string hersteller;
        string farbe;
        string bauform;
        double gewicht;
        double länge;
        DateTime kaufdatum;
        double preis;
        string beschreibung;
        string bilddatei;

        #endregion

        #region Konstruktor

        public Köder(string name, string art, string typ,
                         string hersteller, string farbe, string bauform,
                         double gewicht, double länge, DateTime kaufdatum,
                         double preis, string beschreibung, string bilddatei)
        {
            this.name = name;
            this.art = art;
            this.typ = typ;
            this.hersteller = hersteller;
            this.farbe = farbe;
            this.bauform = bauform;
            this.gewicht = gewicht;
            this.länge = länge;
            this.kaufdatum = kaufdatum;
            this.preis = preis;
            this.beschreibung = beschreibung;
            this.bilddatei = bilddatei;
        }

        public Köder(string csv_Zeile)
        {
            string[] array = csv_Zeile.Split(';');

            this.name = array[0];
            this.hersteller = array[1];
            this.art = array[2];
            this.typ = array[3];
            this.farbe = array[4];
            this.bauform = array[5];
            this.gewicht = Convert.ToDouble(array[6]);
            this.länge = Convert.ToDouble(array[7]);
            this.kaufdatum = Convert.ToDateTime(array[8]);
            this.preis = Convert.ToDouble(array[9]);
            this.beschreibung = array[10];
            this.bilddatei = array[11];
        }

        public Köder(Köder liste)
        {
            this.name = liste.Name;
            this.art = liste.Art;
            this.typ = liste.Typ;
            this.hersteller = liste.Hersteller;
            this.farbe = liste.Farbe;
            this.bauform = liste.Bauform;
            this.gewicht = liste.Gewicht;
            this.länge = liste.Länge;
            this.kaufdatum = liste.Kaufdatum;
            this.preis = liste.Preis;
            this.beschreibung = liste.Beschreibung;
            this.bilddatei = liste.Bilddatei;
        }

        public Köder()
        {
        }

        #endregion

        #region Eigenschaften

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Art
        {
            get { return this.art; }
            set { this.art = value; }
        }

        public string Typ
        {
            get { return this.typ; }
            set { this.typ = value; }
        }

        public string Hersteller
        {
            get { return this.hersteller; }
            set { this.hersteller = value; }
        }

        public string Farbe
        {
            get { return this.farbe; }
            set { this.farbe = value; }
        }

        public string Bauform
        {
            get { return this.bauform; }
            set { this.bauform = value; }
        }

        public double Gewicht
        {
            get { return this.gewicht; }
            set { this.gewicht = value; }
        }

        public double Länge
        {
            get { return this.länge; }
            set { this.länge = value; }
        }

        public DateTime Kaufdatum
        {
            get { return this.kaufdatum; }
            set { this.kaufdatum = value; }
        }

        public double Preis
        {
            get { return this.preis; }
            set { this.preis = value; }
        }

        public string Beschreibung
        {
            get { return this.beschreibung; }
            set { this.beschreibung = value; }
        }

        public string Bilddatei
        {
            get { return this.bilddatei; }
            set { this.bilddatei = value; }
        }

        public string[] GetList
        {
            get
            {
                string[] liste = new string[12];

                liste[0] = this.name;
                liste[1] = this.hersteller;
                liste[2] = this.art;
                liste[3] = this.typ;
                liste[4] = this.farbe;
                liste[5] = this.bauform;
                liste[6] = Convert.ToString(this.gewicht);
                liste[7] = Convert.ToString(this.länge);
                liste[8] = this.kaufdatum.ToShortDateString();
                liste[9] = Convert.ToString(this.preis);
                liste[10] = this.beschreibung;
                liste[11] = this.bilddatei;

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

        public static void Speichere_Fangliste(Köder[] köder, string pfad, string dateiname)
        {
            Sicherheit sicherheit = new Sicherheit();
            StreamWriter schreiber = new StreamWriter(pfad + dateiname);

            for (int i = 0; i < köder.Length; i++)
            {
                string vTxt = sicherheit.StringVerschlüsseln(köder[i].ToString());
                schreiber.WriteLine(vTxt);

                //Alter COde speichert nicht verschlüsselten text
                //schreiber.WriteLine(aktuelle_Fangliste[i].ToString());
            }

            schreiber.Flush();
            schreiber.Close();
        }

        public static Köder[] Lese_Köderliste_aus(string pfad, string dateiname)
        {
            Köder[] köderliste;
            Sicherheit sicherheit = new Sicherheit();
            StreamReader leser1 = new StreamReader(pfad + dateiname);
            StreamReader leser2 = new StreamReader(pfad + dateiname);
            int zeilen = 0;


            while (leser1.Peek() >= 0)
            {
                leser1.ReadLine();
                zeilen++;
            }

            leser1.Close();

            köderliste = new Köder[zeilen];

            for (int i = 0; i < zeilen; i++)
            {
                string vTxt = sicherheit.StringEntschlüsseln(leser2.ReadLine());
                köderliste[i] = new Köder(vTxt);
                //Alter Code lest nicht verschlüsselte Datei aus.
                //alle_Fänge[i] = new Fangliste(leser2.ReadLine());
            }

            leser2.Close();

            return köderliste;

        }

        public static Köder[] Kopiere_Objektarray(Köder[] köderliste)
        {
            Köder[] objekte = new Köder[köderliste.Length];

            for (int i = 0; i < köderliste.Length; i++)
            {
                objekte[i] = new Köder(köderliste[i]);
            }

            return objekte;
        }

        public static Köder[] Kopiere_Objektarray_und_um_eins_vergrößern(Köder[] köderliste)
        {
            Köder[] objekte = new Köder[köderliste.Length + 1];

            for (int i = 0; i < köderliste.Length; i++)
            {
                objekte[i] = new Köder(köderliste[i]);
            }

            return objekte;
        }

        public static Köder[] Kopiere_Objektarray_und_um_eins_verkleinern(Köder[] köderliste, int index)
        {
            Köder[] objekte = new Köder[köderliste.Length - 1];

            int objekt_zahl = 0;

            for (int i = 0; i < köderliste.Length; i++)
            {
                if (i != index)
                {
                    objekte[objekt_zahl] = new Köder(köderliste[i]);
                    objekt_zahl++;
                }
            }

            return objekte;
        }

        public static string[] KunstköderTypen()
        {
            string[] kunstköderTypen = new string[] { "Blinker", "Crankbait", "Darter", "Glider", "Gummifisch", "Jerkbaits", "Pilker", "Popper", "Pullbait", "Shad", "Softjerks", "Spinner", "Spinnerbait", "Swimbait", "Twitchbait", "Twister", "Wobbler", "Sonstige" };

            return kunstköderTypen;
        }

        public static string[] NaturköderTypen()
        {
            string[] naturköderTypen = new string[] { "Fetzenköder", "Kartoffel", "Köderfisch", "Made", "Mais", "Mistwurm", "Muschelfleisch", "Krebsfleisch", "Regenwurm", "Shrimps", "Taumarde", "Teig", "Wattwurm", "Sonstige" };

            return naturköderTypen;
        }

        public static string[] FliegenTypen()
        {
            string[] fliegenTypen = new string[] { "Trockenfliegen", "Nassfliegen", "Nymphen", "Streamer", "Sonstige" };

            return fliegenTypen;
        }

        public static  string[] MontagenSystemeTypen()
        {
            string[] montagenSystemeTypen = new string[] { "Patternoster", "Spinnsystem", "Wobblersystem", "Sonstige" };

            return montagenSystemeTypen;
        }

        public static string[] SonstigeKöderTypen()
        {
            string[] sonstigeKöderTypen = new string[] { "Boilie", "Pellets", "Sonstige" };

            return sonstigeKöderTypen;
        }

        #endregion
    }
}
