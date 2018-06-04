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
            if (cookie.Status == cookieStatus.Match && cookie.Authority == Character.Customer)
            {
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
            }
            else
            {
                TempData["Message"] = "請先登入會員";
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        // GET: ShoppingCart
        public ActionResult AddtoShoppingCart(int ID,string Name ,string color,string size,int quantity)
        {
            //cookie 丟進去 CookieCheck 類別裡面的 static function 做處理
            var cookie = CookieCheck.check(Request.Cookies[FormsAuthentication.FormsCookieName]);
            //如果沒有選擇顏色或尺寸就回傳錯誤訊息 請他選擇尺寸與顏色
            if (color == "" || size == "")
            {
                TempData["Message"] = "請選擇顏色與尺寸";
                return Redirect(Request.UrlReferrer.ToString());
            }
            //如果cookie 符合 登錄的資料 還有他的角色是顧客 他就可以使用加入購物車的動作
            if (cookie.Status == cookieStatus.Match && cookie.Authority == Character.Customer)
            {
                try
                {
                    //宣告一個 ShoppingCartService 的執行個體
                    ShoppingCartService shoppingCartService = new ShoppingCartService();
                    //ShoppingCartService 裡面的 CreateShoppingCart 會回傳 布林 如果是 true 就是加入成功 反之亦然
                    //右鍵 CreateShoppingCart 然後去移置定義
                    if (shoppingCartService.CreateShoppingCart(cookie.Username, ID, quantity, size, color))
                    {
                        TempData["Message"] = "加入" + Name + "到購物車";
                    }
                    else
                    {
                        TempData["Message"] = Name + " 庫存不足";
                    }
                }
                catch
                {
                    TempData["Message"] = "錯誤，稍後重試";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["Message"] = "請先登入會員";
                return Redirect(Request.UrlReferrer.ToString());
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