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

        [Route("CreateEmployee")]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(string Name, string Account, string Password, DateTime Birthday,
            string Email, string Phone, string Address)
        {
            EmployeeService employeeService = new EmployeeService();
            var message = "";
            if (employeeService.CreateEmployee(Name, Account, Password, Birthday, Email, Phone, Address))
            {
                message = "新增成功";
            }
            else
            {
                message = "無法新增，請聯絡客服";
            }
            return Json(message, JsonRequestBehavior.DenyGet);
        }

        [Route("UpdateEmployee/{Account}")]
        public ActionResult UpdateEmployee(string Account)
        {
            var result = new EmployeeService();
            return View(result.BackStageGetEmployeeByAccount(Account));
        }

        [HttpPost]
        public ActionResult UpdateEmployeeChange(string Name, string Account, string Password, DateTime Birthday,
            string Email, string Phone, string Address)
        {
            EmployeeService employeeService = new EmployeeService();
            var message = "";
            if (employeeService.ChangeEmployee(Name, Account, Password, Birthday, Email, Phone, Address))
            {
                message = "更換成功";
            }
            else
            {
                message = "無法更新，請聯絡客服";
            }
            return Json(message, JsonRequestBehavior.DenyGet);
        }
    }
}