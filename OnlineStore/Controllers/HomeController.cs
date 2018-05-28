using OSLibrary.ADO.NET.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategory()
        {
            var result = new CategoryRepository();
            return PartialView(result.GetAll());
        }
    }
}