namespace Fangliste_2016
{
    partial class Frm_FischKalkulator
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
            this.cb_fischarten = new System.Windows.Forms.ComboBox();
            this.tbx_kFaktor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_länge = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_gewicht = new System.Windows.Forms.TextBox();
            this.btn_gewicht = new System.Windows.Forms.Button();
            this.btn_länge = new System.Windows.Forms.Button();
            this.btn_kFaktor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_fischarten
            // 
            this.cb_fischarten.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_fischarten.FormattingEnabled = true;
            this.cb_fischarten.Location = new System.Drawing.Point(12, 12);
            this.cb_fischarten.Name = "cb_fischarten";
            this.cb_fischarten.Size = new System.Drawing.Size(304, 21);
            this.cb_fischarten.TabIndex = 0;
            this.cb_fischarten.SelectionChangeCommitted += new System.EventHandler(this.cb_fischarten_SelectionChangeCommitted);
            // 
            // tbx_kFaktor
            // 
            this.tbx_kFaktor.Location = new System.Drawing.Point(12, 64);
            this.tbx_kFaktor.Name = "tbx_kFaktor";
            this.tbx_kFaktor.Size = new System.Drawing.Size(57, 20);
            this.tbx_kFaktor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "K-Faktor";
            // 
            // tbx_länge
            // 
            this.tbx_länge.Location = new System.Drawing.Point(94, 64);
            this.tbx_länge.Name = "tbx_länge";
            this.tbx_länge.Size = new System.Drawing.Size(100, 20);
            this.tbx_länge.TabIndex = 3;
            this.tbx_länge.Text = "50";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Länge /cm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Gewicht /kg";
            // 
            // tbx_gewicht
            // 
            this.tbx_gewicht.Location = new System.Drawing.Point(216, 64);
            this.tbx_gewicht.Name = "tbx_gewicht";
            this.tbx_gewicht.Size = new System.Drawing.Size(100, 20);
            this.tbx_gewicht.TabIndex = 5;
            // 
            // btn_gewicht
            // 
            this.btn_gewicht.Location = new System.Drawing.Point(216, 90);
            this.btn_gewicht.Name = "btn_gewicht";
            this.btn_gewicht.Size = new System.Drawing.Size(75, 23);
            this.btn_gewicht.TabIndex = 7;
            this.btn_gewicht.Text = "Gewicht";
            this.btn_gewicht.UseVisualStyleBackColor = true;
            this.btn_gewicht.Click += new System.EventHandler(this.btn_gewicht_Click);
            // 
            // btn_länge
            // 
            this.btn_länge.Location = new System.Drawing.Point(94, 90);
            this.btn_länge.Name = "btn_länge";
            this.btn_länge.Size = new System.Drawing.Size(75, 23);
            this.btn_länge.TabIndex = 8;
            this.btn_länge.Text = "Länge";
            this.btn_länge.UseVisualStyleBackColor = true;
            this.btn_länge.Click += new System.EventHandler(this.btn_länge_Click);
            // 
            // btn_kFaktor
            // 
            this.btn_kFaktor.Location = new System.Drawing.Point(12, 90);
            this.btn_kFaktor.Name = "btn_kFaktor";
            this.btn_kFaktor.Size = new System.Drawing.Size(57, 23);
            this.btn_kFaktor.TabIndex = 10;
            this.btn_kFaktor.Text = "K-Faktor";
            this.btn_kFaktor.UseVisualStyleBackColor = true;
            this.btn_kFaktor.Click += new System.EventHandler(this.btn_kFaktor_Click);
            // 
            // Frm_FischKalkulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(328, 125);
            this.Controls.Add(this.btn_kFaktor);
            this.Controls.Add(this.btn_länge);
            this.Controls.Add(this.btn_gewicht);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbx_gewicht);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_länge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_kFaktor);
            this.Controls.Add(this.cb_fischarten);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Frm_FischKalkulator";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fisch Kalkulator";
            this.Load += new System.EventHandler(this.Frm_FischKalkulator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_fischarten;
        private System.Windows.Forms.TextBox tbx_kFaktor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_länge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_gewicht;
        private System.Windows.Forms.Button btn_gewicht;
        private System.Windows.Forms.Button btn_länge;
        private System.Windows.Forms.Button btn_kFaktor;
    }
}