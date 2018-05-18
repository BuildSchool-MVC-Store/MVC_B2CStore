
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    [RoutePrefix("test")]
    public class TestController : Controller
    {
        
        // GET: Test
        public ActionResult Index()
        {
            //respones
            var cookie = new HttpCookie("name");
            cookie.Value = "fingerprint";
            cookie.Expires = DateTime.Now.AddHours(7);
            cookie.Domain = "mydomain.com";
            Response.Cookies.Add(cookie);
            //request
            cookie = Request.Cookies["name"];


            return View();
        }
        public ActionResult Index2()
        {
            var app = Request.RequestContext.HttpContext.Application;
            app.Get("key");
            app.Set("key", "value");
            app.Remove("key");
            return View();
        }
        [Route("")]
        public ActionResult Index3()
        {
            var item = new Testmodel()
            {
                name = "陳",
                phone = "0918"
            };

            ViewData.Add("安安", "去死");

            TempData.Add("data", "0000001");

            return View(item);
        }
        [Route("4")]
        //public ActionResult Index4()
        //{
        //    var db = new BizModel();
        //    var query = db.SalesMan;
        //    return View(query);
        //}
        //public ActionResult DisplaySalesMan()
        //{
        //    var db = new BizModel();
        //    var count = db.SalesMan.Count();
        //    return PartialView(count)
        //}
        public class Testmodel
        {
            public string name { get; set; }
            public string phone { get; set; }
        }
    }
}