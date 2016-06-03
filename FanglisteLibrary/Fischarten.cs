using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FanglisteLibrary
{
    public class Fischarten
    {
        #region Variablen

        int id;
        string name;
        double korpulenzfaktor;

        #endregion

        #region Konstruktor

        public Fischarten(int id, string name, double korpulenzfaktor)
        {
            this.id = id;
            this.name = name;
            this.korpulenzfaktor = korpulenzfaktor;
        }

        public Fischarten(string csv_Zeile)
        {
            string[] array = csv_Zeile.Split(';');

            this.id = Convert.ToInt16(array[0]);
            this.name = array[1];
            this.korpulenzfaktor = Convert.ToDouble(array[2]);
        }

        public Fischarten(Fischarten liste)
        {
            this.id = liste.ID;
            this.name = liste.Name;
            this.korpulenzfaktor = liste.korpulenzfaktor;
        }

        public Fischarten()
        {
            this.id = 0;
            this.name = "";
            this.korpulenzfaktor = 0.0;
        }

        #endregion

        #region Eigenschaften

        public int ID
        {
            get { return id; }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public double Korpulenzfaktor
        {
            get
            {
                return this.korpulenzfaktor;
            }

            set
            {
                this.korpulenzfaktor = value;
            }
        }

        public string[] GetListToDraw
        {
            get
            {
                string[] liste = new string[2];

                liste[0] = this.name;
                liste[1] = Convert.ToString(this.korpulenzfaktor);

                return liste;
            }
        }

        public string[] GetList
        {
            get
            {
                string[] liste = new string[3];

                liste[0] = this.id.ToString();
                liste[1] = this.name;
                liste[2] = Convert.ToString(this.korpulenzfaktor);

                return liste;
            }
        }

        #endregion

        #region Methoden

        public override string ToString()
        {
            string tr = ";";
            string text = "";

            string[] liste = this.GetList;

            for (int i = 0; i < liste.Length; i++)
            {
                text += liste[i];

                if (i < liste.Length - 1)
                {
                    text += tr;
                }
            }

            return text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fischartenliste"></param>
        /// <param name="fischart"></param>
        /// <returns></returns>
        public static double GetK_FaktorFromFischart(List<Fischarten> fischartenliste, string fischart)
        {
            double k = 0;

            for (int i = 0; i < fischartenliste.Count; i++)
            {
                if (fischartenliste[i].Name == fischart)
                {
                    k = fischartenliste[i].Korpulenzfaktor;
                }
            }

            return k;
        }

        public static int Get_ID(List<Fischarten> fischartenliste, string fischart)
        {
            int id = 0;

            for (int i = 0; i < fischartenliste.Count; i++)
            {
                if(fischartenliste[i].Name == fischart)
                {
                    id = fischartenliste[i].id;
                    break;
                }
            }

            return id;
        }

        public static string Get_Name(List<Fischarten> fischartenliste, int id)
        {
            string name = "";

            for (int i = 0; i < fischartenliste.Count; i++)
            {
                if (fischartenliste[i].id == id)
                {
                    name = fischartenliste[i].Name;
                    break;
                }
            }

            return name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fischartenliste"></param>
        /// <param name="pfad"></param>
        /// <param name="dateiname"></param>
        public static void Speichern(List<Fischarten> fischartenliste, string pfad, string dateiname)
        {
            StreamWriter schreiber = new StreamWriter(pfad + dateiname);

            for (int i = 0; i < fischartenliste.Count; i++)
            {
                schreiber.WriteLine(fischartenliste[i].ToString());
            }

            schreiber.Flush();
            schreiber.Close();
        }

        public static List<Fischarten> Laden(string pfad, string dateiname)
        {
            List<Fischarten> fischarten = new List<Fischarten>();
            StreamReader leser = new StreamReader(pfad + dateiname);

            while (leser.Peek() >= 0)
            {
                fischarten.Add(new Fischarten(leser.ReadLine()));
            }

            leser.Close();

            return fischarten;
        }

        public static List<Fischarten> Kopiere_Objektarray(List<Fischarten> fischarten)
        {
            List<Fischarten> objekte = new List<Fischarten>();

            for (int i = 0; i < fischarten.Count; i++)
            {
                objekte.Add(new Fischarten(fischarten[i]));
            }

            return objekte;
        }

        public static List<Fischarten> Kopiere_Objektarray_und_um_eins_vergrößern(List<Fischarten> fischarten)
        {
            List<Fischarten> objekte = new List<Fischarten>();

            for (int i = 0; i < fischarten.Count; i++)
            {
                objekte[i] = new Fischarten(fischarten[i]);
            }

            return objekte;
        }

        public static List<Fischarten> Kopiere_Objektarray_und_um_eins_verkleinern(List<Fischarten> fischarten, int index)
        {
            List<Fischarten> objekte = new List<Fischarten>();

            int objekt_zahl = 0;

            for (int i = 0; i < fischarten.Count; i++)
            {
                if (i != index)
                {
                    objekte.Add(new Fischarten(fischarten[i]));
                    objekt_zahl++;
                }
            }

            return objekte;
        }

        public static List<Fischarten> Standart_FischartenListe()
        {
            List<Fischarten> fischartenliste = new List<Fischarten>();

            /*fischartenliste.Add(new Fischarten("Amur", 2.81));
            fischartenliste.Add(new Fischarten("Aal", 0.21));
            fischartenliste.Add(new Fischarten("Äsche", 1.15));
            fischartenliste.Add(new Fischarten("Bachforelle", 1.0));
            fischartenliste.Add(new Fischarten("Bachsaibling", 1.0));
            fischartenliste.Add(new Fischarten("Barbe", 1.0));
            fischartenliste.Add(new Fischarten("Barsch", 1.48));
            fischartenliste.Add(new Fischarten("Brachse", 1.07));
            fischartenliste.Add(new Fischarten("Hecht", 0.8));
            fischartenliste.Add(new Fischarten("Huchen", 1.2));
            fischartenliste.Add(new Fischarten("Karpfen", 2.81));
            fischartenliste.Add(new Fischarten("Rapfen", 0.96));
            fischartenliste.Add(new Fischarten("Regenbogenforelle", 1.1));
            fischartenliste.Add(new Fischarten("Reinanke", 1.0));
            fischartenliste.Add(new Fischarten("Schleie", 1.0));
            fischartenliste.Add(new Fischarten("Seeforelle", 1.2));
            fischartenliste.Add(new Fischarten("Seesaibling", 1.2));
            fischartenliste.Add(new Fischarten("Silberkarpfen", 1.19));
            fischartenliste.Add(new Fischarten("Stör", 0.8));
            fischartenliste.Add(new Fischarten("Wels", 0.8));
            fischartenliste.Add(new Fischarten("Zander", 0.96));*/

            return fischartenliste;
        }

        public static bool ExistiertFischart(List<Fischarten> fischarten, string name)
        {
            bool exist = false;

            try
            {
                for (int i = 0; i < fischarten.Count; i++)
                {
                    if (fischarten[i].Name == name)
                    {
                        exist = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return exist;
        }

        public static List<Fischarten> SortiereNachNamen(List<Fischarten> fischarten)
        {
            List<Fischarten> namen_Sortiert = new List<Fischarten>();

            string[] abc = new string[] { "A", "Ä", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "Ö", "P", "Q", "R", "S", "T", "U", "Ü", "V", "W", "X", "Y", "Z" };
            int zähler = 0;

            for (int i = 0; i < abc.Length; i++)
            {
                for (int j = 0; j < fischarten.Count; j++)
                {
                    if (abc[i] == fischarten[j].Name[0].ToString())
                    {
                        namen_Sortiert.Add(fischarten[j]);
                        zähler++;
                    }
                }
            }

            return namen_Sortiert;
        }

        #endregion
    }
}
