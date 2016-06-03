namespace Fangliste_2016
{
    partial class Frm_FotolisteImportieren
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
            this.groupBox_ergebnis = new System.Windows.Forms.GroupBox();
            this.lb_gesImportList = new System.Windows.Forms.Label();
            this.cb_keinFoto = new System.Windows.Forms.CheckBox();
            this.lb_anzahlKeinFoto = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_fotolisteAnsehen = new System.Windows.Forms.Button();
            this.groupBox_analyse = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_analysieren = new System.Windows.Forms.Button();
            this.btn_durchsuchen = new System.Windows.Forms.Button();
            this.groupBox_fotoliste = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_importieren = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox_ergebnis.SuspendLayout();
            this.groupBox_analyse.SuspendLayout();
            this.groupBox_fotoliste.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_ergebnis
            // 
            this.groupBox_ergebnis.Controls.Add(this.lb_gesImportList);
            this.groupBox_ergebnis.Controls.Add(this.cb_keinFoto);
            this.groupBox_ergebnis.Controls.Add(this.lb_anzahlKeinFoto);
            this.groupBox_ergebnis.Controls.Add(this.label4);
            this.groupBox_ergebnis.Controls.Add(this.label2);
            this.groupBox_ergebnis.Controls.Add(this.btn_fotolisteAnsehen);
            this.groupBox_ergebnis.Location = new System.Drawing.Point(12, 209);
            this.groupBox_ergebnis.Name = "groupBox_ergebnis";
            this.groupBox_ergebnis.Size = new System.Drawing.Size(412, 137);
            this.groupBox_ergebnis.TabIndex = 13;
            this.groupBox_ergebnis.TabStop = false;
            this.groupBox_ergebnis.Text = "Ergebnis";
            // 
            // lb_gesImportList
            // 
            this.lb_gesImportList.AutoSize = true;
            this.lb_gesImportList.Location = new System.Drawing.Point(178, 30);
            this.lb_gesImportList.Name = "lb_gesImportList";
            this.lb_gesImportList.Size = new System.Drawing.Size(13, 13);
            this.lb_gesImportList.TabIndex = 11;
            this.lb_gesImportList.Text = "0";
            // 
            // cb_keinFoto
            // 
            this.cb_keinFoto.AutoSize = true;
            this.cb_keinFoto.Checked = true;
            this.cb_keinFoto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_keinFoto.Location = new System.Drawing.Point(6, 101);
            this.cb_keinFoto.Name = "cb_keinFoto";
            this.cb_keinFoto.Size = new System.Drawing.Size(208, 17);
            this.cb_keinFoto.TabIndex = 9;
            this.cb_keinFoto.Text = "Nur hinzufügen wenn Foto vorhanden.";
            this.cb_keinFoto.UseVisualStyleBackColor = true;
            this.cb_keinFoto.Click += new System.EventHandler(this.cb_keinFoto_Click);
            // 
            // lb_anzahlKeinFoto
            // 
            this.lb_anzahlKeinFoto.AutoSize = true;
            this.lb_anzahlKeinFoto.Location = new System.Drawing.Point(201, 65);
            this.lb_anzahlKeinFoto.Name = "lb_anzahlKeinFoto";
            this.lb_anzahlKeinFoto.Size = new System.Drawing.Size(13, 13);
            this.lb_anzahlKeinFoto.TabIndex = 8;
            this.lb_anzahlKeinFoto.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Gesamtanzahl der Fotos in der Liste:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Anzahl der Fotos die nicht vorhaden sind:";
            // 
            // btn_fotolisteAnsehen
            // 
            this.btn_fotolisteAnsehen.Location = new System.Drawing.Point(299, 25);
            this.btn_fotolisteAnsehen.Name = "btn_fotolisteAnsehen";
            this.btn_fotolisteAnsehen.Size = new System.Drawing.Size(107, 23);
            this.btn_fotolisteAnsehen.TabIndex = 6;
            this.btn_fotolisteAnsehen.Text = "Fotoliste ansehen";
            this.btn_fotolisteAnsehen.UseVisualStyleBackColor = true;
            this.btn_fotolisteAnsehen.Click += new System.EventHandler(this.btn_fotolisteAnsehen_Click);
            // 
            // groupBox_analyse
            // 
            this.groupBox_analyse.Controls.Add(this.progressBar1);
            this.groupBox_analyse.Controls.Add(this.btn_analysieren);
            this.groupBox_analyse.Location = new System.Drawing.Point(12, 108);
            this.groupBox_analyse.Name = "groupBox_analyse";
            this.groupBox_analyse.Size = new System.Drawing.Size(412, 95);
            this.groupBox_analyse.TabIndex = 12;
            this.groupBox_analyse.TabStop = false;
            this.groupBox_analyse.Text = "Analyse";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 52);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(400, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 5;
            // 
            // btn_analysieren
            // 
            this.btn_analysieren.Location = new System.Drawing.Point(6, 23);
            this.btn_analysieren.Name = "btn_analysieren";
            this.btn_analysieren.Size = new System.Drawing.Size(107, 23);
            this.btn_analysieren.TabIndex = 4;
            this.btn_analysieren.Text = "jetzt analysieren";
            this.btn_analysieren.UseVisualStyleBackColor = true;
            this.btn_analysieren.Click += new System.EventHandler(this.btn_analysieren_Click);
            // 
            // btn_durchsuchen
            // 
            this.btn_durchsuchen.Location = new System.Drawing.Point(299, 41);
            this.btn_durchsuchen.Name = "btn_durchsuchen";
            this.btn_durchsuchen.Size = new System.Drawing.Size(107, 23);
            this.btn_durchsuchen.TabIndex = 0;
            this.btn_durchsuchen.Text = "durchsuchen";
            this.btn_durchsuchen.UseVisualStyleBackColor = true;
            this.btn_durchsuchen.Click += new System.EventHandler(this.btn_durchsuchen_Click);
            // 
            // groupBox_fotoliste
            // 
            this.groupBox_fotoliste.Controls.Add(this.textBox1);
            this.groupBox_fotoliste.Controls.Add(this.btn_durchsuchen);
            this.groupBox_fotoliste.Controls.Add(this.label1);
            this.groupBox_fotoliste.Location = new System.Drawing.Point(12, 12);
            this.groupBox_fotoliste.Name = "groupBox_fotoliste";
            this.groupBox_fotoliste.Size = new System.Drawing.Size(412, 90);
            this.groupBox_fotoliste.TabIndex = 11;
            this.groupBox_fotoliste.TabStop = false;
            this.groupBox_fotoliste.Text = "Fotoliste";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(287, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ordner";
            // 
            // btn_importieren
            // 
            this.btn_importieren.Location = new System.Drawing.Point(177, 363);
            this.btn_importieren.Name = "btn_importieren";
            this.btn_importieren.Size = new System.Drawing.Size(75, 23);
            this.btn_importieren.TabIndex = 10;
            this.btn_importieren.Text = "importieren";
            this.btn_importieren.UseVisualStyleBackColor = true;
            this.btn_importieren.Click += new System.EventHandler(this.btn_importieren_Click);
            // 
            // Frm_FotolisteImportieren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(439, 398);
            this.Controls.Add(this.groupBox_ergebnis);
            this.Controls.Add(this.groupBox_analyse);
            this.Controls.Add(this.groupBox_fotoliste);
            this.Controls.Add(this.btn_importieren);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_FotolisteImportieren";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fotoliste importieren";
            this.Load += new System.EventHandler(this.Frm_FotolisteImportieren_Load);
            this.groupBox_ergebnis.ResumeLayout(false);
            this.groupBox_ergebnis.PerformLayout();
            this.groupBox_analyse.ResumeLayout(false);
            this.groupBox_fotoliste.ResumeLayout(false);
            this.groupBox_fotoliste.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_ergebnis;
        private System.Windows.Forms.Label lb_gesImportList;
        private System.Windows.Forms.CheckBox cb_keinFoto;
        private System.Windows.Forms.Label lb_anzahlKeinFoto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_fotolisteAnsehen;
        private System.Windows.Forms.GroupBox groupBox_analyse;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_analysieren;
        private System.Windows.Forms.Button btn_durchsuchen;
        private System.Windows.Forms.GroupBox groupBox_fotoliste;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_importieren;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}