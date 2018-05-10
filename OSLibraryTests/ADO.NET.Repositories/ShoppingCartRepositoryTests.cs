using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void ShoppingCartRepositoryTests_GetByID()
        {
            ShoppingCartRepository repository = new ShoppingCartRepository();
            var result = repository.GetByID(1);
            Assert.IsTrue(result.Product_ID == 1);
        }


    }
}
