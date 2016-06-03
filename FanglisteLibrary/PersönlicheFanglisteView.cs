using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;


namespace FanglisteLibrary
{
    // Information
    // Entwickler: Kastberger Ferdinand
    // Copyright 2015

    /// <summary>
    /// Ist eine Klasse, die verschiedene Funktionen und Eigenschaften zur verfügung stellt, um
    /// eine Fangliste zu erstellen.
    /// </summary>
    public class PersönlicheFanglisteView
    {
        #region Variablen

        int fang_ID;
        Image bild;
        string fischart;
        double länge;
        double gewicht;
        string gewässer;
        DateTime datum;
        DateTime uhrzeit;
        string angelplatz;
        string köder;
        double lufttemperatur;
        double wassertemperatur;
        string wetter;
        double tiefe;
        bool zurückgesetzt;
        string kommentar;

        #endregion

        #region Konstruktor


        public PersönlicheFanglisteView(int fang_ID, Image bild, string fischart, double größe,
                         double gewicht, string gewässer, DateTime datum,
                         DateTime uhrzeit, string angelplatz, string köder,
                         double tiefe, double temperaturLuft, double wassertemperatur, string wetter, string kommentar)
        {
            this.fang_ID = fang_ID;
            this.bild = bild;
            this.fischart = fischart;
            this.länge = größe;
            this.gewicht = gewicht;
            this.gewässer = gewässer;
            this.datum = datum;
            this.uhrzeit = uhrzeit;
            this.angelplatz = angelplatz;
            this.köder = köder;
            this.tiefe = tiefe;
            this.lufttemperatur = temperaturLuft;
            this.wassertemperatur = wassertemperatur;
            this.wetter = wetter;
            //this.zurückgesetzt = zurückgesetzt;
            this.kommentar = kommentar;
        }

        public PersönlicheFanglisteView(int fang_ID, string fischart, double größe,
                         double gewicht, string gewässer, DateTime datum,
                         DateTime uhrzeit, string angelplatz, string köder,
                         double tiefe, double temperaturLuft, double wassertemperatur, string wetter, string kommentar)
        {
            this.fang_ID = fang_ID;
            this.bild = null;
            this.fischart = fischart;
            this.länge = größe;
            this.gewicht = gewicht;
            this.gewässer = gewässer;
            this.datum = datum;
            this.uhrzeit = uhrzeit;
            this.angelplatz = angelplatz;
            this.köder = köder;
            this.tiefe = tiefe;
            this.lufttemperatur = temperaturLuft;
            this.wassertemperatur = wassertemperatur;
            this.wetter = wetter;
            //this.zurückgesetzt = zurückgesetzt;
            this.kommentar = kommentar;
        }

        public PersönlicheFanglisteView(PersönlicheFanglisteView liste)
        {
            this.fang_ID = liste.Fang_ID;
            this.bild = liste.Bild;
            this.fischart = liste.Fischart;
            this.länge = liste.Größe;
            this.gewicht = liste.Gewicht;
            this.gewässer = liste.Gewässer;
            this.datum = liste.Datum;
            this.uhrzeit = liste.Uhrzeit;
            this.angelplatz = liste.Platzbesch;
            this.köder = liste.Köderbeschr;
            this.tiefe = liste.Tiefe;
            this.lufttemperatur = liste.Lufttemperatur;
            this.wetter = liste.Wetter;
            //this.zurückgesetzt = liste.Zurückgesetzt;
        }

        public PersönlicheFanglisteView()
        {
        }

        #endregion

        #region Eigenschaften

        public int Fang_ID
        {
            get { return fang_ID; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Image Bild
        {
            get
            {
                return this.bild;
            }

            set
            {
                this.bild = value;
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
                /*int text = value;
                if (!Char.IsUpper(text[0]))
                {
                    throw new ArgumentException("Erster Buchstabe der Fischart muss groß sein");
                }*/
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
                return this.länge;
            }
            set
            {
                //if (value > 200)
                //{
                //    throw new ArgumentException("Unrealistische Größe");
                //}
                this.länge = value;
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
        /// Gibt die ID des Gewässers zurück, oder setzt den Wert.
        /// </summary>
        public string Gewässer
        {
            get
            {
                return this.gewässer;
            }
            set
            {
                /*string text = value;
                if (!Char.IsUpper(text[0]))
                {
                    throw new ArgumentException("Erster Buchstabe des Gewässers muss groß sein");
                }*/
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
        /// Gibt die Wassertemperatur zurück, oder setzt den Wert.
        /// </summary>
        public double Wassertemperatur
        {
            get
            {
                return this.wassertemperatur;
            }
            set
            {
                if (value > 60 && value < -20)
                {
                    throw new ArgumentException("Unrealistische Temperatur");
                }
                this.wassertemperatur = value;
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
        /// Gibt den Kommentar zurück, oder setzt den Wert.
        /// </summary>
        public string Kommentar
        {
            get { return this.kommentar; }
            set { this.kommentar = value; }
        }

        /// <summary>
        /// Gibt ein StringArray der Fangliste zurück.
        /// </summary>
        public string[] GetList
        {
            get
            {
                string[] liste = new string[13];

                liste[0] = this.fischart;
                liste[1] = Convert.ToString(this.länge);
                liste[2] = Convert.ToString(this.gewicht);
                liste[3] = this.gewässer.ToString();
                liste[4] = this.datum.ToShortDateString();
                liste[5] = this.uhrzeit.ToShortTimeString();
                liste[6] = this.angelplatz;
                liste[7] = this.köder;
                liste[8] = Convert.ToString(this.tiefe);
                liste[9] = Convert.ToString(this.lufttemperatur);
                liste[10] = Convert.ToString(this.wassertemperatur);
                liste[11] = this.wetter;
                liste[12] = this.kommentar;


                return liste;
            }
        }

        #endregion

        #region Methoden

        #endregion
    }
}
