﻿using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStageOnlineStore.Controllers
{
    public class BackStageOrderController : Controller
    {
        // GET: BackStageOrder
        public ActionResult SelectOrder()
        {
            OrdersService ordersService = new OrdersService();
            return View(ordersService.BackStageGetAllOrders());
        }

        public ActionResult CreateOrder()
        {
            return View();
        }

        //下面OrderDetails

        public ActionResult SelectOrderDetails()
        {
            return View();
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