﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;
namespace OnlineStore.Controllers
{
    [RoutePrefix("Product")]
    public class ProductsController : Controller
    {
        [Route("")]
        // GET: Products
        public ActionResult Index()
        {
            var result = new ProductsRepository();
            IEnumerable<Products> list = result.GetAll();
            return View(list);
        }
    }
}