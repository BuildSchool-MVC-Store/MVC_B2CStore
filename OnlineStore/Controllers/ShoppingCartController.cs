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
        // GET: ShoppingCart
        public ActionResult AddtoShoppingCart(int ID,string Name ,string color,string size,int quantity)
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

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