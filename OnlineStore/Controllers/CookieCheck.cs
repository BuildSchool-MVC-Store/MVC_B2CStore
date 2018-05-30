using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineStore.Controllers
{
    public class CookieCheck
    {
        static public CookieModel check(HttpCookie cookie)
        {
            var result = new CookieModel();
            if (cookie == null)
            {
                result.Status = cookieStatus.noCookie;
                return result;
            }
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            if (ticket.UserData == "12345")
            {
                result.Status = cookieStatus.Match;
                result.Username = ticket.Name;
            }
            return result;
        }
    }
    public enum cookieStatus
    {
        noCookie,
        noMatch,
        Match
    }
}