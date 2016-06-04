namespace Fangliste_2016
{
    partial class Frm_Hit_Parade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Hit_Parade));
            this.listHecht = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tbx_fischart = new System.Windows.Forms.ComboBox();
            this.hitparade_HechtDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hitparade_HechtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fanglisteDBDataSet = new Fangliste_2016.FanglisteDBDataSet();
            this.tableAdapterManager = new Fangliste_2016.FanglisteDBDataSetTableAdapters.TableAdapterManager();
            this.hitparade_HechtTableAdapter = new Fangliste_2016.FanglisteDBDataSetTableAdapters.Hitparade_HechtTableAdapter();
            this.hitparade_BarschBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hitparade_BarschTableAdapter = new Fangliste_2016.FanglisteDBDataSetTableAdapters.Hitparade_BarschTableAdapter();
            this.hitparade_ZanderTableAdapter1 = new Fangliste_2016.FanglisteDBDataSetTableAdapters.Hitparade_ZanderTableAdapter();
            this.hitparade_AndereTableAdapter = new Fangliste_2016.FanglisteDBDataSetTableAdapters.Hitparade_AndereTableAdapter();
            this.hitparade_AndereBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hitparade_ZanderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_HechtDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_HechtBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fanglisteDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_BarschBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_AndereBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_ZanderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listHecht
            // 
            this.listHecht.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listHecht.AutoArrange = false;
            this.listHecht.BackColor = System.Drawing.SystemColors.Window;
            this.listHecht.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.listHecht.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listHecht.FullRowSelect = true;
            this.listHecht.GridLines = true;
            this.listHecht.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listHecht.LabelWrap = false;
            this.listHecht.LargeImageList = this.imageList1;
            this.listHecht.Location = new System.Drawing.Point(24, 30);
            this.listHecht.MultiSelect = false;
            this.listHecht.Name = "listHecht";
            this.listHecht.ShowGroups = false;
            this.listHecht.Size = new System.Drawing.Size(1217, 428);
            this.listHecht.SmallImageList = this.imageList1;
            this.listHecht.StateImageList = this.imageList1;
            this.listHecht.TabIndex = 0;
            this.listHecht.UseCompatibleStateImageBehavior = false;
            this.listHecht.View = System.Windows.Forms.View.Details;
            this.listHecht.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listHecht_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Image";
            this.columnHeader1.Width = 224;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Platz";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 95;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Name";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 198;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Größe [cm]";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 107;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Gewicht [kg]";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 116;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Gewässer";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 302;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Datum";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader12.Width = 194;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(64, 64);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tbx_fischart
            // 
            this.tbx_fischart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbx_fischart.FormattingEnabled = true;
            this.tbx_fischart.Items.AddRange(new object[] {
            "Hecht",
            "Zander",
            "Barsch",
            "Andere"});
            this.tbx_fischart.Location = new System.Drawing.Point(481, 3);
            this.tbx_fischart.Name = "tbx_fischart";
            this.tbx_fischart.Size = new System.Drawing.Size(270, 21);
            this.tbx_fischart.TabIndex = 6;
            this.tbx_fischart.SelectedIndexChanged += new System.EventHandler(this.tbx_fischart_SelectedIndexChanged);
            // 
            // hitparade_HechtDataGridView
            // 
            this.hitparade_HechtDataGridView.AllowUserToAddRows = false;
            this.hitparade_HechtDataGridView.AutoGenerateColumns = false;
            this.hitparade_HechtDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.hitparade_HechtDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.hitparade_HechtDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hitparade_HechtDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.hitparade_HechtDataGridView.DataSource = this.hitparade_HechtBindingSource;
            this.hitparade_HechtDataGridView.Location = new System.Drawing.Point(24, 30);
            this.hitparade_HechtDataGridView.MultiSelect = false;
            this.hitparade_HechtDataGridView.Name = "hitparade_HechtDataGridView";
            this.hitparade_HechtDataGridView.ReadOnly = true;
            this.hitparade_HechtDataGridView.RowHeadersVisible = false;
            this.hitparade_HechtDataGridView.RowTemplate.Height = 100;
            this.hitparade_HechtDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.hitparade_HechtDataGridView.ShowCellErrors = false;
            this.hitparade_HechtDataGridView.ShowCellToolTips = false;
            this.hitparade_HechtDataGridView.ShowEditingIcon = false;
            this.hitparade_HechtDataGridView.ShowRowErrors = false;
            this.hitparade_HechtDataGridView.Size = new System.Drawing.Size(1217, 428);
            this.hitparade_HechtDataGridView.TabIndex = 6;
            this.hitparade_HechtDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.hitparade_HechtDataGridView_CellMouseDoubleClick);
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
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Länge";
            this.dataGridViewTextBoxColumn2.HeaderText = "Länge";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Gewicht";
            this.dataGridViewTextBoxColumn3.HeaderText = "Gewicht";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Gewässer";
            this.dataGridViewTextBoxColumn4.HeaderText = "Gewässer";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Datum";
            this.dataGridViewTextBoxColumn5.HeaderText = "Datum";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // hitparade_HechtBindingSource
            // 
            this.hitparade_HechtBindingSource.DataMember = "Hitparade_Hecht";
            this.hitparade_HechtBindingSource.DataSource = this.fanglisteDBDataSet;
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
            this.tableAdapterManager.OrdnerTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Fangliste_2016.FanglisteDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // hitparade_HechtTableAdapter
            // 
            this.hitparade_HechtTableAdapter.ClearBeforeFill = true;
            // 
            // hitparade_BarschBindingSource
            // 
            this.hitparade_BarschBindingSource.DataMember = "Hitparade_Barsch";
            this.hitparade_BarschBindingSource.DataSource = this.fanglisteDBDataSet;
            // 
            // hitparade_BarschTableAdapter
            // 
            this.hitparade_BarschTableAdapter.ClearBeforeFill = true;
            // 
            // hitparade_ZanderTableAdapter1
            // 
            this.hitparade_ZanderTableAdapter1.ClearBeforeFill = true;
            // 
            // hitparade_AndereTableAdapter
            // 
            this.hitparade_AndereTableAdapter.ClearBeforeFill = true;
            // 
            // hitparade_AndereBindingSource
            // 
            this.hitparade_AndereBindingSource.DataMember = "Hitparade_Andere";
            this.hitparade_AndereBindingSource.DataSource = this.fanglisteDBDataSet;
            // 
            // hitparade_ZanderBindingSource
            // 
            this.hitparade_ZanderBindingSource.DataMember = "Hitparade_Zander";
            this.hitparade_ZanderBindingSource.DataSource = this.fanglisteDBDataSet;
            // 
            // Frm_Hit_Parade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1261, 478);
            this.Controls.Add(this.hitparade_HechtDataGridView);
            this.Controls.Add(this.listHecht);
            this.Controls.Add(this.tbx_fischart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Hit_Parade";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hitparade";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Hit_Parade_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Hit_Parade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_HechtDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_HechtBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fanglisteDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_BarschBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_AndereBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_ZanderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ComboBox tbx_fischart;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listHecht;
        private FanglisteDBDataSet fanglisteDBDataSet;
        private FanglisteDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource hitparade_HechtBindingSource;
        private FanglisteDBDataSetTableAdapters.Hitparade_HechtTableAdapter hitparade_HechtTableAdapter;
        private System.Windows.Forms.DataGridView hitparade_HechtDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource hitparade_BarschBindingSource;
        private FanglisteDBDataSetTableAdapters.Hitparade_BarschTableAdapter hitparade_BarschTableAdapter;
        private FanglisteDBDataSetTableAdapters.Hitparade_ZanderTableAdapter hitparade_ZanderTableAdapter1;
        private FanglisteDBDataSetTableAdapters.Hitparade_AndereTableAdapter hitparade_AndereTableAdapter;
        private System.Windows.Forms.BindingSource hitparade_AndereBindingSource;
        private System.Windows.Forms.BindingSource hitparade_ZanderBindingSource;
    }
}