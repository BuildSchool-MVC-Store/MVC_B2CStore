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
            Assert.IsTrue(result.Count() == 2);
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
            //測試rollback
            SqlConnection connection = new SqlConnection(SqlConnect.str);
            OrdersRepository repository = new OrdersRepository();
            connection.Open();
            var transaction = connection.BeginTransaction();
            int temp1 = repository.GetAll().Count();
            try
            {
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
                repository.Create(connection,model,transaction);
                transaction.Commit();
            }
            catch(Exception)
            {
                try
                {
                    transaction.Rollback();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            var temp2 = repository.GetAll().Count();
            Assert.IsTrue(temp1 < temp2);
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
        [TestMethod]
        public void Orders_GetLatestByAccountTest()
        {
            SqlConnection connection = new SqlConnection(SqlConnect.str);
            connection.Open();
            var transaction= connection.BeginTransaction();
            OrdersRepository repository = new OrdersRepository();
            var ans = repository.GetLatestByAccount(connection,"Osborn", transaction);

            Assert.IsTrue(ans.Order_ID == 29);
        }
        [TestMethod]
        public void OrdersRepositoryTests_GetOrderTotal()
        {
            OrdersRepository repository = new OrdersRepository();
            var result = repository.GetOrderTotal("Osborn");
            Assert.IsTrue(result.Total == 160);
        }
    }
}
