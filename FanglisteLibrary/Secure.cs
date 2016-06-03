using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

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

    public class Secure
    {
        #region Variablen

        private string globalPath;
        string status = "";
        int maxdays = 30;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Leerer Konstruktor
        /// </summary>
        public Secure()
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

            regkey.SetValue("Install", onlyDate); //Value Name,Value Data
            regkey.SetValue("Use", onlyDate); //Value Name,Value Data
        }

        private String checkfirstDate()
        {
            RegistryKey regkey = Registry.CurrentUser;
            regkey = regkey.CreateSubKey(globalPath); //path
            string Br = (string)regkey.GetValue("Install");
            if (regkey.GetValue("Install") == null)
                return "First";
            else
                return Br;
        }

        private bool checkPassword(String pass)
        {
            RegistryKey regkey = Registry.CurrentUser;
            regkey = regkey.CreateSubKey(globalPath); //path
            string Br = (string)regkey.GetValue("Password");
            if (Br == pass)
                return true; //good
            else
                return false;//bad
        }

        private String dayDifPutPresent()
        {
            // get present date from system
            DateTime dt = DateTime.Now;
            string today = dt.ToShortDateString();
            DateTime presentDate = Convert.ToDateTime(today);

            // get instalation date
            RegistryKey regkey = Registry.CurrentUser;
            regkey = regkey.CreateSubKey(globalPath); //path
            string Br = (string)regkey.GetValue("Install");
            DateTime installationDate = Convert.ToDateTime(Br);

            TimeSpan diff = presentDate.Subtract(installationDate); //first.Subtract(second);
            int totaldays = (int)diff.TotalDays;

            // special check if user chenge date in system
            string usd = (string)regkey.GetValue("Use");
            DateTime lastUse = Convert.ToDateTime(usd);
            TimeSpan diff1 = presentDate.Subtract(lastUse); //first.Subtract(second);
            int useBetween = (int)diff1.TotalDays;

            // put next use day in registry
            regkey.SetValue("Use", today); //Value Name,Value Data

            if (useBetween >= 0)
            {

                if (totaldays < 0)
                    return "Error"; // if user change date in system like date set before installation
                else if (totaldays >= 0 && totaldays <= 15)
                    return Convert.ToString(maxdays - totaldays); //how many days remaining
                else
                    return "Expired"; //Expired
            }
            else
                return "Error"; // if user change date in system
        }

        private void blackList()
        {
            RegistryKey regkey = Registry.CurrentUser;
            regkey = regkey.CreateSubKey(globalPath); //path

            regkey.SetValue("Black", "True");

        }

        private bool blackListCheck()
        {
            RegistryKey regkey = Registry.CurrentUser;
            regkey = regkey.CreateSubKey(globalPath); //path
            string Br = (string)regkey.GetValue("Black");
            if (regkey.GetValue("Black") == null)
                return false; //No
            else
                return true;//Yes
        }

        public bool Algorithm(String appPassword, String pass)
        {
            globalPath = pass;
            bool chpass = checkPassword(appPassword);
            if (chpass == true) //execute
                return true;
            else
            {
                bool block = blackListCheck();
                if (block == false)
                {
                    string chinstall = checkfirstDate();
                    if (chinstall == "First")
                    {
                        firstTime();// installation date
                        DialogResult ds = MessageBox.Show("Sie verwenden die Trial-Version! Möchten Sie das Programm jetzt aktivieren?", "Product key", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (ds == DialogResult.Yes)
                        {
                            Frm_Aktivieren f1 = new Frm_Aktivieren(appPassword, globalPath);
                            DialogResult ds1 = f1.ShowDialog();
                            if (ds1 == DialogResult.OK)
                                return true;
                            else
                                return false;
                        }
                        else
                            return true;
                    }
                    else
                    {
                        status = dayDifPutPresent();
                        if (status == "Error")
                        {
                            blackList();
                            DialogResult ds = MessageBox.Show("Anwendung kann nicht geladen werden, unberechtigte Datum Interrupt aufgetreten! Ohne Aktivierung kann es nicht laufen! Möchten Sie das Programm jetzt aktivieren?", "Terminate Error-02", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            if (ds == DialogResult.Yes)
                            {
                                Frm_Aktivieren f1 = new Frm_Aktivieren(appPassword, globalPath);
                                DialogResult ds1 = f1.ShowDialog();
                                if (ds1 == DialogResult.OK)
                                    return true;
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                        else if (status == "Expired")
                        {
                            DialogResult ds = MessageBox.Show("Die Testversion ist nun abgelaufen! Möchten Sie das Programm jetzt aktivieren?", "Product key", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (ds == DialogResult.Yes)
                            {
                                Frm_Aktivieren f1 = new Frm_Aktivieren(appPassword, globalPath);
                                DialogResult ds1 = f1.ShowDialog();
                                if (ds1 == DialogResult.OK)
                                    return true;
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                        else // execute with how many day remaining
                        {
                            DialogResult ds = MessageBox.Show("Sie verwenden die Trial-Version, Sie haben " + status + " Tage noch, bis zur aktivierung! Möchten Sie das Programm jetzt aktivieren?", "Product key", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (ds == DialogResult.Yes)
                            {
                                Frm_Aktivieren f1 = new Frm_Aktivieren(appPassword, globalPath);
                                DialogResult ds1 = f1.ShowDialog();
                                if (ds1 == DialogResult.OK)
                                    return true;
                                else
                                    return false;
                            }
                            else
                                return true;
                        }
                    }
                }
                else
                {
                    DialogResult ds = MessageBox.Show("Anwendung kann nicht geladen werden, unberechtigte Datum Interrupt aufgetreten! Ohne Aktivierung kann es nicht laufen! Möchten Sie das Programm jetzt aktivieren?", "Terminate Error-01", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (ds == DialogResult.Yes)
                    {
                        Frm_Aktivieren f1 = new Frm_Aktivieren(appPassword, globalPath);
                        DialogResult ds1 = f1.ShowDialog();
                        if (ds1 == DialogResult.OK)
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                    //return "BlackList";
                }
            }
        }

        #endregion

        #region Eigenschaften

        /// <summary>
        /// Gibt den Status der Tage zurück die noch verbleiben, bis die Trial-Version abläuft.
        /// </summary>
        public string StatusDaysLeft
        {
            get { return status; }
        }

        #endregion
    }
}
