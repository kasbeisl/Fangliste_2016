using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanglisteLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Wind
    {
        /// <summary>
        /// 
        /// </summary>
        public class Windstärke
        {
            #region Variablen

            Windstärken value = Windstärken.Unbekannt;

            /// <summary>
            /// Implementiert einen Satz vordefinierter Windstärke.
            /// 
            /// <param name="WS0_Windstille">Ist die kleinste Stuffe der Windstärke.</param>
            /// </summary>
            public enum Windstärken
            {
                Unbekannt,
                WS0_Windstille,
                WS1_Leichter_Zug,
                WS2_Leichte_Brise,
                WS3_Schwache_Brise,
                WS4_Mäßige_Brise,
                WS5_Frische_Brise,
                WS6_Starker_Wind,
                WS7_Steifer_Wind,
                WS8_Stürmischer_Wind,
                WS9_Sturm,
                WS10_Schwerer_Sturm,
            }

            #endregion

            #region Konstruktor

            /// <summary>
            /// Initalisiert eine neue Instanz der Windstärke-Klasse.
            /// </summary>
            /// <param name="value">Der Wert der Windstärke.</param>
            public Windstärke(Windstärken value)
            {
                this.value = value;
            }

            #endregion

            #region Methoden

            /// <summary>
            /// 
            /// </summary>
            /// <param name="windstärke"></param>
            /// <returns></returns>
            public override string ToString()
            {
                string ws = "";

                switch (this.value)
                {
                    case Windstärken.WS0_Windstille:
                        ws = "Windstille";
                        break;
                    case Windstärken.WS1_Leichter_Zug:
                        ws = "leichter Zug";
                        break;
                    case Windstärken.WS2_Leichte_Brise:
                        ws = "leichte Brise";
                        break;
                    case Windstärken.WS3_Schwache_Brise:
                        ws = "schwache Brise";
                        break;
                    case Windstärken.WS4_Mäßige_Brise:
                        ws = "mäßige Brise";
                        break;
                    case Windstärken.WS5_Frische_Brise:
                        ws = "frische Brise";
                        break;
                    case Windstärken.WS6_Starker_Wind:
                        ws = "starker Wind";
                        break;
                    case Windstärken.WS7_Steifer_Wind:
                        ws = "steifer Wind";
                        break;
                    case Windstärken.WS8_Stürmischer_Wind:
                        ws = "stürmischer Wind";
                        break;
                    case Windstärken.WS9_Sturm:
                        ws = "Sturm";
                        break;
                    case Windstärken.WS10_Schwerer_Sturm:
                        ws = "schwerer Sturm";
                        break;
                    default:
                        break;
                }

                return ws;
            }

            /// <summary>
            /// Gibt eine Liste aller Windstärken zurück.
            /// </summary>
            /// <returns></returns>
            public static string[] GetWindstärkeListe()
            {
                string[] liste = new string[11];

                //WS0_Windstille,
                //WS1_Leichter_Zug,
                //WS2_Leichte_Brise,
                //WS3_Schwache_Brise,
                //WS4_Mäßige_Brise,
                //WS5_Frische_Brise,
                //WS6_Starker_Wind,
                //WS7_Steifer_Wind,
                //WS8_Stürmischer_Wind,
                //WS9_Sturm,
                //WS10_Schwerer_Sturm,

                liste[0] = "Windstille";
                liste[1] = "leichter Zug";
                liste[2] = "leichte Brise";
                liste[3] = "schwache Brise";
                liste[4] = "mäßige Brise";
                liste[5] = "frische Brise";
                liste[6] = "starker Wind";
                liste[7] = "Steifer Wind";
                liste[8] = "Stürmischer Wind";
                liste[9] = "Sturm";
                liste[10] = "Schwerer Sturm";

                return liste;
            }

            #endregion

            #region Eigenschaften

            /// <summary>
            /// Gibt den Wert der Windstärke zurück, oder setzt ihn.
            /// </summary>
            public Windstärken Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        public class Windrichtung
        {
            #region Variablen

            Windrichtungen value = Windrichtungen.Nord;

            /// <summary>
            /// Implementiert einen Satz vordefinierter Windstärke.
            /// 
            /// <param name="WS0_Windstille">Ist die kleinste Stuffe der Windstärke.</param>
            /// </summary>
            public enum Windrichtungen
            {
                Unbekannt,               
                Nord,
                Nordnordost,
                Nordost,
                Ostnordost,
                Ost,
                Ostsüdost,
                Südost,
                Südsüdost,
                Süd,
                Südsüdwest,
                Südwest,
                Westsüdwest,
                West,
                Westnordwest,
                Nordwest,
                Nordnordwest
            }

            #endregion

            #region Konstruktor

            /// <summary>
            /// Initalisiert eine neue Instanz der Windstärke-Klasse.
            /// </summary>
            /// <param name="value">Der Wert der Windstärke.</param>
            public Windrichtung(Windrichtungen value)
            {
                this.value = value;
            }

            #endregion

            #region Methoden

            /// <summary>
            /// 
            /// </summary>
            /// <param name="windstärke"></param>
            /// <returns></returns>
            public override string ToString()
            {
                string ws = "";

                

                return ws;
            }

            /// <summary>
            /// Gibt eine Liste aller Windstärken zurück.
            /// </summary>
            /// <returns></returns>
            public static string[] GetWindstärkeListe()
            {
                string[] liste = new string[11];

                //WS0_Windstille,
                //WS1_Leichter_Zug,
                //WS2_Leichte_Brise,
                //WS3_Schwache_Brise,
                //WS4_Mäßige_Brise,
                //WS5_Frische_Brise,
                //WS6_Starker_Wind,
                //WS7_Steifer_Wind,
                //WS8_Stürmischer_Wind,
                //WS9_Sturm,
                //WS10_Schwerer_Sturm,

                liste[0] = "Windstille";
                liste[1] = "leichter Zug";
                liste[2] = "leichte Brise";
                liste[3] = "schwache Brise";
                liste[4] = "mäßige Brise";
                liste[5] = "frische Brise";
                liste[6] = "starker Wind";
                liste[7] = "Steifer Wind";
                liste[8] = "Stürmischer Wind";
                liste[9] = "Sturm";
                liste[10] = "Schwerer Sturm";

                return liste;
            }

            #endregion

            #region Eigenschaften

            /// <summary>
            /// Gibt den Wert der Windstärke zurück, oder setzt ihn.
            /// </summary>
            public Windrichtungen Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        public class Mondphase
        {
            #region Variablen

            Mondphasen value = Mondphasen.Unbekannt;

            string[] mondphaseListe = new string[] { "Unbekannt", "Nord", "Nordnordost", "Nordost", "Ostnordost",
                                                     "Ost", "Ostsüdost", "Südost", "Südsüdost", "Süd",
                                                     "Südsüdwest", "Südwest", "Westsüdwest", "West",
                                                     "Westnordwest", "Nordwest", "Nordnordwest" };

            /// <summary>
            /// Implementiert einen Satz vordefinierter Mondphasen.
            /// </summary>
            public enum Mondphasen
            {
                Unbekannt,
                Neumond,
                erstesViertel,
                zunehmenderHalbmond,
                zweitesViertel,
                Vollmond,
                drittesViertel,
                abnehmenderHalbmond,
                letztesViertel
            }

            #endregion

            #region Konstruktor

            /// <summary>
            /// Initalisiert eine neue Instanz der Windstärke-Klasse.
            /// </summary>
            /// <param name="value">Der Wert der Windstärke.</param>
            public Mondphase(Mondphasen value)
            {
                this.value = value;
            }

            #endregion

            #region Methoden

            #endregion

            #region Eigenschaften

            /// <summary>
            /// Gibt den Wert der Windstärke zurück, oder setzt ihn.
            /// </summary>
            public Mondphasen Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            /// <summary>
            /// 
            /// </summary>
            public string[] MondphaseListe
            {
                get { return mondphaseListe; }
            }

            #endregion
        }
    }
}
