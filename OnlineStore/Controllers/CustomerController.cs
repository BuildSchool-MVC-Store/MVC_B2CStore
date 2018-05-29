using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineStore.Controllers
{
    [RoutePrefix("Customer")]
    public class CustomerController : Controller
    {
        [Route("")]
        // GET: Customer
        public ActionResult Index()
        {
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            if (cookie.checkUser)
            {
                OrdersService ordersService = new OrdersService();
                try
                {
                    CustomerService customerService = new CustomerService();
                    var result = customerService.GetCustomerDetail(cookie.Username);

                    return View(result);
                }
                catch
                {
                    TempData["Message"] = "錯誤，稍後重試";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["Message"] = "請先登入會員";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}