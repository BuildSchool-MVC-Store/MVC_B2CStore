using OnlineStore.Controllers;
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
            Status = cookieStatus.noMatch;
            Username = "";
        }
        public string Username { get; set; }
        public cookieStatus Status { get; set; }
    }
}