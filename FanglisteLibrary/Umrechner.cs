using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanglisteLibrary
{
    public class Umrechner
    {
        #region Variablen

        #endregion

        #region Konstruktor

        public Umrechner()
        {
        }

        #endregion

        #region Eigenschaften

        #endregion

        #region Methoden

        #region Gewicht
        //g = oz / 0.035274

        //Von Unze
        public static double VonUnze_InGramm(double unze)
        {
            double gramm = 0;

            try
            {
                gramm = unze / 0.035274;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return gramm;
        }

        public static double VonUnze_InKilogramm(double unze)
        {
            double kilogramm = 0;

            try
            {
                kilogramm = (unze / 0.035274) / 1000;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return kilogramm;
        }

        public static double VonUnze_InPfund(double unze)
        {
            double pfund = 0;

            try
            {
                pfund = unze / 15.9999999;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return pfund;
        }

        // Von Gramm
        public static double VonGramm_InUnze(double gramm)
        {
            double unze = 0;

            try
            {
                unze = gramm * 0.035274;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return unze;
        }

        public static double VonGramm_InKilogramm(double gramm)
        {
            double kilogramm = 0;

            try
            {
                kilogramm = gramm / 1000;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return kilogramm;
        }

        public static double VonGramm_InPfund(double gramm)
        {
            double pfund = 0;

            try
            {
                pfund = gramm * 0.0022046;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return pfund;
        }


        //Von Kilogramm
        public static double VonKilogramm_InUnze(double kilogramm)
        {
            double unze = 0;

            try
            {
                unze = (kilogramm * 0.035274) * 1000;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return unze;
        }

        public static double VonKilogramm_InGramm(double kilogramm)
        {
            double gramm = 0;

            try
            {
                gramm = kilogramm * 1000;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return gramm;
        }

        public static double VonKilogramm_InPfund(double kilogramm)
        {
            double pfund = 0;

            try
            {
                pfund = kilogramm * 2.2046;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return pfund;
        }


        //Von Pfund
        public static double VonPfund_InUnze(double pfund)
        {
            double unze = 0;

            try
            {
                unze = pfund * 15.9999999;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return unze;
        }

        public static double VonPfund_InGramm(double pfund)
        {
            double gramm = 0;

            try
            {
                gramm = (pfund / 2.2046) * 1000;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return gramm;
        }

        public static double VonPfund_InKilogramm(double pfund)
        {
            double kilogramm = 0;

            try
            {
                kilogramm = pfund / 2.2046;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return kilogramm;
        }

        #endregion

        #region Wurfgewicht

        public static double VonLBS_InGramm(double lbs)
        {
            double gramm = 0;

            try
            {
                gramm = (lbs * 454) / 16;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return gramm;
        }

        public static double VonGramm_InLBS(double gramm)
        {
            double lbs = 0;

            try
            {
                lbs = (gramm * 16) / 454;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return lbs;
        }

        public static double VonLBS_InGrammEmpfohlen(double lbs)
        {
            double gramm = 0;

            try
            {
                gramm = ((lbs * 454) / 16) * 0.8;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return gramm;
        }

        public static double VonGramm_InLBS_Empfohlen(double gramm)
        {
            double lbs = 0;

            try
            {
                lbs = ((gramm * 16) / 454) * 0.8;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return lbs;
        }

        #endregion

        #region GPS

        public static decimal GradMinuteSekunde_inDezimalgrad(double grad, double minute, double sekunde)
        {
            decimal dezimalgrad = 0;

            dezimalgrad = Convert.ToDecimal((((sekunde / 60) + minute) / 60) + grad);

            return dezimalgrad;
        }

        public static string[] Dezimalgrad_inGradMinuteSekunde(double dezimalgrad)
        {
            string[] ergebnis = new string[3];

            int grad = 0;
            int minute = 0;
            double sekunde = 0;

            grad = Convert.ToInt16(dezimalgrad);
            decimal x = Convert.ToDecimal((dezimalgrad - grad) * 60);
            minute = Convert.ToInt16(Math.Floor(x));
            sekunde = (Convert.ToDouble(x) - minute) * 60;

            ergebnis[0] = grad.ToString();
            ergebnis[1] = minute.ToString();
            ergebnis[2] = sekunde.ToString();

            return ergebnis;
        }

        public static double[] GPS_SplitStringToGradMinutenSekunden(string text)
        {
            double[] gps = new double[3];

            gps[0] = text[1];
            gps[1] = text[4] - text[2];
            gps[2] = text[9] - text[5];

            return gps;
        }

        #endregion

        #region Leistung

        public static double PS_inWatt(double ps)
        {
            double watt = 0;

            watt = (0.73549875 * ps) * 1000;

            return watt;
        }

        public static double PS_inKW(double ps)
        {
            double kw = 0;

            kw = 0.73549875 * ps;

            return kw;
        }

        public static double Watt_inPS(double watt)
        {
            double ps = 0;

            ps = (watt / 1000) / 0.73549875;
                

            return ps;
        }

        public static double Watt_inKW(double watt)
        {
            double kw = 0;

            kw = watt / 1000;


            return kw;
        }

        public static double KW_inPS(double kw)
        {
            double ps = 0;

            ps = kw / 0.73549875;

            return ps;
        }

        public static double KW_inWatt(double kw)
        {
            double watt = 0;

            watt = kw * 1000;

            return watt;
        }

        #endregion

        #region Geld

        #endregion

        #endregion
    }
}
