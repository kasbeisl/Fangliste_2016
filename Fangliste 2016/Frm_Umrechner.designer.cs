namespace Fangliste_2016
{
    partial class Frm_Umrechner
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_gewicht = new System.Windows.Forms.Button();
            this.tbx_gewichtErgebnis = new System.Windows.Forms.NumericUpDown();
            this.tbx_gewichtIN = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_gewicht = new System.Windows.Forms.NumericUpDown();
            this.tbx_gewichtVon = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_wurfgEmpfohlen = new System.Windows.Forms.CheckBox();
            this.btn_wurfgewicht = new System.Windows.Forms.Button();
            this.tbx_wurfgErgebnis = new System.Windows.Forms.NumericUpDown();
            this.tbx_wurfgIN = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_wurfg = new System.Windows.Forms.NumericUpDown();
            this.tbx_wurfgVon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbx_leistungErgebnis = new System.Windows.Forms.TextBox();
            this.tbx_leistung = new System.Windows.Forms.TextBox();
            this.btn_leistung = new System.Windows.Forms.Button();
            this.tbx_leistungIN = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_leisungVon = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_gewichtErgebnis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_gewicht)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_wurfgErgebnis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_wurfg)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_gewicht);
            this.groupBox1.Controls.Add(this.tbx_gewichtErgebnis);
            this.groupBox1.Controls.Add(this.tbx_gewichtIN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbx_gewicht);
            this.groupBox1.Controls.Add(this.tbx_gewichtVon);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gewicht";
            // 
            // btn_gewicht
            // 
            this.btn_gewicht.Location = new System.Drawing.Point(325, 57);
            this.btn_gewicht.Name = "btn_gewicht";
            this.btn_gewicht.Size = new System.Drawing.Size(75, 23);
            this.btn_gewicht.TabIndex = 6;
            this.btn_gewicht.Text = "berechnen";
            this.btn_gewicht.UseVisualStyleBackColor = true;
            this.btn_gewicht.Click += new System.EventHandler(this.btn_gewicht_Click);
            // 
            // tbx_gewichtErgebnis
            // 
            this.tbx_gewichtErgebnis.DecimalPlaces = 3;
            this.tbx_gewichtErgebnis.Location = new System.Drawing.Point(215, 59);
            this.tbx_gewichtErgebnis.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tbx_gewichtErgebnis.Name = "tbx_gewichtErgebnis";
            this.tbx_gewichtErgebnis.Size = new System.Drawing.Size(104, 20);
            this.tbx_gewichtErgebnis.TabIndex = 5;
            // 
            // tbx_gewichtIN
            // 
            this.tbx_gewichtIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbx_gewichtIN.FormattingEnabled = true;
            this.tbx_gewichtIN.Items.AddRange(new object[] {
            "Gramm",
            "Unze (oz)",
            "Kilogramm",
            "Pfund"});
            this.tbx_gewichtIN.Location = new System.Drawing.Point(96, 59);
            this.tbx_gewichtIN.Name = "tbx_gewichtIN";
            this.tbx_gewichtIN.Size = new System.Drawing.Size(113, 21);
            this.tbx_gewichtIN.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "in";
            // 
            // tbx_gewicht
            // 
            this.tbx_gewicht.DecimalPlaces = 3;
            this.tbx_gewicht.Location = new System.Drawing.Point(215, 19);
            this.tbx_gewicht.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tbx_gewicht.Name = "tbx_gewicht";
            this.tbx_gewicht.Size = new System.Drawing.Size(104, 20);
            this.tbx_gewicht.TabIndex = 2;
            // 
            // tbx_gewichtVon
            // 
            this.tbx_gewichtVon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbx_gewichtVon.FormattingEnabled = true;
            this.tbx_gewichtVon.Items.AddRange(new object[] {
            "Gramm",
            "Unze (oz)",
            "Kilogramm",
            "Pfund"});
            this.tbx_gewichtVon.Location = new System.Drawing.Point(96, 19);
            this.tbx_gewichtVon.Name = "tbx_gewichtVon";
            this.tbx_gewichtVon.Size = new System.Drawing.Size(113, 21);
            this.tbx_gewichtVon.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gewicht von";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_wurfgEmpfohlen);
            this.groupBox2.Controls.Add(this.btn_wurfgewicht);
            this.groupBox2.Controls.Add(this.tbx_wurfgErgebnis);
            this.groupBox2.Controls.Add(this.tbx_wurfgIN);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbx_wurfg);
            this.groupBox2.Controls.Add(this.tbx_wurfgVon);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 113);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wurfgewicht";
            // 
            // cb_wurfgEmpfohlen
            // 
            this.cb_wurfgEmpfohlen.AutoSize = true;
            this.cb_wurfgEmpfohlen.Location = new System.Drawing.Point(96, 90);
            this.cb_wurfgEmpfohlen.Name = "cb_wurfgEmpfohlen";
            this.cb_wurfgEmpfohlen.Size = new System.Drawing.Size(150, 17);
            this.cb_wurfgEmpfohlen.TabIndex = 13;
            this.cb_wurfgEmpfohlen.Text = "Empfohlenes Wurfgewicht";
            this.cb_wurfgEmpfohlen.UseVisualStyleBackColor = true;
            // 
            // btn_wurfgewicht
            // 
            this.btn_wurfgewicht.Location = new System.Drawing.Point(325, 57);
            this.btn_wurfgewicht.Name = "btn_wurfgewicht";
            this.btn_wurfgewicht.Size = new System.Drawing.Size(75, 23);
            this.btn_wurfgewicht.TabIndex = 12;
            this.btn_wurfgewicht.Text = "berechnen";
            this.btn_wurfgewicht.UseVisualStyleBackColor = true;
            this.btn_wurfgewicht.Click += new System.EventHandler(this.btn_wurfgewicht_Click);
            // 
            // tbx_wurfgErgebnis
            // 
            this.tbx_wurfgErgebnis.DecimalPlaces = 3;
            this.tbx_wurfgErgebnis.Location = new System.Drawing.Point(215, 59);
            this.tbx_wurfgErgebnis.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tbx_wurfgErgebnis.Name = "tbx_wurfgErgebnis";
            this.tbx_wurfgErgebnis.Size = new System.Drawing.Size(104, 20);
            this.tbx_wurfgErgebnis.TabIndex = 11;
            // 
            // tbx_wurfgIN
            // 
            this.tbx_wurfgIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbx_wurfgIN.FormattingEnabled = true;
            this.tbx_wurfgIN.Items.AddRange(new object[] {
            "Pfund (lbs)",
            "Gramm"});
            this.tbx_wurfgIN.Location = new System.Drawing.Point(96, 59);
            this.tbx_wurfgIN.Name = "tbx_wurfgIN";
            this.tbx_wurfgIN.Size = new System.Drawing.Size(113, 21);
            this.tbx_wurfgIN.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "in";
            // 
            // tbx_wurfg
            // 
            this.tbx_wurfg.DecimalPlaces = 3;
            this.tbx_wurfg.Location = new System.Drawing.Point(215, 19);
            this.tbx_wurfg.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tbx_wurfg.Name = "tbx_wurfg";
            this.tbx_wurfg.Size = new System.Drawing.Size(104, 20);
            this.tbx_wurfg.TabIndex = 8;
            // 
            // tbx_wurfgVon
            // 
            this.tbx_wurfgVon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbx_wurfgVon.FormattingEnabled = true;
            this.tbx_wurfgVon.Items.AddRange(new object[] {
            "Pfund (lbs)",
            "Gramm"});
            this.tbx_wurfgVon.Location = new System.Drawing.Point(96, 19);
            this.tbx_wurfgVon.Name = "tbx_wurfgVon";
            this.tbx_wurfgVon.Size = new System.Drawing.Size(113, 21);
            this.tbx_wurfgVon.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Wurfgewicht von";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbx_leistungErgebnis);
            this.groupBox4.Controls.Add(this.tbx_leistung);
            this.groupBox4.Controls.Add(this.btn_leistung);
            this.groupBox4.Controls.Add(this.tbx_leistungIN);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.tbx_leisungVon);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(12, 250);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(436, 113);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Leistung";
            // 
            // tbx_leistungErgebnis
            // 
            this.tbx_leistungErgebnis.Location = new System.Drawing.Point(215, 59);
            this.tbx_leistungErgebnis.Name = "tbx_leistungErgebnis";
            this.tbx_leistungErgebnis.Size = new System.Drawing.Size(104, 20);
            this.tbx_leistungErgebnis.TabIndex = 15;
            // 
            // tbx_leistung
            // 
            this.tbx_leistung.Location = new System.Drawing.Point(215, 19);
            this.tbx_leistung.Name = "tbx_leistung";
            this.tbx_leistung.Size = new System.Drawing.Size(104, 20);
            this.tbx_leistung.TabIndex = 14;
            // 
            // btn_leistung
            // 
            this.btn_leistung.Location = new System.Drawing.Point(325, 56);
            this.btn_leistung.Name = "btn_leistung";
            this.btn_leistung.Size = new System.Drawing.Size(75, 23);
            this.btn_leistung.TabIndex = 12;
            this.btn_leistung.Text = "berechnen";
            this.btn_leistung.UseVisualStyleBackColor = true;
            this.btn_leistung.Click += new System.EventHandler(this.btn_leistung_Click);
            // 
            // tbx_leistungIN
            // 
            this.tbx_leistungIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbx_leistungIN.FormattingEnabled = true;
            this.tbx_leistungIN.Items.AddRange(new object[] {
            "PS",
            "Watt",
            "KW"});
            this.tbx_leistungIN.Location = new System.Drawing.Point(96, 59);
            this.tbx_leistungIN.Name = "tbx_leistungIN";
            this.tbx_leistungIN.Size = new System.Drawing.Size(113, 21);
            this.tbx_leistungIN.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "in";
            // 
            // tbx_leisungVon
            // 
            this.tbx_leisungVon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbx_leisungVon.FormattingEnabled = true;
            this.tbx_leisungVon.Items.AddRange(new object[] {
            "PS",
            "Watt",
            "KW"});
            this.tbx_leisungVon.Location = new System.Drawing.Point(96, 19);
            this.tbx_leisungVon.Name = "tbx_leisungVon";
            this.tbx_leisungVon.Size = new System.Drawing.Size(113, 21);
            this.tbx_leisungVon.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Leistung von";
            // 
            // Frm_Umrechner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(460, 383);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Frm_Umrechner";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Umrechner";
            this.Load += new System.EventHandler(this.Frm_Umrechner_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_gewichtErgebnis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_gewicht)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_wurfgErgebnis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_wurfg)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown tbx_gewichtErgebnis;
        private System.Windows.Forms.ComboBox tbx_gewichtIN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown tbx_gewicht;
        private System.Windows.Forms.ComboBox tbx_gewichtVon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown tbx_wurfgErgebnis;
        private System.Windows.Forms.ComboBox tbx_wurfgIN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tbx_wurfg;
        private System.Windows.Forms.ComboBox tbx_wurfgVon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_gewicht;
        private System.Windows.Forms.Button btn_wurfgewicht;
        private System.Windows.Forms.CheckBox cb_wurfgEmpfohlen;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbx_leistungErgebnis;
        private System.Windows.Forms.TextBox tbx_leistung;
        private System.Windows.Forms.Button btn_leistung;
        private System.Windows.Forms.ComboBox tbx_leistungIN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox tbx_leisungVon;
        private System.Windows.Forms.Label label8;
    }
}