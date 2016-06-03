using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanglisteLibrary
{
    public class Statistik
    {
        public class Uhrzeit
        {
            #region Varibalen

            List<Fangliste> alleFänge;
            string fischart;
            
            static int anzahl_stunden = 24;
            int anzahl_Fänge_Pro_Std;
            int[] y_Werte;

            #endregion

            #region Konstruktor

            public Uhrzeit(List<Fangliste> alleFänge, string fischart)
            {
                this.alleFänge = alleFänge;
                this.fischart = fischart;

                Y_Werte_Uhrzeit_berechnen();
            }

            #endregion

            #region Eigenschaften

            public int[] Y_Werte
            {
                get
                {
                    return this.y_Werte;
                }
                set
                {
                    this.y_Werte = value;
                }
            }

            #endregion

            #region Methoden

            private void Y_Werte_Uhrzeit_berechnen()
            {
                y_Werte = new int[anzahl_stunden];

                //for (int i = 0; i < anzahl_stunden; i++)
                //{
                //    y_Werte[i] = 0;
                //}

                for (int i = 0; i < anzahl_stunden; i++)
                {
                    anzahl_Fänge_Pro_Std = 0;

                    for (int j = 0; j < this.alleFänge.Count; j++)
                    {
                        if (this.alleFänge[j].Fischart == this.fischart && this.alleFänge[j].Uhrzeit.Hour == i)
                        {
                            anzahl_Fänge_Pro_Std++;
                        }
                    }

                    y_Werte[i] = anzahl_Fänge_Pro_Std;
                }
            }

            #endregion
        }

        public class Datum
        {
            #region Varibalen

            List<Fangliste> alleFänge;
            string fischart;

            static int anzahl_monate = 12;

            int anzahl_Fänge_Pro_Monat;
            int[] y_Werte;

            #endregion

            #region Konstruktor

            public Datum(List<Fangliste> alleFänge, string fischart)
            {
                this.alleFänge = alleFänge;
                this.fischart = fischart;

                Y_Werte_Datum_berechnen();
            }

            #endregion

            #region Eigenschaften

            public int[] Y_Werte
            {
                get
                {
                    return this.y_Werte;
                }
                set
                {
                    this.y_Werte = value;
                }
            }

            #endregion

            #region Methoden

            private void Y_Werte_Datum_berechnen()
            {
                y_Werte = new int[anzahl_monate];            

                for (int i = 1; i < anzahl_monate + 1; i++)
                {
                    anzahl_Fänge_Pro_Monat = 0;

                    for (int j = 0; j < this.alleFänge.Count; j++)
                    {
                        if (this.alleFänge[j].Fischart == this.fischart && this.alleFänge[j].Datum.Month == i)
                        {
                            anzahl_Fänge_Pro_Monat++;
                        }
                    }

                    y_Werte[i - 1] = anzahl_Fänge_Pro_Monat;
                }
            }

            #endregion
        }

        public class Temperatur
        {
            #region Varibalen

            List<Fangliste> alleFänge;
            string fischart;

            static int anzahl_temperatur = 61;

            int anzahl_Fänge_Pro_Temp;
            int[] y_Werte;

            #endregion

            #region Konstruktor

            public Temperatur(List<Fangliste> alleFänge, string fischart)
            {
                this.alleFänge = alleFänge;
                this.fischart = fischart;

                Y_Werte_Temperatur_berechnen();
            }

            #endregion

            #region Eigenschaften

            public int[] Y_Werte
            {
                get
                {
                    return this.y_Werte;
                }
                set
                {
                    this.y_Werte = value;
                }
            }

            #endregion

            #region Methoden

            private void Y_Werte_Temperatur_berechnen()
            {
                y_Werte = new int[anzahl_temperatur];
                double temp = -20;

                for (int i = 0; i < anzahl_temperatur; i++)
                {
                    anzahl_Fänge_Pro_Temp = 0;

                    for (int j = 0; j < this.alleFänge.Count; j++)
                    {
                        if (this.alleFänge[j].Fischart == this.fischart && this.alleFänge[j].Lufttemperatur == temp)
                        {
                            anzahl_Fänge_Pro_Temp++;
                        }
                    }

                    temp++;

                    y_Werte[i] = anzahl_Fänge_Pro_Temp;
                }
            }

            #endregion
        }

        public class Tiefe
        {
            #region Varibalen

            List<Fangliste> alleFänge;
            string fischart;

            static int anzahl_tiefe = 41;

            int anzahl_Fänge_Pro_tiefe;
            int[] y_Werte;

            #endregion

            #region Konstruktor

            public Tiefe(List<Fangliste> alleFänge, string fischart)
            {
                this.alleFänge = alleFänge;
                this.fischart = fischart;

                Y_Werte_Tiefe_berechnen();
            }

            #endregion

            #region Eigenschaften

            public int[] Y_Werte
            {
                get
                {
                    return this.y_Werte;
                }
                set
                {
                    this.y_Werte = value;
                }
            }

            #endregion

            #region Methoden

            private void Y_Werte_Tiefe_berechnen()
            {
                y_Werte = new int[anzahl_tiefe];
                int tiefe = 0;

                for (int i = 0; i < anzahl_tiefe; i++)
                {
                    anzahl_Fänge_Pro_tiefe = 0;

                    for (int j = 0; j < this.alleFänge.Count; j++)
                    {
                        if (this.alleFänge[j].Fischart == this.fischart && this.alleFänge[j].Tiefe == tiefe)
                        {
                            anzahl_Fänge_Pro_tiefe++;
                        }
                    }

                    tiefe++;

                    y_Werte[i] = anzahl_Fänge_Pro_tiefe;
                }
            }

            #endregion
        }

        public class Größe
        {
            #region Varibalen

            List<Fangliste> alleFänge;
            string fischart;

            static int anzahl_größe = 101;

            int anzahl_Fänge_Pro_größe;
            int[] y_Werte;

            #endregion

            #region Konstruktor

            public Größe(List<Fangliste> alleFänge, string fischart)
            {
                this.alleFänge = alleFänge;
                this.fischart = fischart;

                Y_Werte_Größe_berechnen();
            }

            #endregion

            #region Eigenschaften

            public int[] Y_Werte
            {
                get
                {
                    return this.y_Werte;
                }
                set
                {
                    this.y_Werte = value;
                }
            }

            #endregion

            #region Methoden

            private void Y_Werte_Größe_berechnen()
            {
                y_Werte = new int[anzahl_größe];
                int größe = 0;

                for (int i = 0; i < anzahl_größe; i++)
                {
                    anzahl_Fänge_Pro_größe = 0;

                    for (int j = 0; j < this.alleFänge.Count; j++)
                    {
                        if (this.alleFänge[j].Fischart == this.fischart && this.alleFänge[j].Größe == größe)
                        {
                            anzahl_Fänge_Pro_größe++;
                        }
                    }

                    größe++;

                    y_Werte[i] = anzahl_Fänge_Pro_größe;
                }
            }

            #endregion
        }

        public class Gewicht
        {
            #region Varibalen

            List<Fangliste> alleFänge;
            string fischart;

            static int anzahl_gewicht = 11;

            int anzahl_Fänge_Pro_Gewicht;
            int[] y_Werte;

            #endregion

            #region Konstruktor

            public Gewicht(List<Fangliste> alleFänge, string fischart)
            {
                this.alleFänge = alleFänge;
                this.fischart = fischart;

                Y_Werte_Gewicht_berechnen();
            }

            #endregion

            #region Eigenschaften

            public int[] Y_Werte
            {
                get
                {
                    return this.y_Werte;
                }
                set
                {
                    this.y_Werte = value;
                }
            }

            #endregion

            #region Methoden

            private void Y_Werte_Gewicht_berechnen()
            {
                y_Werte = new int[anzahl_gewicht];
                int gewicht = 0;

                for (int i = 0; i < anzahl_gewicht; i++)
                {
                    anzahl_Fänge_Pro_Gewicht = 0;

                    for (int j = 0; j < this.alleFänge.Count; j++)
                    {
                        int _gewicht = Convert.ToInt32(this.alleFänge[j].Gewicht);
                        if (this.alleFänge[j].Fischart == this.fischart && _gewicht == gewicht)
                        {
                            anzahl_Fänge_Pro_Gewicht++;
                        }
                    }

                    gewicht++;

                    y_Werte[i] = anzahl_Fänge_Pro_Gewicht;
                }
            }

            #endregion
        }

        public class Wetter
        {
            #region Varibalen

            List<Fangliste> alleFänge;
            string fischart;

            int anzahl_Fänge_Pro_wetter = 0;
            int[] y_Werte;

            string[] wetter;

            #endregion

            #region Konstruktor

            public Wetter(List<Fangliste> alleFänge, string fischart, string[] wetter)
            {
                this.alleFänge = alleFänge;
                this.fischart = fischart;
                this.wetter = wetter;

                Y_Werte_Wetter_berechnen();
            }

            #endregion

            #region Eigenschaften

            public int[] Y_Werte
            {
                get
                {
                    return this.y_Werte;
                }
                set
                {
                    this.y_Werte = value;
                }
            }

            #endregion

            #region Methoden

            private void Y_Werte_Wetter_berechnen()
            {
                y_Werte = new int[this.wetter.Length];

                for (int i = 0; i < this.wetter.Length; i++)
                {
                    anzahl_Fänge_Pro_wetter = 0;

                    for (int j = 0; j < this.alleFänge.Count; j++)
                    {
                        if (this.alleFänge[j].Fischart == this.fischart && this.alleFänge[j].Wetter == this.wetter[i])
                        {
                            anzahl_Fänge_Pro_wetter++;
                        }
                    }

                    y_Werte[i] = anzahl_Fänge_Pro_wetter;
                }
            }

            #endregion
        }
    }
}
