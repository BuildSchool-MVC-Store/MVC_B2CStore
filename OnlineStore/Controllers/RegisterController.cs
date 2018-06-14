using OnlineStore.Models;
using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    [RoutePrefix("Register")]
    public class RegisterController : Controller
    {
        // GET: Register
        [HttpGet]
        public ActionResult Signin()
        {
            return PartialView();
        }
        [Route("")]
        [HttpPost]
        public ActionResult Register(RegisterModel register)
        {
            CustomerService customerService = new CustomerService();
            if(customerService.CreateAccount(register.Account,register.Email,register.Password))
            {
                TempData["Message"] = "註冊成功";
                return RedirectToAction("Index","Home"); 
            }
            else
            {
                TempData["Message"] = "帳號重複或系統錯誤";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}