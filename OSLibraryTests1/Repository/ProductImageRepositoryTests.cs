using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary;
using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;

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
            Assert.IsTrue(result.Count() == 6);
        }

        [TestMethod]
        public void ProductImageRepositoryTests_GetByProduct_ID()
        {
            ProductImageRepository repository = new ProductImageRepository();
            var result = repository.GetByProduct_ID(1);
            Assert.IsTrue(result.Count() == 4);
        }

        [TestMethod]
        public void ProductImageRepositoryTests_Create()
        {
            ProductImageRepository repository = new ProductImageRepository();
            var model = new Product_Image
            {
                Product_ID = 1,
                Image_Only = "OFF",
                Image = $"product_img/001.jpg"
            };
            repository.Create(model);
            var result = repository.GetByProduct_ID(1);
            Assert.IsTrue(result.Count() == 5);
        }

        [TestMethod]
        public void ProductImageRepositoryTests_Update()
        {
            ProductImageRepository repository = new ProductImageRepository();
            var model = new Product_Image
            {
                Product_Image_ID = 17,
                Product_ID = 1,
                Image_Only = "ON",
                Image = $"product_img/001.jpg"
            };
            repository.Update(model);
            var result = repository.GetByProduct_ID(1);
            Assert.IsTrue(result.Count() == 5);
        }

        [TestMethod]
        public void ProductImageRepositoryTests_Delete()
        {
            ProductImageRepository repository = new ProductImageRepository();
            var model = new Product_Image
            {
                Product_Image_ID = 17
            };
            repository.Delete(17);
            var result = repository.GetByProduct_ID(1);
            Assert.IsTrue(result.Count() == 4);
        }
    }
}
