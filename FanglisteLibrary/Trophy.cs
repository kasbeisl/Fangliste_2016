using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanglisteLibrary
{
    public class Trophy
    {
        #region Variablen

        List<Fangliste> alleFänge;

        string fischerName_ErsterPlatz;
        string fischerName_ZweiterPlatz;
        string fischerName_DriterPlatz;
        string fischerName_VierterPlatz;
        string fischerName_FünfterPlatz;

        string gewicht_ErsterPlatz;
        string gewicht_ZweiterPlatz;
        string gewicht_DriterPlatz;
        string gewicht_VierterPlatz;
        string gewicht_FünfterPlatz;

        int ausgewähltes_Jahr;

        #endregion

        #region Konstruktor

        public Trophy(List<Fangliste> alleFänge, int ausgewähltes_Jahr)
        {
            this.alleFänge = alleFänge;
            this.ausgewähltes_Jahr = ausgewähltes_Jahr;

            WerteDatenAus();
        }

        #endregion

        #region Eigenschaften

        public string FischerName_ErsterPlatz
        {
            get
            {
                return this.fischerName_ErsterPlatz;
            }
        }

        public string FischerName_ZweiterPlatz
        {
            get
            {
                return this.fischerName_ZweiterPlatz;
            }
        }

        public string FischerName_DriterPlatz
        {
            get
            {
                return this.fischerName_DriterPlatz;
            }
        }

        public string FischerName_VierterPlatz
        {
            get
            {
                return this.fischerName_VierterPlatz;
            }
        }

        public string FischerName_FünfterPlatz
        {
            get
            {
                return this.fischerName_FünfterPlatz;
            }
        }

        public string Gewicht_ErsterPlatz
        {
            get
            {
                return this.gewicht_ErsterPlatz;
            }
        }

        public string Gewicht_ZweiterPlatz
        {
            get
            {
                return this.gewicht_ZweiterPlatz;
            }
        }

        public string Gewicht_DriterPlatz
        {
            get
            {
                return this.gewicht_DriterPlatz;
            }
        }

        public string Gewicht_VierterPlatz
        {
            get
            {
                return this.gewicht_VierterPlatz;
            }
        }

        public string Gewicht_FünfterPlatz
        {
            get
            {
                return this.gewicht_FünfterPlatz;
            }
        }
        public string[] GetList
        {
            get
            {
                string[] liste = new string[6];

                liste[0] = this.fischerName_ErsterPlatz;
                liste[1] = this.fischerName_ZweiterPlatz;
                liste[2] = this.FischerName_DriterPlatz;
                liste[3] = this.gewicht_ErsterPlatz;
                liste[4] = this.gewicht_ZweiterPlatz;
                liste[5] = this.gewicht_DriterPlatz;

                return liste;
            }
        }

        #endregion

        #region Methoden

        private string[] GetAlleFischer()
        {
            //string FischerName = "";
            string[] max_person = new string[alleFänge.Count];
            int anzahl_Personen = 0;

            for (int i = 0; i < alleFänge.Count; i++)
            {
                bool exist = false;
                for (int x = 0; x < max_person.GetLength(0); x++)
                {
                    if (max_person[x] == alleFänge[i].Name)
                    {
                        exist = true;
                    }
                }

                if (!exist)
                {
                    //FischerName = Frm_Hauptmenü.matrixAlle[i, 0];
                    max_person[anzahl_Personen] = alleFänge[i].Name;
                    anzahl_Personen++;
                }
            }

            string[] matrix_personen_check = new string[anzahl_Personen];

            for (int i = 0; i < anzahl_Personen; i++)
            {
                matrix_personen_check[i] = max_person[i];
            }

            return matrix_personen_check;
        }

        private string[,] Gewicht_Zählen(string[] matrix_personen_check)
        {
            string[,] matrixTrophy_Unsortiert = new string[matrix_personen_check.Length, 2];
            decimal Ges_Gewicht;
            int zähler = 0;

            for (int a = 0; a < matrix_personen_check.Length; a++)
            {
                Ges_Gewicht = 0;
                zähler = 0;

                matrixTrophy_Unsortiert[a, 0] = matrix_personen_check[a];
                matrixTrophy_Unsortiert[a, 1] = Convert.ToString(Ges_Gewicht);

                for (int i = 0; i < alleFänge.Count; i++)
                {
                    if (matrix_personen_check[a] == alleFänge[i].Name)
                    {
                        if (alleFänge[i].Datum.Year == ausgewähltes_Jahr)
                        {
                            if ("Hecht" == alleFänge[i].Fischart | "Zander" == alleFänge[i].Fischart | "Barsch" == alleFänge[i].Fischart)
                            {
                                matrixTrophy_Unsortiert[a, 0] = matrix_personen_check[a];

                                Ges_Gewicht = Ges_Gewicht + Convert.ToDecimal(alleFänge[i].Gewicht);

                                zähler++;
                            }
                        }
                    }
                }

                matrixTrophy_Unsortiert[a, 1] = Convert.ToString(Ges_Gewicht);
            }

            return matrixTrophy_Unsortiert;
        }

        private string[,] SortiereListeNachGewicht(string[,] matrixTrophy_Unsortiert)
        {
            string[,] matrixTrophy_Sortiert = new string[matrixTrophy_Unsortiert.GetLength(0), 2];

            decimal platz1 = 0;
            decimal platz2 = 0;
            decimal platz3 = 0;
            decimal platz4 = 0;
            decimal platz5 = 0;
            int zähler = 0;

            #region platz1
            for (int i = 0; i < matrixTrophy_Unsortiert.GetLength(0); i++)
            {
                if (platz1 < Convert.ToDecimal(matrixTrophy_Unsortiert[i, 1]))
                {
                    platz1 = Convert.ToDecimal(matrixTrophy_Unsortiert[i, 1]);
                    matrixTrophy_Sortiert[0, 0] = matrixTrophy_Unsortiert[i, 0];
                }

                //if (zähler == 0)
                //{
                //    platz1 = 0;
                //    matrixTrophy_Sortiert[0, 0] = matrixTrophy_Unsortiert[i, 0];
                //}
            }

            matrixTrophy_Sortiert[0, 1] = Convert.ToString(platz1);
            #endregion

            #region platz2

            try
            {
                for (int i = 0; i < matrixTrophy_Unsortiert.GetLength(0); i++)
                {
                    if (platz1 > Convert.ToDecimal(matrixTrophy_Unsortiert[i, 1]) && platz2 < Convert.ToDecimal(matrixTrophy_Unsortiert[i, 1]))
                    {
                        platz2 = Convert.ToDecimal(matrixTrophy_Unsortiert[i, 1]);
                        matrixTrophy_Sortiert[1, 0] = matrixTrophy_Unsortiert[i, 0];
                    }

                    //if (zähler == 0)
                    //{
                    //    platz2 = 0;
                    //    matrixTrophy_Sortiert[1, 0] = matrixTrophy_Unsortiert[i, 0];
                    //}
                }

                matrixTrophy_Sortiert[1, 1] = Convert.ToString(platz2);
            }
            catch { }
            
            #endregion

            #region platz3

            try
            {
                for (int i = 0; i < matrixTrophy_Unsortiert.GetLength(0); i++)
                {
                    if (platz2 > Convert.ToDecimal(matrixTrophy_Unsortiert[i, 1]) && platz3 < Convert.ToDecimal(matrixTrophy_Unsortiert[i, 1]))
                    {
                        platz3 = Convert.ToDecimal(matrixTrophy_Unsortiert[i, 1]);
                        matrixTrophy_Sortiert[2, 0] = matrixTrophy_Unsortiert[i, 0];
                    }

                    //if (zähler == 0)
                    //{
                    //    platz3 = 0;
                    //    matrixTrophy_Sortiert[2, 0] = matrixTrophy_Unsortiert[i, 0];
                    //}
                }

                matrixTrophy_Sortiert[2, 1] = Convert.ToString(platz3);
            }
            catch { }
            
            #endregion

            #region platz4

            try
            {
                for (int i = 0; i < matrixTrophy_Unsortiert.GetLength(0); i++)
                {
                    if (platz3 > Convert.ToDecimal(matrixTrophy_Unsortiert[i, 1]) && platz4 < Convert.ToDecimal(matrixTrophy_Unsortiert[i, 1]))
                    {
                        platz4 = Convert.ToDecimal(matrixTrophy_Unsortiert[i, 1]);
                        matrixTrophy_Sortiert[3, 0] = matrixTrophy_Unsortiert[i, 0];
                    }

                    //if (zähler == 0)
                    //{
                    //    platz4 = 0;
                    //    matrixTrophy_Sortiert[3, 0] = matrixTrophy_Unsortiert[i, 0];
                    //}
                }

                matrixTrophy_Sortiert[3, 1] = Convert.ToString(platz4);
            }
            catch { }
            
            #endregion

             #region platz5

            try
            {
                zähler = 0;
                for (int i = 0; i < matrixTrophy_Unsortiert.GetLength(0); i++)
                {
                    if (platz4 > Convert.ToDecimal(matrixTrophy_Unsortiert[i, 1]) && platz5 < Convert.ToDecimal(matrixTrophy_Unsortiert[i, 1]))
                    {
                        platz5 = Convert.ToDecimal(matrixTrophy_Unsortiert[i, 1]);
                        matrixTrophy_Sortiert[4, 0] = matrixTrophy_Unsortiert[i, 0];
                        zähler++;
                    }

                    //if (zähler == 0)
                    //{
                    //    platz5 = 0;
                    //    matrixTrophy_Sortiert[4, 0] = matrixTrophy_Unsortiert[i, 0];
                    //}
                }

                matrixTrophy_Sortiert[4, 1] = Convert.ToString(platz5);
            }
            catch { }
            
            #endregion

            return matrixTrophy_Sortiert;
        }

        private void WerteDatenAus()
        {
            try
            {
                string[] alleFischer = GetAlleFischer();

                string[,] gesamtGewicht_je_Fischer_Unsortiert = Gewicht_Zählen(alleFischer);

                string[,] sortierteListeNachGewicht = SortiereListeNachGewicht(gesamtGewicht_je_Fischer_Unsortiert);

                if (sortierteListeNachGewicht.Length > 1)
                {
                    try
                    {
                        fischerName_ErsterPlatz = sortierteListeNachGewicht[0, 0];
                    }
                    catch { }
                }


                if (sortierteListeNachGewicht.Length > 2)
                {
                    try
                    {
                        fischerName_ZweiterPlatz = sortierteListeNachGewicht[1, 0];
                    }
                    catch { }
                }

                if (sortierteListeNachGewicht.Length > 3)
                {
                    try
                    {
                        fischerName_DriterPlatz = sortierteListeNachGewicht[2, 0];
                    }
                    catch { }
                }

                if (sortierteListeNachGewicht.Length > 4)
                {
                    try
                    {
                        fischerName_VierterPlatz = sortierteListeNachGewicht[3, 0];
                    }
                    catch { }
                }

                if (sortierteListeNachGewicht.Length > 5)
                {
                    try
                    {
                        fischerName_FünfterPlatz = sortierteListeNachGewicht[4, 0];
                    }
                    catch { }
                }


                if (sortierteListeNachGewicht.Length > 1)
                {
                    try
                    {
                        gewicht_ErsterPlatz = sortierteListeNachGewicht[0, 1];
                    }
                    catch { }
                }

                if (sortierteListeNachGewicht.Length > 2)
                {
                    try
                    {
                        gewicht_ZweiterPlatz = sortierteListeNachGewicht[1, 1];
                    }
                    catch { }
                }

                if (sortierteListeNachGewicht.Length > 3)
                {
                    try
                    {
                        gewicht_DriterPlatz = sortierteListeNachGewicht[2, 1];
                    }
                    catch { }
                }

                if (sortierteListeNachGewicht.Length > 4)
                {
                    try
                    {
                        gewicht_VierterPlatz = sortierteListeNachGewicht[3, 1];
                    }
                    catch { }
                }

                if (sortierteListeNachGewicht.Length > 5)
                {
                    try
                    {
                        gewicht_FünfterPlatz = sortierteListeNachGewicht[4, 1];
                    }
                    catch { }
                }
            }
            catch { }
        }

        #endregion
    }
}
