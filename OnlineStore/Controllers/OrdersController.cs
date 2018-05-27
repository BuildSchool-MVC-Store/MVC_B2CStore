using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineStore.Controllers
{
    [RoutePrefix("Orders")]
    public class OrdersController : Controller
    {
        // GET: Orders
        [HttpPost]
        public ActionResult CreateOrder(string Pay , string Transport)
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                TempData["Message"] = "請先登入會員";
                return RedirectToAction("Index", "Home");
            }
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            if (ticket.UserData == "12345")
            {
                OrdersService ordersService = new OrdersService();
                ordersService.CreateOrder(ticket.Name, Pay, Transport, 60);
            }
            return RedirectToAction("Index", "Home");
           // ordersService.CreateOrder();
        }
    }
}