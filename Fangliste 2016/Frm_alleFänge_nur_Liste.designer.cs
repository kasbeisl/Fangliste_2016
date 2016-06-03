namespace Fangliste_2016
{
    partial class Frm_alleFänge_nur_Liste
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listAlle_fänge = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFischart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGröße = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGewicht = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGewässer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDatum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUhrzeit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlatzbeschreibung = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKöderbeschreibung = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTiefe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTemperatur = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWetter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alleAuswählenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alleAufhebenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label_exportieren = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listAlle_fänge
            // 
            this.listAlle_fänge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listAlle_fänge.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colFischart,
            this.colGröße,
            this.colGewicht,
            this.colGewässer,
            this.colDatum,
            this.colUhrzeit,
            this.colPlatzbeschreibung,
            this.colKöderbeschreibung,
            this.colTiefe,
            this.colTemperatur,
            this.colWetter});
            this.listAlle_fänge.ContextMenuStrip = this.contextMenuStrip1;
            this.listAlle_fänge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listAlle_fänge.FullRowSelect = true;
            this.listAlle_fänge.GridLines = true;
            this.listAlle_fänge.Location = new System.Drawing.Point(0, 0);
            this.listAlle_fänge.Name = "listAlle_fänge";
            this.listAlle_fänge.Size = new System.Drawing.Size(853, 314);
            this.listAlle_fänge.TabIndex = 7;
            this.listAlle_fänge.UseCompatibleStateImageBehavior = false;
            this.listAlle_fänge.View = System.Windows.Forms.View.Details;
            this.listAlle_fänge.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listAlle_fänge_ColumnClick);
            this.listAlle_fänge.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listAlle_fänge_ItemChecked);
            this.listAlle_fänge.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listAlle_fänge_MouseClick);
            this.listAlle_fänge.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listAlle_fänge_MouseDoubleClick);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 112;
            // 
            // colFischart
            // 
            this.colFischart.Text = "Fischart";
            this.colFischart.Width = 89;
            // 
            // colGröße
            // 
            this.colGröße.Text = "Größe [cm]";
            this.colGröße.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colGröße.Width = 89;
            // 
            // colGewicht
            // 
            this.colGewicht.Text = "Gewicht [kg]";
            this.colGewicht.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colGewicht.Width = 98;
            // 
            // colGewässer
            // 
            this.colGewässer.Text = "Gewässer";
            this.colGewässer.Width = 165;
            // 
            // colDatum
            // 
            this.colDatum.Text = "Datum";
            this.colDatum.Width = 88;
            // 
            // colUhrzeit
            // 
            this.colUhrzeit.Text = "Uhrzeit";
            this.colUhrzeit.Width = 63;
            // 
            // colPlatzbeschreibung
            // 
            this.colPlatzbeschreibung.Text = "Platzbescheibung";
            this.colPlatzbeschreibung.Width = 136;
            // 
            // colKöderbeschreibung
            // 
            this.colKöderbeschreibung.Text = "Köderbeschreibung";
            this.colKöderbeschreibung.Width = 150;
            // 
            // colTiefe
            // 
            this.colTiefe.Text = "Tiefe [m]";
            this.colTiefe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTiefe.Width = 76;
            // 
            // colTemperatur
            // 
            this.colTemperatur.Text = "Temp. [°C]";
            this.colTemperatur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTemperatur.Width = 86;
            // 
            // colWetter
            // 
            this.colWetter.Text = "Wetter";
            this.colWetter.Width = 100;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alleAuswählenToolStripMenuItem,
            this.alleAufhebenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 48);
            // 
            // alleAuswählenToolStripMenuItem
            // 
            this.alleAuswählenToolStripMenuItem.Name = "alleAuswählenToolStripMenuItem";
            this.alleAuswählenToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.alleAuswählenToolStripMenuItem.Text = "Alle auswählen";
            this.alleAuswählenToolStripMenuItem.Click += new System.EventHandler(this.alleAuswählenToolStripMenuItem_Click);
            // 
            // alleAufhebenToolStripMenuItem
            // 
            this.alleAufhebenToolStripMenuItem.Name = "alleAufhebenToolStripMenuItem";
            this.alleAufhebenToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.alleAufhebenToolStripMenuItem.Text = "Alle aufheben";
            this.alleAufhebenToolStripMenuItem.Click += new System.EventHandler(this.alleAufhebenToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label_exportieren});
            this.statusStrip1.Location = new System.Drawing.Point(0, 316);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(853, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // label_exportieren
            // 
            this.label_exportieren.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.label_exportieren.IsLink = true;
            this.label_exportieren.Name = "label_exportieren";
            this.label_exportieren.Size = new System.Drawing.Size(66, 17);
            this.label_exportieren.Text = "exportieren";
            this.label_exportieren.Click += new System.EventHandler(this.label_exportieren_Click);
            // 
            // Frm_alleFänge_nur_Liste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 338);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listAlle_fänge);
            this.MinimizeBox = false;
            this.Name = "Frm_alleFänge_nur_Liste";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alle Fänge";
            this.Load += new System.EventHandler(this.Frm_alleFänge_nur_Liste_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListView listAlle_fänge;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colFischart;
        private System.Windows.Forms.ColumnHeader colGröße;
        private System.Windows.Forms.ColumnHeader colGewicht;
        private System.Windows.Forms.ColumnHeader colGewässer;
        private System.Windows.Forms.ColumnHeader colDatum;
        private System.Windows.Forms.ColumnHeader colUhrzeit;
        private System.Windows.Forms.ColumnHeader colPlatzbeschreibung;
        private System.Windows.Forms.ColumnHeader colKöderbeschreibung;
        private System.Windows.Forms.ColumnHeader colTiefe;
        private System.Windows.Forms.ColumnHeader colTemperatur;
        private System.Windows.Forms.ColumnHeader colWetter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem alleAuswählenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alleAufhebenToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel label_exportieren;
    }
}