using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace FanglisteLibrary
{
    // Information
    // Kasbeisl, Inc.
    // E-mail: kasbeisl@gmail.com
    // Entwickler: Kastberger Ferdinand
    // Copyright 2015
    // Drucker Events written by "Life with .NET" from CodeProject
    // License: The Code Project Open License (CPOL)

    /// <summary>
    /// Stellt eine Drucker-Klasse zur verfügung, zum drucken der Listen.
    /// </summary>
    public class Drucken
    {
        #region Variablen

        string dokumentTitel = "Dokument1";
        Brush titelColor;
        PrintDocument dokument;
        PrinterSettings druckereinstellung;
        PageSettings seiteneinstellung;
        
        PrintDialog printDialog;
        PrintPreviewDialog printPreviewDialog1;
        PageSetupDialog pageSetupDialog1;

        bool showMessagePrintEnd = false;

        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        int seitenAnzahl = 0;
        DataGridView dataGridView1;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Initalisiert eine neue Instanz der Drucker-Klasse.
        /// </summary>
        public Drucken(string dokumentTitel, DataGridView dataGridView, string DokumentName)
        {
            Init();
            this.dokumentTitel = dokumentTitel;
            dataGridView1 = dataGridView;
            this.dokument.DocumentName = DokumentenName;
        }

        /// <summary>
        /// Initalisiert eine neue Instanz der Drucker-Klasse.
        /// </summary>
        public Drucken(string dokumentTitel, DataGridView dataGridView, string DokumentName, bool showMessagePrintEnd)
        {
            Init();
            this.dokumentTitel = dokumentTitel;
            dataGridView1 = dataGridView;
            this.dokument.DocumentName = DokumentenName;
            this.showMessagePrintEnd = showMessagePrintEnd;
        }

        /// <summary>
        /// Initalisiert eine neue Instanz der Drucker-Klasse.
        /// </summary>
        public Drucken(string dokumentTitel, DataGridView dataGridView, string DokumentName, bool showMessagePrintEnd, Font schriftart)
        {
            Init();
            this.dokumentTitel = dokumentTitel;
            dataGridView1 = dataGridView;
            this.dokument.DocumentName = DokumentenName;
            this.showMessagePrintEnd = showMessagePrintEnd;
            this.dataGridView1.Font = schriftart;
        }

        /// <summary>
        /// Initalisiert eine neue Instanz der Drucker-Klasse.
        /// </summary>
        public Drucken(string dokumentTitel, DataGridView dataGridView)
        {
            Init();
            this.dokumentTitel = dokumentTitel;
            dataGridView1 = dataGridView;
        }

        #endregion

        #region Events

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    seitenAnzahl++;
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString(dokumentTitel, new Font(dataGridView1.Font, FontStyle.Bold),
                                    titelColor , e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString(dokumentTitel, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dataGridView1.Font, FontStyle.Bold),
                                    titelColor, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString(dokumentTitel, new Font(new Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw SeitenAnzahl
                            e.Graphics.DrawString("Seite " + seitenAnzahl.ToString(), new Font(dataGridView1.Font, FontStyle.Bold),
                                    titelColor, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString("Seite " + seitenAnzahl.ToString(), new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top + dataGridView1.Height - 
                                    e.Graphics.MeasureString(dokumentTitel, new Font(new Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin + 20,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin + 20, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_EndPrint(object sender, PrintEventArgs e)
        {
            if (showMessagePrintEnd)
                MessageBox.Show("Der Druckauftrag wurde erfolgreich ausgeführt.", "Drucker", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Eigenschaften

        /// <summary>
        /// Gibt den Titel der Überschriften zurück, oder ändert ihn.
        /// </summary>
        public string DokumentTitel
        {
            get { return this.dokumentTitel; }
            set { this.dokumentTitel = value; }
        }

        /// <summary>
        /// Gibt die Farbe der Überschrift des Dokument zurück, oder setzt den Wert.
        /// </summary>
        public Brush TitelColor
        {
            get { return this.titelColor; }
            set { this.titelColor = value; }
        }

        /// <summary>
        /// Gibt den Namen des Dokuments zurück, oder ändert es.
        /// </summary>
        public string DokumentenName
        {
            get { return this.dokument.DocumentName; }
            set { this.dokument.DocumentName = value; }
        }

        /// <summary>
        /// Gibt das Dokument zurück, oder ändert es.
        /// </summary>
        public PrintDocument Dokument
        {
            get { return this.dokument; }
            set { this.dokument = value; }
        }

        /// <summary>
        /// Gibt die Einstellung des Druckers zurück, oder ändert es.
        /// </summary>
        public PrinterSettings DruckerEinstellungen
        {
            get { return this.druckereinstellung; }
            set { this.druckereinstellung = value; }
        }

        /// <summary>
        /// Gibt die Einstellung der Seite zurück, oder ändert es.
        /// </summary>
        public PageSettings SeitenEinstellungen
        {
            get { return this.seiteneinstellung; }
            set { this.seiteneinstellung = value; }
        }

        /// <summary>
        /// Gibt die Schrift des Dokuments zurück, oder ändert es.
        /// </summary>
        public Font Schriftart
        {
            get { return this.dataGridView1.Font; }
            set { this.dataGridView1.Font = value; }
        }

        /// <summary>
        /// Gibt einen boolschen Wert zurück, ob am Ende des Druckvorgangs eine Meldung erscheint, oder setzt ihn.
        /// </summary>
        public bool ShowMessagePrintEnd
        {
            get { return this.showMessagePrintEnd; }
            set { this.showMessagePrintEnd = value; }
        }

        /// <summary>
        /// Gibt das PrintDialog-Objekt zurück.
        /// </summary>
        public PrintDialog GetPrintDialog
        {
            get { return this.printDialog; }
        }

        /// <summary>
        /// Gibt das PageSetupDialog-Objekt zurück.
        /// </summary>
        public PageSetupDialog GetPageSetupDialog
        {
            get { return this.pageSetupDialog1; }
        }

        /// <summary>
        /// Gibt das PrintPreviewDialog-Objekt zurück.
        /// </summary>
        public PrintPreviewDialog GetPrintPreviewDialog
        {
            get { return this.printPreviewDialog1; }
        }

        #endregion

        #region Methoden

        /// <summary>
        /// Initalisiert die Drucker-Klasse.
        /// </summary>
        private void Init()
        {
            this.dokument = new PrintDocument();
            this.dokument.DocumentName = "Dokument";
            this.druckereinstellung = new PrinterSettings();
            this.seiteneinstellung = new PageSettings();

            this.titelColor = Brushes.Black;

            this.printDialog = new PrintDialog();
            printDialog.Document = this.dokument;
            printDialog.UseEXDialog = true;

            this.printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = this.dokument;

            pageSetupDialog1 = new PageSetupDialog();
            pageSetupDialog1.Document = this.dokument;

            this.dokument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.dokument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.dokument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
        }

        /// <summary>
        /// Starten den Druckauftrag.
        /// </summary>
        public void Start()
        {
            dokument.Print();
        }

        /// <summary>
        /// Rüft den DrcukerDialog auf.
        /// </summary>
        /// <returns></returns>
        public void ShowDruckerDialog()
        {
            //printDialog.Document = this.dokument;
            //printDialog.UseEXDialog = true;
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                this.dokument.PrinterSettings = printDialog.PrinterSettings;
            }
        }

        /// <summary>
        /// Ruft den SeitenansichtDialog af.
        /// </summary>
        public void ShowSeitenansichtDialog()
        {
            if (DialogResult.OK == printPreviewDialog1.ShowDialog())
            {
            }

        }

        /// <summary>
        /// Ruft den SeitenDiaog auf.
        /// </summary>
        /// <returns></returns>
        public void ShowSeitenDialog()
        {
            if (DialogResult.OK == pageSetupDialog1.ShowDialog())
            {
                this.SeitenEinstellungen = pageSetupDialog1.PageSettings;
            }       
        }

        /// <summary>
        /// Erstellt ein DataGridView und gibt es zurück.
        /// </summary>
        /// <param name="columns">Alle Spalten in einem StringArray.</param>
        /// <param name="liste"></param>
        /// <returns></returns>
        public static DataGridView GetDataGridView(string[] columns, string[,] liste)
        {
            //Neues DataGirdView-Objekt erstellen.
            DataGridView _dataGridView = new DataGridView();

            //DataGridView alle Spalten löschen.
            _dataGridView.Columns.Clear();

            if (columns == null) //Wenn StringArray null ist, dann gibt es ein leeres Objekt zurück.
                return _dataGridView;

            //Spalten hinzufügen.
            for (int i = 0; i < columns.Length; i++)
            {
                _dataGridView.Columns.Add("col" + i, columns[i]);
            }

            //Wenn StringArray null ist, dann gibt es das Objekt zurück.
            if (liste == null)
                return _dataGridView;

            //Zeilen hinzufügen
            for (int i = 0; i < liste.Length - columns.Length; i++)
            {
                string[] listToPrint = new string[liste.Length - columns.Length];
                int count = 0;
                for (int a = 0; a < columns.Length; a++)
                {
                    listToPrint[count] = liste[i, a];
                    count++;
                }

                _dataGridView.Rows.Add(listToPrint);
            }

            return _dataGridView;
        }

        #endregion
    }
}
