using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace FanglisteLibrary
{
    public class TrophyTeilnehmer
    {
        #region Membervariablen

        int angler_id;
        double gewicht;
        Image bild;

        #endregion

        #region Konstruktor

        public TrophyTeilnehmer(int angler_ID, double gewicht, Image bild)
        {
            this.angler_id = angler_ID;
            this.gewicht = gewicht;
            this.bild = bild;
        }

        public TrophyTeilnehmer(int angler_ID, double gewicht)
        {
            this.angler_id = angler_ID;
            this.gewicht = gewicht;
            this.bild = null;
        }

        public TrophyTeilnehmer(int angler_ID)
        {
            this.angler_id = angler_ID;
            this.gewicht = 0;
            this.bild = null;
        }

        public TrophyTeilnehmer()
        {
            this.angler_id = 0;
            this.gewicht = 0;
            this.bild = null;
        }

        #endregion

        #region Eigenschaften

        public int Angler_ID
        {
            get { return angler_id; }
        }

        public double Gewicht
        {
            get { return gewicht; }
            set { gewicht = value; }
        }

        public Image Bild
        {
            get { return bild; }
            set { this.bild = value; }
        }

        #endregion

        #region Methoden

        
        #endregion
    }
}
