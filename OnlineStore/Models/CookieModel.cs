using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class CookieModel
    {
        public CookieModel ()
        {
            checkCookie = true;
            checkUser = false;
            Username = "";
        }
        public bool checkCookie { get; set; }
        public bool checkUser { get; set; }
        public string Username { get; set; }
    }
}