using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fangliste_2016
{
    public partial class Frm_FischartenÜberblick : Form
    {
        #region Variablen

        #endregion

        #region Konstruktor

        public Frm_FischartenÜberblick()
        {
            InitializeComponent();
        }

        private void Frm_FischartenÜberblick_Load(object sender, EventArgs e)
        {
            btn_back.Enabled = false;
            btn_next.Enabled = false;
        }

        #endregion

        #region Events

        private void btn_back_Click(object sender, EventArgs e)
        {
            Zurück();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            Vorwärts();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                btn_back.Enabled = true;
            }
            else
            {
                btn_back.Enabled = false;
            }

            if (webBrowser1.CanGoForward)
            {
                btn_next.Enabled = true;
            }
            else
            {
                btn_next.Enabled = false;
            }
        }

        #endregion

        #region Eigenschaften

        #endregion

        #region Methoden

        private void Zurück()
        {
            webBrowser1.GoBack();
        }

        private void Vorwärts()
        {
            webBrowser1.GoForward();
        }

        #endregion
    }
}
