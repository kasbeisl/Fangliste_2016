using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using FanglisteLibrary;

namespace Fangliste_2016
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //check lizenz
            bool ok = false;
            try
            {
                Lizenz lizenz = new Lizenz();
                ok = lizenz.Algorithm("455212988kasI", "Fangliste");
            }
            catch (Exception)
            {
                MessageBox.Show("Die Lizenz ist fehlerhaft!\n\nBitte Aktivieren Sie das Programm neu.", "Fangliste - Lizenz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (ok == false)
                Application.Exit();
            else
            {
                if (PrüfenObWichtigeDatenExistieren())
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Frm_Hauptmenu());
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        #region Methoden

        private static bool PrüfenObWichtigeDatenExistieren()
        {
            bool ok = false;

            if (!File.Exists("FanglisteLibrary.dll"))
            {
                MessageBox.Show("Die 'FanglisteLibrary.dll' existiert nicht.\n\nBitte installieren Sie das Programm neu.", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //ACHTUNG ! FEHLT
                if (File.Exists("AxInterop.ShockwaveFlashObjects.dll"))
                {
                    MessageBox.Show("Die 'AxInterop.ShockwaveFlashObjects.dll' existiert nicht.\n\nBitte installieren Sie das Programm neu.", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.ExitThread();
                }
                else
                {
                    if (File.Exists("AxInterop.WMPLib.dll"))
                    {
                        MessageBox.Show("Die 'AxInterop.WMPLib.dll' existiert nicht.\n\nBitte installieren Sie das Programm neu.", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.ExitThread();
                    }
                    else
                    {
                        if (File.Exists("Interop.ShockwaveFlashObjects.dll"))
                        {
                            ok = false;
                            MessageBox.Show("Die 'Interop.ShockwaveFlashObjects.dll' existiert nicht.\n\nBitte installieren Sie das Programm neu.", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.ExitThread();
                        }
                        else
                        {
                            if (File.Exists("Interop.WMPLib.dll"))
                            {
                                ok = false;
                                MessageBox.Show("Die 'Interop.WMPLib.dll' existiert nicht.\n\nBitte installieren Sie das Programm neu.", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.ExitThread();
                            }
                            else
                            {
                                ok = true;
                            }
                        }
                    }
                }
            }

            return ok;
        }

        #endregion
    }
}
