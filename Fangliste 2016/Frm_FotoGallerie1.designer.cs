namespace Fangliste_2016
{
    partial class Frm_FotoGallerie1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_FotoGallerie1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.übersichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.diashowShuffleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.speichernUnterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplikateSuchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip_keinFoto = new System.Windows.Forms.ToolTip(this.components);
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.cb_gewässer = new System.Windows.Forms.ComboBox();
            this.cb_anzahlFotos = new System.Windows.Forms.ComboBox();
            this.label_foto_von_anzahl = new System.Windows.Forms.Label();
            this.label_speed = new System.Windows.Forms.Label();
            this.btn_bearbeiten = new System.Windows.Forms.Button();
            this.button_diashow = new System.Windows.Forms.Button();
            this.lb_fotoInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btn_audio_next = new System.Windows.Forms.Button();
            this.btn_audio_back = new System.Windows.Forms.Button();
            this.cb_audio_shuffle = new System.Windows.Forms.CheckBox();
            this.trackBar_volume = new System.Windows.Forms.TrackBar();
            this.trackBar_speed = new System.Windows.Forms.TrackBar();
            this.button_vor = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.button_foto_löschen = new System.Windows.Forms.Button();
            this.button_fotos_hinzufügen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_kommentar = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker_MusikLaden = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.übersichtToolStripMenuItem,
            this.toolStripSeparator2,
            this.diashowShuffleToolStripMenuItem,
            this.toolStripSeparator1,
            this.speichernUnterToolStripMenuItem,
            this.duplikateSuchenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 104);
            // 
            // übersichtToolStripMenuItem
            // 
            this.übersichtToolStripMenuItem.Name = "übersichtToolStripMenuItem";
            this.übersichtToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.übersichtToolStripMenuItem.Text = "Übersicht";
            this.übersichtToolStripMenuItem.Click += new System.EventHandler(this.übersichtToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // diashowShuffleToolStripMenuItem
            // 
            this.diashowShuffleToolStripMenuItem.CheckOnClick = true;
            this.diashowShuffleToolStripMenuItem.Name = "diashowShuffleToolStripMenuItem";
            this.diashowShuffleToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.diashowShuffleToolStripMenuItem.Text = "Diashow shuffle";
            this.diashowShuffleToolStripMenuItem.Click += new System.EventHandler(this.diashowShuffleToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // speichernUnterToolStripMenuItem
            // 
            this.speichernUnterToolStripMenuItem.Name = "speichernUnterToolStripMenuItem";
            this.speichernUnterToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.speichernUnterToolStripMenuItem.Text = "Speichern unter";
            this.speichernUnterToolStripMenuItem.Click += new System.EventHandler(this.speichernUnterToolStripMenuItem_Click);
            // 
            // duplikateSuchenToolStripMenuItem
            // 
            this.duplikateSuchenToolStripMenuItem.Name = "duplikateSuchenToolStripMenuItem";
            this.duplikateSuchenToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.duplikateSuchenToolStripMenuItem.Text = "Duplikate suchen";
            this.duplikateSuchenToolStripMenuItem.Click += new System.EventHandler(this.duplikateSuchenToolStripMenuItem_Click);
            // 
            // toolTip_keinFoto
            // 
            this.toolTip_keinFoto.IsBalloon = true;
            this.toolTip_keinFoto.ShowAlways = true;
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 175);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(150, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(1181, 25);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightToolStripPanel.Location = new System.Drawing.Point(150, 25);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 150);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 25);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 150);
            // 
            // cb_gewässer
            // 
            this.cb_gewässer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_gewässer.DisplayMember = "Alle Fotos";
            this.cb_gewässer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_gewässer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cb_gewässer.FormattingEnabled = true;
            this.cb_gewässer.Items.AddRange(new object[] {
            "Alle Fotos"});
            this.cb_gewässer.Location = new System.Drawing.Point(158, 50);
            this.cb_gewässer.Name = "cb_gewässer";
            this.cb_gewässer.Size = new System.Drawing.Size(151, 23);
            this.cb_gewässer.Sorted = true;
            this.cb_gewässer.TabIndex = 1016;
            this.cb_gewässer.SelectionChangeCommitted += new System.EventHandler(this.cb_gewässer_SelectionChangeCommitted);
            // 
            // cb_anzahlFotos
            // 
            this.cb_anzahlFotos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_anzahlFotos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_anzahlFotos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_anzahlFotos.FormattingEnabled = true;
            this.cb_anzahlFotos.Location = new System.Drawing.Point(1093, 30);
            this.cb_anzahlFotos.Name = "cb_anzahlFotos";
            this.cb_anzahlFotos.Size = new System.Drawing.Size(52, 21);
            this.cb_anzahlFotos.TabIndex = 1014;
            this.cb_anzahlFotos.SelectedIndexChanged += new System.EventHandler(this.cb_anzahlFotos_SelectedIndexChanged);
            this.cb_anzahlFotos.SelectionChangeCommitted += new System.EventHandler(this.cb_anzahlFotos_SelectionChangeCommitted);
            // 
            // label_foto_von_anzahl
            // 
            this.label_foto_von_anzahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_foto_von_anzahl.AutoSize = true;
            this.label_foto_von_anzahl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_foto_von_anzahl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_foto_von_anzahl.Location = new System.Drawing.Point(1092, 54);
            this.label_foto_von_anzahl.Name = "label_foto_von_anzahl";
            this.label_foto_von_anzahl.Size = new System.Drawing.Size(53, 15);
            this.label_foto_von_anzahl.TabIndex = 1013;
            this.label_foto_von_anzahl.Text = "0 von 0";
            // 
            // label_speed
            // 
            this.label_speed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_speed.AutoSize = true;
            this.label_speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_speed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_speed.Location = new System.Drawing.Point(829, 3);
            this.label_speed.Name = "label_speed";
            this.label_speed.Size = new System.Drawing.Size(89, 16);
            this.label_speed.TabIndex = 1012;
            this.label_speed.Text = "4 sec./ Foto";
            // 
            // btn_bearbeiten
            // 
            this.btn_bearbeiten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_bearbeiten.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_bearbeiten.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_bearbeiten.BackgroundImage")));
            this.btn_bearbeiten.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_bearbeiten.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btn_bearbeiten.Location = new System.Drawing.Point(482, 4);
            this.btn_bearbeiten.Name = "btn_bearbeiten";
            this.btn_bearbeiten.Size = new System.Drawing.Size(71, 69);
            this.btn_bearbeiten.TabIndex = 1017;
            this.btn_bearbeiten.UseVisualStyleBackColor = false;
            this.btn_bearbeiten.Click += new System.EventHandler(this.btn_bearbeiten_Click);
            // 
            // button_diashow
            // 
            this.button_diashow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_diashow.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_diashow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_diashow.BackgroundImage")));
            this.button_diashow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_diashow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_diashow.Location = new System.Drawing.Point(713, 5);
            this.button_diashow.Name = "button_diashow";
            this.button_diashow.Size = new System.Drawing.Size(71, 68);
            this.button_diashow.TabIndex = 1008;
            this.button_diashow.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_diashow.UseVisualStyleBackColor = false;
            this.button_diashow.Click += new System.EventHandler(this.button_diashow_Click);
            // 
            // lb_fotoInfo
            // 
            this.lb_fotoInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_fotoInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lb_fotoInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_fotoInfo.Location = new System.Drawing.Point(0, 540);
            this.lb_fotoInfo.Name = "lb_fotoInfo";
            this.lb_fotoInfo.Size = new System.Drawing.Size(1180, 20);
            this.lb_fotoInfo.TabIndex = 1018;
            this.lb_fotoInfo.Text = "Keine Infos";
            this.lb_fotoInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.btn_audio_next);
            this.panel1.Controls.Add(this.btn_audio_back);
            this.panel1.Controls.Add(this.cb_audio_shuffle);
            this.panel1.Controls.Add(this.trackBar_volume);
            this.panel1.Controls.Add(this.trackBar_speed);
            this.panel1.Controls.Add(this.button_vor);
            this.panel1.Controls.Add(this.cb_gewässer);
            this.panel1.Controls.Add(this.button_back);
            this.panel1.Controls.Add(this.btn_bearbeiten);
            this.panel1.Controls.Add(this.button_foto_löschen);
            this.panel1.Controls.Add(this.cb_anzahlFotos);
            this.panel1.Controls.Add(this.button_fotos_hinzufügen);
            this.panel1.Controls.Add(this.label_speed);
            this.panel1.Controls.Add(this.button_diashow);
            this.panel1.Controls.Add(this.label_foto_von_anzahl);
            this.panel1.Location = new System.Drawing.Point(0, 560);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1180, 83);
            this.panel1.TabIndex = 1019;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(35, 60);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(72, 13);
            this.linkLabel1.TabIndex = 1023;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Ordner öffnen";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btn_audio_next
            // 
            this.btn_audio_next.Location = new System.Drawing.Point(80, 9);
            this.btn_audio_next.Name = "btn_audio_next";
            this.btn_audio_next.Size = new System.Drawing.Size(58, 23);
            this.btn_audio_next.TabIndex = 1022;
            this.btn_audio_next.Text = ">>";
            this.btn_audio_next.UseVisualStyleBackColor = true;
            this.btn_audio_next.Click += new System.EventHandler(this.btn_audio_next_Click);
            // 
            // btn_audio_back
            // 
            this.btn_audio_back.Location = new System.Drawing.Point(4, 9);
            this.btn_audio_back.Name = "btn_audio_back";
            this.btn_audio_back.Size = new System.Drawing.Size(58, 23);
            this.btn_audio_back.TabIndex = 1021;
            this.btn_audio_back.Text = "<<";
            this.btn_audio_back.UseVisualStyleBackColor = true;
            this.btn_audio_back.Click += new System.EventHandler(this.btn_audio_back_Click);
            // 
            // cb_audio_shuffle
            // 
            this.cb_audio_shuffle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_audio_shuffle.AutoSize = true;
            this.cb_audio_shuffle.Location = new System.Drawing.Point(158, 13);
            this.cb_audio_shuffle.Name = "cb_audio_shuffle";
            this.cb_audio_shuffle.Size = new System.Drawing.Size(60, 17);
            this.cb_audio_shuffle.TabIndex = 1020;
            this.cb_audio_shuffle.Text = "Zufällig";
            this.cb_audio_shuffle.UseVisualStyleBackColor = true;
            // 
            // trackBar_volume
            // 
            this.trackBar_volume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBar_volume.Location = new System.Drawing.Point(4, 35);
            this.trackBar_volume.Maximum = 100;
            this.trackBar_volume.Name = "trackBar_volume";
            this.trackBar_volume.Size = new System.Drawing.Size(134, 45);
            this.trackBar_volume.TabIndex = 1019;
            this.trackBar_volume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_volume.Scroll += new System.EventHandler(this.trackBar_volume_Scroll);
            // 
            // trackBar_speed
            // 
            this.trackBar_speed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBar_speed.Location = new System.Drawing.Point(790, 28);
            this.trackBar_speed.Name = "trackBar_speed";
            this.trackBar_speed.Size = new System.Drawing.Size(166, 45);
            this.trackBar_speed.TabIndex = 1018;
            this.trackBar_speed.Value = 4;
            this.trackBar_speed.Scroll += new System.EventHandler(this.trackBar_speed_Scroll);
            // 
            // button_vor
            // 
            this.button_vor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_vor.AutoSize = true;
            this.button_vor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_vor.BackgroundImage")));
            this.button_vor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_vor.Location = new System.Drawing.Point(636, 4);
            this.button_vor.Name = "button_vor";
            this.button_vor.Size = new System.Drawing.Size(71, 70);
            this.button_vor.TabIndex = 1004;
            this.button_vor.UseVisualStyleBackColor = true;
            this.button_vor.Click += new System.EventHandler(this.button_vor_Click);
            // 
            // button_back
            // 
            this.button_back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_back.AutoSize = true;
            this.button_back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_back.BackgroundImage")));
            this.button_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_back.Location = new System.Drawing.Point(559, 3);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(71, 71);
            this.button_back.TabIndex = 1003;
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button_foto_löschen
            // 
            this.button_foto_löschen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_foto_löschen.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_foto_löschen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_foto_löschen.BackgroundImage")));
            this.button_foto_löschen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_foto_löschen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.button_foto_löschen.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_foto_löschen.Location = new System.Drawing.Point(405, 5);
            this.button_foto_löschen.Name = "button_foto_löschen";
            this.button_foto_löschen.Size = new System.Drawing.Size(71, 68);
            this.button_foto_löschen.TabIndex = 1015;
            this.button_foto_löschen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_foto_löschen.UseVisualStyleBackColor = false;
            this.button_foto_löschen.Click += new System.EventHandler(this.button_foto_löschen_Click);
            // 
            // button_fotos_hinzufügen
            // 
            this.button_fotos_hinzufügen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_fotos_hinzufügen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_fotos_hinzufügen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_fotos_hinzufügen.BackgroundImage")));
            this.button_fotos_hinzufügen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_fotos_hinzufügen.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_fotos_hinzufügen.Location = new System.Drawing.Point(328, 5);
            this.button_fotos_hinzufügen.Name = "button_fotos_hinzufügen";
            this.button_fotos_hinzufügen.Size = new System.Drawing.Size(71, 68);
            this.button_fotos_hinzufügen.TabIndex = 1005;
            this.button_fotos_hinzufügen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_fotos_hinzufügen.UseVisualStyleBackColor = false;
            this.button_fotos_hinzufügen.Click += new System.EventHandler(this.button_foto_hinzufügen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1180, 516);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1006;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox1_LoadCompleted);
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ContentPanel
            // 
            this.ContentPanel.BackColor = System.Drawing.Color.Transparent;
            this.ContentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ContentPanel.BackgroundImage")));
            this.ContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ContentPanel.Size = new System.Drawing.Size(1181, 620);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label_kommentar);
            this.panel2.Controls.Add(this.lb_fotoInfo);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1180, 560);
            this.panel2.TabIndex = 1020;
            // 
            // label_kommentar
            // 
            this.label_kommentar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_kommentar.BackColor = System.Drawing.Color.Transparent;
            this.label_kommentar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label_kommentar.Location = new System.Drawing.Point(3, 519);
            this.label_kommentar.Name = "label_kommentar";
            this.label_kommentar.Size = new System.Drawing.Size(1174, 21);
            this.label_kommentar.TabIndex = 1019;
            this.label_kommentar.Text = "Kommentar";
            this.label_kommentar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backgroundWorker_MusikLaden
            // 
            this.backgroundWorker_MusikLaden.WorkerSupportsCancellation = true;
            this.backgroundWorker_MusikLaden.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_MusikLaden_DoWork);
            // 
            // Frm_FotoGallerie1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1181, 645);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1100, 500);
            this.Name = "Frm_FotoGallerie1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Foto Gallerie";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Gallerie_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Gallerie_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem übersichtToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem diashowShuffleToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip_keinFoto;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ComboBox cb_gewässer;
        private System.Windows.Forms.Button button_fotos_hinzufügen;
        private System.Windows.Forms.ComboBox cb_anzahlFotos;
        private System.Windows.Forms.Label label_foto_von_anzahl;
        private System.Windows.Forms.Label label_speed;
        private System.Windows.Forms.Button button_foto_löschen;
        private System.Windows.Forms.Button btn_bearbeiten;
        private System.Windows.Forms.Button button_diashow;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_vor;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Label lb_fotoInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBar_speed;
        private System.Windows.Forms.TrackBar trackBar_volume;
        private System.Windows.Forms.CheckBox cb_audio_shuffle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_audio_next;
        private System.Windows.Forms.Button btn_audio_back;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label_kommentar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem speichernUnterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem duplikateSuchenToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker_MusikLaden;


    }
}