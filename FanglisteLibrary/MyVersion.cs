using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FanglisteLibrary.Tools
{
    //
    //
    //
    //
    //

    /// <summary>
    /// 
    /// </summary>
    public class MyVersion
    {
        #region Variablen

        int versionsNummer;
        int builtcount;
        DateTime datum;

        #endregion

        #region Konstruktor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="versionsNummer"></param>
        /// <param name="count"></param>
        /// <param name="datum"></param>
        public MyVersion(int versionsNummer, int count, DateTime datum)
        {
            this.versionsNummer = versionsNummer;
            this.builtcount = count;
            this.datum = datum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="csvZeile"></param>
        public MyVersion(string csvZeile)
        {
            string[] array = csvZeile.Split('.');

            this.versionsNummer = Convert.ToInt16(array[0]);
            this.builtcount = Convert.ToInt16(array[4]);
            this.datum = new DateTime(Convert.ToInt16(array[3]), Convert.ToInt16(array[2]), 
                                        Convert.ToInt16(array[1]));
        }

        /// <summary>
        /// 
        /// </summary>
        public MyVersion()
        {
            this.versionsNummer = 1;
            this.builtcount = 0;
            this.datum = DateTime.Now;
            this.Speichern(this.GetVersion, MyVersion.GetDateiname());
        }

        #endregion

        #region Eigenschaften

        /// <summary>
        /// 
        /// </summary>
        public MyVersion GetVersion
        {
            get { return new MyVersion(this.versionsNummer, this.builtcount, this.datum); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int GetVersionsnummer
        {
            get { return this.versionsNummer; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int GetBuiltCount
        {
            get { return this.builtcount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime GetDatum
        {
            get { return this.datum; }
        }

        #endregion

        #region Methoden

        /// <summary>
        /// Gibt einen String der Version zurück.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string tr = ".";
            string text = "";

            string[] liste = new string[] { this.versionsNummer.ToString(), this.datum.ToShortDateString(), this.builtcount.ToString() };

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
        public static string GetDateiname()
        {
            string dateiname = "version.config";

            return dateiname;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateiname"></param>
        /// <returns></returns>
        public static MyVersion Laden(string dateiname)
        {
            MyVersion v = null; ;
            StreamReader leser1 = new StreamReader(dateiname);

            if (leser1.Peek() >= 0)
            {
                v = new MyVersion(leser1.ReadLine());
            }

            leser1.Close();

            v.IncrementBuiltCount();

            return v;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateiname"></param>
        /// <returns></returns>
        public static MyVersion LadenOhneBuiltIncrement(string dateiname)
        {
            MyVersion v = null; ;
            StreamReader leser1 = new StreamReader(dateiname);

            if (leser1.Peek() >= 0)
            {
                v = new MyVersion(leser1.ReadLine());
            }

            leser1.Close();

            return v;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="dateiname"></param>
        private void Speichern(MyVersion v, string dateiname)
        {
            //Schreiber-Objekt wird erstellt.
            StreamWriter schreiber = new StreamWriter(dateiname);

            //Objekt wird in einen String konvertiert und dann in eine Zeile geschrieben.
            schreiber.WriteLine(v.ToString());

            schreiber.Flush(); //Puffer löschen
            schreiber.Close(); //Schreiber-Objekt schließen
        }

        /// <summary>
        /// 
        /// </summary>
        public void IncrementBuiltCount()
        {
            this.builtcount++;
            this.datum = DateTime.Now;
            Speichern(this.GetVersion, MyVersion.GetDateiname());
        }

        /// <summary>
        /// 
        /// </summary>
        public void IncrementVersionsnummer()
        {
            this.versionsNummer++;
            this.datum = DateTime.Now;
            Speichern(this.GetVersion, MyVersion.GetDateiname());
        }

        /// <summary>
        /// 
        /// </summary>
        public void IncrementTotal()
        {
            this.versionsNummer++;
            this.builtcount++;
            this.datum = DateTime.Now;
            Speichern(this.GetVersion, MyVersion.GetDateiname());
        }
        
        #endregion
    }
}
