namespace Fangliste_2016
{
    partial class Frm_Fang_bearbeiten
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Fang_bearbeiten));
            this.tbx_Größe = new System.Windows.Forms.NumericUpDown();
            this.tbx_Uhrzeit = new System.Windows.Forms.DateTimePicker();
            this.tbx_Datum = new System.Windows.Forms.DateTimePicker();
            this.epFehlermeldungen = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbx_Temperatur = new System.Windows.Forms.NumericUpDown();
            this.tbx_Tiefe = new System.Windows.Forms.NumericUpDown();
            this.tbx_Gewässer = new System.Windows.Forms.ComboBox();
            this.tbx_Gewicht = new System.Windows.Forms.NumericUpDown();
            this.tbx_Fischart = new System.Windows.Forms.ComboBox();
            this.btn_fertig = new System.Windows.Forms.Button();
            this.lb_Uhrzeit = new System.Windows.Forms.Label();
            this.lb_Temperatur = new System.Windows.Forms.Label();
            this.tbx_Köderbeschreibung = new System.Windows.Forms.TextBox();
            this.tbx_Platzbeschreibung = new System.Windows.Forms.TextBox();
            this.lb_Köderbeshreibung = new System.Windows.Forms.Label();
            this.lb_Tiefe = new System.Windows.Forms.Label();
            this.lb_Platzbeschreibung = new System.Windows.Forms.Label();
            this.lb_Gewässer = new System.Windows.Forms.Label();
            this.lb_Datum = new System.Windows.Forms.Label();
            this.lb_Gewicht = new System.Windows.Forms.Label();
            this.lb_Größe = new System.Windows.Forms.Label();
            this.lb_Fischart = new System.Windows.Forms.Label();
            this.comboBox_Name = new System.Windows.Forms.ComboBox();
            this.tbx_Wetter = new System.Windows.Forms.ComboBox();
            this.lb_Wetter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_zurückgesetzt = new System.Windows.Forms.CheckBox();
            this.btn_vorlage2 = new System.Windows.Forms.Button();
            this.btn_vorlage1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Größe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFehlermeldungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Temperatur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Tiefe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Gewicht)).BeginInit();
            this.SuspendLayout();
            // 
            // tbx_Größe
            // 
            this.tbx_Größe.DecimalPlaces = 2;
            this.tbx_Größe.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.tbx_Größe.Location = new System.Drawing.Point(149, 134);
            this.tbx_Größe.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Größe.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.tbx_Größe.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.tbx_Größe.Name = "tbx_Größe";
            this.tbx_Größe.Size = new System.Drawing.Size(264, 22);
            this.tbx_Größe.TabIndex = 73;
            this.tbx_Größe.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            this.tbx_Größe.ValueChanged += new System.EventHandler(this.tbx_Größe_ValueChanged);
            // 
            // tbx_Uhrzeit
            // 
            this.tbx_Uhrzeit.CustomFormat = "MMMM";
            this.tbx_Uhrzeit.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.tbx_Uhrzeit.Location = new System.Drawing.Point(597, 214);
            this.tbx_Uhrzeit.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Uhrzeit.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.tbx_Uhrzeit.MinDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
            this.tbx_Uhrzeit.Name = "tbx_Uhrzeit";
            this.tbx_Uhrzeit.ShowUpDown = true;
            this.tbx_Uhrzeit.Size = new System.Drawing.Size(163, 22);
            this.tbx_Uhrzeit.TabIndex = 72;
            this.tbx_Uhrzeit.ValueChanged += new System.EventHandler(this.tbx_Uhrzeit_ValueChanged);
            // 
            // tbx_Datum
            // 
            this.tbx_Datum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tbx_Datum.Location = new System.Drawing.Point(597, 140);
            this.tbx_Datum.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Datum.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.tbx_Datum.MinDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
            this.tbx_Datum.Name = "tbx_Datum";
            this.tbx_Datum.Size = new System.Drawing.Size(163, 22);
            this.tbx_Datum.TabIndex = 71;
            this.tbx_Datum.ValueChanged += new System.EventHandler(this.tbx_Datum_ValueChanged);
            // 
            // epFehlermeldungen
            // 
            this.epFehlermeldungen.ContainerControl = this;
            // 
            // tbx_Temperatur
            // 
            this.tbx_Temperatur.DecimalPlaces = 1;
            this.tbx_Temperatur.Location = new System.Drawing.Point(597, 24);
            this.tbx_Temperatur.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Temperatur.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.tbx_Temperatur.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.tbx_Temperatur.Name = "tbx_Temperatur";
            this.tbx_Temperatur.Size = new System.Drawing.Size(163, 22);
            this.tbx_Temperatur.TabIndex = 70;
            this.tbx_Temperatur.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.tbx_Temperatur.ValueChanged += new System.EventHandler(this.tbx_Temperatur_ValueChanged);
            // 
            // tbx_Tiefe
            // 
            this.tbx_Tiefe.DecimalPlaces = 1;
            this.tbx_Tiefe.Location = new System.Drawing.Point(597, 85);
            this.tbx_Tiefe.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Tiefe.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.tbx_Tiefe.Name = "tbx_Tiefe";
            this.tbx_Tiefe.Size = new System.Drawing.Size(163, 22);
            this.tbx_Tiefe.TabIndex = 69;
            this.tbx_Tiefe.ValueChanged += new System.EventHandler(this.tbx_Tiefe_ValueChanged);
            // 
            // tbx_Gewässer
            // 
            this.tbx_Gewässer.FormattingEnabled = true;
            this.tbx_Gewässer.Location = new System.Drawing.Point(149, 265);
            this.tbx_Gewässer.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Gewässer.Name = "tbx_Gewässer";
            this.tbx_Gewässer.Size = new System.Drawing.Size(264, 24);
            this.tbx_Gewässer.Sorted = true;
            this.tbx_Gewässer.TabIndex = 68;
            this.tbx_Gewässer.TextChanged += new System.EventHandler(this.tbx_Gewässer_TextChanged);
            // 
            // tbx_Gewicht
            // 
            this.tbx_Gewicht.DecimalPlaces = 2;
            this.tbx_Gewicht.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.tbx_Gewicht.Location = new System.Drawing.Point(149, 192);
            this.tbx_Gewicht.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Gewicht.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.tbx_Gewicht.Name = "tbx_Gewicht";
            this.tbx_Gewicht.Size = new System.Drawing.Size(264, 22);
            this.tbx_Gewicht.TabIndex = 67;
            this.tbx_Gewicht.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.tbx_Gewicht.ValueChanged += new System.EventHandler(this.tbx_Gewicht_ValueChanged);
            // 
            // tbx_Fischart
            // 
            this.tbx_Fischart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbx_Fischart.FormattingEnabled = true;
            this.tbx_Fischart.Location = new System.Drawing.Point(149, 73);
            this.tbx_Fischart.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Fischart.Name = "tbx_Fischart";
            this.tbx_Fischart.Size = new System.Drawing.Size(264, 24);
            this.tbx_Fischart.Sorted = true;
            this.tbx_Fischart.TabIndex = 66;
            this.tbx_Fischart.TextChanged += new System.EventHandler(this.tbx_Fischart_TextChanged);
            // 
            // btn_fertig
            // 
            this.btn_fertig.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_fertig.Location = new System.Drawing.Point(597, 415);
            this.btn_fertig.Margin = new System.Windows.Forms.Padding(5);
            this.btn_fertig.Name = "btn_fertig";
            this.btn_fertig.Size = new System.Drawing.Size(163, 47);
            this.btn_fertig.TabIndex = 65;
            this.btn_fertig.Text = "Fertig";
            this.btn_fertig.UseVisualStyleBackColor = true;
            this.btn_fertig.Click += new System.EventHandler(this.btn_fertig_Click);
            // 
            // lb_Uhrzeit
            // 
            this.lb_Uhrzeit.AutoSize = true;
            this.lb_Uhrzeit.BackColor = System.Drawing.Color.Transparent;
            this.lb_Uhrzeit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Uhrzeit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Uhrzeit.Location = new System.Drawing.Point(539, 219);
            this.lb_Uhrzeit.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_Uhrzeit.Name = "lb_Uhrzeit";
            this.lb_Uhrzeit.Size = new System.Drawing.Size(49, 16);
            this.lb_Uhrzeit.TabIndex = 64;
            this.lb_Uhrzeit.Text = "Uhrzeit";
            // 
            // lb_Temperatur
            // 
            this.lb_Temperatur.AutoSize = true;
            this.lb_Temperatur.BackColor = System.Drawing.Color.Transparent;
            this.lb_Temperatur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Temperatur.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Temperatur.Location = new System.Drawing.Point(510, 27);
            this.lb_Temperatur.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_Temperatur.Name = "lb_Temperatur";
            this.lb_Temperatur.Size = new System.Drawing.Size(78, 16);
            this.lb_Temperatur.TabIndex = 63;
            this.lb_Temperatur.Text = "Temperatur";
            // 
            // tbx_Köderbeschreibung
            // 
            this.tbx_Köderbeschreibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tbx_Köderbeschreibung.Location = new System.Drawing.Point(149, 415);
            this.tbx_Köderbeschreibung.Margin = new System.Windows.Forms.Padding(5);
            this.tbx_Köderbeschreibung.Multiline = true;
            this.tbx_Köderbeschreibung.Name = "tbx_Köderbeschreibung";
            this.tbx_Köderbeschreibung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Köderbeschreibung.Size = new System.Drawing.Size(264, 47);
            this.tbx_Köderbeschreibung.TabIndex = 62;
            this.tbx_Köderbeschreibung.TextChanged += new System.EventHandler(this.tbx_Köderbeschreibung_TextChanged);
            // 
            // tbx_Platzbeschreibung
            // 
            this.tbx_Platzbeschreibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tbx_Platzbeschreibung.Location = new System.Drawing.Point(149, 328);
            this.tbx_Platzbeschreibung.Margin = new System.Windows.Forms.Padding(5);
            this.tbx_Platzbeschreibung.Multiline = true;
            this.tbx_Platzbeschreibung.Name = "tbx_Platzbeschreibung";
            this.tbx_Platzbeschreibung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Platzbeschreibung.Size = new System.Drawing.Size(264, 47);
            this.tbx_Platzbeschreibung.TabIndex = 61;
            this.tbx_Platzbeschreibung.TextChanged += new System.EventHandler(this.tbx_Platzbeschreibung_TextChanged);
            // 
            // lb_Köderbeshreibung
            // 
            this.lb_Köderbeshreibung.AutoSize = true;
            this.lb_Köderbeshreibung.BackColor = System.Drawing.Color.Transparent;
            this.lb_Köderbeshreibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Köderbeshreibung.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Köderbeshreibung.Location = new System.Drawing.Point(14, 406);
            this.lb_Köderbeshreibung.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_Köderbeshreibung.Name = "lb_Köderbeshreibung";
            this.lb_Köderbeshreibung.Size = new System.Drawing.Size(131, 16);
            this.lb_Köderbeshreibung.TabIndex = 60;
            this.lb_Köderbeshreibung.Text = "Köder-Beschreibung";
            // 
            // lb_Tiefe
            // 
            this.lb_Tiefe.AutoSize = true;
            this.lb_Tiefe.BackColor = System.Drawing.Color.Transparent;
            this.lb_Tiefe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Tiefe.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Tiefe.Location = new System.Drawing.Point(549, 87);
            this.lb_Tiefe.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_Tiefe.Name = "lb_Tiefe";
            this.lb_Tiefe.Size = new System.Drawing.Size(39, 16);
            this.lb_Tiefe.TabIndex = 59;
            this.lb_Tiefe.Text = "Tiefe";
            // 
            // lb_Platzbeschreibung
            // 
            this.lb_Platzbeschreibung.AutoSize = true;
            this.lb_Platzbeschreibung.BackColor = System.Drawing.Color.Transparent;
            this.lb_Platzbeschreibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Platzbeschreibung.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Platzbeschreibung.Location = new System.Drawing.Point(21, 331);
            this.lb_Platzbeschreibung.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_Platzbeschreibung.Name = "lb_Platzbeschreibung";
            this.lb_Platzbeschreibung.Size = new System.Drawing.Size(124, 16);
            this.lb_Platzbeschreibung.TabIndex = 58;
            this.lb_Platzbeschreibung.Text = "Platz-Beschreibung";
            // 
            // lb_Gewässer
            // 
            this.lb_Gewässer.AutoSize = true;
            this.lb_Gewässer.BackColor = System.Drawing.Color.Transparent;
            this.lb_Gewässer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Gewässer.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Gewässer.Location = new System.Drawing.Point(76, 268);
            this.lb_Gewässer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_Gewässer.Name = "lb_Gewässer";
            this.lb_Gewässer.Size = new System.Drawing.Size(69, 16);
            this.lb_Gewässer.TabIndex = 57;
            this.lb_Gewässer.Text = "Gewässer";
            // 
            // lb_Datum
            // 
            this.lb_Datum.AutoSize = true;
            this.lb_Datum.BackColor = System.Drawing.Color.Transparent;
            this.lb_Datum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Datum.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Datum.Location = new System.Drawing.Point(541, 145);
            this.lb_Datum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_Datum.Name = "lb_Datum";
            this.lb_Datum.Size = new System.Drawing.Size(47, 16);
            this.lb_Datum.TabIndex = 56;
            this.lb_Datum.Text = "Datum";
            // 
            // lb_Gewicht
            // 
            this.lb_Gewicht.AutoSize = true;
            this.lb_Gewicht.BackColor = System.Drawing.Color.Transparent;
            this.lb_Gewicht.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Gewicht.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Gewicht.Location = new System.Drawing.Point(90, 194);
            this.lb_Gewicht.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_Gewicht.Name = "lb_Gewicht";
            this.lb_Gewicht.Size = new System.Drawing.Size(55, 16);
            this.lb_Gewicht.TabIndex = 55;
            this.lb_Gewicht.Text = "Gewicht";
            // 
            // lb_Größe
            // 
            this.lb_Größe.AutoSize = true;
            this.lb_Größe.BackColor = System.Drawing.Color.Transparent;
            this.lb_Größe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Größe.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Größe.Location = new System.Drawing.Point(99, 136);
            this.lb_Größe.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_Größe.Name = "lb_Größe";
            this.lb_Größe.Size = new System.Drawing.Size(46, 16);
            this.lb_Größe.TabIndex = 54;
            this.lb_Größe.Text = "Größe";
            // 
            // lb_Fischart
            // 
            this.lb_Fischart.AutoSize = true;
            this.lb_Fischart.BackColor = System.Drawing.Color.Transparent;
            this.lb_Fischart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Fischart.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Fischart.Location = new System.Drawing.Point(90, 76);
            this.lb_Fischart.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_Fischart.Name = "lb_Fischart";
            this.lb_Fischart.Size = new System.Drawing.Size(55, 16);
            this.lb_Fischart.TabIndex = 53;
            this.lb_Fischart.Text = "Fischart";
            // 
            // comboBox_Name
            // 
            this.comboBox_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Name.FormattingEnabled = true;
            this.comboBox_Name.Location = new System.Drawing.Point(149, 24);
            this.comboBox_Name.Name = "comboBox_Name";
            this.comboBox_Name.Size = new System.Drawing.Size(264, 24);
            this.comboBox_Name.Sorted = true;
            this.comboBox_Name.TabIndex = 74;
            this.comboBox_Name.TextChanged += new System.EventHandler(this.comboBox_Name_TextChanged);
            // 
            // tbx_Wetter
            // 
            this.tbx_Wetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbx_Wetter.FormattingEnabled = true;
            this.tbx_Wetter.Location = new System.Drawing.Point(597, 279);
            this.tbx_Wetter.Name = "tbx_Wetter";
            this.tbx_Wetter.Size = new System.Drawing.Size(163, 24);
            this.tbx_Wetter.Sorted = true;
            this.tbx_Wetter.TabIndex = 76;
            this.tbx_Wetter.TextChanged += new System.EventHandler(this.tbx_Wetter_TextChanged);
            // 
            // lb_Wetter
            // 
            this.lb_Wetter.AutoSize = true;
            this.lb_Wetter.BackColor = System.Drawing.Color.Transparent;
            this.lb_Wetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Wetter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Wetter.Location = new System.Drawing.Point(541, 282);
            this.lb_Wetter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Wetter.Name = "lb_Wetter";
            this.lb_Wetter.Size = new System.Drawing.Size(47, 16);
            this.lb_Wetter.TabIndex = 75;
            this.lb_Wetter.Text = "Wetter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(100, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 77;
            this.label1.Text = "Name";
            // 
            // tbx_zurückgesetzt
            // 
            this.tbx_zurückgesetzt.AutoSize = true;
            this.tbx_zurückgesetzt.BackColor = System.Drawing.Color.Transparent;
            this.tbx_zurückgesetzt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbx_zurückgesetzt.Location = new System.Drawing.Point(597, 327);
            this.tbx_zurückgesetzt.Name = "tbx_zurückgesetzt";
            this.tbx_zurückgesetzt.Size = new System.Drawing.Size(110, 20);
            this.tbx_zurückgesetzt.TabIndex = 78;
            this.tbx_zurückgesetzt.Text = "Zurückgesetzt";
            this.tbx_zurückgesetzt.UseVisualStyleBackColor = false;
            // 
            // btn_vorlage2
            // 
            this.btn_vorlage2.Location = new System.Drawing.Point(431, 415);
            this.btn_vorlage2.Name = "btn_vorlage2";
            this.btn_vorlage2.Size = new System.Drawing.Size(32, 30);
            this.btn_vorlage2.TabIndex = 80;
            this.btn_vorlage2.Text = "...";
            this.btn_vorlage2.UseVisualStyleBackColor = true;
            this.btn_vorlage2.Click += new System.EventHandler(this.btn_vorlage2_Click);
            // 
            // btn_vorlage1
            // 
            this.btn_vorlage1.Location = new System.Drawing.Point(431, 328);
            this.btn_vorlage1.Name = "btn_vorlage1";
            this.btn_vorlage1.Size = new System.Drawing.Size(32, 30);
            this.btn_vorlage1.TabIndex = 79;
            this.btn_vorlage1.Text = "...";
            this.btn_vorlage1.UseVisualStyleBackColor = true;
            this.btn_vorlage1.Click += new System.EventHandler(this.btn_vorlage1_Click);
            // 
            // Frm_Fang_bearbeiten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(815, 489);
            this.Controls.Add(this.btn_vorlage2);
            this.Controls.Add(this.btn_vorlage1);
            this.Controls.Add(this.tbx_zurückgesetzt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_Wetter);
            this.Controls.Add(this.lb_Wetter);
            this.Controls.Add(this.comboBox_Name);
            this.Controls.Add(this.tbx_Größe);
            this.Controls.Add(this.tbx_Uhrzeit);
            this.Controls.Add(this.tbx_Datum);
            this.Controls.Add(this.tbx_Temperatur);
            this.Controls.Add(this.tbx_Tiefe);
            this.Controls.Add(this.tbx_Gewässer);
            this.Controls.Add(this.tbx_Gewicht);
            this.Controls.Add(this.tbx_Fischart);
            this.Controls.Add(this.btn_fertig);
            this.Controls.Add(this.lb_Uhrzeit);
            this.Controls.Add(this.lb_Temperatur);
            this.Controls.Add(this.tbx_Köderbeschreibung);
            this.Controls.Add(this.tbx_Platzbeschreibung);
            this.Controls.Add(this.lb_Köderbeshreibung);
            this.Controls.Add(this.lb_Tiefe);
            this.Controls.Add(this.lb_Platzbeschreibung);
            this.Controls.Add(this.lb_Gewässer);
            this.Controls.Add(this.lb_Datum);
            this.Controls.Add(this.lb_Gewicht);
            this.Controls.Add(this.lb_Größe);
            this.Controls.Add(this.lb_Fischart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Fang_bearbeiten";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fang bearbeiten";
            this.Load += new System.EventHandler(this.Frm_Fang_bearbeiten_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Größe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFehlermeldungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Temperatur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Tiefe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Gewicht)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown tbx_Größe;
        private System.Windows.Forms.DateTimePicker tbx_Uhrzeit;
        private System.Windows.Forms.DateTimePicker tbx_Datum;
        private System.Windows.Forms.ErrorProvider epFehlermeldungen;
        private System.Windows.Forms.NumericUpDown tbx_Temperatur;
        private System.Windows.Forms.NumericUpDown tbx_Tiefe;
        private System.Windows.Forms.ComboBox tbx_Gewässer;
        private System.Windows.Forms.NumericUpDown tbx_Gewicht;
        private System.Windows.Forms.ComboBox tbx_Fischart;
        private System.Windows.Forms.Button btn_fertig;
        private System.Windows.Forms.Label lb_Uhrzeit;
        private System.Windows.Forms.Label lb_Temperatur;
        private System.Windows.Forms.TextBox tbx_Köderbeschreibung;
        private System.Windows.Forms.TextBox tbx_Platzbeschreibung;
        private System.Windows.Forms.Label lb_Köderbeshreibung;
        private System.Windows.Forms.Label lb_Tiefe;
        private System.Windows.Forms.Label lb_Platzbeschreibung;
        private System.Windows.Forms.Label lb_Gewässer;
        private System.Windows.Forms.Label lb_Datum;
        private System.Windows.Forms.Label lb_Gewicht;
        private System.Windows.Forms.Label lb_Größe;
        private System.Windows.Forms.Label lb_Fischart;
        private System.Windows.Forms.ComboBox comboBox_Name;
        private System.Windows.Forms.ComboBox tbx_Wetter;
        private System.Windows.Forms.Label lb_Wetter;
        private System.Windows.Forms.CheckBox tbx_zurückgesetzt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_vorlage2;
        private System.Windows.Forms.Button btn_vorlage1;
    }
}