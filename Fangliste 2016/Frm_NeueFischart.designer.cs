namespace Fangliste_2016
{
    partial class Frm_NeueFischart
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
            this.label10 = new System.Windows.Forms.Label();
            this.tbx_korpulenzfaktor = new System.Windows.Forms.NumericUpDown();
            this.btn_fertig = new System.Windows.Forms.Button();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_berechnen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_korpulenzfaktor)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(68, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Korpulenzfaktor";
            // 
            // tbx_korpulenzfaktor
            // 
            this.tbx_korpulenzfaktor.DecimalPlaces = 2;
            this.tbx_korpulenzfaktor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.tbx_korpulenzfaktor.Location = new System.Drawing.Point(71, 99);
            this.tbx_korpulenzfaktor.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tbx_korpulenzfaktor.Name = "tbx_korpulenzfaktor";
            this.tbx_korpulenzfaktor.Size = new System.Drawing.Size(160, 20);
            this.tbx_korpulenzfaktor.TabIndex = 21;
            // 
            // btn_fertig
            // 
            this.btn_fertig.Location = new System.Drawing.Point(276, 156);
            this.btn_fertig.Name = "btn_fertig";
            this.btn_fertig.Size = new System.Drawing.Size(75, 23);
            this.btn_fertig.TabIndex = 23;
            this.btn_fertig.Text = "fertig";
            this.btn_fertig.UseVisualStyleBackColor = true;
            this.btn_fertig.Click += new System.EventHandler(this.btn_fertig_Click);
            // 
            // tbx_name
            // 
            this.tbx_name.Location = new System.Drawing.Point(71, 47);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(211, 20);
            this.tbx_name.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(68, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Fischart";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_berechnen
            // 
            this.btn_berechnen.Location = new System.Drawing.Point(237, 99);
            this.btn_berechnen.Name = "btn_berechnen";
            this.btn_berechnen.Size = new System.Drawing.Size(38, 20);
            this.btn_berechnen.TabIndex = 39;
            this.btn_berechnen.Text = "...";
            this.btn_berechnen.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_berechnen.UseVisualStyleBackColor = true;
            this.btn_berechnen.Click += new System.EventHandler(this.btn_berechnen_Click);
            // 
            // Frm_NeueFischart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(363, 191);
            this.Controls.Add(this.btn_berechnen);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbx_name);
            this.Controls.Add(this.btn_fertig);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbx_korpulenzfaktor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Frm_NeueFischart";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Neue Fischart";
            this.Load += new System.EventHandler(this.Frm_Fischarten_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbx_korpulenzfaktor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown tbx_korpulenzfaktor;
        private System.Windows.Forms.Button btn_fertig;
        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_berechnen;

    }
}