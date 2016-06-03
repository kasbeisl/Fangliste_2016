using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanglisteLibrary
{
    public class Wetter
    {
        #region Variablen

        int zeilen = 10;
        string[] wetterliste;

        #endregion

        #region Konstruktor

        public Wetter()
        {
            wetterliste = new string[zeilen];

            wetterliste[0] = "bewölkt";
            wetterliste[1] = "bewölkt mit starkem Wind";
            wetterliste[2] = "neblig";
            wetterliste[3] = "Regen";
            wetterliste[4] = "regnerisch";
            wetterliste[5] = "Schnee";
            wetterliste[6] = "sonnig";
            wetterliste[7] = "sonnig mit starkem Wind";
            wetterliste[8] = "unbekannt";
            wetterliste[9] = "vor Gewitter";
        }

        #endregion

        #region Eigenschaften

        public string[] Wetterliste
        {
            get
            {
                return this.wetterliste;
            }
            set
            {
                value = this.wetterliste;
            }
        }

        #endregion

        #region Methoden

        #endregion
    }
}
