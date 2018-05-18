using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary;
using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OSLibraryTests.ADO.NET.Repositories
{
    [TestClass]
    public class ShoppingCartRepositoryTests
    {
        [TestMethod]
        public void ShoppingCartRepositoryTests_GetAllTest()
        {
            ShoppingCartRepository repository = new ShoppingCartRepository();
            var result = repository.GetAll();
            Assert.IsTrue(result.Count() ==2);
        }

        [TestMethod]
        public void ShoppingCartRepositoryTests_GetByAccount()
        {
            ShoppingCartRepository repository = new ShoppingCartRepository();
            var result = repository.GetByAccount("Osborn");
            Assert.IsTrue(result.Count() == 2);
        }

        [TestMethod]
        public void ShoppingCartRepositoryTests_Create()
        {
            ShoppingCartRepository repository = new ShoppingCartRepository();
            var model = new Shopping_Cart()
            {
                Account = "Bill",
                Product_ID = 3,
                Quantity = 1,
                size = "s"
            };
            repository.Create(model);
            var result = repository.GetAll();
            var test = result.Where(x => x.Account == "Bill");
            foreach (var item in test)
            {
                Assert.IsTrue(item.Account == "Bill");
            }
        }

        [TestMethod]
        public void ShoppingCartRepositoryTests_Update()
        {
            ShoppingCartRepository repository = new ShoppingCartRepository();
            var model = new Shopping_Cart()
            {
                Shopping_Cart_ID = 3,
                Account = "Bill",
                Product_ID = 3,
                Quantity = 3,
                UnitPrice = 150,
                Discount = 0,
                size = "s"
            };
            repository.Update(model);
            var result = repository.GetAll();
            var test = result.Where(x => x.Quantity == 3);
            foreach (var item in test)
            {
                Assert.IsTrue(item.Quantity == 3);
            }
        }

        [TestMethod]
        public void ShoppingCartRepositoryTests_Delete()
        {
            ShoppingCartRepository repository = new ShoppingCartRepository();
            var model = new Shopping_Cart()
            {
                Shopping_Cart_ID = 3
            };
            repository.Delete(3);
            var result = repository.GetAll();
            var test = result.Where(x => x.Shopping_Cart_ID == 3);
            foreach (var item in test)
            {
                Assert.IsTrue(item.Shopping_Cart_ID == 3);
            }
        }
    }
}
