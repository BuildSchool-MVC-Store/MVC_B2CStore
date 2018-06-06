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
            switch (cookie.Status)
            {
                case cookieStatus.Match:
                    OrdersService ordersService = new OrdersService();
                    TempData["Message"] = ordersService.CreateOrder(cookie.Username, Pay, Transport, 60);
                    return RedirectToAction("completeOrder");
                default:
                    TempData["Message"] = "請先登入會員";
                    return Redirect(Request.UrlReferrer.ToString());
            }
        }
        [Route("completeOrder")]
        public ActionResult CompleteOrder()
        {
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            if (cookie.Status == cookieStatus.Match && cookie.Authority == Character.Customer)
            {
                try
                {
                    OrdersService ordersService = new OrdersService();
                    var result = ordersService.GetNewOrders(cookie.Username);
                    return View(result);
                }
                catch
                {
                    TempData["Message"] = "錯誤，稍後重試";
                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            else
            {
                TempData["Message"] = "請先登入會員";
                return Redirect(Request.UrlReferrer.ToString());
            }
        }
        [HttpGet]
        [Route("status")]
        public ActionResult GetOrderByStatus(int status,string account)
        {

            OrdersService ordersService = new OrdersService();
            if(account ==null)
            {
                return PartialView(ordersService.GetOrders(status).OrderByDescending(x => x.Order_Date));
            }
            else
            {
                return PartialView(ordersService.GetOrders(status).Where(x => x.Account == account).OrderByDescending(x => x.Order_Date));
            }
        }                                                                                                                            

        [HttpPost]
        [Route("UpdateOrderStatus")]
        public ActionResult UpdateOrderStatus(int OrderID,int Status)
        {
            OrdersService ordersService = new OrdersService();
            if(ordersService.UpdateOrdersStatus(OrderID,Status+1))
            {
                return Json("OK", JsonRequestBehavior.DenyGet); ;
            }
            else
            {
                return Json("NO", JsonRequestBehavior.DenyGet); ;
            }
        }

        [Route("Detail")]
        public ActionResult GetOrderDetail(int OrderID)
        {
            OrdersService ordersService = new OrdersService();
            return View(ordersService.GetDetails(OrderID));
        }
    }
}