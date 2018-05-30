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
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            switch (cookie.Status)
            {
                case cookieStatus.noCookie:
                    TempData["Message"] = "請先登入會員";
                    return RedirectToAction("Index", "Home");
                case cookieStatus.Match:
                    try
                    {
                        OrdersService ordersService = new OrdersService();
                        ShoppingCartService shoppingCartService = new ShoppingCartService();
                        var shoppingcart = shoppingCartService.GetAccountCart(cookie.Username);
                        if (shoppingcart.Count() == 0)
                        {
                            TempData["Message"] = "購物車是空的，返回上一頁";
                            return RedirectToAction("Index", "Home");
                        }
                        ViewBag.totalmoney = shoppingcart.Sum(x => x.RowPrice);
                        return View(shoppingcart);
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

        [HttpPost]
        public ActionResult DeleteShoppingCart(int shoppingCartID)
        {
            ShoppingCartService shoppingCartService = new ShoppingCartService();
            if(shoppingCartService.Delete_ProductOfCart(shoppingCartID))
            {
                TempData["Message"] = "刪除成功";
            }
            else
            {
                TempData["Message"] = " 刪除失敗";
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPost]
        [Route("UpdateShoppingCart")]
        public ActionResult UpdateShoppingCart(int shoppingCartID,int Qunatity)
        {
            ShoppingCartService shoppingCartService = new ShoppingCartService();
            var message = "";
            if (shoppingCartService.ChangeProductofCart(shoppingCartID,Qunatity))
            {
                message = "更換數量";
            }
            else
            {
                message = "無法更新，請聯絡客服";
            }
            return Json(message, JsonRequestBehavior.DenyGet);
        }
    }
}