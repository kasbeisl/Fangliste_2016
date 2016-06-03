using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanglisteLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Dropbox
    {
        public Dropbox(string accessToken)
        {
            

            if (String.IsNullOrEmpty(accessToken))
            {
                this.GetAccessToken();
            }
            else
            {
                this.GetFiles();
            }
        }

        private void GetAccessToken()
        {
            //var login = 
        }

        private void GetFiles()
        {
            throw new NotImplementedException();
        }

        
    }
}
