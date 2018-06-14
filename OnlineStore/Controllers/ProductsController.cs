using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSLibrary.ViewModels;
using OSLibrary.Sevices;
using OSLibrary.ADO.NET.Repositories;

namespace OnlineStore.Controllers
{
    [RoutePrefix("Products")]
    public class ProductsController : Controller
    {
        [Route("")]
        [Route("Index")]
        // GET: Products
        public ActionResult Index(string CategoryName,string Gender)
        {
            var result = new ProductService();
            IEnumerable<ProductModel> list;
            if (CategoryName != null && Gender != null)
            {
                list = result.GetAllProducts().Where(x => x.CategoryName == CategoryName && x.Gender == Gender);
                ViewBag.Gender = Gender;

            }
            else if (Gender != null && CategoryName == null)
            {
                list = result.GetAllProducts().Where(x => x.Gender == Gender);
                ViewBag.Gender = Gender;
            }
            else
            {
                list = result.GetAllProducts();        
            }
            return View(list);
        }
        public ActionResult GetCategory(string Gender)
        {
            var result = new CategoryRepository();
            ViewBag.Gender = Gender;
            return PartialView(result.GetAll());
        }
        [Route("{ProductID}")]
        public ActionResult ProductDetail(int ProductID)
        {
            var productService = new ProductService();
            return View(productService.GetProductDetail(ProductID));
        }
        [HttpGet]
        [Route("GetProductCS")]
        public ActionResult GetProductCS(int ProductID)
        {
            var productService = new ProductService();
            return PartialView(productService.GetProductDetail(ProductID));
        }
    }
}