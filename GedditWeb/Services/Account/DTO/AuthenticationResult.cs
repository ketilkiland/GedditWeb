using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GedditWeb.Services.Account.DTO
{
    public class AuthenticationResult
    {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string[] Roles { get; set; }
    }
}