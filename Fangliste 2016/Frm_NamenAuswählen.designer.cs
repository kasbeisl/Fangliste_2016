namespace Fangliste_2016
{
    partial class Frm_NamenAuswählen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_NamenAuswählen));
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.namenHinzufügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.namenLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView_Fischer = new System.Windows.Forms.ListView();
            this.imageList_Fischer = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_hinzufügen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_löschen = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.namenHinzufügenToolStripMenuItem,
            this.namenLöschenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 48);
            // 
            // namenHinzufügenToolStripMenuItem
            // 
            this.namenHinzufügenToolStripMenuItem.Name = "namenHinzufügenToolStripMenuItem";
            this.namenHinzufügenToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.namenHinzufügenToolStripMenuItem.Text = "Fischer Hinzufügen";
            this.namenHinzufügenToolStripMenuItem.Click += new System.EventHandler(this.namenHinzufügenToolStripMenuItem_Click);
            // 
            // namenLöschenToolStripMenuItem
            // 
            this.namenLöschenToolStripMenuItem.Enabled = false;
            this.namenLöschenToolStripMenuItem.Name = "namenLöschenToolStripMenuItem";
            this.namenLöschenToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.namenLöschenToolStripMenuItem.Text = "Fischer Löschen";
            this.namenLöschenToolStripMenuItem.Click += new System.EventHandler(this.namenLöschenToolStripMenuItem_Click);
            // 
            // listView_Fischer
            // 
            this.listView_Fischer.AllowDrop = true;
            this.listView_Fischer.BackgroundImageTiled = true;
            this.listView_Fischer.ContextMenuStrip = this.contextMenuStrip1;
            this.listView_Fischer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Fischer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.listView_Fischer.ForeColor = System.Drawing.SystemColors.MenuText;
            this.listView_Fischer.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_Fischer.LargeImageList = this.imageList_Fischer;
            this.listView_Fischer.Location = new System.Drawing.Point(0, 0);
            this.listView_Fischer.MultiSelect = false;
            this.listView_Fischer.Name = "listView_Fischer";
            this.listView_Fischer.ShowItemToolTips = true;
            this.listView_Fischer.Size = new System.Drawing.Size(689, 358);
            this.listView_Fischer.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_Fischer.TabIndex = 11;
            this.listView_Fischer.UseCompatibleStateImageBehavior = false;
            this.listView_Fischer.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView_Fischer_DrawItem);
            this.listView_Fischer.SelectedIndexChanged += new System.EventHandler(this.listView_Fischer_SelectedIndexChanged);
            this.listView_Fischer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView_Fischer_KeyPress);
            this.listView_Fischer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_Fischer_MouseDoubleClick);
            this.listView_Fischer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView_Fischer_MouseDown);
            this.listView_Fischer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView_Fischer_MouseMove);
            this.listView_Fischer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView_Fischer_MouseUp);
            // 
            // imageList_Fischer
            // 
            this.imageList_Fischer.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList_Fischer.ImageSize = new System.Drawing.Size(128, 128);
            this.imageList_Fischer.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_hinzufügen,
            this.toolStripButton_löschen});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(689, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_hinzufügen
            // 
            this.toolStripButton_hinzufügen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButton_hinzufügen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_hinzufügen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_hinzufügen.Image")));
            this.toolStripButton_hinzufügen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_hinzufügen.Name = "toolStripButton_hinzufügen";
            this.toolStripButton_hinzufügen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_hinzufügen.Text = "Hinzufügen";
            this.toolStripButton_hinzufügen.Click += new System.EventHandler(this.toolStripButton_hinzufügen_Click);
            // 
            // toolStripButton_löschen
            // 
            this.toolStripButton_löschen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButton_löschen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_löschen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_löschen.Image")));
            this.toolStripButton_löschen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_löschen.Name = "toolStripButton_löschen";
            this.toolStripButton_löschen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_löschen.Text = "Löschen";
            this.toolStripButton_löschen.Click += new System.EventHandler(this.toolStripButton_löschen_Click);
            // 
            // Frm_NamenAuswählen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(689, 358);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listView_Fischer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_NamenAuswählen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wählen Sie Ihren Name aus.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_NamenAuswählen_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_NamenAuswählen_FormClosed);
            this.Load += new System.EventHandler(this.Frm_NamenAuswählen_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem namenHinzufügenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem namenLöschenToolStripMenuItem;
        private System.Windows.Forms.ListView listView_Fischer;
        private System.Windows.Forms.ImageList imageList_Fischer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_hinzufügen;
        private System.Windows.Forms.ToolStripButton toolStripButton_löschen;
    }
}

