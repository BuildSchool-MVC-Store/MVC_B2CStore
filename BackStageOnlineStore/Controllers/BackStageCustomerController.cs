using OSLibrary.Sevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStageOnlineStore.Controllers
{
    public class BackStageCustomerController : Controller
    {
        // GET: BackStageCustomer
        public ActionResult SelectCustomer()
        {
            var result = new CustomerService();
            var list = result.BackStageGetAllCustomers();
            return View(list);
        }
    }
}