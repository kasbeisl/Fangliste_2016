using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace FanglisteLibrary
{

    /// <summary>
    /// 
    /// </summary>
    public class Foto1
    {
        #region Variablen

        int id;
        int angler_ID;
        int fang_ID;
        int ordner_ID;
        string kommentar;
        Image bild;

        #endregion

        #region Konstruktor

        public Foto1(int id, int angler_ID, int fang_ID, int ordner_ID, string kommentar, Image bild)
        {
            this.id = id;
            this.angler_ID = angler_ID;
            this.fang_ID = fang_ID;
            this.ordner_ID = ordner_ID;
            this.kommentar = kommentar;
            this.bild = bild;
        }

        public Foto1(int id, int angler_ID, int fang_ID, int ordner_ID, string kommentar)
        {
            this.id = id;
            this.angler_ID = angler_ID;
            this.fang_ID = fang_ID;
            this.ordner_ID = ordner_ID;
            this.kommentar = kommentar;
            this.bild = null;
        }

        public Foto1(string csv_Zeile)
        {
            string[] array = csv_Zeile.Split(';');

            this.id = Convert.ToInt16(array[0]);
            this.angler_ID = Convert.ToInt16(array[1]);
            this.fang_ID = Convert.ToInt16(array[2]);
            this.ordner_ID = Convert.ToInt16(array[3]);
            this.kommentar = array[4];
        }

        public Foto1(Foto1 liste)
        {
            this.id = liste.ID;
            this.angler_ID = liste.Angler_ID;
            this.fang_ID = liste.Fang_ID;
            this.ordner_ID = liste.Ordner_ID;
            this.kommentar = liste.kommentar;
            this.bild = liste.Bild;
        }

        public Foto1()
        {
            this.id = 0;
            this.angler_ID = 0;
            this.fang_ID = 0;
            this.ordner_ID = 0;
            this.kommentar = "";
            this.bild = null;
        }

        #endregion

        #region Eigenschaften

        public string[] GetList
        {
            get
            {
                string[] liste = new string[5];

                liste[0] = this.id.ToString();
                liste[1] = this.angler_ID.ToString();
                liste[2] = this.fang_ID.ToString();
                liste[3] = this.ordner_ID.ToString();
                liste[4] = this.kommentar;

                return liste;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public int Angler_ID
        {
            get
            {
                return this.angler_ID;
            }
            set
            {
                this.angler_ID = value;
            }
        }

        public int Fang_ID
        {
            get
            {
                return this.fang_ID;
            }
            set
            {
                this.fang_ID = value;
            }
        }

        public int Ordner_ID
        {
            get
            {
                return this.ordner_ID;
            }
            set
            {
                this.ordner_ID = value;
            }
        }

        public Image Bild
        {
            get
            {
                return this.bild;
            }
            set
            {
                this.bild = value;
            }
        }

        public string Kommentar
        {
            get
            {
                return this.kommentar;
            }
            set
            {
                this.kommentar = value;
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
        /// Durchsucht den Ordner nach doppelte Bilder.
        /// </summary>
        /// <param name="Ordner">Der Pfad des zu durchsuchenden Ordners</param>
        /// <param name="checkSubOrdner">Durchsucht auch die Unterordner.</param>
        /// <returns></returns>
        public static List<List<string>> Vergleichen(string Ordner, bool checkSubOrdner)
        {
            List<List<string>> list = new List<List<string>>();

            try
            {
                list = XnaFan.ImageComparison.ImageTool.GetDuplicateImages(Ordner, checkSubOrdner);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<string> GetFilesFromDirection(string path)
        {
            string[] files1 = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
            string[] files2 = Directory.GetFiles(path, "*.png", SearchOption.AllDirectories);

            List<string> files = new List<string>();
            files.AddRange(files1);
            files.AddRange(files2);

            return files;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static List<string> SortiereFilesNachDatum(List<string> files)
        {
            List<FileInfo> files2 = new List<FileInfo>();
            List<string> sortiert = new List<string>();

            for (int i = 0; i < files.Count; i++)
            {
                FileInfo fi = new FileInfo(files[i]);
                files2.Add(fi);
            }

            files2.Sort(new CompareFileInfoEntries());

            for (int i = 0; i < files.Count; i++)
            {
                sortiert.Add(files2[i].FullName);
            }

            return sortiert;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static List<string> GetImagesFromFiles(string[] files)
        {
            List<string> images = new List<string>();
            FileInfo image = null;

            for (int i = 0; i < files.Length; i++)
            {
                image = new FileInfo(files[i]);

                if ((image.Extension == ".jpg") || (image.Extension == ".png"))
                    images.Add(files[i]);
            }

            return images;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aktuelle_Fotoliste"></param>
        /// <param name="pfad"></param>
        /// <param name="dateiname"></param>
        public static void Speichere_Fotoliste(List<Foto1> aktuelle_Fotoliste, string pfad, string dateiname)
        {
            StreamWriter schreiber = new StreamWriter(pfad + dateiname);

            for (int i = 0; i < aktuelle_Fotoliste.Count; i++)
            {
                schreiber.WriteLine(aktuelle_Fotoliste[i].ToString());
            }

            schreiber.Flush();
            schreiber.Close();
        }

        /// <summary>
        /// Lest eine Fotoliste-Datei aus und gibt sie zurück.
        /// </summary>
        /// <param name="pfad"></param>
        /// <param name="dateiname"></param>
        /// <returns></returns>
        public static List<Foto1> LadenAsList(string pfad, string dateiname)
        {
            List<Foto1> fotoliste = new List<Foto1>();
            StreamReader leser1 = new StreamReader(pfad + dateiname);

            while (leser1.Peek() >= 0)
            {
                fotoliste.Add(new Foto1(leser1.ReadLine()));
            }

            leser1.Close();

            return fotoliste;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alleFotos"></param>
        /// <returns></returns>
        public static List<Foto1> Kopiere_Objektarray(List<Foto1> alleFotos)
        {
            List<Foto1> objekte = new List<Foto1>();

            for (int i = 0; i < alleFotos.Count; i++)
            {
                objekte.Add(new Foto1(alleFotos[i]));
            }

            return objekte;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alleFotos"></param>
        /// <returns></returns>
        public static List<Foto1> Kopiere_Objektarray_und_um_eins_vergrößern(List<Foto1> alleFotos)
        {
            List<Foto1> objekte = new List<Foto1>();

            for (int i = 0; i < alleFotos.Count; i++)
            {
                objekte[i] = new Foto1(alleFotos[i]);
            }

            return objekte;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alleFotos"></param>
        /// <param name="neueFotos"></param>
        /// <returns></returns>
        public static Foto1[] Kopiere_Objektarray_und_um_neuesObjekt_vergrößern(Foto1[] alleFotos, Foto1[] neueFotos)
        {
            Foto1[] objekte = new Foto1[alleFotos.Length + neueFotos.Length];

            for (int i = 0; i < alleFotos.Length; i++)
            {
                objekte[i] = new Foto1(alleFotos[i]);
            }

            return objekte;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alleFotos"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Foto1[] Kopiere_Objektarray_und_um_eins_verkleinern(Foto1[] alleFotos, int index)
        {
            Foto1[] objekte = new Foto1[alleFotos.Length - 1];

            int objekt_zahl = 0;

            for (int i = 0; i < alleFotos.Length; i++)
            {
                if (i != index)
                {
                    objekte[objekt_zahl] = new Foto1(alleFotos[i]);
                    objekt_zahl++;
                }
            }

            return objekte;
        }

        public static List<Foto1> SortiereNachDatum(List<Foto1> alleFotos)
        {
            List<Foto1> kopie_Objektarray = Kopiere_Objektarray(alleFotos);
            List<Foto1> kopie2 = Kopiere_Objektarray(alleFotos);
            List<Foto1> datum_Sortiert = new List<Foto1>();

            //for (int i = 0; i < kopie_Objektarray.Count; i++)
            //{
            //    int alt = 0;

            //    for (int j = 0; j < kopie_Objektarray.Count; j++)
            //    {
            //        if (kopie_Objektarray[j].Datum.Date > kopie_Objektarray[alt].Datum.Date)
            //        {
            //            alt = j;
            //        }
            //    }

            //    datum_Sortiert[i] = kopie2[alt];
            //    kopie_Objektarray[alt].Datum = new DateTime(2000, 1, 1);
            //}

            return datum_Sortiert;
        }

        #endregion
    }
}
