using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanglisteLibrary
{
    public class SQLCollection
    {
        public static string GetConnectionString()
        {
        return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Directory.GetCurrentDirectory() + @"\FanglisteDB.mdf;Integrated Security=True;Connect Timeout=30";
        }
    }
}
