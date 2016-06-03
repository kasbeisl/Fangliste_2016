namespace Fangliste_2016
{
    partial class Frm_Fotoliste
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.colFotoNR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFischerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFischart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGröße = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGewicht = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGewässer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDatum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateiname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUhrzeit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fotoAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.alleAuswählenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keineAuswahlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFotoNR,
            this.colFischerName,
            this.colFischart,
            this.colGröße,
            this.colGewicht,
            this.colGewässer,
            this.colDatum,
            this.colDateiname,
            this.colUhrzeit});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1152, 568);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            this.listView1.MouseEnter += new System.EventHandler(this.listView1_MouseEnter);
            this.listView1.MouseLeave += new System.EventHandler(this.listView1_MouseLeave);
            // 
            // colFotoNR
            // 
            this.colFotoNR.Text = "Foto Nr.";
            this.colFotoNR.Width = 69;
            // 
            // colFischerName
            // 
            this.colFischerName.Text = "Name";
            this.colFischerName.Width = 157;
            // 
            // colFischart
            // 
            this.colFischart.Text = "Fischart";
            this.colFischart.Width = 133;
            // 
            // colGröße
            // 
            this.colGröße.Text = "Größe";
            this.colGröße.Width = 73;
            // 
            // colGewicht
            // 
            this.colGewicht.Text = "Gewicht";
            this.colGewicht.Width = 79;
            // 
            // colGewässer
            // 
            this.colGewässer.Text = "Gewässer";
            this.colGewässer.Width = 126;
            // 
            // colDatum
            // 
            this.colDatum.Text = "Datum";
            this.colDatum.Width = 119;
            // 
            // colDateiname
            // 
            this.colDateiname.Text = "Dateiname";
            this.colDateiname.Width = 316;
            // 
            // colUhrzeit
            // 
            this.colUhrzeit.Text = "Uhrzeit";
            this.colUhrzeit.Width = 72;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fotoAToolStripMenuItem,
            this.toolStripSeparator1,
            this.alleAuswählenToolStripMenuItem,
            this.keineAuswahlToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 76);
            // 
            // fotoAToolStripMenuItem
            // 
            this.fotoAToolStripMenuItem.Name = "fotoAToolStripMenuItem";
            this.fotoAToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.fotoAToolStripMenuItem.Text = "Foto Anzeigen";
            this.fotoAToolStripMenuItem.Click += new System.EventHandler(this.fotoAToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // alleAuswählenToolStripMenuItem
            // 
            this.alleAuswählenToolStripMenuItem.Name = "alleAuswählenToolStripMenuItem";
            this.alleAuswählenToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.alleAuswählenToolStripMenuItem.Text = "Alle auswählen";
            this.alleAuswählenToolStripMenuItem.Click += new System.EventHandler(this.alleAuswählenToolStripMenuItem_Click);
            // 
            // keineAuswahlToolStripMenuItem
            // 
            this.keineAuswahlToolStripMenuItem.Name = "keineAuswahlToolStripMenuItem";
            this.keineAuswahlToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.keineAuswahlToolStripMenuItem.Text = "Alle aufheben";
            this.keineAuswahlToolStripMenuItem.Click += new System.EventHandler(this.keineAuswahlToolStripMenuItem_Click);
            // 
            // Frm_Fotoliste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1152, 568);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Fotoliste";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fotoliste";
            this.Load += new System.EventHandler(this.Frm_Fotoliste_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colFischerName;
        private System.Windows.Forms.ColumnHeader colFischart;
        private System.Windows.Forms.ColumnHeader colGröße;
        private System.Windows.Forms.ColumnHeader colGewicht;
        private System.Windows.Forms.ColumnHeader colGewässer;
        private System.Windows.Forms.ColumnHeader colDatum;
        private System.Windows.Forms.ColumnHeader colDateiname;
        private System.Windows.Forms.ColumnHeader colUhrzeit;
        private System.Windows.Forms.ColumnHeader colFotoNR;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fotoAToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem alleAuswählenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keineAuswahlToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}