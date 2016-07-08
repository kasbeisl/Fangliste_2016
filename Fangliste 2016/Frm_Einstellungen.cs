using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FanglisteLibrary;
using System.IO;
using System.Media;

namespace Fangliste_2016
{
    public partial class Frm_Einstellungen : Form
    {
        #region Variablen

        
        #endregion

        #region Konstruktor

        public Frm_Einstellungen()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Frm_Einstellungen_Load(object sender, EventArgs e)
        {
            TextBox_mit_Daten_füllen();
        }

        private void Frm_Einstellungen_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        #endregion

        #region Buttons

        private void btn_ok_Click_1(object sender, EventArgs e)
        {
            Fangliste_2016.Properties.Settings.Default.FangVorlageAutomatik = cb_FangVorlageAutotik.Checked;
            Fangliste_2016.Properties.Settings.Default.PlaySound = cb_sound.Checked;
            Fangliste_2016.Properties.Settings.Default.Hostname = tbx_host.Text;
            Fangliste_2016.Properties.Settings.Default.Username = tbx_username.Text;
            Fangliste_2016.Properties.Settings.Default.Passwort = tbx_password.Text;
            Fangliste_2016.Properties.Settings.Default.HitparadeFischAuswahl = tbx_hitparadeAuswahl.Text;
            Fangliste_2016.Properties.Settings.Default.Save();
            Fangliste_2016.Properties.Settings.Default.Reload();
            this.Close();
        }
        
        private void btn_abbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Methoden

        private void TextBox_mit_Daten_füllen()
        {
            cb_FangVorlageAutotik.Checked = Fangliste_2016.Properties.Settings.Default.FangVorlageAutomatik;
            cb_sound.Checked = Properties.Settings.Default.PlaySound;
            tbx_host.Text = Fangliste_2016.Properties.Settings.Default.Hostname;
            tbx_username.Text = Fangliste_2016.Properties.Settings.Default.Username;
            tbx_password.Text = Fangliste_2016.Properties.Settings.Default.Passwort;
            tbx_hitparadeAuswahl.Text = Properties.Settings.Default.HitparadeFischAuswahl;
        }

        #endregion
    }
}
