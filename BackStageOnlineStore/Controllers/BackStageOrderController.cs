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
        public ActionResult SelectOrderByAccount(string Account)
        {
            OrdersService ordersService = new OrdersService();
            return View(ordersService.BackStageGetAccountOrders(Account));
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