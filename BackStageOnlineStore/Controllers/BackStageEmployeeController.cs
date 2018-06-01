using OSLibrary.Models;
using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStageOnlineStore.Controllers
{
    [RoutePrefix("Employees")]
    public class BackStageEmployeeController : Controller
    {
        [Route("Index")]
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

        [Route("UpdateEmployee/{Account}")]
        public ActionResult UpdateEmployee(string Account)
        {
            var result = new EmployeeService();
            return View(result.BackStageGetEmployeeByAccount(Account));
        }
    }
}