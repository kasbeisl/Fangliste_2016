using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FanglisteLibrary
{
    public class Demo
    {
        #region Variablen

        string pfad = Path.GetTempPath();
        string dateiname = "fishdemo";
        int verbleibendeTage = 0;

        #endregion
            
        #region Konstruktor

        public Demo()
        {
            //ErstelleDemoDateiMit30Tagen();
            try
            {
                if (File.Exists(pfad + dateiname))
                {
                    this.verbleibendeTage = BerechneVerbleibendeTage_mitCounter();
                    //this.verbleibendeTage = BerechneVerbleibendeTage_mitDateTime(LeseDateiAus());
                }
                else
	            {
                    ErstelleDemoDateiMit30Tagen();
                    //ErstelleDemoDateiMitDateTimeToday();
	            }
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler beim lesen der Datei.\n\nInformation:\n" + ex.ToString());
            }
        }

        #endregion

        #region Eigenschaften

        public int VerbleibendeTage
        {
            get { return this.verbleibendeTage; }
        }

        #endregion

        #region Methoden

        private string LeseDateiAus()
        {
            string datumstring = "";
            try
            {
                StreamReader leser = new StreamReader(pfad + dateiname);

                datumstring = leser.ReadLine();

                leser.Close();

            }
            catch
            {
                throw new InvalidOperationException("Keine Datei zum Lesen vorhanden!");
            }
            return datumstring;
        }

        private void ErstelleDemoDateiMit30Tagen()
        {
            //beschreibung
            Speichern(31); 
        }

        public void ErstelleDemoDateiMitDateTimeToday()
        {
            StreamWriter schreiber = new StreamWriter(this.pfad + this.dateiname);

            DateTime today = new DateTime();

            schreiber.WriteLine(today.Date.ToString());

            schreiber.Flush();
            schreiber.Close(); 
        }

        public void Speichern(int counter)
        {
            StreamWriter schreiber = new StreamWriter(this.pfad + this.dateiname);

            schreiber.WriteLine(counter);

            schreiber.Flush();
            schreiber.Close(); 
        }

        private int BerechneVerbleibendeTage_mitDateTime(string datum)
        {
            int tage = 0;

            DateTime now = new DateTime();
            DateTime old = new DateTime();
            old = Convert.ToDateTime(datum);

            TimeSpan ts = new TimeSpan();
            ts = now.Date - old.Date;

            tage = ts.Days;

            return tage;
        }

        private int BerechneVerbleibendeTage_mitCounter()
        {
            int tage = Convert.ToInt16(LeseDateiAus());

            if (tage > 0)
                tage--;

            Speichern(tage);

            return tage;
        }

        public void DateiLöschen()
        {
            File.Delete(pfad + dateiname);
        }

        #endregion
    }
}
