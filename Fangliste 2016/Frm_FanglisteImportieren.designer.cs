namespace Fangliste_2016
{
    partial class Frm_FanglisteImportieren
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
            this.btn_durchsuchen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_importieren = new System.Windows.Forms.Button();
            this.btn_analysieren = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_fanglisteAnsehen = new System.Windows.Forms.Button();
            this.groupBox_fangliste = new System.Windows.Forms.GroupBox();
            this.groupBox_analyse = new System.Windows.Forms.GroupBox();
            this.groupBox_ergebnis = new System.Windows.Forms.GroupBox();
            this.cb_keinedoppeltenEinträge = new System.Windows.Forms.CheckBox();
            this.lb_anzahlDoppelterEinträge = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_gesImportList = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox_fangliste.SuspendLayout();
            this.groupBox_analyse.SuspendLayout();
            this.groupBox_ergebnis.SuspendLayout();
            this.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dateiname";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(287, 20);
            this.textBox1.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_importieren
            // 
            this.btn_importieren.Location = new System.Drawing.Point(180, 363);
            this.btn_importieren.Name = "btn_importieren";
            this.btn_importieren.Size = new System.Drawing.Size(75, 23);
            this.btn_importieren.TabIndex = 3;
            this.btn_importieren.Text = "importieren";
            this.btn_importieren.UseVisualStyleBackColor = true;
            this.btn_importieren.Click += new System.EventHandler(this.btn_importieren_Click);
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
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 52);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(400, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 5;
            // 
            // btn_fanglisteAnsehen
            // 
            this.btn_fanglisteAnsehen.Location = new System.Drawing.Point(299, 25);
            this.btn_fanglisteAnsehen.Name = "btn_fanglisteAnsehen";
            this.btn_fanglisteAnsehen.Size = new System.Drawing.Size(107, 23);
            this.btn_fanglisteAnsehen.TabIndex = 6;
            this.btn_fanglisteAnsehen.Text = "Fangliste ansehen";
            this.btn_fanglisteAnsehen.UseVisualStyleBackColor = true;
            this.btn_fanglisteAnsehen.Click += new System.EventHandler(this.btn_fanglisteAnsehen_Click);
            // 
            // groupBox_fangliste
            // 
            this.groupBox_fangliste.Controls.Add(this.textBox1);
            this.groupBox_fangliste.Controls.Add(this.btn_durchsuchen);
            this.groupBox_fangliste.Controls.Add(this.label1);
            this.groupBox_fangliste.Location = new System.Drawing.Point(15, 12);
            this.groupBox_fangliste.Name = "groupBox_fangliste";
            this.groupBox_fangliste.Size = new System.Drawing.Size(412, 90);
            this.groupBox_fangliste.TabIndex = 7;
            this.groupBox_fangliste.TabStop = false;
            this.groupBox_fangliste.Text = "Fangliste";
            // 
            // groupBox_analyse
            // 
            this.groupBox_analyse.Controls.Add(this.progressBar1);
            this.groupBox_analyse.Controls.Add(this.btn_analysieren);
            this.groupBox_analyse.Location = new System.Drawing.Point(15, 108);
            this.groupBox_analyse.Name = "groupBox_analyse";
            this.groupBox_analyse.Size = new System.Drawing.Size(412, 95);
            this.groupBox_analyse.TabIndex = 8;
            this.groupBox_analyse.TabStop = false;
            this.groupBox_analyse.Text = "Analyse";
            // 
            // groupBox_ergebnis
            // 
            this.groupBox_ergebnis.Controls.Add(this.lb_gesImportList);
            this.groupBox_ergebnis.Controls.Add(this.cb_keinedoppeltenEinträge);
            this.groupBox_ergebnis.Controls.Add(this.lb_anzahlDoppelterEinträge);
            this.groupBox_ergebnis.Controls.Add(this.label4);
            this.groupBox_ergebnis.Controls.Add(this.label2);
            this.groupBox_ergebnis.Controls.Add(this.btn_fanglisteAnsehen);
            this.groupBox_ergebnis.Location = new System.Drawing.Point(15, 209);
            this.groupBox_ergebnis.Name = "groupBox_ergebnis";
            this.groupBox_ergebnis.Size = new System.Drawing.Size(412, 137);
            this.groupBox_ergebnis.TabIndex = 9;
            this.groupBox_ergebnis.TabStop = false;
            this.groupBox_ergebnis.Text = "Ergebnis";
            // 
            // cb_keinedoppeltenEinträge
            // 
            this.cb_keinedoppeltenEinträge.AutoSize = true;
            this.cb_keinedoppeltenEinträge.Checked = true;
            this.cb_keinedoppeltenEinträge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_keinedoppeltenEinträge.Location = new System.Drawing.Point(6, 101);
            this.cb_keinedoppeltenEinträge.Name = "cb_keinedoppeltenEinträge";
            this.cb_keinedoppeltenEinträge.Size = new System.Drawing.Size(203, 17);
            this.cb_keinedoppeltenEinträge.TabIndex = 9;
            this.cb_keinedoppeltenEinträge.Text = "Keine doppelten Einträge hinzufügen.";
            this.cb_keinedoppeltenEinträge.UseVisualStyleBackColor = true;
            this.cb_keinedoppeltenEinträge.Click += new System.EventHandler(this.cb_keinedoppeltenEinträge_Click);
            // 
            // lb_anzahlDoppelterEinträge
            // 
            this.lb_anzahlDoppelterEinträge.AutoSize = true;
            this.lb_anzahlDoppelterEinträge.Location = new System.Drawing.Point(190, 68);
            this.lb_anzahlDoppelterEinträge.Name = "lb_anzahlDoppelterEinträge";
            this.lb_anzahlDoppelterEinträge.Size = new System.Drawing.Size(13, 13);
            this.lb_anzahlDoppelterEinträge.TabIndex = 8;
            this.lb_anzahlDoppelterEinträge.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Anzahl der Einträge die Doppelt sind:";
            // 
            // lb_gesImportList
            // 
            this.lb_gesImportList.AutoSize = true;
            this.lb_gesImportList.Location = new System.Drawing.Point(190, 30);
            this.lb_gesImportList.Name = "lb_gesImportList";
            this.lb_gesImportList.Size = new System.Drawing.Size(13, 13);
            this.lb_gesImportList.TabIndex = 11;
            this.lb_gesImportList.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Gesamteinträge der import Fangliste:";
            // 
            // Frm_Importieren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(439, 398);
            this.Controls.Add(this.groupBox_ergebnis);
            this.Controls.Add(this.groupBox_analyse);
            this.Controls.Add(this.groupBox_fangliste);
            this.Controls.Add(this.btn_importieren);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_Importieren";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fangliste Importieren";
            this.Load += new System.EventHandler(this.Frm_Importieren_Load);
            this.groupBox_fangliste.ResumeLayout(false);
            this.groupBox_fangliste.PerformLayout();
            this.groupBox_analyse.ResumeLayout(false);
            this.groupBox_ergebnis.ResumeLayout(false);
            this.groupBox_ergebnis.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_durchsuchen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_importieren;
        private System.Windows.Forms.Button btn_analysieren;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_fanglisteAnsehen;
        private System.Windows.Forms.GroupBox groupBox_fangliste;
        private System.Windows.Forms.GroupBox groupBox_analyse;
        private System.Windows.Forms.GroupBox groupBox_ergebnis;
        private System.Windows.Forms.Label lb_anzahlDoppelterEinträge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_keinedoppeltenEinträge;
        private System.Windows.Forms.Label lb_gesImportList;
        private System.Windows.Forms.Label label4;

    }
}