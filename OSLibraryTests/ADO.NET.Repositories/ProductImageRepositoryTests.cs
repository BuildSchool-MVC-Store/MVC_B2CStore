using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary;
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
            Assert.IsTrue(result.Count() == 7);
        }

        [TestMethod]
        public void ProductImageRepositoryTests_GetByProduct_ID()
        {
            ProductImageRepository repository = new ProductImageRepository();
            var result = repository.GetByProduct_ID(1);
            Assert.IsTrue(result.Count() == 5);
        }

        [TestMethod]
        public void ProductImageRepositoryTests_Creat()
        {
            ProductImageRepository repository = new ProductImageRepository();
            var model = new Product_Image
            {
                Product_ID = 1,
                Product_Image_Only = "OFF",
                Pictrue = new byte[] { 1,2}
            };
            repository.Create(model);
            var result = repository.GetByProduct_ID(1);
            Assert.IsTrue(result.Count() == 1);
        }
    }
}
