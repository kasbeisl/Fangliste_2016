using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanglisteLibrary
{
    public class Fanggerät
    {
        #region Variablen

        string name;
        Rute rute;
        Rolle rolle;
        Schnur schnur;
        string beschreibung;
        string bilddatei;
        string verwendungszweck;
        double gesamtpreis;

        #endregion

        #region Konstruktor

        public Fanggerät()
        {
        }

        #endregion

        #region Eigenschaften

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Rute _Rute
        {
            get { return this.rute; }
            set { this.rute = value; }
        }

        public Rolle _Rolle
        {
            get { return this.rolle; }
            set { this.rolle = value; }
        }

        public Schnur _Schnur
        {
            get { return this.schnur; }
            set { this.schnur = value; }
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

        public string Verwendungszweck
        {
            get { return this.verwendungszweck; }
            set { this.verwendungszweck = value; }
        }

        public double GesamtPreis
        {
            get { return this.gesamtpreis; }
            set { this.gesamtpreis = value; }
        }

        #endregion

        #region Methoden

        #endregion
    }
}
