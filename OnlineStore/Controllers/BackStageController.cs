using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineStore.Controllers
{
    [RoutePrefix("BackStage")]
    public class BackStageController : Controller
    {
        // GET: BackStage
        public ActionResult Index()
        {
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            if (cookie.Status == cookieStatus.Match && cookie.Authority == Character.Employee)
            {
                return View();
            }
            else
            {
                TempData["Message"] = "請先登入會員";
                return RedirectToAction("AdminLoginPage", "Login");
            }
        }
        public ActionResult GetCustomers()
        {
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            if (cookie.Status == cookieStatus.Match && cookie.Authority == Character.Employee)
            {
                CustomerService customerService = new CustomerService();
                return View(customerService.GetAll());
            }
            else
            {
                TempData["Message"] = "請先登入會員";
                return RedirectToAction("AdminLoginPage", "Login");
            }
        }
        public ActionResult GetProducts()
        {
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            if (cookie.Status == cookieStatus.Match && cookie.Authority == Character.Employee)
            {
                ProductService productService = new ProductService();
                return View(productService.GetProductOfBackstage());
            }
            else
            {
                TempData["Message"] = "請先登入會員";
                return RedirectToAction("AdminLoginPage", "Login");
            }
        }
        public ActionResult GetOrders()
        {
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            if (cookie.Status == cookieStatus.Match && cookie.Authority == Character.Employee)
            {
                OrdersService ordersService = new OrdersService();
                return View(ordersService.GetOrders());
            }
            else
            {
                TempData["Message"] = "請先登入會員";
                return RedirectToAction("AdminLoginPage", "Login");
            }
        }
        public ActionResult GetEmployees()
        {
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            if (cookie.Status == cookieStatus.Match && cookie.Authority == Character.Employee)
            {
                EmployeeService employeeService = new EmployeeService();
                return View(employeeService.GetAll());
            }
            else
            {
                TempData["Message"] = "請先登入會員";
                return RedirectToAction("AdminLoginPage", "Login");
            }
        }
        [Route("GetEmployee")]
        public ActionResult GetEmployee(string Account)
        {
            EmployeeService employeeService = new EmployeeService();
            return View(employeeService.GetEmployeeDetail(Account));
        }
        public ActionResult GetStocks()
        {
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            if (cookie.Status == cookieStatus.Match && cookie.Authority == Character.Employee)
            {
                StockService stockService = new StockService();
                return View(stockService.GetAll());
            }
            else
            {
                TempData["Message"] = "請先登入會員";
                return RedirectToAction("AdminLoginPage", "Login");
            }
        }
    }
}