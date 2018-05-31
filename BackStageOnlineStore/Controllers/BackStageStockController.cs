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
            return View();
        }

        public ActionResult UpdateStock()
        {
            return View();
        }
    }
}