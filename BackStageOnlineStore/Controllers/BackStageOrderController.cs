using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStageOnlineStore.Controllers
{
    public class BackStageOrderController : Controller
    {
        //[HttpPost]
        //public ActionResult Index(int id)
        //{
        //    var orderid = id;
        //    return View();
        //}
        // GET: BackStageOrder
        public ActionResult SelectOrder()
        {
            OrdersService ordersService = new OrdersService();
            return View(ordersService.BackStageGetAllOrders());
        }
        [HttpPost]
        public ActionResult SelectOrderByAccount(string Account)
        {

            OrdersService ordersService = new OrdersService();
            return View(ordersService.BackStageGetAccountOrders(Account));
        }
        [HttpPost]
        public ActionResult SelectOrderByOrder_ID(int Order_ID)
        {
            //var Id = Order_ID;
            OrdersService ordersService = new OrdersService();
            //return View(ordersService.BackStageGetOrderByOrder_ID(Order_ID));
            return View(ordersService.BackStageGetOrderByOrder_ID(Order_ID));
        }
  
        public ActionResult CreateOrder()
        {
            return View();
        }

        //下面OrderDetails

        public ActionResult SelectOrderDetails()
        {
            var result = new Order_DetailsService();
            var list = result.BackStageGetAllOrderDetails();
            return View(list);
        }

        public ActionResult CreateOrderDetails()
        {
            return View();
        }

        public ActionResult UpdateOrderDetails()
        {
            return View();
        }
    }
}