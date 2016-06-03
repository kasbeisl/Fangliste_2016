using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FanglisteLibrary;
using System.Runtime.InteropServices;
//using Excel = Microsoft.Office.Interop.Excel;

namespace Fangliste_2016
{
    public partial class Frm_FanglisteExportExcel : Form
    {
        #region Variablen

        List<Fangliste> alleFänge;
        Angler1 aktuellerFischer;

        #endregion

        #region Konstruktor

        public Frm_FanglisteExportExcel(List<Fangliste> alleFänge, Angler1 aktuellerFischer)
        {
            InitializeComponent();

            this.alleFänge = alleFänge;
            this.aktuellerFischer = aktuellerFischer;
        }

        private void Frm_ExportExcel_Load(object sender, EventArgs e)
        {
            if (!isExcelInstalled())
            {
                btn_hitparade.Enabled = false;
                btn_alleFänge.Enabled = false;
                btn_jahresfänge.Enabled = false;
                btn_persönlichefangliste.Enabled = false;
            }

            
        }

        #endregion

        #region Methoden

        private bool isExcelInstalled() 
        { 
            string programName = "Microsoft Office"; 
            string uninstallList = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"; 
            object obj; Microsoft.Win32.RegistryKey RegKeyUninstallList = Microsoft.Win32.Registry.LocalMachine; Microsoft.Win32.RegistryKey SubKeyUninstallList = Microsoft.Win32.Registry.LocalMachine; 
            
            foreach (string subKey in RegKeyUninstallList.OpenSubKey(uninstallList).GetSubKeyNames()) 
            { 
                obj = SubKeyUninstallList.OpenSubKey(uninstallList + "\\" + subKey).GetValue("DisplayName"); 
                if (obj != null) 
                { if (obj.ToString().ToLower().Contains(programName.ToLower()))                
                    return true; 
                } 
            } 
            
            return false; 
        }

        private void HitparadeExportierenExcel(List<Fangliste> hitparadeListe, string titel)
        {
           /* if ((hitparadeListe != null) && (hitparadeListe.Count != 0))
            {
                string[] kopfzeile = new string[] { "Platz", "Name", "Größe [cm]", "Gewicht [kg]", "Gewässer", "Datum" };

                try
                {
                    try
                    {
                        // Variablen deklarieren 
                        Excel.Application myExcelApplication;
                        Excel.Workbook myExcelWorkbook;
                        Excel.Worksheet myExcelWorkSheet;
                        myExcelApplication = null;

                        try
                        {
                            // First Contact: Excel Prozess initialisieren
                            myExcelApplication = new Excel.Application();
                            myExcelApplication.Visible = true;
                            myExcelApplication.ScreenUpdating = true;

                            // Excel Datei anlegen: Workbook
                            var myCount = myExcelApplication.Workbooks.Count;
                            myExcelWorkbook = (Excel.Workbook)(myExcelApplication.Workbooks.Add(System.Reflection.Missing.Value));
                            myExcelWorkSheet = (Excel.Worksheet)myExcelWorkbook.ActiveSheet;

                            myExcelWorkSheet.Cells[1, 1] = titel;
                            //myExcelWorkSheet.Cells[3, 1] = String.Format("Abschüsse: {0} von {1} geplanten", daten.Length, this.jahr.Abschussziel);

                            Excel.Range überschrift;
                            überschrift = myExcelWorkSheet.get_Range("A1", "E1");
                            überschrift.Font.Size = 20;
                            überschrift.Font.Underline = true;
                            überschrift.Font.Bold = true;
                            überschrift.Merge();

                            for (int i = 0; i < kopfzeile.Length; i++)
                            {
                                myExcelWorkSheet.Cells[3, i + 1] = kopfzeile[i];
                            }

                            // Formatieren der Überschrift 

                            string[] alph = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                            string bis = alph[kopfzeile.Length - 1] + Convert.ToString(hitparadeListe.Count + 3);

                            Excel.Range myRangeHeadline;
                            myRangeHeadline = myExcelWorkSheet.get_Range("A3", bis);
                            myRangeHeadline.Font.Bold = false;
                            myRangeHeadline.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            myRangeHeadline.Borders.Weight = Excel.XlBorderWeight.xlThin;

                            // Daten eingeben 
                            myExcelWorkSheet.Name = titel;

                            int zähler = 1;

                            //länge = hitparade geht nur bis eintrag 10
                            int länge = hitparadeListe.Count;
                            if (länge > 10)
                            {
                                länge = 10;
                            }

                            for (int i = 0; i < länge; i++)
                            {
                                string[] eineZeile = hitparadeListe[i].GetList;

                                myExcelWorkSheet.Cells[i + 4, 0 + 1] = zähler;

                                for (int j = 1; j < 6; j++)
                                {
                                    myExcelWorkSheet.Cells[i + 4, j + 1] = eineZeile[j];
                                }

                                zähler++;
                            }

                            //for (int i = 0; i < this.zanderListe.Length; i++)
                            //{
                            //    string[] eineZeile = this.hechtListe[i].GetList;

                            //    for (int j = 0; j < eineZeile.Length; j++)
                            //    {
                            //        myExcelWorkSheet.Cells[i + 4, j + 1] = eineZeile[j];
                            //    }
                            //}

                            // Excel Datei abspeichern 
                            // wenn die Datei vorher vorhanden ist, kommt in Excel eine Fehlermeldung. 

                            myExcelWorkSheet.Columns["A:R"].EntireColumn.AutoFit();

                            //myExcelApplication.ActiveWorkbook.PrintPreview();
                        }

                        catch (Exception ex)
                        {
                            String myErrorString = ex.Message;
                            MessageBox.Show(myErrorString);
                        }
                        finally
                        {
                            // Excel beenden 
                            //if (myExcelApplication != null)
                            //{
                            //    myExcelApplication.Quit();
                            //}
                        }
                    }
                    catch
                    {

                        MessageBox.Show("Fehler beim Öffnen von Excel!!", "Fehler");
                    }
                }
                catch
                {

                    MessageBox.Show("Fehler beim Drucken!!", "Fehler");
                }
            }*/
        }

        private void PersönlicheFanglisteExportierenExcel(List<Fangliste> persönliche_Liste)
        {
          /*  if ((persönliche_Liste != null) && (persönliche_Liste.Count != 0))
            {
                string[] kopfzeile = new string[] { "Platz", "Name", "Fischart", "Größe [cm]", "Gewicht [kg]", "Gewässer", "Datum", "Uhrzeit", "Platzbeschreibung", "Köderbeschreibung", "Tiefe [m]", "Temperatur [°C]", "Wetter", "Zurückgesetzt" };

                try
                {
                    try
                    {
                        // Variablen deklarieren 
                        Excel.Application myExcelApplication;
                        Excel.Workbook myExcelWorkbook;
                        Excel.Worksheet myExcelWorkSheet;
                        myExcelApplication = null;

                        try
                        {
                            // First Contact: Excel Prozess initialisieren
                            myExcelApplication = new Excel.Application();
                            myExcelApplication.Visible = true;
                            myExcelApplication.ScreenUpdating = true;

                            // Excel Datei anlegen: Workbook
                            var myCount = myExcelApplication.Workbooks.Count;
                            myExcelWorkbook = (Excel.Workbook)(myExcelApplication.Workbooks.Add(System.Reflection.Missing.Value));
                            myExcelWorkSheet = (Excel.Worksheet)myExcelWorkbook.ActiveSheet;

                            myExcelWorkSheet.Cells[1, 1] = "Persönliche Fangliste von " + aktuellerFischer.Name;
                            //myExcelWorkSheet.Cells[3, 1] = String.Format("Abschüsse: {0} von {1} geplanten", daten.Length, this.jahr.Abschussziel);

                            Excel.Range überschrift;
                            überschrift = myExcelWorkSheet.get_Range("A1", "E1");
                            überschrift.Font.Size = 20;
                            überschrift.Font.Underline = true;
                            überschrift.Font.Bold = true;
                            überschrift.Merge();

                            for (int i = 0; i < kopfzeile.Length; i++)
                            {
                                myExcelWorkSheet.Cells[3, i + 1] = kopfzeile[i];
                            }

                            // Formatieren der Überschrift 

                            string[] alph = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                            string bis = alph[kopfzeile.Length - 1] + Convert.ToString(this.alleFänge.Count + 3);

                            Excel.Range myRangeHeadline;
                            myRangeHeadline = myExcelWorkSheet.get_Range("A3", bis);
                            myRangeHeadline.Font.Bold = false;
                            myRangeHeadline.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            myRangeHeadline.Borders.Weight = Excel.XlBorderWeight.xlThin;

                            // Daten eingeben 
                            myExcelWorkSheet.Name = "Persönliche Fangliste von " + aktuellerFischer.Name;

                            for (int i = 0; i < persönliche_Liste.Count; i++)
                            {
                                string[] eineZeile = persönliche_Liste[i].GetList;

                                for (int j = 0; j < eineZeile.Length; j++)
                                {
                                    myExcelWorkSheet.Cells[i + 4, j + 1] = eineZeile[j];
                                }
                            }

                            // Excel Datei abspeichern 
                            // wenn die Datei vorher vorhanden ist, kommt in Excel eine Fehlermeldung. 

                            myExcelWorkSheet.Columns["A:R"].EntireColumn.AutoFit();

                            //myExcelApplication.ActiveWorkbook.PrintPreview();
                        }

                        catch (Exception ex)
                        {
                            String myErrorString = ex.Message;
                            MessageBox.Show(myErrorString);
                        }
                        finally
                        {
                            // Excel beenden 
                            //if (myExcelApplication != null)
                            //{
                            //    myExcelApplication.Quit();
                            //}
                        }
                    }
                    catch
                    {

                        MessageBox.Show("Fehler beim Öffnen von Excel!!", "Fehler");
                    }
                }
                catch
                {

                    MessageBox.Show("Fehler beim Drucken!!", "Fehler");
                }
            }*/
        }

        private void AlleFängeExportierenExcel(List<Fangliste> alleFänge)
        {
           /* if ((alleFänge != null) && (alleFänge.Count != 0))
            {
                string[] kopfzeile = new string[] { "Platz", "Name", "Fischart", "Größe [cm]", "Gewicht [kg]", "Gewässer", "Datum", "Uhrzeit", "Platzbeschreibung", "Köderbeschreibung", "Tiefe [m]", "Temperatur [°C]", "Wetter", "Zurückgesetzt" };

                try
                {
                    try
                    {
                        // Variablen deklarieren 
                        Excel.Application myExcelApplication;
                        Excel.Workbook myExcelWorkbook;
                        Excel.Worksheet myExcelWorkSheet;
                        myExcelApplication = null;

                        try
                        {
                            // First Contact: Excel Prozess initialisieren
                            myExcelApplication = new Excel.Application();
                            myExcelApplication.Visible = true;
                            myExcelApplication.ScreenUpdating = true;

                            // Excel Datei anlegen: Workbook
                            var myCount = myExcelApplication.Workbooks.Count;
                            myExcelWorkbook = (Excel.Workbook)(myExcelApplication.Workbooks.Add(System.Reflection.Missing.Value));
                            myExcelWorkSheet = (Excel.Worksheet)myExcelWorkbook.ActiveSheet;

                            myExcelWorkSheet.Cells[1, 1] = "Alle Fänge";
                            //myExcelWorkSheet.Cells[3, 1] = String.Format("Abschüsse: {0} von {1} geplanten", daten.Length, this.jahr.Abschussziel);

                            Excel.Range überschrift;
                            überschrift = myExcelWorkSheet.get_Range("A1", "E1");
                            überschrift.Font.Size = 20;
                            überschrift.Font.Underline = true;
                            überschrift.Font.Bold = true;
                            überschrift.Merge();

                            for (int i = 0; i < kopfzeile.Length; i++)
                            {
                                myExcelWorkSheet.Cells[3, i + 1] = kopfzeile[i];
                            }

                            // Formatieren der Überschrift 

                            string[] alph = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                            string bis = alph[kopfzeile.Length - 1] + Convert.ToString(this.alleFänge.Count + 3);

                            Excel.Range myRangeHeadline;
                            myRangeHeadline = myExcelWorkSheet.get_Range("A3", bis);
                            myRangeHeadline.Font.Bold = false;
                            myRangeHeadline.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            myRangeHeadline.Borders.Weight = Excel.XlBorderWeight.xlThin;

                            // Daten eingeben 
                            myExcelWorkSheet.Name = "Alle Fänge";

                            for (int i = 0; i < this.alleFänge.Count; i++)
                            {
                                string[] eineZeile = this.alleFänge[i].GetList;

                                for (int j = 0; j < eineZeile.Length; j++)
                                {
                                    myExcelWorkSheet.Cells[i + 4, j + 1] = eineZeile[j];
                                }
                            }

                            // Excel Datei abspeichern 
                            // wenn die Datei vorher vorhanden ist, kommt in Excel eine Fehlermeldung. 

                            myExcelWorkSheet.Columns["A:R"].EntireColumn.AutoFit();

                            //myExcelApplication.ActiveWorkbook.PrintPreview();
                        }

                        catch (Exception ex)
                        {
                            String myErrorString = ex.Message;
                            MessageBox.Show(myErrorString);
                        }
                        finally
                        {
                            // Excel beenden 
                            //if (myExcelApplication != null)
                            //{
                            //    myExcelApplication.Quit();
                            //}
                        }
                    }
                    catch
                    {

                        MessageBox.Show("Fehler beim Öffnen von Excel!!", "Fehler");
                    }
                }
                catch
                {

                    MessageBox.Show("Fehler beim Drucken!!", "Fehler");
                }
            }*/
        }

        private void AktuelleJahrsfängeExportierenExcel(List<Fangliste> heurige_Fänge)
        {
          /*  if ((heurige_Fänge != null) && (heurige_Fänge.Count != 0))
            {
                string[] kopfzeile = new string[] { "Platz", "Name", "Fischart", "Größe [cm]", "Gewicht [kg]", "Gewässer", "Datum", "Uhrzeit", "Platzbeschreibung", "Köderbeschreibung", "Tiefe [m]", "Temperatur [°C]", "Wetter", "Zurückgesetzt" };

                try
                {
                    try
                    {
                        // Variablen deklarieren 
                        Excel.Application myExcelApplication;
                        Excel.Workbook myExcelWorkbook;
                        Excel.Worksheet myExcelWorkSheet;
                        myExcelApplication = null;

                        try
                        {
                            // First Contact: Excel Prozess initialisieren
                            myExcelApplication = new Excel.Application();
                            myExcelApplication.Visible = true;
                            myExcelApplication.ScreenUpdating = true;

                            // Excel Datei anlegen: Workbook
                            var myCount = myExcelApplication.Workbooks.Count;
                            myExcelWorkbook = (Excel.Workbook)(myExcelApplication.Workbooks.Add(System.Reflection.Missing.Value));
                            myExcelWorkSheet = (Excel.Worksheet)myExcelWorkbook.ActiveSheet;

                            myExcelWorkSheet.Cells[1, 1] = "Aktuelle Jahresfänge (" + DateTime.Now.Year + ")";
                            //myExcelWorkSheet.Cells[3, 1] = String.Format("Abschüsse: {0} von {1} geplanten", daten.Length, this.jahr.Abschussziel);

                            Excel.Range überschrift;
                            überschrift = myExcelWorkSheet.get_Range("A1", "E1");
                            überschrift.Font.Size = 20;
                            überschrift.Font.Underline = true;
                            überschrift.Font.Bold = true;
                            überschrift.Merge();

                            for (int i = 0; i < kopfzeile.Length; i++)
                            {
                                myExcelWorkSheet.Cells[3, i + 1] = kopfzeile[i];
                            }

                            // Formatieren der Überschrift 

                            string[] alph = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                            string bis = alph[kopfzeile.Length - 1] + Convert.ToString(this.alleFänge.Count + 3);

                            Excel.Range myRangeHeadline;
                            myRangeHeadline = myExcelWorkSheet.get_Range("A3", bis);
                            myRangeHeadline.Font.Bold = false;
                            myRangeHeadline.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            myRangeHeadline.Borders.Weight = Excel.XlBorderWeight.xlThin;

                            // Daten eingeben 
                            myExcelWorkSheet.Name = "Aktuelle Jahresfänge (" + DateTime.Now.Year + ")";

                            for (int i = 0; i < heurige_Fänge.Count; i++)
                            {
                                string[] eineZeile = heurige_Fänge[i].GetList;

                                for (int j = 0; j < eineZeile.Length; j++)
                                {
                                    myExcelWorkSheet.Cells[i + 4, j + 1] = eineZeile[j];
                                }
                            }

                            // Excel Datei abspeichern 
                            // wenn die Datei vorher vorhanden ist, kommt in Excel eine Fehlermeldung. 

                            myExcelWorkSheet.Columns["A:R"].EntireColumn.AutoFit();

                            //myExcelApplication.ActiveWorkbook.PrintPreview();
                        }

                        catch (Exception ex)
                        {
                            String myErrorString = ex.Message;
                            MessageBox.Show(myErrorString);
                        }
                        finally
                        {
                            // Excel beenden 
                            //if (myExcelApplication != null)
                            //{
                            //    myExcelApplication.Quit();
                            //}
                        }
                    }
                    catch
                    {

                        MessageBox.Show("Fehler beim Öffnen von Excel!!", "Fehler");
                    }
                }
                catch
                {

                    MessageBox.Show("Fehler beim Drucken!!", "Fehler");
                }
            }*/
        }

        #endregion

        #region Eigenschaften

        #endregion

        #region Events

        private void btn_hitparade_Click(object sender, EventArgs e)
        {
            List<Fangliste> hechtListe = Fangliste.Spezifische_Fischart_Liste("Hecht", this.alleFänge);
            List<Fangliste> zanderListe = Fangliste.Spezifische_Fischart_Liste("Zander", this.alleFänge);
            List<Fangliste> barschListe = Fangliste.Spezifische_Fischart_Liste("Barsch", this.alleFänge);
            List<Fangliste> andereListe = Fangliste.Andere_Fischarten_Liste(this.alleFänge);

            HitparadeExportierenExcel(hechtListe, "Hecht Hitparade");
            HitparadeExportierenExcel(zanderListe, "Zander Hitparade");
            HitparadeExportierenExcel(barschListe, "Barsch Hitparade");
            HitparadeExportierenExcel(andereListe, "Andere Hitparade");
        }

        private void btn_alleFänge_Click(object sender, EventArgs e)
        {
            AlleFängeExportierenExcel(this.alleFänge);
        }

        private void btn_jahresfänge_Click(object sender, EventArgs e)
        {
            List<Fangliste> aktuellesJahr_Liste = Fangliste.Fangliste_je_jahr(this.alleFänge);
            AktuelleJahrsfängeExportierenExcel(aktuellesJahr_Liste);
        }

        private void btn_persönlichefangliste_Click(object sender, EventArgs e)
        {
            List<Fangliste> persönliche_Liste = Fangliste.PersönlicheFangliste(this.alleFänge, this.aktuellerFischer);

            PersönlicheFanglisteExportierenExcel(persönliche_Liste);
        }

        #endregion
    }
}
