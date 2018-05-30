using OnlineStore.Models;
using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineStore.Controllers
{
    [RoutePrefix("Customer")]
    public class CustomerController : Controller
    {
        [Route("")]
        // GET: Customer
        public ActionResult Index()
        {
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            switch (cookie.Status)
            {
                case cookieStatus.noCookie:
                    TempData["Message"] = "請先登入會員";
                    return RedirectToAction("Index", "Home");
                case cookieStatus.Match:
                    try
                    {
                        CustomerService customerService = new CustomerService();
                        return View(customerService.GetCustomerDetail(cookie.Username));
                    }
                    catch
                    {
                        TempData["Message"] = "錯誤，稍後重試";
                        return RedirectToAction("Index", "Home");
                    }
                default:
                    TempData["Message"] = "錯誤，稍後重試";
                    return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult UpdateCustomer(CustomerChangeModel model)
        {
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            switch (cookie.Status)
            {
                case cookieStatus.noCookie:
                    TempData["Message"] = "請先登入會員";
                    return RedirectToAction("Index", "Home");
                case cookieStatus.Match:
                    CustomerService customerService = new CustomerService();
                    if (model.NewPassword != null)
                    {
                        if (model.NewPassword != model.ConfirmNewPassword)
                        {
                            TempData["Message"] = "二次驗證密碼錯誤";
                            return RedirectToAction("Index", "Customer");
                        }
                        else if (customerService.UpdateCustomerDetail(cookie.Username, model.NewPassword, model.CustomerName, model.Email, model.Phone, model.Address) == false)
                        {
                            TempData["Message"] = "更改失敗，稍後重試";
                        }
                        return RedirectToAction("Index", "Customer");
                    }
                    if (customerService.UpdateCustomerDetail(cookie.Username, model.CustomerName, model.Email, model.Phone, model.Address) == false)
                    {
                        TempData["Message"] = "更改失敗，稍後重試";
                    }
                    return RedirectToAction("Index", "Customer");
                default:
                    TempData["Message"] = "錯誤，稍後重試";
                    return RedirectToAction("Index", "Home");
            }
        }
    }
}