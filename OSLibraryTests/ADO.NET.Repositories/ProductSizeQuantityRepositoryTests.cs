using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary.ADO.NET.Repositories;

namespace OSLibraryTests.ADO.NET.Repositories
{
    [TestClass]
    public class ProductSizeQuantityRepositoryTests
    {
        [TestMethod]
        public void ProductSizeQuantityRepositoryTests_GetAll()
        {
            ProductSizeQuantityRepository repository = new ProductSizeQuantityRepository();
            var result = repository.GetAll();
            Assert.IsTrue(result.Count() == 6);
        }

        [TestMethod]
        public void ProductSizeQuantityRepositoryTests_GetByID()
        {
            ProductSizeQuantityRepository repository = new ProductSizeQuantityRepository();
            var result = repository.GetByID(1, "M");
            Assert.IsTrue(result.Quantity == 8);
        }
    }
}
