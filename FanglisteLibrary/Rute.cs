using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanglisteLibrary
{
    public class Rute
    {
        #region Variablen

        string name;
        string hersteller;
        string bauart;
        string art;
        double wurfgewichtVon;
        double wurfgewichtBis;
        double länge;
        double transportlänge;
        double gewicht;
        DateTime kaufdatum;
        double preis;
        string beschreibung;
        string bilddatei;

        #endregion

        #region Konstruktor

        public Rute()
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

        public string Art
        {
            get { return this.art; }
            set { this.art = value; }
        }

        public double WurfgewichtVon
        {
            get { return this.wurfgewichtVon; }
            set { this.wurfgewichtVon = value; }
        }

        public double WurfgewichtBis
        {
            get { return this.wurfgewichtBis; }
            set { this.wurfgewichtBis = value; }
        }

        public double Länge
        {
            get { return this.länge; }
            set { this.länge = value; }
        }

        public double Transportlänge
        {
            get { return this.transportlänge; }
            set { this.transportlänge = value; }
        }

        public double Gewicht
        {
            get { return this.gewicht; }
            set { this.gewicht = value; }
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

        #endregion

        #region Methoden

        #endregion
    }
}
