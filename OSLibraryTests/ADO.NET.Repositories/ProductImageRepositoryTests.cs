using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary.ADO.NET.Repositories;

namespace OSLibraryTests.ADO.NET.Repositories
{
    [TestClass]
    public class ProductImageRepositoryTests
    {
        [TestMethod]
        public void ProductImageRepositoryTests_GetAll()
        {
            ProductImageRepository repository = new ProductImageRepository();
            var result = repository.GetAll();
            Assert.IsTrue(result.Count() == 4);
        }

        [TestMethod]
        public void ProductImageRepositoryTests_GetByProduct_ID()
        {
            ProductImageRepository repository = new ProductImageRepository();
            var result = repository.GetByProduct_ID(1);
            Assert.IsTrue(result.Count() == 2);
        }
    }
}
