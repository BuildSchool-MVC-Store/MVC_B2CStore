using OSLibrary.Sevices;
using OSLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStageOnlineStore.Controllers
{
    [RoutePrefix("Product")]
    public class BackStageProductController : Controller
    {
        [Route("")]
        // GET: BackStageProduct
        public ActionResult SelectProduct()
        {
            var result = new ProductService();
            var list = result.BackStageGetAllProducts();
            return View(list);
        }

        [Route("AddProduct")]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [Route("UpdateProduct/{Product_ID}")]
        public ActionResult UpdateProduct(int Product_ID)
        {
            var service = new ProductService();
            return View(service.GetProductByProductID(Product_ID));
        }

        [HttpPost]
        public ActionResult Update(int Product_ID, string ProductName, decimal Price, string CategoryName, string Gender, string Online, string Comments)
        {
            var service = new ProductService();
            if(service.UpdateProducts(Product_ID, ProductName, Price, CategoryName, Gender, Online, Comments))
            {
                TempData["message"] = "更新成功";
            }
            else
            {
                TempData["message"] = "更新失敗，請聯絡客服";
            }
            return RedirectToAction("SelectProduct");
        }
    }
}