using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.CORE.AuthenticationModel
{
    public class LDAPInfo
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Role { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }
        public string RefreshToken { get; set; }
        public string ExpiredTime { get; set; }
    }
}
