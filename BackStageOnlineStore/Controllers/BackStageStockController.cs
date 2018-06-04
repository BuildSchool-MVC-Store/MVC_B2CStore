using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStageOnlineStore.Controllers
{
    public class BackStageStockController : Controller
    {
        // GET: BackStageStock
        public ActionResult SelectStock()
        {
            var service = new StockService();
            return View(service.GetAllByStock());
        }

        public ActionResult UpdateStock()
        {
            return View();
        }
    }
}