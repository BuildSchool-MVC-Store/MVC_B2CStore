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
                Account = "",
                Product_ID = 2,
                Quantity = 1,
                size = "s"
            };
        }


    }
}
