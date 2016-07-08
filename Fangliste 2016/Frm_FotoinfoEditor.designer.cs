namespace Fangliste_2016
{
    partial class Frm_FotoinfoEditor
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
            this.btn_fangAuswählen = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_fertig = new System.Windows.Forms.Button();
            this.btn_löschen = new System.Windows.Forms.Button();
            this.btn_entfernen = new System.Windows.Forms.Button();
            this.cb_ordner = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_neuerOrdner = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_fangAuswählen
            // 
            this.btn_fangAuswählen.Location = new System.Drawing.Point(12, 232);
            this.btn_fangAuswählen.Name = "btn_fangAuswählen";
            this.btn_fangAuswählen.Size = new System.Drawing.Size(115, 23);
            this.btn_fangAuswählen.TabIndex = 0;
            this.btn_fangAuswählen.Text = "Fang auswählen";
            this.btn_fangAuswählen.UseVisualStyleBackColor = true;
            this.btn_fangAuswählen.Click += new System.EventHandler(this.btn_fangAuswählen_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(12, 279);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(389, 148);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "Kein Fang ausgewählt";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fang:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kommentar:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 457);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(386, 64);
            this.textBox1.TabIndex = 4;
            // 
            // btn_fertig
            // 
            this.btn_fertig.Location = new System.Drawing.Point(326, 547);
            this.btn_fertig.Name = "btn_fertig";
            this.btn_fertig.Size = new System.Drawing.Size(75, 23);
            this.btn_fertig.TabIndex = 5;
            this.btn_fertig.Text = "fertig";
            this.btn_fertig.UseVisualStyleBackColor = true;
            this.btn_fertig.Click += new System.EventHandler(this.btn_fertig_Click);
            // 
            // btn_löschen
            // 
            this.btn_löschen.Enabled = false;
            this.btn_löschen.Location = new System.Drawing.Point(326, 232);
            this.btn_löschen.Name = "btn_löschen";
            this.btn_löschen.Size = new System.Drawing.Size(75, 23);
            this.btn_löschen.TabIndex = 6;
            this.btn_löschen.Text = "Löschen";
            this.btn_löschen.UseVisualStyleBackColor = true;
            this.btn_löschen.Click += new System.EventHandler(this.btn_löschen_Click);
            // 
            // btn_entfernen
            // 
            this.btn_entfernen.Location = new System.Drawing.Point(12, 408);
            this.btn_entfernen.Name = "btn_entfernen";
            this.btn_entfernen.Size = new System.Drawing.Size(80, 19);
            this.btn_entfernen.TabIndex = 7;
            this.btn_entfernen.Text = "entfernen";
            this.btn_entfernen.UseVisualStyleBackColor = true;
            this.btn_entfernen.Click += new System.EventHandler(this.btn_entfernen_Click);
            // 
            // cb_ordner
            // 
            this.cb_ordner.FormattingEnabled = true;
            this.cb_ordner.Location = new System.Drawing.Point(57, 549);
            this.cb_ordner.Name = "cb_ordner";
            this.cb_ordner.Size = new System.Drawing.Size(172, 21);
            this.cb_ordner.TabIndex = 9;
            this.cb_ordner.Text = "Sonstige";
            this.cb_ordner.SelectedIndexChanged += new System.EventHandler(this.cb_ordner_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 552);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ordner";
            // 
            // btn_neuerOrdner
            // 
            this.btn_neuerOrdner.Location = new System.Drawing.Point(235, 547);
            this.btn_neuerOrdner.Name = "btn_neuerOrdner";
            this.btn_neuerOrdner.Size = new System.Drawing.Size(37, 23);
            this.btn_neuerOrdner.TabIndex = 11;
            this.btn_neuerOrdner.Text = "+";
            this.btn_neuerOrdner.UseVisualStyleBackColor = true;
            this.btn_neuerOrdner.Click += new System.EventHandler(this.btn_neuerOrdner_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(389, 212);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_FotoinfoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(415, 587);
            this.Controls.Add(this.btn_neuerOrdner);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_ordner);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_entfernen);
            this.Controls.Add(this.btn_löschen);
            this.Controls.Add(this.btn_fertig);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_fangAuswählen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Frm_FotoinfoEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor";
            this.Load += new System.EventHandler(this.Frm_FotoinfoEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_fangAuswählen;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_fertig;
        private System.Windows.Forms.Button btn_löschen;
        private System.Windows.Forms.Button btn_entfernen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cb_ordner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_neuerOrdner;
    }
}