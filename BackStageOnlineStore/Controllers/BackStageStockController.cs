using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStageOnlineStore.Controllers
{
    [RoutePrefix("Stock")]
    public class BackStageStockController : Controller
    {
        [Route("")]
        // GET: BackStageStock
        public ActionResult SelectStock()
        {
            var service = new StockService();
            return View(service.GetAllByStock());
        }

        [Route("UpdateStock/{Product_ID}")]
        public ActionResult UpdateStock(int Product_ID)
        {
            var service = new StockService();
            return View(service.GetProductIDByStock(Product_ID));
        }

        [HttpPost]
        public ActionResult UpdateStock(int Product_ID, string Color, string Size, int Quantity)
        {
            var service = new StockService();
            if(service.UpdateStock(Product_ID, Size, Quantity, Color))
            {
                TempData["message"] = "修改成功";
            }
            else
            {
                TempData["message"] = "修改失敗，請聯絡客服";
            }
            return RedirectToAction("SelectStock");
        }
    }
}