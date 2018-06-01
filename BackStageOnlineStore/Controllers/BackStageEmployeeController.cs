using OSLibrary.Models;
using OSLibrary.Sevices;
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
            var result = new EmployeeService();
            var list = result.BackStageGetEmployeeByAll();
            return View(list);
        }

        public ActionResult CreateEmployee()
        {
            return View();
        }

        public ActionResult UpdateEmployee(string account)
        {
            var result = new EmployeeService();
            var list = result.BackStageGetEmployeeByAccount(account);
            return View(list);
        }
    }
}