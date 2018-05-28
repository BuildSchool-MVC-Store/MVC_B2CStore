using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class CookieModel
    {
        public bool check { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
    }
}