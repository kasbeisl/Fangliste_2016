using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanglisteLibrary
{
    public class Link
    {
        int id;
        string name;
        string link;

        public Link(int id, string name, string link)
        {
            this.id = id;
            this.name = name;
            this.link = link;
        }

        public Link()
        {

        }

        public int ID
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public string LinkValue
        {
            get { return link; }
        }
    }
}
