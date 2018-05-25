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
    [RoutePrefix("login")]
    public class LoginController : Controller
    {
        public ActionResult LoginPage()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null)
            {
                ViewBag.IsAuthenticated = false;
                return View();
            }
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            if (ticket.UserData == "12345")
            {
                ViewBag.IsAuthenticated = true;
                ViewBag.Username = ticket.Name;
            }
            else
            {
                ViewBag.IsAuthenticated = false;
            }
            return PartialView();
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
                //生COOKIE
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName,ticketData);
                cookie.Expires = ticket.Expiration;
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("LoginModel", "使用者名稱密碼不正確");
            }
            return View();
        }
        [Route("logout")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            cookie.Expires = DateTime.Now;
            Response.Cookies.Add(cookie);

            return RedirectToAction("index");
        }
    }
}