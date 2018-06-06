using OSLibrary.Sevices;
using OSLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BackStageOnlineStore.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            //判斷使用者已登入驗證
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");//登入後導向後台主畫面
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginemployee)
        {
            var service = new LoginService();
            var Validatestr = service.LoginCheck(loginemployee.Account, loginemployee.Password);
            if(String.IsNullOrEmpty(Validatestr))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, loginemployee.Account, DateTime.Now, DateTime.Now.AddMinutes(30), false, null, FormsAuthentication.FormsCookiePath);
            }
        }
    }
}