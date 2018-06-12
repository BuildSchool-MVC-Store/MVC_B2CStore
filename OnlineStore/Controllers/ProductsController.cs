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
        public ActionResult Index()
        {
            var result = new ProductService();
            IEnumerable<ProductModel> list = result.GetAllProducts();
            return View(list);
        }
        public ActionResult GetCategory()
        {
            var result = new CategoryRepository();
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