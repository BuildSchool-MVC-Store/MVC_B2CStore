using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSLibrary.ViewModel;
using OSLibrary.Sevices;
using OSLibrary.ADO.NET.Repositories;

namespace OnlineStore.Controllers
{
    [RoutePrefix("Products")]
    public class ProductsController : Controller
    {
        [Route("")]
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
    }
}