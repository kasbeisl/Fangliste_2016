using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Fangliste_2016
{
    //Informationen
    //Kasbeisl, Inc.
    //E-mail: kasbeisl@gmail.com
    //Entwickler: Kastberger Ferdinand
    //
    //Weiter Informationen:
    //Secure Class and Frm_Aktivieren written by Tanmay Sarkar.
    //
    //Sep 04, 2010
    //Code kann von der Webseite heruntergeladen werden.
    //Webseite: http://www.c-sharpcorner.com/uploadfile/tanmayit08/make-your-application-with-trial-version/
    //

    public partial class Frm_Aktivieren : Form
    {
        #region Variablen

        string getpassword;
        string regPath;

        #endregion

        #region Konstruktor

        public Frm_Aktivieren()
        {
            InitializeComponent();
        }

        public Frm_Aktivieren(String passname, String path)
        {
            InitializeComponent();
            getpassword = passname;
            regPath = path;
        }

        #endregion

        #region Methoden

        public bool passwordEntry(String originalPass, String pass)
        {
            if (originalPass == pass)
            {
                RegistryKey regkey = Registry.CurrentUser;
                regkey = regkey.CreateSubKey(regPath); //path

                if (regkey != null)
                {
                    regkey.SetValue("Password", pass); //Value Name,Value Data
                }
                return true;
            }
            else
                return false;
        }

        #endregion

        #region Events

        private void button1_Click(object sender, EventArgs e)
        {
            //if password true then send true			
            bool value = passwordEntry(getpassword,textBox1.Text);
            if (value ==true)
            {
                MessageBox.Show("Vielen Dank für die Aktivierung!", "Aktivierung", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Product Key ist ungültig! Bitte geben Sie einen gültigen Product Key!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//----------------------------------------------		
		
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        #endregion
    }
}
