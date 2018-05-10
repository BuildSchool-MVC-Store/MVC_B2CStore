using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary.ADO.NET.Repositories;

namespace OSLibraryTests.ADO.NET.Repositories
{
    [TestClass]
    public class ProductsRepositoryTests
    {
        [TestMethod]
        public void ProductsRepositoryTests_GetAll()
        {
            ProductsRepository repository = new ProductsRepository();
            var result = repository.GetAll();
            Assert.IsTrue(result.Count()>=2);
        }
        [TestMethod]
        public void ProductsRepositoryTests_GetByProduct_ID()
        {
            ProductsRepository repository = new ProductsRepository();
            var result = repository.GetByProduct_ID(1);
            Assert.IsTrue(result.Product_Name=="黑色內褲");
        }
    }
}
