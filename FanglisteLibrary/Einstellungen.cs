using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace FanglisteLibrary
{
    public class Einstellungen
    {
        #region Variablen

        string datienameEinstellungen = "config.ini";
        string pfad_fischartenliste = "";
        string dateiname_fischartenliste = "fal.data";
        string musik_ordner = "audio/";
        string httpAdresseVideoliste = "http://kasbeisl.funpic.de/";
        string ftpAdresseVideoliste = "ftp://ftp-web.funpic.de/";
        string dateinameVideoliste = "Videolist";

        //Verzeichnise Dateiname und Internet Adressen
        string pfad = "data/";
        string dateinameFangliste = "Fangliste";
        string dateinameUserliste = "Benutzerliste";
        string dateinameFotoliste = "Fotoliste";
        string fotoOrdner = "pics/";

        string servername = "ftp1941149";
        string passwort = "kasbeisl";

        string httpAdresseFangliste = "http://kasbeisl.funpic.de/fangliste/";
        string httpAdresseUserliste = "http://kasbeisl.funpic.de/";
        string ftpAdresseFangliste = "ftp://ftp-web.funpic.de/fangliste/";
        string ftpAdresseUserliste = "ftp://ftp-web.funpic.de/";
        string httpAdresseFotoliste = "http://kasbeisl.funpic.de/fotos/";
        string ftpAdresseFotoliste = "ftp://ftp-web.funpic.de/fotos/";


        //Verzeichnise für Sound Dateien
        string sound_hitparade = "data/hulk.mp3";
        string sound_persönlicheFangliste_jubel = "data/jubel.mp3";
        string sound_persönlicheFangliste_schade = "data/loser.mp3";
        string sound_lakeTrophy = "data/champions.mp3";

        Einstellungen[] einstellungArry;

        #endregion

        #region Konstruktor

        public Einstellungen(string csv_Zeile)
        {
            string[] array = csv_Zeile.Split(';');

            this.pfad = array[0];
            this.dateinameFangliste = array[1];
            this.dateinameUserliste = array[2];
            this.dateinameFotoliste = array[3];
            this.fotoOrdner = array[4];
            this.servername = array[5];
            this.passwort = array[6];
            this.httpAdresseFangliste = array[7];
            this.httpAdresseUserliste = array[8];
            this.httpAdresseFotoliste = array[9];
            this.ftpAdresseFangliste = array[10];
            this.ftpAdresseUserliste = array[11];
            this.ftpAdresseFotoliste = array[12];
            this.sound_hitparade = array[13];
            this.sound_persönlicheFangliste_jubel = array[14];
            this.sound_persönlicheFangliste_schade = array[15];
            this.sound_lakeTrophy = array[16];
        }

        public Einstellungen()
        {
            try
            {
                int größe = 17;

                einstellungArry = new Einstellungen[größe];
                einstellungArry = LeseEinstellungsDateiAus(this.datienameEinstellungen);

                this.pfad = einstellungArry[0].pfad;
                this.dateinameFangliste = einstellungArry[0].dateinameFangliste;
                this.dateinameUserliste = einstellungArry[0].dateinameUserliste;
                this.dateinameFotoliste = einstellungArry[0].dateinameFotoliste;
                this.fotoOrdner = einstellungArry[0].fotoOrdner;
                this.servername = einstellungArry[0].servername;
                this.passwort = einstellungArry[0].passwort;
                this.httpAdresseFangliste = einstellungArry[0].httpAdresseFangliste;
                this.httpAdresseUserliste = einstellungArry[0].httpAdresseUserliste;
                this.httpAdresseFotoliste = einstellungArry[0].httpAdresseFotoliste;
                this.ftpAdresseFangliste = einstellungArry[0].ftpAdresseFangliste;
                this.ftpAdresseUserliste = einstellungArry[0].ftpAdresseUserliste;
                this.ftpAdresseFotoliste = einstellungArry[0].ftpAdresseFotoliste;
                this.sound_hitparade = einstellungArry[0].sound_hitparade;
                this.sound_persönlicheFangliste_jubel = einstellungArry[0].Sound_PersönlicheF_Jubel_Dateiname;
                this.sound_persönlicheFangliste_schade = einstellungArry[0].Sound_PersönlicheF_Schade_Dateiname;
                this.sound_lakeTrophy = einstellungArry[0].sound_lakeTrophy;
            }
            catch { }
        }

        public Einstellungen(Einstellungen liste)
        {
            this.pfad = liste.Pfad;
            this.dateinameFangliste = liste.Dateiname_Fangliste;
            this.dateinameUserliste = liste.Dateiname_Userliste;
            this.dateinameFotoliste = liste.Dateiname_Fotoliste;
            this.fotoOrdner = liste.FotoOrdner;

            this.servername = liste.ServerName;
            this.passwort = liste.Passwort;

            this.httpAdresseFangliste = liste.Http_Adresse_Fangliste;
            this.httpAdresseUserliste = liste.Http_Adresse_Userliste;
            this.httpAdresseFotoliste = liste.Http_Adresse_Fotoliste;
            this.ftpAdresseFangliste = liste.Ftp_Adresse_Fangliste;
            this.ftpAdresseUserliste = liste.Ftp_Adresse_Userliste;
            this.ftpAdresseFotoliste = liste.Ftp_Adresse_Fotoliste;

            this.sound_hitparade = liste.Sound_Hitparade_Dateiname;
            this.sound_persönlicheFangliste_jubel = liste.Sound_PersönlicheF_Jubel_Dateiname;
            this.sound_persönlicheFangliste_schade = liste.Sound_PersönlicheF_Schade_Dateiname;
            this.sound_lakeTrophy = liste.Sound_LakeTrophy_Dateiname;
        }

    #endregion

        #region Eigenschaften

        public string Dateiname_Einstellungen
        {
            get
            {
                return this.datienameEinstellungen;
            }
        }

        public Einstellungen[] Einstellungs_Objekt
        {
            get
            {
                return this.einstellungArry;
            }
        }

        public string Pfad
        {
            get
            {
                return this.pfad;
            }
            set
            {
                this.pfad = value;
            }
        }

        public string Dateiname_Fangliste
        {
            get
            {
                return this.dateinameFangliste;
            }
            set
            {
                this.dateinameFangliste = value;
            }
        }

        public string Dateiname_Userliste
        {
            get
            {
                return this.dateinameUserliste;
            }
            set
            {
                this.dateinameUserliste = value;
            }
        }

        public string Dateiname_Fotoliste
        {
            get
            {
                return this.dateinameFotoliste;
            }
            set
            {
                this.dateinameFotoliste = value;
            }
        }

        public string FotoOrdner
        {
            get
            {
                return this.fotoOrdner;
            }
            set
            {
                this.fotoOrdner = value;
            }
        }

        public string ServerName
        {
            get
            {
                return this.servername;
            }
            set
            {
                this.servername = value;
            }
        }

        public string Passwort
        {
            get
            {
                return this.passwort;
            }
            set
            {
                this.passwort = value;
            }
        }

        public string Http_Adresse_Fangliste
        {
            get
            {
                return this.httpAdresseFangliste;
            }
            set
            {
                this.httpAdresseFangliste = value;
            }
        }

        public string Http_Adresse_Userliste
        {
            get
            {
                return this.httpAdresseUserliste;
            }
            set
            {
                this.httpAdresseUserliste = value;
            }
        }

        public string Http_Adresse_Fotoliste
        {
            get
            {
                return this.httpAdresseFotoliste;
            }
            set
            {
                this.httpAdresseFotoliste = value;
            }
        }

        public string Ftp_Adresse_Fangliste
        {
            get
            {
                return this.ftpAdresseFangliste;
            }
            set
            {
                this.ftpAdresseFangliste = value;
            }
        }

        public string Ftp_Adresse_Userliste
        {
            get
            {
                return this.ftpAdresseUserliste;
            }
            set
            {
                this.ftpAdresseUserliste = value;
            }
        }

        public string Ftp_Adresse_Fotoliste
        {
            get
            {
                return this.ftpAdresseFotoliste;
            }
            set
            {
                this.ftpAdresseFotoliste = value;
            }
        }

        public string Sound_Hitparade_Dateiname
        {
            get
            {
                return this.sound_hitparade;
            }
            set
            {
                this.sound_hitparade = value;
            }
        }

        public string Sound_PersönlicheF_Jubel_Dateiname
        {
            get
            {
                return this.sound_persönlicheFangliste_jubel;
            }
            set
            {
                this.sound_persönlicheFangliste_jubel = value;
            }
        }

        public string Sound_PersönlicheF_Schade_Dateiname
        {
            get
            {
                return this.sound_persönlicheFangliste_schade;
            }
            set
            {
                this.sound_persönlicheFangliste_schade = value;
            }
        }

        public string Sound_LakeTrophy_Dateiname
        {
            get
            {
                return this.sound_lakeTrophy;
            }
            set
            {
                this.sound_lakeTrophy = value;
            }
        }

        public string[] GetList
        {
            get
            {
                string[] liste = new string[17];

                liste[0] = this.pfad;
                liste[1] = this.dateinameFangliste;
                liste[2] = this.dateinameUserliste;
                liste[3] = this.dateinameFotoliste;
                liste[4] = this.fotoOrdner;

                liste[5] = this.servername;
                liste[6] = this.passwort;

                liste[7] = this.httpAdresseFangliste;
                liste[8] = this.httpAdresseUserliste;
                liste[9] = this.httpAdresseFotoliste;

                liste[10] = this.ftpAdresseFangliste;
                liste[11] = this.ftpAdresseUserliste;
                liste[12] = this.ftpAdresseFotoliste;
                
                liste[13] = this.sound_hitparade;
                liste[14] = this.sound_persönlicheFangliste_jubel;
                liste[15] = this.sound_persönlicheFangliste_schade;
                liste[16] = this.sound_lakeTrophy;

                return liste;
            }
        }

        public string Pfad_Fischartenliste
        {
            get
            {
                return this.pfad_fischartenliste;
            }
            set
            {
                value = this.pfad_fischartenliste;
            }
        }

        public string Dateiname_Fischartenliste
        {
            get
            {
                return this.dateiname_fischartenliste;
            }
            set
            {
                value = this.dateiname_fischartenliste;
            }
        }

        public string MusikOrdner
        {
            get
            {
                return this.musik_ordner;
            }
            set
            {
                value = this.musik_ordner;
            }
        }

        public string Http_Adresse_Videoliste
        {
            get
            {
                return this.httpAdresseVideoliste;
            }
            set
            {
                value = this.httpAdresseVideoliste;
            }
        }

        public string Ftp_Adresse_Videoliste
        {
            get
            {
                return this.ftpAdresseVideoliste;
            }
            set
            {
                value = this.ftpAdresseVideoliste;
            }
        }

        public string Dateiname_Videoliste
        {
            get
            {
                return this.dateinameVideoliste;
            }
            set
            {
                value = this.dateinameVideoliste;
            }
        }

        #endregion

        #region Methoden

        /// <summary>
        /// Gibt den Pfad des Dokumenten-Ordners zurück.
        /// </summary>
        /// <returns></returns>
        public static string GetPfad()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

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

        public static void EinstellungenSpeichern(Einstellungen einstellungen, string dateiname)
        {
            Sicherheit sicherheit = new Sicherheit();
            StreamWriter schreiber = new StreamWriter(dateiname);

            string vTxt = sicherheit.StringVerschlüsseln(einstellungen.ToString());
            schreiber.WriteLine(vTxt);

            //Alter Code in Datei schreiben ohne verschlüsseln
            //schreiber.WriteLine(einstellungen.ToString());

            schreiber.Flush();
            schreiber.Close();
        }

        public static Einstellungen[] Kopiere_Objektarray(Einstellungen[] einstellungen)
        {
            Einstellungen[] objekte = new Einstellungen[einstellungen.Length];

            for (int i = 0; i < einstellungen.Length; i++)
            {
                objekte[i] = new Einstellungen(einstellungen[i]);
            }

            return objekte;
        }

        public Einstellungen[] LeseEinstellungsDateiAus(string dateiname)
        {
            Einstellungen[] einstellungenArry;

            Sicherheit sicherheit = new Sicherheit();
            StreamReader leser1 = new StreamReader(dateiname);
            StreamReader leser2 = new StreamReader(dateiname);
            int zeilen = 0;
            

            while (leser1.Peek() >= 0)
            {
                leser1.ReadLine();
                zeilen++;
            }

            leser1.Close();

            einstellungenArry = new Einstellungen[zeilen];

            for (int i = 0; i < zeilen; i++)
            {
                string entTxt = sicherheit.StringEntschlüsseln(leser2.ReadLine());
                einstellungenArry[i] = new Einstellungen(entTxt);

                //Alter Code nicht verschlüsselter Text auslesen
                //einstellungenArry[i] = new Einstellungen(leser2.ReadLine());
            }

            leser2.Close();

            return einstellungenArry;
        }

        #endregion
    }
}
