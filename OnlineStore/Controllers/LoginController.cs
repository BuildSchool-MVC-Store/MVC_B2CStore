using OnlineStore.Models;
using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineStore.Controllers
{
    [RoutePrefix("Login")]
    public class LoginController : Controller
    {
        public ActionResult LoginPage()
        {
            var result = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            if (result.checkUser)
            {
                ViewBag.IsAuthenticated = true;
                ViewBag.Username = result.Username;
                return PartialView();
            }
            else
            {
                ViewBag.IsAuthenticated = false;
                return View();
            }
        }

        [Route("")]
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            CustomerService customerService = new CustomerService();
            if (customerService.CheckAccount(username,password))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,username, DateTime.Now, DateTime.Now.AddMinutes(30), false,"12345");
                var ticketData = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName,ticketData);
                cookie.Expires = ticket.Expiration;
                Response.Cookies.Add(cookie);

                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                TempData["Message"] = "帳號或密碼不正確";
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            cookie.Expires = DateTime.Now;
            Response.Cookies.Add(cookie);

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}