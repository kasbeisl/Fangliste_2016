using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace FanglisteLibrary
{
    public class Lizenz
    {
        #region Variablen

        private string globalPath;
        string status = "";
        string name;
        int maxdays = 365;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Leerer Konstruktor
        /// </summary>
        public Lizenz()
        {
        }

        #endregion

        #region Methoden

        private void firstTime()
        {
            RegistryKey regkey = Registry.CurrentUser;
            regkey = regkey.CreateSubKey(globalPath); //path

            DateTime dt = DateTime.Now;
            string onlyDate = dt.ToShortDateString(); // get only date not time

            Sicherheit s = new Sicherheit();

            regkey.SetValue("Install", s.StringVerschlüsseln(onlyDate)); //Value Name,Value Data
            regkey.SetValue("Use", s.StringVerschlüsseln(onlyDate)); //Value Name,Value Data
        }

        private String checkfirstDate()
        {
            Sicherheit s = new Sicherheit();
            RegistryKey regkey = Registry.CurrentUser;
            regkey = regkey.CreateSubKey(globalPath); //path
            string Br = s.StringEntschlüsseln((string)regkey.GetValue("Install"));
            if (s.StringEntschlüsseln((string)regkey.GetValue("Install")) == null)
                return "First";
            else
                return Br;
        }

        private bool checkPassword(String pass)
        {
            Sicherheit s = new Sicherheit();
            RegistryKey regkey = Registry.CurrentUser;
            regkey = regkey.CreateSubKey(globalPath); //path
            string Br = s.StringEntschlüsseln((string)regkey.GetValue("Password"));
            if (Br == pass)
                return true; //good
            else
                return false;//bad
        }

        private string getName()
        {
            Sicherheit s = new Sicherheit();
            RegistryKey regkey = Registry.CurrentUser;
            regkey = regkey.CreateSubKey(globalPath); //path
            string name = s.StringEntschlüsseln((string)regkey.GetValue("Name"));

            return name;
        }

        private void blackList()
        {
            Sicherheit s = new Sicherheit();
            RegistryKey regkey = Registry.CurrentUser;
            regkey = regkey.CreateSubKey(globalPath); //path

            regkey.SetValue("Black", s.StringVerschlüsseln("True"));

        }

        private bool blackListCheck()
        {
            Sicherheit s = new Sicherheit();
            RegistryKey regkey = Registry.CurrentUser;
            regkey = regkey.CreateSubKey(globalPath); //path
            string Br = s.StringEntschlüsseln((string)regkey.GetValue("Black"));
            if (s.StringEntschlüsseln((string)regkey.GetValue("Black")) == null)
                return false; //No
            else
                return true;//Yes
        }

        public bool Algorithm(String appPassword, String pass)
        {
            globalPath = pass;
            this.name = getName();
            string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            if (this.name == username)
            {
                bool chpass = checkPassword(appPassword);
                if (chpass == true) //execute
                {
                    status = dayDifPutPresent();
                    if (status == "Error")
                    {
                        blackList();
                        MessageBox.Show("Anwendung kann nicht geladen werden, dass Datum wurde manipuliert!", "Fangliste - Lizenz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (status == "Expired")
                    {
                        MessageBox.Show("Die Lizenz ist nun abgelaufen!", "Fangliste - Lizenz", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return false;
                    }
                    //else // execute with how many day remaining
                    //{
                    //    MessageBox.Show("Sie verwenden die Trial-Version, Sie haben " + status + " Tage noch, bis zur aktivierung!", "Kabel Kalkulator", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    //    return false;
                    //}

                    return true;
                }
                else
                {
                    bool block = blackListCheck();
                    if (block == false)
                    {
                        MessageBox.Show("Sie müssen das Programm aktivieren?", "Fangliste - Lizenz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Anwendung kann nicht geladen werden!", "Fangliste - Lizenz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Sie haben keine Lizenz.", "Fangliste - Lizenz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private String dayDifPutPresent()
        {
            Sicherheit s = new Sicherheit();

            // get present date from system
            DateTime dt = DateTime.Now;
            string today = dt.ToShortDateString();
            DateTime presentDate = Convert.ToDateTime(today);

            // get instalation date
            RegistryKey regkey = Registry.CurrentUser;
            regkey = regkey.CreateSubKey(globalPath); //path
            string Br = s.StringEntschlüsseln((string)regkey.GetValue("Install"));
            DateTime installationDate = Convert.ToDateTime(Br);

            TimeSpan diff = presentDate.Subtract(installationDate); //first.Subtract(second);
            int totaldays = (int)diff.TotalDays;

            // special check if user chenge date in system
            string usd = s.StringEntschlüsseln((string)regkey.GetValue("Use"));
            DateTime lastUse = Convert.ToDateTime(usd);
            TimeSpan diff1 = presentDate.Subtract(lastUse); //first.Subtract(second);
            int useBetween = (int)diff1.TotalDays;

            // put next use day in registry
            regkey.SetValue("Use", s.StringVerschlüsseln(today)); //Value Name,Value Data

            if (useBetween >= 0)
            {

                if (totaldays < 0)
                    return "Error"; // if user change date in system like date set before installation
                else if (totaldays >= 0 && totaldays <= 365)
                    return Convert.ToString(maxdays - totaldays); //how many days remaining
                else
                    return "Expired"; //Expired
            }
            else
                return "Error"; // if user change date in system
        }

        #endregion

        #region Eigenschaften

        /// <summary>
        /// Gibt den Status der Tage zurück die noch verbleiben, bis die Trial-Version abläuft.
        /// </summary>
        public string StatusDaysLeft
        {
            get { return this.status; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string GetName
        {
            get { return this.name; }
        }

        #endregion
    }
}
