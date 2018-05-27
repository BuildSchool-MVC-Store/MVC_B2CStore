using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    [RoutePrefix("Orders")]
    public class OrdersController : Controller
    {
        // GET: Orders
        [HttpPost]
        public ActionResult CreateOrder()
        {
            OrdersService ordersService = new OrdersService();
            return View();
        }
    }
}