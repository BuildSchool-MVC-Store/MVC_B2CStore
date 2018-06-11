using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStageOnlineStore.Controllers
{
    [Authorize]
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
        public ActionResult SelectOrder_CheckIs0()
        {
            OrdersService ordersService = new OrdersService();
            return View(ordersService.BackStageGetOrder_CheckIs0());
        }
        public ActionResult SelectOrder_CheckIs1()
        {
            OrdersService ordersService = new OrdersService();
            return View(ordersService.BackStageGetOrder_CheckIs1());
        }
        public ActionResult SelectOrder_CheckIs2()
        {
            OrdersService ordersService = new OrdersService();
            return View(ordersService.BackStageGetOrder_CheckIs2());
        }
        public ActionResult SelectOrder_CheckIs3()
        {
            OrdersService ordersService = new OrdersService();
            return View(ordersService.BackStageGetOrder_CheckIs3());
        }
        public ActionResult SelectOrder_CheckIs4()
        {
            OrdersService ordersService = new OrdersService();
            return View(ordersService.BackStageGetOrder_CheckIs4());
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