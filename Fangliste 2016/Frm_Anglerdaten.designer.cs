namespace Fangliste_2016
{
    partial class Frm_Anglerdaten
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Anglerdaten));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_löschen = new System.Windows.Forms.Button();
            this.btn_durchsuchen = new System.Windows.Forms.Button();
            this.pic_Fischer = new System.Windows.Forms.PictureBox();
            this.tbx_kürzel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Fischer)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_löschen
            // 
            this.btn_löschen.Enabled = false;
            this.btn_löschen.Location = new System.Drawing.Point(12, 12);
            this.btn_löschen.Name = "btn_löschen";
            this.btn_löschen.Size = new System.Drawing.Size(42, 23);
            this.btn_löschen.TabIndex = 36;
            this.btn_löschen.Text = "X";
            this.btn_löschen.UseVisualStyleBackColor = true;
            this.btn_löschen.Click += new System.EventHandler(this.btn_fischerPicLöschen_Click);
            // 
            // btn_durchsuchen
            // 
            this.btn_durchsuchen.Location = new System.Drawing.Point(342, 12);
            this.btn_durchsuchen.Name = "btn_durchsuchen";
            this.btn_durchsuchen.Size = new System.Drawing.Size(36, 23);
            this.btn_durchsuchen.TabIndex = 35;
            this.btn_durchsuchen.Text = "...";
            this.btn_durchsuchen.UseVisualStyleBackColor = true;
            this.btn_durchsuchen.Click += new System.EventHandler(this.btn_durchsuchen_Click);
            // 
            // pic_Fischer
            // 
            this.pic_Fischer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pic_Fischer.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pic_Fischer.ErrorImage")));
            this.pic_Fischer.Image = ((System.Drawing.Image)(resources.GetObject("pic_Fischer.Image")));
            this.pic_Fischer.Location = new System.Drawing.Point(0, 0);
            this.pic_Fischer.Name = "pic_Fischer";
            this.pic_Fischer.Size = new System.Drawing.Size(396, 276);
            this.pic_Fischer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Fischer.TabIndex = 34;
            this.pic_Fischer.TabStop = false;
            // 
            // tbx_kürzel
            // 
            this.tbx_kürzel.Location = new System.Drawing.Point(65, 284);
            this.tbx_kürzel.Name = "tbx_kürzel";
            this.tbx_kürzel.Size = new System.Drawing.Size(141, 20);
            this.tbx_kürzel.TabIndex = 33;
            this.tbx_kürzel.TextChanged += new System.EventHandler(this.tbx_kürzel_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Name";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(342, 282);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(36, 23);
            this.btn_ok.TabIndex = 37;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_fischerBearbeiten_Click);
            // 
            // Frm_Anglerdaten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(396, 317);
            this.Controls.Add(this.tbx_kürzel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_löschen);
            this.Controls.Add(this.btn_durchsuchen);
            this.Controls.Add(this.pic_Fischer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_Anglerdaten";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stammdaten";
            this.Load += new System.EventHandler(this.Frm_Anglerdaten_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Fischer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_löschen;
        private System.Windows.Forms.Button btn_durchsuchen;
        private System.Windows.Forms.PictureBox pic_Fischer;
        private System.Windows.Forms.TextBox tbx_kürzel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ok;
    }
}