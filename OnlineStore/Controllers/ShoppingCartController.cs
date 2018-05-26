using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineStore.Controllers
{
    [RoutePrefix("ShoppingCart")]
    public class ShoppingCartController : Controller
    {
        [Route("")]
        public ActionResult ShoppingCart()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if(cookie == null)
            {
                TempData["Message"] = "請先登入會員";
                return RedirectToAction("Index", "Home");
            }
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            if(ticket.UserData == "12345")
            {
                ShoppingCartService shoppingCartService = new ShoppingCartService();
                var shoppingcart = shoppingCartService.GetAccountCart(ticket.Name);
                ViewBag.totalmoney = shoppingcart.Sum(x => x.RowPrice);

                return View(shoppingcart);
            }
            TempData["Message"] = "錯誤";
            return RedirectToAction("Index", "Home");
        }
        // GET: ShoppingCart
        public ActionResult AddtoShoppingCart(int ID,string Name ,string color,string size,int quantity)
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if(color == "" || size =="")
            {
                TempData["Message"] = "請選擇顏色與尺寸";
                return Redirect(Request.UrlReferrer.ToString());
            }
            if (cookie == null)
            {
                TempData["Message"]= "請登入會員";
                return Redirect(Request.UrlReferrer.ToString());
            }
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            if (ticket.UserData == "12345")
            {
                var account = ticket.Name;
                ShoppingCartService shoppingCartService = new ShoppingCartService();
                if(shoppingCartService.CreateShoppingCart(account, ID, quantity, size, color))
                {
                    TempData["Message"] = "加入" + Name + "到購物車";

                }
                else
                {
                    TempData["Message"] = Name+ " 庫存不足";
                }
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}