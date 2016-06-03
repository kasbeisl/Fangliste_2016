using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanglisteLibrary
{
    public class Schnur
    {
        #region Variablen

        string name;
        string hersteller;
        string typ;
        string farbe;
        double schnurstärke;
        double tragfähigkeit;
        DateTime kaufdatum;
        double preis;
        string beschreibung;
        string bilddatei;

        #endregion

        #region Konstruktor

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

        public string Typ
        {
            get { return this.typ; }
            set { this.typ = value; }
        }

        public string Farbe
        {
            get { return this.farbe; }
            set { this.farbe = value; }
        }

        public double Schnurstärke
        {
            get { return this.schnurstärke; }
            set { this.schnurstärke = value; }
        }

        public double Tragfähigkeit
        {
            get { return this.tragfähigkeit; }
            set { this.tragfähigkeit = value; }
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
