namespace Fangliste_2016
{
    partial class Frm_Files
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kopierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einfügentoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.löschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_ok = new System.Windows.Forms.Button();
            this.cb_filetyp = new System.Windows.Forms.ComboBox();
            this.tbx_neueDatei = new System.Windows.Forms.TextBox();
            this.btn_neueDatei = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(13, 41);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(272, 308);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kopierenToolStripMenuItem,
            this.einfügentoolStripMenuItem,
            this.löschenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(122, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // kopierenToolStripMenuItem
            // 
            this.kopierenToolStripMenuItem.Name = "kopierenToolStripMenuItem";
            this.kopierenToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.kopierenToolStripMenuItem.Text = "Kopieren";
            this.kopierenToolStripMenuItem.Click += new System.EventHandler(this.kopierenToolStripMenuItem_Click);
            // 
            // einfügentoolStripMenuItem
            // 
            this.einfügentoolStripMenuItem.Name = "einfügentoolStripMenuItem";
            this.einfügentoolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.einfügentoolStripMenuItem.Text = "Einfügen";
            this.einfügentoolStripMenuItem.Click += new System.EventHandler(this.einfügentoolStripMenuItem_Click);
            // 
            // löschenToolStripMenuItem
            // 
            this.löschenToolStripMenuItem.Name = "löschenToolStripMenuItem";
            this.löschenToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.löschenToolStripMenuItem.Text = "Löschen";
            this.löschenToolStripMenuItem.Click += new System.EventHandler(this.löschenToolStripMenuItem_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(211, 356);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // cb_filetyp
            // 
            this.cb_filetyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_filetyp.FormattingEnabled = true;
            this.cb_filetyp.Location = new System.Drawing.Point(13, 356);
            this.cb_filetyp.Name = "cb_filetyp";
            this.cb_filetyp.Size = new System.Drawing.Size(191, 24);
            this.cb_filetyp.TabIndex = 3;
            this.cb_filetyp.SelectionChangeCommitted += new System.EventHandler(this.cb_filetyp_SelectionChangeCommitted);
            // 
            // tbx_neueDatei
            // 
            this.tbx_neueDatei.Location = new System.Drawing.Point(13, 12);
            this.tbx_neueDatei.Name = "tbx_neueDatei";
            this.tbx_neueDatei.Size = new System.Drawing.Size(220, 22);
            this.tbx_neueDatei.TabIndex = 4;
            this.tbx_neueDatei.TextChanged += new System.EventHandler(this.tbx_neueDatei_TextChanged);
            // 
            // btn_neueDatei
            // 
            this.btn_neueDatei.Location = new System.Drawing.Point(239, 12);
            this.btn_neueDatei.Name = "btn_neueDatei";
            this.btn_neueDatei.Size = new System.Drawing.Size(46, 23);
            this.btn_neueDatei.TabIndex = 5;
            this.btn_neueDatei.Text = "neu";
            this.btn_neueDatei.UseVisualStyleBackColor = true;
            this.btn_neueDatei.Click += new System.EventHandler(this.btn_neueDatei_Click);
            // 
            // Frm_Files
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(303, 389);
            this.Controls.Add(this.btn_neueDatei);
            this.Controls.Add(this.tbx_neueDatei);
            this.Controls.Add(this.cb_filetyp);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Files";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Frm_Files_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.ComboBox cb_filetyp;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kopierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem;
        private System.Windows.Forms.TextBox tbx_neueDatei;
        private System.Windows.Forms.Button btn_neueDatei;
        private System.Windows.Forms.ToolStripMenuItem einfügentoolStripMenuItem;
    }
}