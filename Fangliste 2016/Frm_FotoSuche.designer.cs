namespace Fangliste_2016
{
    partial class Frm_FotoSuche
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_FotoSuche));
            this.btn_sucheStarten = new System.Windows.Forms.Button();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.cb_fotosuche_nach = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_auswahl = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_sucheStarten
            // 
            this.btn_sucheStarten.Location = new System.Drawing.Point(87, 114);
            this.btn_sucheStarten.Name = "btn_sucheStarten";
            this.btn_sucheStarten.Size = new System.Drawing.Size(105, 23);
            this.btn_sucheStarten.TabIndex = 1;
            this.btn_sucheStarten.Text = "Suche starten";
            this.btn_sucheStarten.UseVisualStyleBackColor = true;
            this.btn_sucheStarten.Click += new System.EventHandler(this.btn_sucheStarten_Click);
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // cb_fotosuche_nach
            // 
            this.cb_fotosuche_nach.DisplayMember = "Name";
            this.cb_fotosuche_nach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_fotosuche_nach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cb_fotosuche_nach.FormattingEnabled = true;
            this.cb_fotosuche_nach.Items.AddRange(new object[] {
            "Fischart",
            "Gewässer",
            "Gewicht (in kg)",
            "Größe (in cm)",
            "Jahr",
            "Name"});
            this.cb_fotosuche_nach.Location = new System.Drawing.Point(29, 31);
            this.cb_fotosuche_nach.Name = "cb_fotosuche_nach";
            this.cb_fotosuche_nach.Size = new System.Drawing.Size(216, 25);
            this.cb_fotosuche_nach.Sorted = true;
            this.cb_fotosuche_nach.TabIndex = 2;
            this.cb_fotosuche_nach.ValueMember = "Name";
            this.cb_fotosuche_nach.SelectionChangeCommitted += new System.EventHandler(this.cb_fotosuche_nach_SelectionChangeCommitted);
            this.cb_fotosuche_nach.TextChanged += new System.EventHandler(this.cb_fotosuche_nach_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "nach";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Auswahl";
            // 
            // cb_auswahl
            // 
            this.cb_auswahl.DisplayMember = "Name";
            this.cb_auswahl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_auswahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.cb_auswahl.FormattingEnabled = true;
            this.cb_auswahl.Location = new System.Drawing.Point(29, 77);
            this.cb_auswahl.Name = "cb_auswahl";
            this.cb_auswahl.Size = new System.Drawing.Size(216, 25);
            this.cb_auswahl.Sorted = true;
            this.cb_auswahl.TabIndex = 5;
            this.cb_auswahl.ValueMember = "Name";
            this.cb_auswahl.SelectionChangeCommitted += new System.EventHandler(this.cb_auswahl_SelectionChangeCommitted);
            // 
            // Frm_FotoSuche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(272, 159);
            this.Controls.Add(this.cb_auswahl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_fotosuche_nach);
            this.Controls.Add(this.btn_sucheStarten);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_FotoSuche";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fotosuche";
            this.Load += new System.EventHandler(this.Frm_FotoSuche_Load);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_sucheStarten;
        private System.Windows.Forms.ErrorProvider error;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_fotosuche_nach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_auswahl;
    }
}