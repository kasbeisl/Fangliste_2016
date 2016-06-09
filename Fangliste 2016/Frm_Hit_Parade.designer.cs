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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tbx_fischart = new System.Windows.Forms.ComboBox();
            this.hitparade_HechtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fanglisteDBDataSet = new Fangliste_2016.FanglisteDBDataSet();
            this.tableAdapterManager = new Fangliste_2016.FanglisteDBDataSetTableAdapters.TableAdapterManager();
            this.hitparade_BarschBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hitparade_BarschTableAdapter = new Fangliste_2016.FanglisteDBDataSetTableAdapters.Hitparade_BarschTableAdapter();
            this.hitparade_ZanderTableAdapter1 = new Fangliste_2016.FanglisteDBDataSetTableAdapters.Hitparade_ZanderTableAdapter();
            this.hitparade_AndereTableAdapter = new Fangliste_2016.FanglisteDBDataSetTableAdapters.Hitparade_AndereTableAdapter();
            this.hitparade_AndereBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hitparade_ZanderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hitparade_HechtTableAdapter = new Fangliste_2016.FanglisteDBDataSetTableAdapters.Hitparade_HechtTableAdapter();
            this.hitparade_HechtDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_HechtBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fanglisteDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_BarschBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_AndereBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_ZanderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_HechtDataGridView)).BeginInit();
            this.SuspendLayout();
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
            // hitparade_HechtTableAdapter
            // 
            this.hitparade_HechtTableAdapter.ClearBeforeFill = true;
            // 
            // hitparade_HechtDataGridView
            // 
            this.hitparade_HechtDataGridView.AllowUserToAddRows = false;
            this.hitparade_HechtDataGridView.AllowUserToDeleteRows = false;
            this.hitparade_HechtDataGridView.AllowUserToResizeColumns = false;
            this.hitparade_HechtDataGridView.AllowUserToResizeRows = false;
            this.hitparade_HechtDataGridView.AutoGenerateColumns = false;
            this.hitparade_HechtDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.hitparade_HechtDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.hitparade_HechtDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hitparade_HechtDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.hitparade_HechtDataGridView.DataSource = this.hitparade_HechtBindingSource;
            this.hitparade_HechtDataGridView.Location = new System.Drawing.Point(12, 39);
            this.hitparade_HechtDataGridView.MultiSelect = false;
            this.hitparade_HechtDataGridView.Name = "hitparade_HechtDataGridView";
            this.hitparade_HechtDataGridView.ReadOnly = true;
            this.hitparade_HechtDataGridView.RowHeadersVisible = false;
            this.hitparade_HechtDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.hitparade_HechtDataGridView.RowTemplate.Height = 100;
            this.hitparade_HechtDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.hitparade_HechtDataGridView.ShowCellErrors = false;
            this.hitparade_HechtDataGridView.ShowCellToolTips = false;
            this.hitparade_HechtDataGridView.ShowEditingIcon = false;
            this.hitparade_HechtDataGridView.ShowRowErrors = false;
            this.hitparade_HechtDataGridView.Size = new System.Drawing.Size(1237, 427);
            this.hitparade_HechtDataGridView.TabIndex = 6;
            this.hitparade_HechtDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.hitparade_HechtDataGridView_CellDoubleClick_1);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Platz";
            this.dataGridViewTextBoxColumn1.HeaderText = "Platz";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "Icon";
            this.dataGridViewImageColumn1.HeaderText = "Icon";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Länge";
            this.dataGridViewTextBoxColumn3.HeaderText = "Länge";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Gewicht";
            this.dataGridViewTextBoxColumn4.HeaderText = "Gewicht";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Gewässer";
            this.dataGridViewTextBoxColumn5.HeaderText = "Gewässer";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Datum";
            this.dataGridViewTextBoxColumn6.HeaderText = "Datum";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn7.HeaderText = "Id";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Fischart";
            this.dataGridViewTextBoxColumn8.HeaderText = "Fischart";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // Frm_Hit_Parade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1261, 478);
            this.Controls.Add(this.hitparade_HechtDataGridView);
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
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_HechtBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fanglisteDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_BarschBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_AndereBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_ZanderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hitparade_HechtDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox tbx_fischart;
        private System.Windows.Forms.ImageList imageList1;
        private FanglisteDBDataSet fanglisteDBDataSet;
        private FanglisteDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource hitparade_HechtBindingSource;
        private System.Windows.Forms.BindingSource hitparade_BarschBindingSource;
        private FanglisteDBDataSetTableAdapters.Hitparade_BarschTableAdapter hitparade_BarschTableAdapter;
        private FanglisteDBDataSetTableAdapters.Hitparade_ZanderTableAdapter hitparade_ZanderTableAdapter1;
        private FanglisteDBDataSetTableAdapters.Hitparade_AndereTableAdapter hitparade_AndereTableAdapter;
        private System.Windows.Forms.BindingSource hitparade_AndereBindingSource;
        private System.Windows.Forms.BindingSource hitparade_ZanderBindingSource;
        private FanglisteDBDataSetTableAdapters.Hitparade_HechtTableAdapter hitparade_HechtTableAdapter;
        private System.Windows.Forms.DataGridView hitparade_HechtDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}