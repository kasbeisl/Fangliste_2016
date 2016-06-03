namespace Fangliste_2016
{
    partial class Frm_FanglisteExportExcel
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
            this.btn_hitparade = new System.Windows.Forms.Button();
            this.btn_alleFänge = new System.Windows.Forms.Button();
            this.btn_jahresfänge = new System.Windows.Forms.Button();
            this.btn_persönlichefangliste = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_hitparade
            // 
            this.btn_hitparade.Location = new System.Drawing.Point(24, 44);
            this.btn_hitparade.Name = "btn_hitparade";
            this.btn_hitparade.Size = new System.Drawing.Size(102, 37);
            this.btn_hitparade.TabIndex = 0;
            this.btn_hitparade.Text = "Hitparade";
            this.btn_hitparade.UseVisualStyleBackColor = true;
            this.btn_hitparade.Click += new System.EventHandler(this.btn_hitparade_Click);
            // 
            // btn_alleFänge
            // 
            this.btn_alleFänge.Location = new System.Drawing.Point(132, 44);
            this.btn_alleFänge.Name = "btn_alleFänge";
            this.btn_alleFänge.Size = new System.Drawing.Size(102, 37);
            this.btn_alleFänge.TabIndex = 1;
            this.btn_alleFänge.Text = "Alle Fänge";
            this.btn_alleFänge.UseVisualStyleBackColor = true;
            this.btn_alleFänge.Click += new System.EventHandler(this.btn_alleFänge_Click);
            // 
            // btn_jahresfänge
            // 
            this.btn_jahresfänge.Location = new System.Drawing.Point(240, 44);
            this.btn_jahresfänge.Name = "btn_jahresfänge";
            this.btn_jahresfänge.Size = new System.Drawing.Size(102, 37);
            this.btn_jahresfänge.TabIndex = 2;
            this.btn_jahresfänge.Text = "Jahresfänge";
            this.btn_jahresfänge.UseVisualStyleBackColor = true;
            this.btn_jahresfänge.Click += new System.EventHandler(this.btn_jahresfänge_Click);
            // 
            // btn_persönlichefangliste
            // 
            this.btn_persönlichefangliste.Location = new System.Drawing.Point(348, 44);
            this.btn_persönlichefangliste.Name = "btn_persönlichefangliste";
            this.btn_persönlichefangliste.Size = new System.Drawing.Size(102, 37);
            this.btn_persönlichefangliste.TabIndex = 3;
            this.btn_persönlichefangliste.Text = "Persönliche Fangliste";
            this.btn_persönlichefangliste.UseVisualStyleBackColor = true;
            this.btn_persönlichefangliste.Click += new System.EventHandler(this.btn_persönlichefangliste_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(499, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Wählen Sie eine belibige Fangliste aus, um sie in Excel zu exportieren. (Execl wi" +
                "rd automatisch geöffnet.)";
            // 
            // Frm_FanglisteExportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(524, 108);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_persönlichefangliste);
            this.Controls.Add(this.btn_jahresfänge);
            this.Controls.Add(this.btn_alleFänge);
            this.Controls.Add(this.btn_hitparade);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_FanglisteExportExcel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportieren in Excel";
            this.Load += new System.EventHandler(this.Frm_ExportExcel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_hitparade;
        private System.Windows.Forms.Button btn_alleFänge;
        private System.Windows.Forms.Button btn_jahresfänge;
        private System.Windows.Forms.Button btn_persönlichefangliste;
        private System.Windows.Forms.Label label1;
    }
}