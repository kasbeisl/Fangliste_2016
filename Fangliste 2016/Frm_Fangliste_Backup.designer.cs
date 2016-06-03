namespace Fangliste_2016
{
    partial class Frm_Fangliste_Backup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Fangliste_Backup));
            this.btn_wiederherstellen = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_anzeigen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_wiederherstellen
            // 
            this.btn_wiederherstellen.Location = new System.Drawing.Point(182, 338);
            this.btn_wiederherstellen.Name = "btn_wiederherstellen";
            this.btn_wiederherstellen.Size = new System.Drawing.Size(91, 23);
            this.btn_wiederherstellen.TabIndex = 1;
            this.btn_wiederherstellen.Text = "wiederherstellen";
            this.btn_wiederherstellen.UseVisualStyleBackColor = true;
            this.btn_wiederherstellen.Click += new System.EventHandler(this.btn_wiederherstellen_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(1, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(282, 324);
            this.listBox1.TabIndex = 0;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btn_anzeigen
            // 
            this.btn_anzeigen.Location = new System.Drawing.Point(12, 339);
            this.btn_anzeigen.Name = "btn_anzeigen";
            this.btn_anzeigen.Size = new System.Drawing.Size(75, 23);
            this.btn_anzeigen.TabIndex = 2;
            this.btn_anzeigen.Text = "anzeigen";
            this.btn_anzeigen.UseVisualStyleBackColor = true;
            this.btn_anzeigen.Click += new System.EventHandler(this.btn_anzeigen_Click);
            // 
            // Frm_Fangliste_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(285, 373);
            this.Controls.Add(this.btn_anzeigen);
            this.Controls.Add(this.btn_wiederherstellen);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Fangliste_Backup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fangliste Backup";
            this.Load += new System.EventHandler(this.Frm_Fangliste_Backup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_wiederherstellen;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_anzeigen;
    }
}