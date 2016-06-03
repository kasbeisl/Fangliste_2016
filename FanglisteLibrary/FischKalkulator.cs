using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FanglisteLibrary
{
    public class FischKalkulator
    {
        // Futon'sche Formel zur berechnung des Fisches.

        #region Variablen

        //double korpulenzfaktor;
        //double länge;
        //double gewicht;

        #endregion

        #region Konstruktor

        public FischKalkulator()
        {
        }

        #endregion

        #region Eigenschaften



        #endregion

        #region Methoden

        public static double FischLängeBerechnen(double k, double gewicht)
        {
            double länge = 0;
            double länge_kopie = 0;

            //Länge[cm] = wurzel³ gewicht[g] * 100 / Korpulenzfaktor
            länge_kopie = (gewicht * 100) / k;
            länge = Math.Pow(länge_kopie, 1.0 / 3.0);

            return länge;
        }

        public static double FischGewichtBerechnen(double k, double länge)
        {
            double gewicht = 0;

            //Gewicht[g] = (Länge[cm]³ * Korpulenzfaktor) / 100
            double länge_kopie = Math.Pow(länge, 3);
            gewicht = (länge_kopie * k) / 100;

            return gewicht;
        }

        public static double K_FaktorBerechnen(double gewicht, double länge)
        {
            double k_Faktor = 0;
            double länge_kopie = Math.Pow(länge, 3);

            //K_Faktor = (gewicht[g] * 100 ) / länge [cm]³
            k_Faktor = (gewicht * 100) / länge_kopie;

            return k_Faktor;
        }

        #endregion
    }
}
