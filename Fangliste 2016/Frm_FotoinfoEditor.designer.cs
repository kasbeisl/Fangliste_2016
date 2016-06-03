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
            this.SuspendLayout();
            // 
            // btn_fangAuswählen
            // 
            this.btn_fangAuswählen.Location = new System.Drawing.Point(12, 12);
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
            this.richTextBox1.Location = new System.Drawing.Point(12, 59);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(361, 148);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "Kein Fang ausgewählt";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fang:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kommentar:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 237);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(358, 104);
            this.textBox1.TabIndex = 4;
            // 
            // btn_fertig
            // 
            this.btn_fertig.Location = new System.Drawing.Point(298, 354);
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
            this.btn_löschen.Location = new System.Drawing.Point(298, 12);
            this.btn_löschen.Name = "btn_löschen";
            this.btn_löschen.Size = new System.Drawing.Size(75, 23);
            this.btn_löschen.TabIndex = 6;
            this.btn_löschen.Text = "Löschen";
            this.btn_löschen.UseVisualStyleBackColor = true;
            this.btn_löschen.Click += new System.EventHandler(this.btn_löschen_Click);
            // 
            // btn_entfernen
            // 
            this.btn_entfernen.Location = new System.Drawing.Point(12, 188);
            this.btn_entfernen.Name = "btn_entfernen";
            this.btn_entfernen.Size = new System.Drawing.Size(80, 19);
            this.btn_entfernen.TabIndex = 7;
            this.btn_entfernen.Text = "entfernen";
            this.btn_entfernen.UseVisualStyleBackColor = true;
            this.btn_entfernen.Click += new System.EventHandler(this.btn_entfernen_Click);
            // 
            // Frm_FotoinfoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(393, 389);
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
    }
}