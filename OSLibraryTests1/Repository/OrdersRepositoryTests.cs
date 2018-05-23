using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary;
using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
            Assert.IsTrue(result.Count() == 6);
        }

        [TestMethod]
        public void OrdersRepositoryTests_GetByOrderID()
        {
            OrdersRepository repository = new OrdersRepository();
            var result = repository.GetByOrder_ID(2);
            Assert.IsTrue(result.Account == "Osborn");
        }

        [TestMethod]
        public void OrdersRepositoryTests_Create()
        {
            SqlConnection connection = new SqlConnection();
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
            repository.Create(model,connection.BeginTransaction());
            var result = repository.GetByOrder_ID(6);
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void OrdersRepositoryTests_Update()
        {
            OrdersRepository repository = new OrdersRepository();
            var model = new Orders
            {
                Order_Date = DateTime.Parse("2018-05-12 00:00:00.000"),
                Account = "Osborn",
                Pay = "超商取貨",
                Transport = "物流",
                Order_Check = "運送中",
                Total = 680,
                TranMoney = 0
            };
            repository.Update(model);
            var result = repository.GetByOrder_ID(6);
            Assert.IsTrue(result.Order_Check == "備貨中");
        }

        [TestMethod]
        public void OrdersRepositoryTests_Delete()
        {
            OrdersRepository repository = new OrdersRepository();
            var model = new Orders
            {
                Order_ID = 5
            };
            repository.Delete(5);
            var result = repository.GetByOrder_ID(5);
            Assert.IsTrue(result == null);
        }
    }
}
