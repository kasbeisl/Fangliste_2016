using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanglisteLibrary
{
    public class Ordner
    {
        #region Membervariablen

        int id;
        string name;

        #endregion

        #region Konstruktor

        public Ordner(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Ordner()
        {

        }

        #endregion

        #region Eigenschaften

        public int ID
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion

        #region Methoden

        #endregion
    }
}
