using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanglisteLibrary
{
    public class Rolle
    {
        #region Variablen

        string name;
        string hersteller;
        string bauart;
        Fassungsvermögen fassungsvermögen;
        DateTime kaufdatum;
        string übersetzung;
        int anzahlKugellager;
        double gewicht;
        double preis;
        string beschreibung;
        string bilddatei;

        #endregion

        #region Konstruktor

        public Rolle()
        {
        }

        #endregion

        #region Eigenschaften

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Hersteller
        {
            get { return this.hersteller; }
            set { this.hersteller = value; }
        }

        public string Bauart
        {
            get { return this.bauart; }
            set { this.bauart = value; }
        }

        public Fassungsvermögen _Fassungsvermögen
        {
            get { return this.fassungsvermögen; }
            set { this.fassungsvermögen = value; }
        }

        public DateTime Kaufdatum
        {
            get { return this.kaufdatum; }
            set { this.kaufdatum = value; }
        }

        public string Übersetzung
        {
            get { return this.übersetzung; }
            set { this.übersetzung = value; }
        }

        public int AnzahlKugellager
        {
            get { return this.anzahlKugellager; }
            set { this.anzahlKugellager = value; }
        }

        public double Gewicht
        {
            get { return this.gewicht; }
            set { this.gewicht = value; }
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

        #endregion

        #region Methoden

        #endregion

        public class Fassungsvermögen
        {
            #region Variablen

            double schnurlänge;
            double schnurstärke;

            #endregion

            #region Konstruktor

            public Fassungsvermögen()
            {
            }

            #endregion

            #region Eigenschaften

            public double Schnurlänge
            {
                get { return this.schnurlänge; }
                set { this.schnurlänge = value; }
            }

            public double Schnurstärke
            {
                get { return this.schnurstärke; }
                set { this.schnurstärke = value; }
            }

            #endregion
        }
    }
}
