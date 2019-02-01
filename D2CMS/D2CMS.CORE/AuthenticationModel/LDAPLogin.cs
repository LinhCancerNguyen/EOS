using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.CORE.AuthenticationModel
{
    public class LDAPLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Application { get; set; }

        public LDAPLogin()
        {
            Application = "che";
        }
    }
}
