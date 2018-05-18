using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary;
using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;

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
            Assert.IsTrue(result.Count() >= 2);
        }
        [TestMethod]
        public void ProductsRepositoryTests_GetByProduct_ID()
        {
            ProductsRepository repository = new ProductsRepository();
            var result = repository.GetByProduct_ID(2);
            Assert.IsTrue(result.Product_Name == "短褲");
        }
        [TestMethod]
        public void ProductsRepositoryTests_Create()
        {
            ProductsRepository repository = new ProductsRepository();
            var model = new Products
            {
                Product_ID = 5,
                Product_Name = "機能外套",
                UnitPrice = 500,
                Product_Types_Name = "外套",
                Gender = "女"
            };
            repository.Create(model);
            var result = repository.GetByProduct_ID(5);
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void ProductsRepositoryTests_Update()
        {
            ProductsRepository repository = new ProductsRepository();
            var model = new Products
            {
                Product_ID = 5,
                Product_Name = "機能外套(限量)",
                UnitPrice = 1500,
                Product_Types_Name = "外套",
                Gender = "女"
            };
            repository.Update(model);
            var result = repository.GetByProduct_ID(5);
            Assert.IsTrue(result.UnitPrice == 1500);
        }

        [TestMethod]
        public void ProductsRepositoryTests_Delete()
        {
            ProductsRepository repository = new ProductsRepository();
            var model = new Products
            { Product_ID = 5 };
            repository.Delete(5);
            var result = repository.GetByProduct_ID(5);
            Assert.IsTrue(result == null);
        }
    }
}
