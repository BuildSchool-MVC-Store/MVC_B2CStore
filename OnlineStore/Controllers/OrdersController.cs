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
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            if (cookie.checkUser)
            {
                OrdersService ordersService = new OrdersService();
                try
                {
                    ordersService.CreateOrder(cookie.Username, Pay, Transport, 60);
                    return RedirectToAction("completeOrder");
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
        [Route("completeOrder")]
        public ActionResult CompleteOrder()
        {
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            if (cookie.checkUser)
            {
                OrdersService ordersService = new OrdersService();
                try
                {
                    var result = ordersService.GetNewOrders(cookie.Username);
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