namespace Fangliste_2016
{
    partial class Frm_Vollbild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Vollbild));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_fotoInfo = new System.Windows.Forms.Label();
            this.label_kommentar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1280, 768);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox1_LoadCompleted);
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // lb_fotoInfo
            // 
            this.lb_fotoInfo.BackColor = System.Drawing.Color.Black;
            this.lb_fotoInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_fotoInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.lb_fotoInfo.Location = new System.Drawing.Point(0, 742);
            this.lb_fotoInfo.Name = "lb_fotoInfo";
            this.lb_fotoInfo.Size = new System.Drawing.Size(1280, 26);
            this.lb_fotoInfo.TabIndex = 3;
            this.lb_fotoInfo.Text = "Fotoinfo";
            this.lb_fotoInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label_kommentar
            // 
            this.label_kommentar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_kommentar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_kommentar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label_kommentar.Location = new System.Drawing.Point(0, 719);
            this.label_kommentar.Name = "label_kommentar";
            this.label_kommentar.Size = new System.Drawing.Size(1280, 23);
            this.label_kommentar.TabIndex = 4;
            this.label_kommentar.Text = "Kommentar";
            this.label_kommentar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_kommentar.Click += new System.EventHandler(this.label1_Click);
            // 
            // Frm_Vollbild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1280, 768);
            this.ControlBox = false;
            this.Controls.Add(this.label_kommentar);
            this.Controls.Add(this.lb_fotoInfo);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Vollbild";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vollbild";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Vollbild_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_Vollbild_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_fotoInfo;
        private System.Windows.Forms.Label label_kommentar;


    }
}