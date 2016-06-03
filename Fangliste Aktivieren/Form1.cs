using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FanglisteLibrary;
using Microsoft.Win32;

namespace Fangliste_Aktivieren
{
    public partial class Form1 : Form
    {
        #region Variablen

        #endregion

        #region Konstruktor

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_aktivieren_Click(object sender, EventArgs e)
        {
            try
            {
                bool value = passwordEntry("455212988kasI", tbx_passwort.Text);
                if (value == true)
                {
                    MessageBox.Show("Vielen Dank für die Aktivierung!", "Aktivierung", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Product Key ist ungültig! Bitte geben Sie einen gültigen Product Key!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Fehler");
            }
        }

        #endregion

        public bool passwordEntry(String originalPass, String pass)
        {
            if (originalPass == pass)
            {
                RegistryKey regkey = Registry.CurrentUser;
                regkey = regkey.CreateSubKey("Fangliste"); //path

                DateTime dt = DateTime.Now;
                string onlyDate = dt.ToShortDateString();

                if (regkey != null)
                {
                    Sicherheit s = new FanglisteLibrary.Sicherheit();

                    string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                    regkey.SetValue("Password", s.StringVerschlüsseln(pass)); //Value Name,Value Data
                    regkey.SetValue("Name", s.StringVerschlüsseln(username));
                    regkey.SetValue("Install", s.StringVerschlüsseln(onlyDate));
                    regkey.SetValue("Use", s.StringVerschlüsseln(onlyDate));
                }
                return true;
            }
            else
                return false;
        }
    }
}
