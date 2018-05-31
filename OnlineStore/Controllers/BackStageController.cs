using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    [RoutePrefix("Management")]
    public class BackStageController : Controller
    {
        [Route("")]
        // GET: BackStage
        public ActionResult Index()
        {
            return View();
        }

        [Route("Customer")]
        public ActionResult GetCustomer()
        {

        }
    }
}