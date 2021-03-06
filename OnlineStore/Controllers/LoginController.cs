﻿using OnlineStore.Models;
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
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            if(cookie.Status == cookieStatus.Match && cookie.Authority == Character.Customer)
            {
                ViewBag.IsAuthenticated = true;
                ViewBag.Username = cookie.Username;
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
                SetTicket(ticket);
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

        [Route("admin")]
        public ActionResult AdminLoginPage()
        {
            return View();
        }    
        [HttpPost]
        public ActionResult AdminLogin(string account , string password)
        {
            EmployeeService employeeService = new EmployeeService();
            if (employeeService.GetEmployee(account, password))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, account, DateTime.Now, DateTime.Now.AddMinutes(30), false, "員工");
                SetTicket(ticket);
                return RedirectToAction("Index","BackStage");
            }
            else
            {
                TempData["Message"] = "帳號或密碼不正確";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        private void SetTicket(FormsAuthenticationTicket ticket)
        {
            var ticketData = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketData);
            cookie.Expires = ticket.Expiration;
            Response.Cookies.Add(cookie);
        }
    }
}