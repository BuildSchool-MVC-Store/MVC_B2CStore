using OSLibrary.Models;
using OSLibrary.Sevices;
using OSLibrary.ViewModels;
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
        [HttpGet]
        public ActionResult GetOrders(string Account)
        {
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            if (cookie.Status == cookieStatus.Match && cookie.Authority == Character.Employee)
            {
                TempData["Account"] = Account;
                return View();
            }
            else
            {
                TempData["Message"] = "請先登入會員";
                return RedirectToAction("AdminLoginPage", "Login");
            }
        }

        [HttpPost]
        public ActionResult GetOrdersStatus(int status)
        {
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            if (cookie.Status == cookieStatus.Match && cookie.Authority == Character.Employee)
            {
                OrdersService ordersService = new OrdersService();
                return View(ordersService.GetOrders(status));
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
        [HttpGet]
        public ActionResult GetStock(Stock model)
        {
            StockService stockService = new StockService();
            return View(stockService.GetStock(model));
        }
        [HttpPost]
        public ActionResult UpdateStockQunatity(Stock model)
        {
            StockService stockService = new StockService();
            stockService.UpdateStock(model);
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult PurchaseQunatity(int Product_ID,string Color,string Size,int Qunatity)
        {
            StockService stockService = new StockService();
            if(stockService.PurchaseStock(Product_ID, Size, Color, Qunatity))
            {
                TempData["stock"] = 1;
            }
            else
            {
                TempData["stock"] = 0;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpGet]
        public ActionResult CreateStock()
        {
            ProductService productService = new ProductService();
            ViewBag.Products = productService.GetProductsOfCreateStock();
            return View();
        }

        [HttpPost]
        public ActionResult CreateStock(CreateStock stock)
        {
            StockService stockService = new StockService();
            if (stockService.CreateStock(stock))
            {
                TempData["CreateStock"] = 1;
            }
            else
            {
                TempData["CreateStock"] = 0;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpGet]
        public ActionResult UpdateOrderDetail(Person_OrderDetail model)
        {
            return View();
        }

    }
}