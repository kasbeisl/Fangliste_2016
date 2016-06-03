using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using XnaFan.ImageComparison;

namespace FanglisteLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class CompareFileInfoEntries : IComparer<FileInfo>
    {
        public int Compare(FileInfo f1, FileInfo f2)
        {
            return (string.Compare(f2.LastWriteTime.ToString(), f1.LastWriteTime.ToString()));
        }
    } 

    /// <summary>
    /// 
    /// </summary>
    public class Foto
    {
        #region Variablen

        int id;
        string dateiname;
        string kommentar;

        #endregion

        #region Konstruktor

        public Foto(int id, string dateiname, string kommentar)
        {
            this.id = id;
            this.dateiname = dateiname;
            this.kommentar = kommentar;
        }

        public Foto(string csv_Zeile)
        {
            string[] array = csv_Zeile.Split(';');

            this.id = Convert.ToInt16(array[0]);
            this.dateiname = array[1];
            this.kommentar = array[2];
        }

        public Foto(Foto liste)
        {
            this.id = liste.ID;
            this.dateiname = liste.Dateiname;
            this.kommentar = liste.kommentar;
        }

        #endregion

        #region Eigenschaften

        public string[] GetList
        {
            get
            {
                string[] liste = new string[3];

                liste[0] = this.id.ToString();
                liste[1] = this.dateiname;
                liste[2] = this.kommentar;

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

        public string Dateiname
        {
            get
            {
                return this.dateiname;
            }
            set
            {
                this.dateiname = value;
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
        public static void Speichere_Fotoliste(List<Foto> aktuelle_Fotoliste, string pfad, string dateiname)
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
        public static List<Foto> LadenAsList(string pfad, string dateiname)
        {
            List<Foto> fotoliste = new List<Foto>();
            StreamReader leser1 = new StreamReader(pfad + dateiname);

            while (leser1.Peek() >= 0)
            {
                fotoliste.Add(new Foto(leser1.ReadLine()));
            }

            leser1.Close();

            return fotoliste;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alleFotos"></param>
        /// <returns></returns>
        public static List<Foto> Kopiere_Objektarray(List<Foto> alleFotos)
        {
            List<Foto> objekte = new List<Foto>();

            for (int i = 0; i < alleFotos.Count; i++)
            {
                objekte.Add(new Foto(alleFotos[i]));
            }

            return objekte;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alleFotos"></param>
        /// <returns></returns>
        public static List<Foto> Kopiere_Objektarray_und_um_eins_vergrößern(List<Foto> alleFotos)
        {
            List<Foto> objekte = new List<Foto>();

            for (int i = 0; i < alleFotos.Count; i++)
            {
                objekte[i] = new Foto(alleFotos[i]);
            }

            return objekte;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alleFotos"></param>
        /// <param name="neueFotos"></param>
        /// <returns></returns>
        public static Foto[] Kopiere_Objektarray_und_um_neuesObjekt_vergrößern(Foto[] alleFotos, Foto[] neueFotos)
        {
            Foto[] objekte = new Foto[alleFotos.Length + neueFotos.Length];

            for (int i = 0; i < alleFotos.Length; i++)
            {
                objekte[i] = new Foto(alleFotos[i]);
            }

            return objekte;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alleFotos"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Foto[] Kopiere_Objektarray_und_um_eins_verkleinern(Foto[] alleFotos, int index)
        {
            Foto[] objekte = new Foto[alleFotos.Length - 1];

            int objekt_zahl = 0;

            for (int i = 0; i < alleFotos.Length; i++)
            {
                if (i != index)
                {
                    objekte[objekt_zahl] = new Foto(alleFotos[i]);
                    objekt_zahl++;
                }
            }

            return objekte;
        }

        public static List<Foto> SortiereNachDatum(List<Foto> alleFotos)
        {
            List<Foto> kopie_Objektarray = Kopiere_Objektarray(alleFotos);
            List<Foto> kopie2 = Kopiere_Objektarray(alleFotos);
            List<Foto> datum_Sortiert = new List<Foto>();

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
