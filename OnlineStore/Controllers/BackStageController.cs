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
                OrdersService ordersService = new OrdersService();
                CustomerService customerService = new CustomerService();
                ViewBag.OrdersNum = ordersService.GetOrders(false);
                ViewBag.NewOrdersNum = ordersService.GetOrders(true);
                ViewBag.CustomerNum = customerService.GetAll().Count();
                return View();
            }
            else
            {
                TempData["Message"] = "請先登入會員";
                return RedirectToAction("AdminLoginPage", "Login");
            }
        }
        [HttpGet]
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
        //=================================================================================================== Product↓
        [HttpGet]
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
        public ActionResult GetProduct(int Product_ID)
        {
            ProductService productService = new ProductService();
            return View(productService.GetProduct(Product_ID));
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            CategoryService categoryService = new CategoryService();
            ViewBag.category = categoryService.GetCategory();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Products products)
        {
            ProductService productService = new ProductService();
            if (productService.CreateProduct(products))
            {
                TempData["CreateProduct"] = 1;
            }
            else
            {
                TempData["CreateProduct"] = 0;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPost]
        public ActionResult UpdateProduct(Products model)
        {
            ProductService productService = new ProductService();
            if (productService.UpdateProduct(model))
            {
                TempData["UpdateProduct"] = 1;
            }
            else
            {
                TempData["UpdateProduct"] = 0;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        //===================================================================================== ProdustImages↓
        [HttpGet]
        public ActionResult GetProductImages(int? Product_ID)
        {
            return View();
        }


        //====================================================================================== Orders↓
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
        [HttpGet]
        public ActionResult UpdateOrder(int OrderID)
        {
            OrdersService ordersService = new OrdersService();

            return View(ordersService.GetOrder(OrderID));
        }

        [HttpPost]
        public ActionResult UpdateOrder(Orders orders)
        {
            OrdersService ordersService = new OrdersService();

            return View();
        }
        // =========================================================================================== OrderDetail↓

        [HttpGet]
        public ActionResult CreateOrderDetail(int OrderID)
        {
            Order_DetailsService order_DetailsService = new Order_DetailsService();
            ProductService productService = new ProductService();
            ViewBag.OrderID = OrderID;
            ViewBag.Products = productService.GetProductsOfCreateStock();
            return View();
        }
        [HttpPost]
        public ActionResult CreateOrderDetail(Order_Details order_Details)
        {
            Order_DetailsService order_DetailsService = new Order_DetailsService();
            if (order_DetailsService.CreateOrderDetail(order_Details))
            {
                TempData["CreateOrderDetail"] = 1;

            }
            else
            {
                TempData["CreateOrderDetail"] = 0;

            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpGet]
        public ActionResult UpdateOrderDetail(int Order_Details_ID, int? Product_ID)
        {
            Order_DetailsService order_DetailsService = new Order_DetailsService();
            ProductService productService = new ProductService();
            var orderDetail = order_DetailsService.GetByOrderDetail_ID(Order_Details_ID);
            ViewBag.Products = productService.GetProductsOfCreateStock();

            if (Product_ID == null)
            {
                TempData["ProductDetail"] = productService.GetProductDetail(orderDetail.Product_ID);
            }
            else
            {
                var temp = productService.GetProductDetail((int)Product_ID);
                TempData["ProductDetail"] = temp;
                orderDetail.Product_ID = (int)Product_ID;
                orderDetail.Color = temp.ColorSize.Keys.ToList()[0];
                orderDetail.size = "";
                orderDetail.Quantity = 1;
            }
            return View(orderDetail);
        }
        [HttpPost]
        public ActionResult UpdateOrderDetail(Person_OrderDetail person_OrderDetail)
        {
            Order_DetailsService order_DetailsService = new Order_DetailsService();
            if (order_DetailsService.UpdateOrderDetail(person_OrderDetail))
            {
                TempData["UpdateOrderDetail"] = 1;

            }
            else
            {
                TempData["UpdateOrderDetail"] = 0;

            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult DeleteOrderDetail(int Order_Details_ID)
        {
            Order_DetailsService order_DetailsService = new Order_DetailsService();
            if (order_DetailsService.DeleteOrderDetail(Order_Details_ID))
            {
                TempData["DeleteOrderDetail"] = 1;

            }
            else
            {
                TempData["DeleteOrderDetail"] = 0;

            }
            return Redirect(Request.UrlReferrer.ToString());
        }


        // =========================================================================================== Employee ↓
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

        // =========================================================================================== Stock
        [HttpGet]
        public ActionResult GetStocks(int? Product_ID)
        {
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            if (cookie.Status == cookieStatus.Match && cookie.Authority == Character.Employee)
            {
                StockService stockService = new StockService();
                if (Product_ID == null)
                {
                    return View(stockService.GetAll());
                }
                else
                {
                    ViewBag.notall =0;
                    return View(stockService.GetProduct_ID((int)Product_ID));
                }
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
        public ActionResult UpdateStockQuantity(Stock model)
        {
            StockService stockService = new StockService();
            stockService.UpdateStock(model);
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult PurchaseQuantity(int Product_ID, string Color, string Size, int Quantity)
        {
            StockService stockService = new StockService();
            if (stockService.PurchaseStock(Product_ID, Size, Color, Quantity))
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

    }
}