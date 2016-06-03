using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace FanglisteLibrary
{
    public class SoundInfo
    {
        #region ImportService

        [DllImport("winmm.dll")]
        private static extern uint mciSendString(
            string command,
            StringBuilder returnValue,
            int returnLength,
            IntPtr winHandle);

        #endregion

        #region Variablen

        #endregion

        #region Konstruktor

        public SoundInfo()
        {
        }

        #endregion

        #region Eigenschaften

        #endregion

        #region Methoden

        /// <summary>
        /// Gibt die Länge der Wave Datei in ms zurück.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static int GetSoundDuration(string fileName)
        {
            try
            {
                int length = 0;

                if (fileName != "")
                {
                    StringBuilder lengthBuf = new StringBuilder(32);

                    mciSendString(string.Format("open \"{0}\" type waveaudio alias wave", fileName), null, 0, IntPtr.Zero);
                    mciSendString("status wave length", lengthBuf, lengthBuf.Capacity, IntPtr.Zero);
                    mciSendString("close wave", null, 0, IntPtr.Zero);

                    int.TryParse(lengthBuf.ToString(), out length);
                }

                return length;
            }
            catch (Exception ex)
            {

                throw new Exception("Unerwarteter Fehler.\n\nInformation:\n" + ex.ToString());
            }
        }

        #endregion
    }
}
