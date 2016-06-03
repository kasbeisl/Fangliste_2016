using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FanglisteLibrary
{
    // Information
    // Entwickler: Kastberger Ferdinand
    // Copyright 2015

    /// <summary>
    /// Ist eine Klasse, die verschiedene Funktionen und Eigenschaften zur verfügung stellt, um
    /// eine Fangliste zu erstellen.
    /// </summary>
    public class Fangliste
    {
        #region Variablen

        int id;
        string name;
        string fischart;
        double größe;
        double gewicht;
        string gewässer;
        DateTime datum;
        DateTime uhrzeit;
        string angelplatz;
        string köder;
        double lufttemperatur;
        string wetter;
        double tiefe;
        bool zurückgesetzt;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Initalisiert eine neue Instanz der Fangliste-Klasse mit übergabe aller Variablen.
        /// </summary>
        /// <param name="id">ID des Fangs.</param>
        /// <param name="name">Name des Anglers.</param>
        /// <param name="fischart"></param>
        /// <param name="größe">Länge in cm.</param>
        /// <param name="gewicht">in cm.</param>
        /// <param name="gewässer"></param>
        /// <param name="datum"></param>
        /// <param name="uhrzeit"></param>
        /// <param name="angelplatz"></param>
        /// <param name="köder"></param>
        /// <param name="tiefe">in m.</param>
        /// <param name="temperaturLuft">in C°</param>
        /// <param name="wetter"></param>
        public Fangliste(int id, string name, string fischart, double größe,
                         double gewicht, string gewässer, DateTime datum,
                         DateTime uhrzeit, string angelplatz, string köder,
                         double tiefe, double temperaturLuft, string wetter, bool zurückgesetzt)
        {
            this.id = id;
            this.name = name;
            this.fischart = fischart;
            this.größe = größe;
            this.gewicht = gewicht;
            this.gewässer = gewässer;
            this.datum = datum;
            this.uhrzeit = uhrzeit;
            this.angelplatz = angelplatz;
            this.köder = köder;
            this.tiefe = tiefe;
            this.lufttemperatur = temperaturLuft;
            this.wetter = wetter;
            this.zurückgesetzt = zurückgesetzt;
        }

        /// <summary>
        /// Initalisiert eine neue Instanz der Fangliste-Klasse mit übergabe einer CSV Zeile.
        /// </summary>
        /// <param name="csv_Zeile">Die ausgelesene CSV Zeile.</param>
        public Fangliste(string csv_Zeile)
        {
            string[] array = csv_Zeile.Split(';');

            this.id = Convert.ToInt16(array[0]);
            this.name = array[1];
            this.fischart = array[2];
            this.größe = Convert.ToDouble(array[3]);
            this.gewicht = Convert.ToDouble(array[4]);
            this.gewässer = array[5];
            this.datum = Convert.ToDateTime(array[6]);
            this.uhrzeit = Convert.ToDateTime(array[7]);
            this.angelplatz = array[8];
            this.köder = array[9];
            this.tiefe = Convert.ToDouble(array[10]);
            this.lufttemperatur = Convert.ToDouble(array[11]);
            this.wetter = array[12];
            this.zurückgesetzt = Convert.ToBoolean(array[13]);
        }

        /// <summary>
        /// Initalisiert eine neue Instanz der Fangliste-Klasse mit übergabe eines Fanglisten-Objekts.
        /// </summary>
        /// <param name="liste">Fanglisten-Objekt</param>
        public Fangliste(Fangliste liste)
        {
            this.id = liste.ID;
            this.name = liste.Name;
            this.fischart = liste.Fischart;
            this.größe = liste.Größe;
            this.gewicht = liste.Gewicht;
            this.gewässer = liste.Gewässer;
            this.datum = liste.Datum;
            this.uhrzeit = liste.Uhrzeit;
            this.angelplatz = liste.Platzbesch;
            this.köder = liste.Köderbeschr;
            this.tiefe = liste.Tiefe;
            this.lufttemperatur = liste.Lufttemperatur;
            this.wetter = liste.Wetter;
            this.zurückgesetzt = liste.Zurückgesetzt;
        }

        /// <summary>
        /// Initalisiert eine neue leer Instanz der Fangliste-Klasse.
        /// </summary>
        public Fangliste()
        {
        }

        #endregion

        #region Eigenschaften

        /// <summary>
        /// Gibt die ID des Fangs zurück, oder setzt den Wert.
        /// </summary>
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
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
        /// Gibt die Fischart zurück, oder setzt den Wert.
        /// </summary>
        public string Fischart
        {
            get
            {
                return this.fischart;
            }
            set
            {
                string text = value;
                if (!Char.IsUpper(text[0]))
                {
                    throw new ArgumentException("Erster Buchstabe der Fischart muss groß sein");
                }
                this.fischart = value;
            }
        }

        /// <summary>
        /// Gibt die Größe zurück, oder setzt den Wert.
        /// </summary>
        public double Größe
        {
            get
            {
                return this.größe;
            }
            set
            {
                //if (value > 200)
                //{
                //    throw new ArgumentException("Unrealistische Größe");
                //}
                this.größe = value;
            }
        }

        /// <summary>
        /// Gibt das Gewicht zurück, oder setzt den Wert.
        /// </summary>
        public double Gewicht
        {
            get
            {
                return this.gewicht;
            }
            set
            {
                if (value > 200)
                {
                    throw new ArgumentException("Unrealistisches Gewicht");
                }
                this.gewicht = value;
            }
        }

        /// <summary>
        /// Gibt den Gewässername zurück, oder setzt den Wert.
        /// </summary>
        public string Gewässer
        {
            get
            {
                return this.gewässer;
            }
            set
            {
                string text = value;
                if (!Char.IsUpper(text[0]))
                {
                    throw new ArgumentException("Erster Buchstabe des Gewässers muss groß sein");
                }
                this.gewässer = value;
            }
        }

        /// <summary>
        /// Gibt das Datum zurück, oder setzt den Wert.
        /// </summary>
        public DateTime Datum
        {
            get
            {
                return this.datum;
            }
            set
            {
                if (value.Date > DateTime.Today)
                {
                    throw new ArgumentException("Keine Fänge in der Zukunft möglich");
                }
                this.datum = value;
            }
        }

        /// <summary>
        /// Gibt die Uhrzeit zurück, oder setzt den Wert.
        /// </summary>
        public DateTime Uhrzeit
        {
            get
            {
                return this.uhrzeit;
            }
            set
            {
                this.uhrzeit = value;
            }
        }

        /// <summary>
        /// Gibt den Name des Angelplatzes zurück, oder setzt den Wert.
        /// </summary>
        public string Platzbesch
        {
            get
            {
                return this.angelplatz;
            }
            set
            {
                string text = value;
                if (!Char.IsUpper(text[0]))
                {
                    throw new ArgumentException("Erster Buchstabe des Platzes muss groß sein");
                }
                this.angelplatz = value;
            }
        }

        /// <summary>
        /// Gibt die Köderbeschreibung zurück, oder setzt den Wert.
        /// </summary>
        public string Köderbeschr
        {
            get
            {
                return this.köder;
            }
            set
            {
                string text = value;
                if (!Char.IsUpper(text[0]))
                {
                    throw new ArgumentException("Erster Buchstabe des Köders muss groß sein");
                }
                this.köder = value;
            }
        }

        /// <summary>
        /// Gibt die Tiefe zurück, oder setzt den Wert.
        /// </summary>
        public double Tiefe
        {
            get
            {
                return this.tiefe;
            }
            set
            {
                if (value > 100)
                {
                    throw new ArgumentException("Unrealistische Tiefe");
                }
                this.tiefe = value;
            }
        }

        /// <summary>
        /// Gibt die Lufttemperatur zurück, oder setzt den Wert.
        /// </summary>
        public double Lufttemperatur
        {
            get
            {
                return this.lufttemperatur;
            }
            set
            {
                if (value > 60 && value < -20)
                {
                    throw new ArgumentException("Unrealistische Temperatur");
                }
                this.lufttemperatur = value;
            }
        }

        /// <summary>
        /// Gibt das Wetter zurück, oder setzt den Wert.
        /// </summary>
        public string Wetter
        {
            get
            {
                return this.wetter;
            }
            set
            {
                this.wetter = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Zurückgesetzt
        {
            get { return this.zurückgesetzt; }
            set { this.zurückgesetzt = value; }
        }

        /// <summary>
        /// Gibt die Uhrzeit als String zurück, oder setzt den Wert.
        /// </summary>
        public string String_Uhrzeit
        {
            get
            {
                return this.uhrzeit.ToShortTimeString();
            }

        }

        /// <summary>
        /// Gibt das Datum als String zurück, oder setzt den Wert.
        /// </summary>
        public string String_Datum
        {
            get
            {
                return this.datum.ToShortDateString();
            }
        }

        /// <summary>
        /// Gibt ein StringArray der Fangliste zurück.
        /// </summary>
        public string[] GetList
        {
            get
            {
                string[] liste = new string[14];

                liste[0] = Convert.ToString(this.id);
                liste[1] = this.name;
                liste[2] = this.fischart;
                liste[3] = Convert.ToString(this.größe);
                liste[4] = Convert.ToString(this.gewicht);
                liste[5] = this.gewässer;
                liste[6] = this.datum.ToShortDateString();
                liste[7] = this.uhrzeit.ToShortTimeString();
                liste[8] = this.angelplatz;
                liste[9] = this.köder;
                liste[10] = Convert.ToString(this.tiefe);
                liste[11] = Convert.ToString(this.lufttemperatur);
                liste[12] = this.wetter;
                liste[13] = this.zurückgesetzt.ToString();


                return liste;
            }
        }

        public string[] GetListToDraw
        {
            get
            {
                string[] liste = new string[12];

                liste[0] = this.name;
                liste[1] = this.fischart;
                liste[2] = Convert.ToString(this.größe);
                liste[3] = Convert.ToString(this.gewicht);
                liste[4] = this.gewässer;
                liste[5] = this.datum.ToShortDateString();
                liste[6] = this.uhrzeit.ToShortTimeString();
                liste[7] = this.angelplatz;
                liste[8] = this.köder;
                liste[9] = Convert.ToString(this.tiefe);
                liste[10] = Convert.ToString(this.lufttemperatur);
                liste[11] = this.wetter;
                //liste[12] = this.zurückgesetzt.ToString();

                return liste;
            }
        }

        /// <summary>
        /// Gibt eine Liste für die Hitparade zurück. (Nur Hecht, Barsch und Zander)
        /// </summary>
        public string[] Get_Hitparaden_List_Hecht_Zander_Barsch
        {
            get
            {
                string[] liste = new string[] { this.name, Convert.ToString(this.Größe), Convert.ToString(this.Gewicht), this.Gewässer, this.datum.ToShortDateString() };

                return liste;
            }
        }

        /// <summary>
        /// Gibt eine Liste für die Hitparade zurück. (Alle Fischarten aus Hecht, Zander und Barsch)
        /// </summary>
        public string[] Get_Hitparaden_List_Andere
        {
            get
            {
                string[] liste = new string[] { this.name, Convert.ToString(this.Größe), Convert.ToString(this.Gewicht), this.Gewässer, this.datum.ToShortDateString(), this.fischart };

                return liste;
            }
        }

        /// <summary>
        /// Gibt die Persönliche Fangliste zurück.
        /// </summary>
        public string[] Get_Persönliche_List
        {
            get
            {
                string[] liste = new string[11];

                liste[0] = this.fischart;
                liste[1] = Convert.ToString(this.größe);
                liste[2] = Convert.ToString(this.gewicht);
                liste[3] = this.gewässer;
                liste[4] = this.datum.ToShortDateString();
                liste[5] = this.uhrzeit.ToShortTimeString();
                liste[6] = this.angelplatz;
                liste[7] = this.köder;
                liste[8] = Convert.ToString(this.tiefe);
                liste[9] = Convert.ToString(this.lufttemperatur);
                liste[10] = this.wetter;


                return liste;
            }
        }

        #endregion

        #region Methoden

        /// <summary>
        /// Gibt einen String des Fangs zurück.
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

                if (i < liste.Length-1)
                {
                    text += tr;
                }
            }

            return text;
        }

        private static bool CheckExistID(List<Fangliste> fangliste, int id)
        {
            bool exist = false;

            for (int i = 0; i < fangliste.Count; i++)
            {
                if (fangliste[i].ID == id)
                {
                    exist = true;
                }
            }

            return exist;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fangliste"></param>
        /// <returns></returns>
        public static int GetNewID(List<Fangliste> fangliste)
        {
            int id = 0;

            if ((fangliste != null) && (fangliste.Count != 0))
            {
                id = fangliste[fangliste.Count - 1].ID;
                id++;
            }

            while (CheckExistID(fangliste, id))
	        {
	            id++;
	        }

            return id;
        }

        /// <summary>
        /// Überprüft ob die Fischart gültig ist.
        /// </summary>
        /// <param name="fischart"></param>
        /// <returns></returns>
        public bool IstFischartGültig(string fischart)
        {
            bool exist = false; //Variable ob Fischart gültig ist.
            switch (fischart)
            {
                case "Hecht": exist = true; break;
                case "Zander": exist = true; break;
                case "Barsch": exist = true; break;
                case "Äsche": exist = true; break;
                case "Bachforelle": exist = true; break;
                case "Bachsaibling": exist = true; break;
                case "Huchen": exist = true; break;
                case "Regenbogenforelle": exist = true; break;
                case "Reinanke": exist = true; break;
                case "Seeforelle": exist = true; break;
                case "Seesaibling": exist = true; break;
                case "Karpfen": exist = true; break;
                case "Barbe": exist = true; break;
                case "Brachse": exist = true; break;
                case "Stör": exist = true; break;
                case "Rapfen": exist = true; break;
                case "Schleie": exist = true; break;
                case "Wels": exist = true; break;
                case "Aal": exist = true; break;
                case "Amur": exist = true; break;
                case "Silberkarpfen": exist = true; break;

                default: break;
            }

            return exist;
        }

        /// <summary>
        /// Schreibt eine Fangliste in die CSV Datei.
        /// </summary>
        /// <param name="aktuelle_Fangliste"></param>
        /// <param name="pfad"></param>
        /// <param name="dateiname"></param>
        public static void SpeichereAsArrayObjekt(Fangliste[] aktuelle_Fangliste, string pfad, string dateiname)
        {
            StreamWriter schreiber = new StreamWriter(pfad + dateiname);

            for (int i = 0; i < aktuelle_Fangliste.Length; i++)
            {
                schreiber.WriteLine(aktuelle_Fangliste[i].ToString());
            }

            schreiber.Flush();
            schreiber.Close();      
        }

        /// <summary>
        /// Lest eine Fanglisten-Datei aus und gibt sie zurück.
        /// </summary>
        /// <param name="pfad"></param>
        /// <param name="dateiname"></param>
        /// <returns></returns>
        public static List<Fangliste> LadenAsList(string pfad, string dateiname)
        {
            List<Fangliste> fangliste;
            StreamReader leser1 = new StreamReader(pfad + dateiname);
            fangliste = new List<Fangliste>();

            while (leser1.Peek() >= 0)
            {
                fangliste.Add(new Fangliste(leser1.ReadLine()));
            }

            leser1.Close();

            return fangliste;
        }

        /// <summary>
        /// Schreibt eine Fangliste in die CSV Datei.
        /// </summary>
        /// <param name="fangliste"></param>
        /// <param name="pfad"></param>
        /// <param name="dateiname"></param>
        public static void SpeichernAsList(List<Fangliste> fangliste, string pfad, string dateiname)
        {
            //Schreiber-Objekt wird erstellt.
            StreamWriter schreiber = new StreamWriter(pfad + dateiname);

            //Schleife um alle einträge in die Datei zu schreiben.
            for (int i = 0; i < fangliste.Count; i++)
            {
                //Objekt wird in einen String konvertiert und dann in eine Zeile geschrieben.
                schreiber.WriteLine(fangliste[i].ToString());
            }

            schreiber.Flush(); //Puffer löschen
            schreiber.Close(); //Schreiber-Objekt schließen
        }

        /// <summary>
        /// Lest eine Fanglisten-Datei aus und gibt sie zurück.
        /// </summary>
        /// <param name="pfad"></param>
        /// <param name="dateiname"></param>
        /// <returns></returns>
        public static Fangliste[] LadenAsArrayObjekt(string pfad, string dateiname)
        {
            Fangliste[] alle_Fänge;
            StreamReader leser1 = new StreamReader(pfad + dateiname);
            StreamReader leser2 = new StreamReader(pfad + dateiname);
            int zeilen = 0;
            

            while (leser1.Peek() >= 0)
            {
                leser1.ReadLine();
                zeilen++;
            }

            leser1.Close();

            alle_Fänge = new Fangliste[zeilen];

            for (int i = 0; i < zeilen; i++)
            {
                alle_Fänge[i] = new Fangliste(leser2.ReadLine());
            }

            leser2.Close();

            return alle_Fänge;
        }

        /// <summary>
        /// Kopiert ein Fanglisten-Objekt und gibt es zurück.
        /// </summary>
        /// <param name="fangliste"></param>
        /// <returns></returns>
        public static List<Fangliste> Kopiere_Objektarray(List<Fangliste> fangliste)
        {
            List<Fangliste> objekte = new List<Fangliste>();

            for (int i = 0; i < fangliste.Count; i++)
            {
                objekte.Add(new Fangliste(fangliste[i]));
            }

            return objekte;
        }

        public static List<Fangliste> Kopiere_ObjektarrayAslist(List<Fangliste> fangliste)
        {
            List<Fangliste> objekte = new List<Fangliste>();

            for (int i = 0; i < fangliste.Count; i++)
            {
                objekte.Add(new Fangliste(fangliste[i]));
            }

            return objekte;
        }

        /// <summary>
        /// Kopiert ein Fanglisten-Objekt, vergrößert das Objekt um eins und gibt es zurück.
        /// </summary>
        /// <param name="alleFänge"></param>
        /// <returns></returns>
        public static List<Fangliste> Kopiere_Objektarray_und_um_eins_vergrößern(List<Fangliste> alleFänge)
        {
            List<Fangliste> objekte = new List<Fangliste>();

            for (int i = 0; i < alleFänge.Count; i++)
            {
                objekte.Add(new Fangliste(alleFänge[i]));
            }

            return objekte;
        }

        /// <summary>
        /// Kopiert ein Fanglisten-Objekt, verkleinert es um eins und gibt es zurück.
        /// </summary>
        /// <param name="alleFänge"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static List<Fangliste> Kopiere_Objektarray_und_um_eins_verkleinern(List<Fangliste> alleFänge, int index)
        {
            List<Fangliste> objekte = new List<Fangliste>();

            for (int i = 0; i < alleFänge.Count; i++)
            {
                if (i != index)
                {
                    objekte.Add(new Fangliste(alleFänge[i]));
                }
            }

            return objekte;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fischart"></param>
        /// <param name="alleFänge"></param>
        /// <returns></returns>
        public static List<Fangliste> Spezifische_Fischart_Liste(string fischart, List<Fangliste> alleFänge)
        {
            List<Fangliste> nach_Länge = Fangliste.SortiereNachLänge(alleFänge);
            List<Fangliste> nach_Größe = Fangliste.SortiereNachGewicht(nach_Länge);
            List<Fangliste> spez_Fischart = new List<Fangliste>();
            List<Fangliste> spez_Fischart_Datum = new List<Fangliste>();

            for (int i = 0; i < nach_Größe.Count; i++)
            {
                if (nach_Größe[i].Fischart == fischart)
                {
                    spez_Fischart.Add(nach_Größe[i]);
                }
            }

            for (int i = 0; i < spez_Fischart.Count; i++)
            {
                spez_Fischart_Datum.Add(spez_Fischart[i]);
            }

            try
            {
                for (int i = 0; i < spez_Fischart.Count; i++)
                {
                    if (i + 2 <= spez_Fischart.Count)
                    {
                        if (spez_Fischart_Datum[i].Gewicht == spez_Fischart[i + 1].Gewicht)
                        {
                            if (spez_Fischart_Datum[i + 1].Größe >= spez_Fischart[i].Größe)
                            {
                                if (spez_Fischart_Datum[i + 1].Datum < spez_Fischart[i].Datum)
                                {
                                    spez_Fischart_Datum[i] = spez_Fischart[i + 1];
                                    spez_Fischart_Datum[i + 1] = spez_Fischart[i];
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            

            return spez_Fischart_Datum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alleFänge"></param>
        /// <returns></returns>
        public static List<Fangliste> Andere_Fischarten_Liste(List<Fangliste> alleFänge)
        {
            List<Fangliste> nach_Länge = Fangliste.SortiereNachLänge(alleFänge);
            List<Fangliste> nach_Größe = Fangliste.SortiereNachGewicht(nach_Länge);
            List<Fangliste> spez_Fischart = new List<Fangliste>();

            for (int i = 0; i < nach_Größe.Count; i++)
            {
                if ((nach_Größe[i].fischart != "Hecht") && (nach_Größe[i].fischart != "Zander") && (nach_Größe[i].fischart != "Barsch"))
                {
                    spez_Fischart.Add(nach_Größe[i]);
                }
            }

            return spez_Fischart;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alleFänge"></param>
        /// <param name="auswahl"></param>
        /// <returns></returns>
        public static List<Fangliste> Andere_Fischarten_Liste(List<Fangliste> alleFänge, string[] auswahl)
        {
            List<Fangliste> nach_Länge = Fangliste.SortiereNachLänge(alleFänge);
            List<Fangliste> nach_Größe = Fangliste.SortiereNachGewicht(nach_Länge);
            List<Fangliste> spez_Fischart = new List<Fangliste>();

            for (int i = 0; i < nach_Größe.Count; i++)
            {
                if ((nach_Größe[i].fischart != auswahl[0]) && (nach_Größe[i].fischart != auswahl[1]) && (nach_Größe[i].fischart != auswahl[2]))
                {
                    spez_Fischart.Add(nach_Größe[i]);
                }
            }

            return spez_Fischart;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alleFänge"></param>
        /// <returns></returns>
        public static List<Fangliste> Fangliste_je_jahr(List<Fangliste> alleFänge)
        {
            List<Fangliste> fänge_je_jahr = new List<Fangliste>();

            if (alleFänge != null)
            {
                for (int i = 0; i < alleFänge.Count; i++)
                {
                    if (alleFänge[i].Datum.Year == DateTime.Now.Year)
                    {
                        fänge_je_jahr.Add(alleFänge[i]);
                    }
                }
            }

            return fänge_je_jahr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alleFänge"></param>
        /// <param name="jahr"></param>
        /// <returns></returns>
        public static List<Fangliste> Fangliste_je_jahr(List<Fangliste> alleFänge, int jahr)
        {
            List<Fangliste> fänge_je_jahr = new List<Fangliste>();

            if (alleFänge != null)
            {
                for (int i = 0; i < alleFänge.Count; i++)
                {
                    if (alleFänge[i].Datum.Year == jahr)
                    {
                        fänge_je_jahr.Add(alleFänge[i]);
                    }
                }
            }

            return fänge_je_jahr;
        }

        public static List<Fangliste> PersönlicheFangliste(List<Fangliste> alleFänge,Angler1 fischer)
        {
            List<Fangliste> persönlicheFangliste = new List<Fangliste>();

            try
            {
                for (int i = 0; i < alleFänge.Count; i++)
                {
                    if (fischer.Name == alleFänge[i].Name)
                    {
                        persönlicheFangliste.Add(alleFänge[i]);
                    }
                }
            }
            catch { }

            return persönlicheFangliste;
        }

        public static List<Fangliste> SortiereNachGewicht(List<Fangliste> alleFänge)
        {

            List<Fangliste> kopie_Objektarray = Kopiere_Objektarray(alleFänge);
            List<Fangliste> kopie2 = Kopiere_Objektarray(alleFänge);
            List<Fangliste> gewicht_Sortiert = new List<Fangliste>();

            for (int i = 0; i < kopie_Objektarray.Count; i++)
            {
                int schwer = 0;

                for (int j = 0; j < kopie_Objektarray.Count; j++)
                {
                    if (kopie_Objektarray[j].Gewicht > kopie_Objektarray[schwer].Gewicht)
                    {
                        schwer = j;
                    }
                }

                gewicht_Sortiert.Add(kopie2[schwer]);
                kopie_Objektarray[schwer].Gewicht = -1;
            }


            return gewicht_Sortiert;
        }

        public static List<Fangliste> SortiereNachLänge(List<Fangliste> alleFänge)
        {
            List<Fangliste> kopie_Objektarray = Kopiere_Objektarray(alleFänge);
            List<Fangliste> kopie2 = Kopiere_Objektarray(alleFänge);
            List<Fangliste> länge_Sortiert = new List<Fangliste>();

            for (int i = 0; i < kopie_Objektarray.Count; i++)
            {
                int größter = 0;

                for (int j = 0; j < kopie_Objektarray.Count; j++)
                {
                    if (kopie_Objektarray[j].Größe > kopie_Objektarray[größter].Größe)
                    {
                        größter = j;
                    }
                }

                länge_Sortiert.Add(kopie2[größter]);
                kopie_Objektarray[größter].Größe = -1;
            }


            return länge_Sortiert;
        }

        public static List<Fangliste> SortiereNachTemperatur(List<Fangliste> alleFänge)
        {
            List<Fangliste> kopie_Objektarray = Kopiere_Objektarray(alleFänge);
            List<Fangliste> kopie2 = Kopiere_Objektarray(alleFänge);
            List<Fangliste> temp_Sortiert = new List<Fangliste>();

            for (int i = 0; i < kopie_Objektarray.Count; i++)
            {
                int kälter = 0;

                for (int j = 0; j < kopie_Objektarray.Count; j++)
                {
                    if (kopie_Objektarray[j].Lufttemperatur > kopie_Objektarray[kälter].Lufttemperatur)
                    {
                        kälter = j;
                    }
                }

                temp_Sortiert[i] = kopie2[kälter];
                kopie_Objektarray[kälter].Lufttemperatur = -1;
            }


            return temp_Sortiert;
        }

        public static List<Fangliste> SortiereNachTiefe(List<Fangliste> alleFänge)
        {
            List<Fangliste> kopie_Objektarray = Kopiere_Objektarray(alleFänge);
            List<Fangliste> kopie2 = Kopiere_Objektarray(alleFänge);
            List<Fangliste> tiefe_Sortiert = new List<Fangliste>();

            for (int i = 0; i < kopie_Objektarray.Count; i++)
            {
                int tiefer = 0;

                for (int j = 0; j < kopie_Objektarray.Count; j++)
                {
                    if (kopie_Objektarray[j].Tiefe > kopie_Objektarray[tiefer].Tiefe)
                    {
                        tiefer = j;
                    }
                }

                tiefe_Sortiert[i] = kopie2[tiefer];
                kopie_Objektarray[tiefer].Tiefe = -1;
            }


            return tiefe_Sortiert;
        }

        public static List<Fangliste> SortiereNachGewässer(List<Fangliste> alleFänge)
        {
            List<Fangliste> kopie_Objektarray = Kopiere_Objektarray(alleFänge);
            List<Fangliste> gewässer_Sortiert = new List<Fangliste>();

            string[] abc = new string[] { "A", "Ä", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "Ö", "P", "Q", "R", "S", "T", "U", "Ü", "V", "W", "X", "Y", "Z" };
            int zähler = 0;

            for (int i = 0; i < abc.Length; i++)
            {
                for (int j = 0; j < kopie_Objektarray.Count; j++)
                {
                    if (abc[i] == kopie_Objektarray[j].Gewässer[0].ToString())
                    {
                        gewässer_Sortiert[zähler] = kopie_Objektarray[j];
                        zähler++;
                    }
                }
            }

            return gewässer_Sortiert;
        }

        public static List<Fangliste> SortiereNachWetter(List<Fangliste> alleFänge)
        {
            List<Fangliste> kopie_Objektarray = Kopiere_Objektarray(alleFänge);
            List<Fangliste> wetter_Sortiert = new List<Fangliste>();

            string[] abc = new string[] { "a", "ä", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "ö", "p", "q", "r", "s", "t", "u", "ü", "v", "w", "x", "y", "z" };
            int zähler = 0;

            for (int i = 0; i < abc.Length; i++)
            {
                for (int j = 0; j < kopie_Objektarray.Count; j++)
                {
                    if (abc[i] == kopie_Objektarray[j].Wetter[0].ToString())
                    {
                        wetter_Sortiert[zähler] = kopie_Objektarray[j];
                        zähler++;
                    }
                }
            }

            return wetter_Sortiert;
        }

        public static List<Fangliste> SortiereNachNamen(List<Fangliste> alleFänge)
        {
            List<Fangliste> kopie_Objektarray = Kopiere_Objektarray(alleFänge);
            List<Fangliste> namen_Sortiert = new List<Fangliste>();

            string[] abc = new string[] { "A", "Ä", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "Ö", "P", "Q", "R", "S", "T", "U", "Ü", "V", "W", "X", "Y", "Z" };
            int zähler = 0;

            for (int i = 0; i < abc.Length; i++)
            {
                for (int j = 0; j < kopie_Objektarray.Count; j++)
                {
                    if (abc[i] == kopie_Objektarray[j].Name[0].ToString())
                    {
                        namen_Sortiert[zähler] = kopie_Objektarray[j];
                        zähler++;
                    }
                }
            }

            return namen_Sortiert;
        }

        public static List<Fangliste> SortiereNachDatum(List<Fangliste> alleFänge)
        {
            List<Fangliste> kopie_Objektarray = Kopiere_Objektarray(alleFänge);
            List<Fangliste> kopie2 = Kopiere_Objektarray(alleFänge);
            List<Fangliste> datum_Sortiert = new List<Fangliste>();

            for (int i = 0; i < kopie_Objektarray.Count; i++)
            {
                int alt = 0;

                for (int j = 0; j < kopie_Objektarray.Count; j++)
                {
                    if (kopie_Objektarray[j].Datum.Date > kopie_Objektarray[alt].Datum.Date)
                    {
                        alt = j;
                    }
                }

                datum_Sortiert[i] = kopie2[alt];
                kopie_Objektarray[alt].Datum = new DateTime(2000, 1, 1);
            }

            return datum_Sortiert;
        }

        public static List<Fangliste> SortiereNachUhrzeit(List<Fangliste> alleFänge)
        {
            List<Fangliste> kopie_Objektarray = Kopiere_Objektarray(alleFänge);
            List<Fangliste> kopie2 = Kopiere_Objektarray(alleFänge);
            List<Fangliste> uhrzeit_Sortiert = new List<Fangliste>();

            for (int i = 0; i < kopie_Objektarray.Count; i++)
            {
                int alt = 0;

                for (int j = 0; j < kopie_Objektarray.Count; j++)
                {
                    if (kopie_Objektarray[j].Uhrzeit > kopie_Objektarray[alt].Uhrzeit)
                    {
                        alt = j;
                    }
                }

                uhrzeit_Sortiert[i] = kopie2[alt];
                kopie_Objektarray[alt].Uhrzeit = new DateTime();
            }

            return uhrzeit_Sortiert;
        }

        public static List<Fangliste> SortiereNachFischart(List<Fangliste> alleFänge)
        {
            List<Fangliste> kopie_Objektarray = Kopiere_Objektarray(alleFänge);
            List<Fangliste> fischart_Sortiert = new List<Fangliste>();

            string[] abc = new string[] { "A", "Ä", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "Ö", "P", "Q", "R", "S", "T", "U", "Ü", "V", "W", "X", "Y", "Z" };
            int zähler = 0;

            for (int i = 0; i < abc.Length; i++)
            {
                for (int j = 0; j < kopie_Objektarray.Count; j++)
                {
                    if (abc[i] == kopie_Objektarray[j].Fischart[0].ToString())
                    {
                        fischart_Sortiert[zähler] = kopie_Objektarray[j];
                        zähler++;
                    }
                }
            }

            return fischart_Sortiert;
        }

        public static List<Fangliste> SortiereNachKöderbeschreibung(List<Fangliste> alleFänge)
        {
            List<Fangliste> kopie_Objektarray = Kopiere_Objektarray(alleFänge);
            List<Fangliste> köderb_Sortiert = new List<Fangliste>();

            string[] abc = new string[] { "A", "Ä", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "Ö", "P", "Q", "R", "S", "T", "U", "Ü", "V", "W", "X", "Y", "Z" };
            int zähler = 0;

            for (int i = 0; i < abc.Length; i++)
            {
                for (int j = 0; j < kopie_Objektarray.Count; j++)
                {
                    if (abc[i] == kopie_Objektarray[j].Köderbeschr[0].ToString())
                    {
                        köderb_Sortiert[zähler] = kopie_Objektarray[j];
                        zähler++;
                    }
                }
            }

            return köderb_Sortiert;
        }

        public static List<Fangliste> SortiereNachPlatzbeschreibung(List<Fangliste> alleFänge)
        {
            List<Fangliste> kopie_Objektarray = Kopiere_Objektarray(alleFänge);
            List<Fangliste> platzb_Sortiert = new List<Fangliste>();

            string[] abc = new string[] { "A", "Ä", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "Ö", "P", "Q", "R", "S", "T", "U", "Ü", "V", "W", "X", "Y", "Z" };
            int zähler = 0;

            for (int i = 0; i < abc.Length; i++)
            {
                for (int j = 0; j < kopie_Objektarray.Count; j++)
                {
                    if (abc[i] == kopie_Objektarray[j].Platzbesch[0].ToString())
                    {
                        platzb_Sortiert[zähler] = kopie_Objektarray[j];
                        zähler++;
                    }
                }
            }

            return platzb_Sortiert;
        }

        /// <summary>
        /// Prüft die Fangliste, ob ein Angler heuer einen Fisch gefangen hat.
        /// </summary>
        /// <param name="aktuelleJahresFänge"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool HeuerEtwasGefangen(List<Fangliste> aktuelleJahresFänge, string name)
        {
            bool heuerEtwasGewangen = false; //Variable ob etwas gefangen wurde.

            string year = Convert.ToString(DateTime.Today.Year); //Aktuelles Jahr.
            string fang_jahr; //Variable für das Jahr des aktuellen Fangs.

            for (int i = 0; i < aktuelleJahresFänge.Count; i++) //Durchläuft die gesamte Fangliste
            {
                if (aktuelleJahresFänge[i].Name == name) //Prüft den Fang, ob der Name mit dem Anglername gleich ist. 
                {
                    fang_jahr = Convert.ToString(aktuelleJahresFänge[i].datum.Year); //Gibt das Datum des Fangs zurück
                    if (fang_jahr == year) //Prüft das Datum
                    {
                        heuerEtwasGewangen = true; //Ja es wurde etwas gefangen.
                        break; //Schleife wird beendet. (Fangliste braucht nicht mehr weiter durchsucht werden.)
                    }
                }
            }

            return heuerEtwasGewangen;
        }

        #endregion
    }
}
