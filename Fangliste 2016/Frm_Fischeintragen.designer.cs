namespace Fangliste_2016
{
    partial class Frm_Fischeintragen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Fischeintragen));
            this.lb_Temperatur = new System.Windows.Forms.Label();
            this.tbx_Köderbeschreibung = new System.Windows.Forms.TextBox();
            this.tbx_Platzbeschreibung = new System.Windows.Forms.TextBox();
            this.tbx_kommentar = new System.Windows.Forms.TextBox();
            this.lb_Köderbeshreibung = new System.Windows.Forms.Label();
            this.lb_Tiefe = new System.Windows.Forms.Label();
            this.lb_Platzbeschreibung = new System.Windows.Forms.Label();
            this.lb_Gewässer = new System.Windows.Forms.Label();
            this.lb_Datum = new System.Windows.Forms.Label();
            this.lb_Gewicht = new System.Windows.Forms.Label();
            this.lb_Größe = new System.Windows.Forms.Label();
            this.lb_Fischart = new System.Windows.Forms.Label();
            this.lb_Uhrzeit = new System.Windows.Forms.Label();
            this.epFehlermeldungen = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbx_Fischart = new System.Windows.Forms.ComboBox();
            this.tbx_Gewicht = new System.Windows.Forms.NumericUpDown();
            this.tbx_Gewässer = new System.Windows.Forms.ComboBox();
            this.tbx_Tiefe = new System.Windows.Forms.NumericUpDown();
            this.tbx_Temperatur = new System.Windows.Forms.NumericUpDown();
            this.tbx_wassertemperatur = new System.Windows.Forms.NumericUpDown();
            this.tbx_Datum = new System.Windows.Forms.DateTimePicker();
            this.tbx_Uhrzeit = new System.Windows.Forms.DateTimePicker();
            this.tbx_Größe = new System.Windows.Forms.NumericUpDown();
            this.lb_Wetter = new System.Windows.Forms.Label();
            this.tbx_Wetter = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbx_zurückgesetzt = new System.Windows.Forms.CheckBox();
            this.btn_eintragen = new System.Windows.Forms.Button();
            this.btn_vorlage1 = new System.Windows.Forms.Button();
            this.btn_vorlage2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epFehlermeldungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Gewicht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Tiefe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Temperatur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_wassertemperatur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Größe)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Temperatur
            // 
            this.lb_Temperatur.AutoSize = true;
            this.lb_Temperatur.BackColor = System.Drawing.Color.Transparent;
            this.lb_Temperatur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Temperatur.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Temperatur.Location = new System.Drawing.Point(531, 45);
            this.lb_Temperatur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Temperatur.Name = "lb_Temperatur";
            this.lb_Temperatur.Size = new System.Drawing.Size(116, 16);
            this.lb_Temperatur.TabIndex = 38;
            this.lb_Temperatur.Text = "Lufttemperatur [°C]";
            // 
            // tbx_Köderbeschreibung
            // 
            this.tbx_Köderbeschreibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Köderbeschreibung.Location = new System.Drawing.Point(175, 326);
            this.tbx_Köderbeschreibung.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Köderbeschreibung.Multiline = true;
            this.tbx_Köderbeschreibung.Name = "tbx_Köderbeschreibung";
            this.tbx_Köderbeschreibung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Köderbeschreibung.Size = new System.Drawing.Size(264, 47);
            this.tbx_Köderbeschreibung.TabIndex = 5;
            this.tbx_Köderbeschreibung.Validating += new System.ComponentModel.CancelEventHandler(this.tbx_Köderbeschreibung_Validating);
            this.tbx_Köderbeschreibung.Validated += new System.EventHandler(this.tbx_Köderbeschreibung_Validated);
            // 
            // tbx_Platzbeschreibung
            // 
            this.tbx_Platzbeschreibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Platzbeschreibung.Location = new System.Drawing.Point(175, 249);
            this.tbx_Platzbeschreibung.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Platzbeschreibung.Multiline = true;
            this.tbx_Platzbeschreibung.Name = "tbx_Platzbeschreibung";
            this.tbx_Platzbeschreibung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Platzbeschreibung.Size = new System.Drawing.Size(264, 47);
            this.tbx_Platzbeschreibung.TabIndex = 4;
            this.tbx_Platzbeschreibung.Validating += new System.ComponentModel.CancelEventHandler(this.tbx_Platzbeschreibung_Validating);
            this.tbx_Platzbeschreibung.Validated += new System.EventHandler(this.tbx_Platzbeschreibung_Validated);
            // 
            // tbx_kommentar
            // 
            this.tbx_kommentar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_kommentar.Location = new System.Drawing.Point(175, 393);
            this.tbx_kommentar.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_kommentar.Multiline = true;
            this.tbx_kommentar.Name = "tbx_kommentar";
            this.tbx_kommentar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_kommentar.Size = new System.Drawing.Size(264, 47);
            this.tbx_kommentar.TabIndex = 6;
            // 
            // lb_Köderbeshreibung
            // 
            this.lb_Köderbeshreibung.AutoSize = true;
            this.lb_Köderbeshreibung.BackColor = System.Drawing.Color.Transparent;
            this.lb_Köderbeshreibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Köderbeshreibung.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Köderbeshreibung.Location = new System.Drawing.Point(30, 329);
            this.lb_Köderbeshreibung.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Köderbeshreibung.Name = "lb_Köderbeshreibung";
            this.lb_Köderbeshreibung.Size = new System.Drawing.Size(131, 16);
            this.lb_Köderbeshreibung.TabIndex = 30;
            this.lb_Köderbeshreibung.Text = "Köder-Beschreibung";
            // 
            // lb_Tiefe
            // 
            this.lb_Tiefe.AutoSize = true;
            this.lb_Tiefe.BackColor = System.Drawing.Color.Transparent;
            this.lb_Tiefe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Tiefe.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Tiefe.Location = new System.Drawing.Point(586, 148);
            this.lb_Tiefe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Tiefe.Name = "lb_Tiefe";
            this.lb_Tiefe.Size = new System.Drawing.Size(61, 16);
            this.lb_Tiefe.TabIndex = 29;
            this.lb_Tiefe.Text = "Tiefe [m]";
            // 
            // lb_Platzbeschreibung
            // 
            this.lb_Platzbeschreibung.AutoSize = true;
            this.lb_Platzbeschreibung.BackColor = System.Drawing.Color.Transparent;
            this.lb_Platzbeschreibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Platzbeschreibung.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Platzbeschreibung.Location = new System.Drawing.Point(37, 249);
            this.lb_Platzbeschreibung.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Platzbeschreibung.Name = "lb_Platzbeschreibung";
            this.lb_Platzbeschreibung.Size = new System.Drawing.Size(124, 16);
            this.lb_Platzbeschreibung.TabIndex = 28;
            this.lb_Platzbeschreibung.Text = "Platz-Beschreibung";
            // 
            // lb_Gewässer
            // 
            this.lb_Gewässer.AutoSize = true;
            this.lb_Gewässer.BackColor = System.Drawing.Color.Transparent;
            this.lb_Gewässer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Gewässer.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Gewässer.Location = new System.Drawing.Point(92, 201);
            this.lb_Gewässer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Gewässer.Name = "lb_Gewässer";
            this.lb_Gewässer.Size = new System.Drawing.Size(69, 16);
            this.lb_Gewässer.TabIndex = 27;
            this.lb_Gewässer.Text = "Gewässer";
            // 
            // lb_Datum
            // 
            this.lb_Datum.AutoSize = true;
            this.lb_Datum.BackColor = System.Drawing.Color.Transparent;
            this.lb_Datum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Datum.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Datum.Location = new System.Drawing.Point(600, 203);
            this.lb_Datum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Datum.Name = "lb_Datum";
            this.lb_Datum.Size = new System.Drawing.Size(47, 16);
            this.lb_Datum.TabIndex = 26;
            this.lb_Datum.Text = "Datum";
            // 
            // lb_Gewicht
            // 
            this.lb_Gewicht.AutoSize = true;
            this.lb_Gewicht.BackColor = System.Drawing.Color.Transparent;
            this.lb_Gewicht.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Gewicht.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Gewicht.Location = new System.Drawing.Point(80, 148);
            this.lb_Gewicht.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Gewicht.Name = "lb_Gewicht";
            this.lb_Gewicht.Size = new System.Drawing.Size(81, 16);
            this.lb_Gewicht.TabIndex = 25;
            this.lb_Gewicht.Text = "Gewicht [kg]";
            // 
            // lb_Größe
            // 
            this.lb_Größe.AutoSize = true;
            this.lb_Größe.BackColor = System.Drawing.Color.Transparent;
            this.lb_Größe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Größe.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Größe.Location = new System.Drawing.Point(86, 101);
            this.lb_Größe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Größe.Name = "lb_Größe";
            this.lb_Größe.Size = new System.Drawing.Size(75, 16);
            this.lb_Größe.TabIndex = 24;
            this.lb_Größe.Text = "Größe [cm]";
            // 
            // lb_Fischart
            // 
            this.lb_Fischart.AutoSize = true;
            this.lb_Fischart.BackColor = System.Drawing.Color.Transparent;
            this.lb_Fischart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Fischart.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Fischart.Location = new System.Drawing.Point(106, 46);
            this.lb_Fischart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Fischart.Name = "lb_Fischart";
            this.lb_Fischart.Size = new System.Drawing.Size(55, 16);
            this.lb_Fischart.TabIndex = 22;
            this.lb_Fischart.Text = "Fischart";
            // 
            // lb_Uhrzeit
            // 
            this.lb_Uhrzeit.AutoSize = true;
            this.lb_Uhrzeit.BackColor = System.Drawing.Color.Transparent;
            this.lb_Uhrzeit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Uhrzeit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Uhrzeit.Location = new System.Drawing.Point(598, 256);
            this.lb_Uhrzeit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Uhrzeit.Name = "lb_Uhrzeit";
            this.lb_Uhrzeit.Size = new System.Drawing.Size(49, 16);
            this.lb_Uhrzeit.TabIndex = 40;
            this.lb_Uhrzeit.Text = "Uhrzeit";
            // 
            // epFehlermeldungen
            // 
            this.epFehlermeldungen.ContainerControl = this;
            // 
            // tbx_Fischart
            // 
            this.tbx_Fischart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbx_Fischart.FormattingEnabled = true;
            this.tbx_Fischart.Location = new System.Drawing.Point(175, 42);
            this.tbx_Fischart.Name = "tbx_Fischart";
            this.tbx_Fischart.Size = new System.Drawing.Size(264, 24);
            this.tbx_Fischart.Sorted = true;
            this.tbx_Fischart.TabIndex = 0;
            // 
            // tbx_Gewicht
            // 
            this.tbx_Gewicht.DecimalPlaces = 2;
            this.tbx_Gewicht.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.tbx_Gewicht.Location = new System.Drawing.Point(175, 146);
            this.tbx_Gewicht.Name = "tbx_Gewicht";
            this.tbx_Gewicht.Size = new System.Drawing.Size(264, 22);
            this.tbx_Gewicht.TabIndex = 2;
            this.tbx_Gewicht.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbx_Gewicht.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.tbx_Gewicht.ValueChanged += new System.EventHandler(this.tbx_Gewicht_ValueChanged);
            // 
            // tbx_Gewässer
            // 
            this.tbx_Gewässer.FormattingEnabled = true;
            this.tbx_Gewässer.Location = new System.Drawing.Point(175, 198);
            this.tbx_Gewässer.Name = "tbx_Gewässer";
            this.tbx_Gewässer.Size = new System.Drawing.Size(264, 24);
            this.tbx_Gewässer.Sorted = true;
            this.tbx_Gewässer.TabIndex = 3;
            this.tbx_Gewässer.Validating += new System.ComponentModel.CancelEventHandler(this.tbx_Gewässer_Validating);
            this.tbx_Gewässer.Validated += new System.EventHandler(this.tbx_Gewässer_Validated);
            // 
            // tbx_Tiefe
            // 
            this.tbx_Tiefe.DecimalPlaces = 1;
            this.tbx_Tiefe.Location = new System.Drawing.Point(659, 146);
            this.tbx_Tiefe.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.tbx_Tiefe.Name = "tbx_Tiefe";
            this.tbx_Tiefe.Size = new System.Drawing.Size(163, 22);
            this.tbx_Tiefe.TabIndex = 9;
            this.tbx_Tiefe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbx_Temperatur
            // 
            this.tbx_Temperatur.DecimalPlaces = 1;
            this.tbx_Temperatur.Location = new System.Drawing.Point(659, 44);
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
            this.tbx_Temperatur.TabIndex = 7;
            this.tbx_Temperatur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbx_Temperatur.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // tbx_wassertemperatur
            // 
            this.tbx_wassertemperatur.DecimalPlaces = 1;
            this.tbx_wassertemperatur.Location = new System.Drawing.Point(659, 99);
            this.tbx_wassertemperatur.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.tbx_wassertemperatur.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.tbx_wassertemperatur.Name = "tbx_wassertemperatur";
            this.tbx_wassertemperatur.Size = new System.Drawing.Size(163, 22);
            this.tbx_wassertemperatur.TabIndex = 8;
            this.tbx_wassertemperatur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbx_wassertemperatur.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // tbx_Datum
            // 
            this.tbx_Datum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tbx_Datum.Location = new System.Drawing.Point(659, 198);
            this.tbx_Datum.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.tbx_Datum.MinDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
            this.tbx_Datum.Name = "tbx_Datum";
            this.tbx_Datum.Size = new System.Drawing.Size(163, 22);
            this.tbx_Datum.TabIndex = 10;
            this.tbx_Datum.ValueChanged += new System.EventHandler(this.tbx_Datum_ValueChanged);
            this.tbx_Datum.Validating += new System.ComponentModel.CancelEventHandler(this.tbx_Datum_Validating);
            this.tbx_Datum.Validated += new System.EventHandler(this.tbx_Datum_Validated);
            // 
            // tbx_Uhrzeit
            // 
            this.tbx_Uhrzeit.CustomFormat = "MMMM";
            this.tbx_Uhrzeit.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.tbx_Uhrzeit.Location = new System.Drawing.Point(659, 251);
            this.tbx_Uhrzeit.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.tbx_Uhrzeit.MinDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
            this.tbx_Uhrzeit.Name = "tbx_Uhrzeit";
            this.tbx_Uhrzeit.ShowUpDown = true;
            this.tbx_Uhrzeit.Size = new System.Drawing.Size(163, 22);
            this.tbx_Uhrzeit.TabIndex = 11;
            this.tbx_Uhrzeit.Value = new System.DateTime(2014, 3, 23, 5, 0, 0, 0);
            this.tbx_Uhrzeit.ValueChanged += new System.EventHandler(this.tbx_Uhrzeit_ValueChanged);
            this.tbx_Uhrzeit.Validating += new System.ComponentModel.CancelEventHandler(this.tbx_Uhrzeit_Validating);
            this.tbx_Uhrzeit.Validated += new System.EventHandler(this.tbx_Uhrzeit_Validated);
            // 
            // tbx_Größe
            // 
            this.tbx_Größe.DecimalPlaces = 1;
            this.tbx_Größe.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.tbx_Größe.Location = new System.Drawing.Point(175, 99);
            this.tbx_Größe.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.tbx_Größe.Name = "tbx_Größe";
            this.tbx_Größe.Size = new System.Drawing.Size(264, 22);
            this.tbx_Größe.TabIndex = 1;
            this.tbx_Größe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbx_Größe.ValueChanged += new System.EventHandler(this.tbx_Größe_ValueChanged);
            this.tbx_Größe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_Größe_KeyPress);
            // 
            // lb_Wetter
            // 
            this.lb_Wetter.AutoSize = true;
            this.lb_Wetter.BackColor = System.Drawing.Color.Transparent;
            this.lb_Wetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Wetter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_Wetter.Location = new System.Drawing.Point(600, 304);
            this.lb_Wetter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Wetter.Name = "lb_Wetter";
            this.lb_Wetter.Size = new System.Drawing.Size(47, 16);
            this.lb_Wetter.TabIndex = 41;
            this.lb_Wetter.Text = "Wetter";
            // 
            // tbx_Wetter
            // 
            this.tbx_Wetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbx_Wetter.FormattingEnabled = true;
            this.tbx_Wetter.Location = new System.Drawing.Point(659, 301);
            this.tbx_Wetter.Name = "tbx_Wetter";
            this.tbx_Wetter.Size = new System.Drawing.Size(163, 24);
            this.tbx_Wetter.Sorted = true;
            this.tbx_Wetter.TabIndex = 12;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tbx_zurückgesetzt
            // 
            this.tbx_zurückgesetzt.AutoSize = true;
            this.tbx_zurückgesetzt.BackColor = System.Drawing.Color.Transparent;
            this.tbx_zurückgesetzt.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tbx_zurückgesetzt.Location = new System.Drawing.Point(659, 345);
            this.tbx_zurückgesetzt.Name = "tbx_zurückgesetzt";
            this.tbx_zurückgesetzt.Size = new System.Drawing.Size(110, 20);
            this.tbx_zurückgesetzt.TabIndex = 13;
            this.tbx_zurückgesetzt.Text = "Zurückgesetzt";
            this.tbx_zurückgesetzt.UseVisualStyleBackColor = false;
            // 
            // btn_eintragen
            // 
            this.btn_eintragen.Location = new System.Drawing.Point(659, 393);
            this.btn_eintragen.Margin = new System.Windows.Forms.Padding(4);
            this.btn_eintragen.Name = "btn_eintragen";
            this.btn_eintragen.Size = new System.Drawing.Size(163, 47);
            this.btn_eintragen.TabIndex = 14;
            this.btn_eintragen.Text = "eintragen";
            this.btn_eintragen.UseVisualStyleBackColor = true;
            this.btn_eintragen.Click += new System.EventHandler(this.btn_eintragen_Click);
            // 
            // btn_vorlage1
            // 
            this.btn_vorlage1.Location = new System.Drawing.Point(446, 249);
            this.btn_vorlage1.Name = "btn_vorlage1";
            this.btn_vorlage1.Size = new System.Drawing.Size(32, 30);
            this.btn_vorlage1.TabIndex = 45;
            this.btn_vorlage1.Text = "...";
            this.btn_vorlage1.UseVisualStyleBackColor = true;
            this.btn_vorlage1.Click += new System.EventHandler(this.btn_vorlage1_Click);
            // 
            // btn_vorlage2
            // 
            this.btn_vorlage2.Location = new System.Drawing.Point(446, 326);
            this.btn_vorlage2.Name = "btn_vorlage2";
            this.btn_vorlage2.Size = new System.Drawing.Size(32, 30);
            this.btn_vorlage2.TabIndex = 46;
            this.btn_vorlage2.Text = "...";
            this.btn_vorlage2.UseVisualStyleBackColor = true;
            this.btn_vorlage2.Click += new System.EventHandler(this.btn_vorlage2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(504, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 16);
            this.label1.TabIndex = 48;
            this.label1.Text = "Wassertemperatur [°C]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(85, 396);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 50;
            this.label2.Text = "Kommentar";
            // 
            // Frm_Fischeintragen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(894, 497);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_kommentar);
            this.Controls.Add(this.tbx_wassertemperatur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_vorlage2);
            this.Controls.Add(this.btn_vorlage1);
            this.Controls.Add(this.btn_eintragen);
            this.Controls.Add(this.tbx_zurückgesetzt);
            this.Controls.Add(this.tbx_Wetter);
            this.Controls.Add(this.lb_Wetter);
            this.Controls.Add(this.tbx_Größe);
            this.Controls.Add(this.tbx_Uhrzeit);
            this.Controls.Add(this.tbx_Datum);
            this.Controls.Add(this.tbx_Temperatur);
            this.Controls.Add(this.tbx_Tiefe);
            this.Controls.Add(this.tbx_Gewässer);
            this.Controls.Add(this.tbx_Gewicht);
            this.Controls.Add(this.tbx_Fischart);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Frm_Fischeintragen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fisch eintragen";
            this.Load += new System.EventHandler(this.Frm_Fischeintragen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epFehlermeldungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Gewicht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Tiefe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Temperatur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_wassertemperatur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Größe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Temperatur;
        private System.Windows.Forms.TextBox tbx_Köderbeschreibung;
        private System.Windows.Forms.TextBox tbx_kommentar;
        private System.Windows.Forms.TextBox tbx_Platzbeschreibung;
        private System.Windows.Forms.Label lb_Köderbeshreibung;
        private System.Windows.Forms.Label lb_Tiefe;
        private System.Windows.Forms.Label lb_Platzbeschreibung;
        private System.Windows.Forms.Label lb_Gewässer;
        private System.Windows.Forms.Label lb_Datum;
        private System.Windows.Forms.Label lb_Gewicht;
        private System.Windows.Forms.Label lb_Größe;
        private System.Windows.Forms.Label lb_Fischart;
        private System.Windows.Forms.Label lb_Uhrzeit;
        private System.Windows.Forms.ErrorProvider epFehlermeldungen;
        private System.Windows.Forms.ComboBox tbx_Fischart;
        private System.Windows.Forms.DateTimePicker tbx_Datum;
        private System.Windows.Forms.NumericUpDown tbx_Temperatur;
        private System.Windows.Forms.NumericUpDown tbx_wassertemperatur;
        private System.Windows.Forms.NumericUpDown tbx_Tiefe;
        private System.Windows.Forms.ComboBox tbx_Gewässer;
        private System.Windows.Forms.NumericUpDown tbx_Gewicht;
        private System.Windows.Forms.DateTimePicker tbx_Uhrzeit;
        private System.Windows.Forms.NumericUpDown tbx_Größe;
        private System.Windows.Forms.ComboBox tbx_Wetter;
        private System.Windows.Forms.Label lb_Wetter;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox tbx_zurückgesetzt;
        private System.Windows.Forms.Button btn_eintragen;
        private System.Windows.Forms.Button btn_vorlage2;
        private System.Windows.Forms.Button btn_vorlage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        
    }
}