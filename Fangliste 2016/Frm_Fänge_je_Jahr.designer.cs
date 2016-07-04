namespace Fangliste_2016
{
    partial class Frm_Fänge_je_Jahr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Fänge_je_Jahr));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fotoAnzeigenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_jahr = new System.Windows.Forms.ComboBox();
            this.label_gesanzahl = new System.Windows.Forms.Label();
            this.label_ges_anzahl = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fanglisteDBDataSet = new Fangliste_2016.FanglisteDBDataSet();
            this.tableAdapterManager = new Fangliste_2016.FanglisteDBDataSetTableAdapters.TableAdapterManager();
            this.fänge_Je_JahrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fänge_Je_JahrTableAdapter = new Fangliste_2016.FanglisteDBDataSetTableAdapters.Fänge_Je_JahrTableAdapter();
            this.fänge_Je_JahrDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fanglisteDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fänge_Je_JahrBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fänge_Je_JahrDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fotoAnzeigenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 26);
            // 
            // fotoAnzeigenToolStripMenuItem
            // 
            this.fotoAnzeigenToolStripMenuItem.Name = "fotoAnzeigenToolStripMenuItem";
            this.fotoAnzeigenToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.fotoAnzeigenToolStripMenuItem.Text = "Foto Anzeigen";
            this.fotoAnzeigenToolStripMenuItem.Click += new System.EventHandler(this.fotoAnzeigenToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(64, 64);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.comboBox_jahr);
            this.groupBox1.Controls.Add(this.label_gesanzahl);
            this.groupBox1.Controls.Add(this.label_ges_anzahl);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1219, 61);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // comboBox_jahr
            // 
            this.comboBox_jahr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_jahr.FormattingEnabled = true;
            this.comboBox_jahr.Location = new System.Drawing.Point(223, 13);
            this.comboBox_jahr.Name = "comboBox_jahr";
            this.comboBox_jahr.Size = new System.Drawing.Size(121, 21);
            this.comboBox_jahr.Sorted = true;
            this.comboBox_jahr.TabIndex = 15;
            this.comboBox_jahr.SelectionChangeCommitted += new System.EventHandler(this.comboBox_jahr_SelectionChangeCommitted);
            // 
            // label_gesanzahl
            // 
            this.label_gesanzahl.AutoSize = true;
            this.label_gesanzahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_gesanzahl.Location = new System.Drawing.Point(123, 16);
            this.label_gesanzahl.Name = "label_gesanzahl";
            this.label_gesanzahl.Size = new System.Drawing.Size(16, 18);
            this.label_gesanzahl.TabIndex = 13;
            this.label_gesanzahl.Text = "0";
            // 
            // label_ges_anzahl
            // 
            this.label_ges_anzahl.AutoSize = true;
            this.label_ges_anzahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ges_anzahl.Location = new System.Drawing.Point(9, 16);
            this.label_ges_anzahl.Name = "label_ges_anzahl";
            this.label_ges_anzahl.Size = new System.Drawing.Size(108, 18);
            this.label_ges_anzahl.TabIndex = 12;
            this.label_ges_anzahl.Text = "Gesamtanzahl:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.fänge_Je_JahrDataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.81759F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.18241F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1225, 865);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // fanglisteDBDataSet
            // 
            this.fanglisteDBDataSet.DataSetName = "FanglisteDBDataSet";
            this.fanglisteDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.tableAdapterManager.LinkTableAdapter = null;
            this.tableAdapterManager.OrdnerTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Fangliste_2016.FanglisteDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // fänge_Je_JahrBindingSource
            // 
            this.fänge_Je_JahrBindingSource.DataMember = "Fänge_Je_Jahr";
            this.fänge_Je_JahrBindingSource.DataSource = this.fanglisteDBDataSet;
            // 
            // fänge_Je_JahrTableAdapter
            // 
            this.fänge_Je_JahrTableAdapter.ClearBeforeFill = true;
            // 
            // fänge_Je_JahrDataGridView
            // 
            this.fänge_Je_JahrDataGridView.AllowUserToAddRows = false;
            this.fänge_Je_JahrDataGridView.AutoGenerateColumns = false;
            this.fänge_Je_JahrDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fänge_Je_JahrDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.fänge_Je_JahrDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fänge_Je_JahrDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
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
            this.dataGridViewTextBoxColumn15});
            this.fänge_Je_JahrDataGridView.DataSource = this.fänge_Je_JahrBindingSource;
            this.fänge_Je_JahrDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fänge_Je_JahrDataGridView.Location = new System.Drawing.Point(3, 70);
            this.fänge_Je_JahrDataGridView.MultiSelect = false;
            this.fänge_Je_JahrDataGridView.Name = "fänge_Je_JahrDataGridView";
            this.fänge_Je_JahrDataGridView.ReadOnly = true;
            this.fänge_Je_JahrDataGridView.RowHeadersVisible = false;
            this.fänge_Je_JahrDataGridView.RowTemplate.Height = 100;
            this.fänge_Je_JahrDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fänge_Je_JahrDataGridView.ShowCellErrors = false;
            this.fänge_Je_JahrDataGridView.ShowCellToolTips = false;
            this.fänge_Je_JahrDataGridView.ShowEditingIcon = false;
            this.fänge_Je_JahrDataGridView.ShowRowErrors = false;
            this.fänge_Je_JahrDataGridView.Size = new System.Drawing.Size(1219, 792);
            this.fänge_Je_JahrDataGridView.TabIndex = 6;
            this.fänge_Je_JahrDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fänge_Je_JahrDataGridView_CellDoubleClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "Icon";
            this.dataGridViewImageColumn1.HeaderText = "Icon";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Fischart";
            this.dataGridViewTextBoxColumn2.HeaderText = "Fischart";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Länge";
            this.dataGridViewTextBoxColumn3.HeaderText = "Länge";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Gewicht";
            this.dataGridViewTextBoxColumn4.HeaderText = "Gewicht";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Gewässer";
            this.dataGridViewTextBoxColumn5.HeaderText = "Gewässer";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Datum";
            this.dataGridViewTextBoxColumn6.HeaderText = "Datum";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Uhrzeit";
            this.dataGridViewTextBoxColumn7.HeaderText = "Uhrzeit";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Angelplatz";
            this.dataGridViewTextBoxColumn8.HeaderText = "Angelplatz";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Köder";
            this.dataGridViewTextBoxColumn9.HeaderText = "Köder";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Tiefe";
            this.dataGridViewTextBoxColumn10.HeaderText = "Tiefe";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Lufttemperatur";
            this.dataGridViewTextBoxColumn11.HeaderText = "Lufttemperatur";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Wassertemperatur";
            this.dataGridViewTextBoxColumn12.HeaderText = "Wassertemperatur";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Wetter";
            this.dataGridViewTextBoxColumn13.HeaderText = "Wetter";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Kommentar";
            this.dataGridViewTextBoxColumn14.HeaderText = "Kommentar";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn15.HeaderText = "Id";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // Frm_Fänge_je_Jahr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1225, 865);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "Frm_Fänge_je_Jahr";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aktuelle Jahresfänge";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Fänge_je_Jahr_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fanglisteDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fänge_Je_JahrBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fänge_Je_JahrDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fotoAnzeigenToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private FanglisteDBDataSet fanglisteDBDataSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_jahr;
        private System.Windows.Forms.Label label_gesanzahl;
        private System.Windows.Forms.Label label_ges_anzahl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FanglisteDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource fänge_Je_JahrBindingSource;
        private FanglisteDBDataSetTableAdapters.Fänge_Je_JahrTableAdapter fänge_Je_JahrTableAdapter;
        private System.Windows.Forms.DataGridView fänge_Je_JahrDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
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
    }
}