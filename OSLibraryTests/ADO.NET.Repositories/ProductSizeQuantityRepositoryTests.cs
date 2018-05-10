using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary;
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

        [TestMethod]
        public void ProductSizeQuantityRepositoryTests_Create()
        {
            ProductSizeQuantityRepository repository = new ProductSizeQuantityRepository();
            var model = new Product_Size_Quantity()
            {
                Product_ID = 1,
                Quantity = 20,
                Product_Size = "S"
            };
            repository.Create(model);
            var result = repository.GetByID(1, "S");
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void ProductSizeQuantityRepositoryTests_Update()
        {
            ProductSizeQuantityRepository repository = new ProductSizeQuantityRepository();
            var model = new Product_Size_Quantity()
            {
                Product_ID = 1,
                Quantity = 100,
                Product_Size = "S"
            };
            repository.Update(model);
            var result = repository.GetByID(1, "S");
            Assert.IsTrue(result.Quantity == 100);
        }

        [TestMethod]
        public void ProductSizeQuantityRepositoryTests_Delete()
        {
            ProductSizeQuantityRepository repository = new ProductSizeQuantityRepository();
            var model = new Product_Size_Quantity()
            {
                Product_ID = 1,
                Product_Size = "S"
            };
            int oldN = repository.GetAll().Count();
            repository.Delete(model);
            int newN = repository.GetAll().Count();
            Assert.IsTrue((oldN-1) == newN);
        }

    }
}
