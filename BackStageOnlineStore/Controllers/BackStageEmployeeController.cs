using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStageOnlineStore.Controllers
{
    public class BackStageEmployeeController : Controller
    {
        // GET: BackStageEmployee
        public ActionResult SelectEmployee()
        {
            return View();
        }

        public ActionResult CreateEmployee()
        {
            return View();
        }

        public ActionResult UpdateEmployee()
        {
            return View();
        }
    }
}