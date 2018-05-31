using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStageOnlineStore.Controllers
{
    public class BackStageProductController : Controller
    {
        // GET: BackStageProduct
        public ActionResult SelectProduct()
        {
            var result = new ProductService();
            var list = result.BackStageGetAllProducts();
            return View(list);
        }

        public ActionResult CreateProduct()
        {
            return View();
        }

        public ActionResult UpdateProduct()
        {
            return View();
        }
    }
}