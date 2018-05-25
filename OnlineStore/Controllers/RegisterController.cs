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
        public ActionResult Index()
        {
            return View();
        }
        [Route("")]
        [HttpPost]
        public ActionResult Register(string username,string password)
        {
            CustomerService customerService = new CustomerService();
            if(customerService.CheckAccount(username,password))
            {
                return RedirectToAction("Index","Home"); 
            }
            else
            {
                return JavaScript("alert('帳號或密碼錯誤');");
            }
        }
    }
}