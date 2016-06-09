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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alleAuswählenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alleAufhebenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label_exportieren = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.listAlle_fänge = new System.Windows.Forms.ListView();
            this.alleFängeNurListeDataGridView = new System.Windows.Forms.DataGridView();
            this.alleFängeNurListeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fanglisteDBDataSet = new Fangliste_2016.FanglisteDBDataSet();
            this.alleFängeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.alleFängeTableAdapter = new Fangliste_2016.FanglisteDBDataSetTableAdapters.AlleFängeTableAdapter();
            this.tableAdapterManager = new Fangliste_2016.FanglisteDBDataSetTableAdapters.TableAdapterManager();
            this.alleFängeNurListeTableAdapter = new Fangliste_2016.FanglisteDBDataSetTableAdapters.AlleFängeNurListeTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alleFängeNurListeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alleFängeNurListeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fanglisteDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alleFängeBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 542);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(873, 22);
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
            this.listAlle_fänge.Size = new System.Drawing.Size(893, 768);
            this.listAlle_fänge.TabIndex = 7;
            this.listAlle_fänge.UseCompatibleStateImageBehavior = false;
            this.listAlle_fänge.View = System.Windows.Forms.View.Details;
            this.listAlle_fänge.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listAlle_fänge_ColumnClick);
            this.listAlle_fänge.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listAlle_fänge_ItemChecked);
            this.listAlle_fänge.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listAlle_fänge_MouseClick);
            this.listAlle_fänge.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listAlle_fänge_MouseDoubleClick);
            // 
            // alleFängeNurListeDataGridView
            // 
            this.alleFängeNurListeDataGridView.AllowUserToAddRows = false;
            this.alleFängeNurListeDataGridView.AllowUserToDeleteRows = false;
            this.alleFängeNurListeDataGridView.AllowUserToResizeColumns = false;
            this.alleFängeNurListeDataGridView.AllowUserToResizeRows = false;
            this.alleFängeNurListeDataGridView.AutoGenerateColumns = false;
            this.alleFängeNurListeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.alleFängeNurListeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.alleFängeNurListeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16});
            this.alleFängeNurListeDataGridView.DataSource = this.alleFängeNurListeBindingSource;
            this.alleFängeNurListeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alleFängeNurListeDataGridView.Location = new System.Drawing.Point(0, 0);
            this.alleFängeNurListeDataGridView.MultiSelect = false;
            this.alleFängeNurListeDataGridView.Name = "alleFängeNurListeDataGridView";
            this.alleFängeNurListeDataGridView.ReadOnly = true;
            this.alleFängeNurListeDataGridView.RowHeadersVisible = false;
            this.alleFängeNurListeDataGridView.RowTemplate.Height = 100;
            this.alleFängeNurListeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.alleFängeNurListeDataGridView.ShowCellErrors = false;
            this.alleFängeNurListeDataGridView.ShowCellToolTips = false;
            this.alleFängeNurListeDataGridView.ShowEditingIcon = false;
            this.alleFängeNurListeDataGridView.ShowRowErrors = false;
            this.alleFängeNurListeDataGridView.Size = new System.Drawing.Size(893, 792);
            this.alleFängeNurListeDataGridView.TabIndex = 8;
            this.alleFängeNurListeDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.alleFängeNurListeDataGridView_CellDoubleClick);
            // 
            // alleFängeNurListeBindingSource
            // 
            this.alleFängeNurListeBindingSource.DataMember = "AlleFängeNurListe";
            this.alleFängeNurListeBindingSource.DataSource = this.fanglisteDBDataSet;
            // 
            // fanglisteDBDataSet
            // 
            this.fanglisteDBDataSet.DataSetName = "FanglisteDBDataSet";
            this.fanglisteDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // alleFängeBindingSource
            // 
            this.alleFängeBindingSource.DataMember = "AlleFänge";
            this.alleFängeBindingSource.DataSource = this.fanglisteDBDataSet;
            // 
            // alleFängeTableAdapter
            // 
            this.alleFängeTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AnglerTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.FangTableAdapter = null;
            this.tableAdapterManager.FischTableAdapter = null;
            this.tableAdapterManager.FotoTableAdapter = null;
            this.tableAdapterManager.GewässerTableAdapter = null;
            this.tableAdapterManager.OrdnerTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Fangliste_2016.FanglisteDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // alleFängeNurListeTableAdapter
            // 
            this.alleFängeNurListeTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Fang_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Fang_ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 54;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Angler_ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Angler_ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "Icon";
            this.dataGridViewImageColumn1.HeaderText = "Icon";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 34;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Fischart";
            this.dataGridViewTextBoxColumn4.HeaderText = "Fischart";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 69;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Länge";
            this.dataGridViewTextBoxColumn5.HeaderText = "Länge";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 62;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Gewicht";
            this.dataGridViewTextBoxColumn6.HeaderText = "Gewicht";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 71;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Gewässer";
            this.dataGridViewTextBoxColumn7.HeaderText = "Gewässer";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 79;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Datum";
            this.dataGridViewTextBoxColumn8.HeaderText = "Datum";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 63;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Uhrzeit";
            this.dataGridViewTextBoxColumn9.HeaderText = "Uhrzeit";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 65;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Angelplatz";
            this.dataGridViewTextBoxColumn10.HeaderText = "Angelplatz";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 81;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Köder";
            this.dataGridViewTextBoxColumn11.HeaderText = "Köder";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 60;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Tiefe";
            this.dataGridViewTextBoxColumn12.HeaderText = "Tiefe";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 56;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Lufttemperatur";
            this.dataGridViewTextBoxColumn13.HeaderText = "Lufttemperatur";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Wassertemperatur";
            this.dataGridViewTextBoxColumn14.HeaderText = "Wassertemperatur";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 118;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Wetter";
            this.dataGridViewTextBoxColumn15.HeaderText = "Wetter";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 64;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Kommentar";
            this.dataGridViewTextBoxColumn16.HeaderText = "Kommentar";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 85;
            // 
            // Frm_alleFänge_nur_Liste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 792);
            this.Controls.Add(this.alleFängeNurListeDataGridView);
            this.Controls.Add(this.listAlle_fänge);
            this.Controls.Add(this.statusStrip1);
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
            ((System.ComponentModel.ISupportInitialize)(this.alleFängeNurListeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alleFängeNurListeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fanglisteDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alleFängeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem alleAuswählenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alleAufhebenToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel label_exportieren;
        private FanglisteDBDataSet fanglisteDBDataSet;
        private System.Windows.Forms.BindingSource alleFängeBindingSource;
        private FanglisteDBDataSetTableAdapters.AlleFängeTableAdapter alleFängeTableAdapter;
        private FanglisteDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
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
        public System.Windows.Forms.ListView listAlle_fänge;
        private System.Windows.Forms.BindingSource alleFängeNurListeBindingSource;
        private FanglisteDBDataSetTableAdapters.AlleFängeNurListeTableAdapter alleFängeNurListeTableAdapter;
        private System.Windows.Forms.DataGridView alleFängeNurListeDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
    }
}