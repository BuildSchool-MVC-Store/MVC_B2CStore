using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary;
using OSLibrary.ADO.NET.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibraryTests.ADO.NET.Repositories
{
    [TestClass]
    public class OrdersRepositoryTests
    {
        [TestMethod]
        public void OrdersRepositoryTests_GetAll()
        {
            OrdersRepository repository = new OrdersRepository();
            var result = repository.GetAll();
            Assert.IsTrue(result.Count() == 4);
        }

        [TestMethod]
        public void OrdersRepositoryTests_GetByID()
        {
            OrdersRepository repository = new OrdersRepository();
            var result = repository.GetByID(2);
            Assert.IsTrue(result.Account == "Osborn");
        }

        [TestMethod]
        public void OrdersRepositoryTests_Create()
        {
            OrdersRepository repository = new OrdersRepository();
            var model = new Orders
            {
                Order_Date = DateTime.Parse("2018-05-10 00:00:00.000"),
                Account = "Osborn",
                Pay = "超商取貨",
                Transport = "物流",
                Order_Check = "運送中",
                Total = 680,
                TranMoney = 0
            };
            repository.Create(model);
            var result = repository.GetByID(6);
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void OrdersRepositoryTest_Update()
        {
            OrdersRepository repository = new OrdersRepository();
            var model = new Orders
            {
                Order_ID = 6,
                Order_Date = DateTime.Parse("2018-05-10 00:00:00.000"),
                Account = "Osborn",
                Pay = "超商取貨",
                Transport = "物流",
                Order_Check = "備貨中",
                Total = 680,
                TranMoney = 0
            };
            repository.Update(model);
            var result = repository.GetByID(6);
            Assert.IsTrue(result.Order_Check == "備貨中");
        }

        [TestMethod]
        public void OrdersRepositoryTest_Delete()
        {
            OrdersRepository repository = new OrdersRepository();
            var model = new Orders
            {
                Order_ID = 5
            };
            repository.Delete(model);
            var result = repository.GetByID(5);
            Assert.IsTrue(result == null);
        }
    }
}
