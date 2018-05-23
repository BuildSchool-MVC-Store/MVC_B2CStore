using System;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary;
using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;

namespace OSLibraryTests.ADO.NET.Repositories
{
    [TestClass]
    public class ProductSizeQuantityRepositoryTests
    {
        [TestMethod]
        public void ProductSizeQuantityRepositoryTests_GetAll()
        {
            StockRepository repository = new StockRepository();
            var result = repository.GetAll();
            Assert.IsTrue(result.Count() == 6);
        }

        [TestMethod]
        public void ProductSizeQuantityRepositoryTests_GetByProduct_ID_Product_Size()
        {
            StockRepository repository = new StockRepository();
            var result = repository.GetByProduct_IDandProduct_Size(1, "M");
            Assert.IsTrue(result.Quantity == 8);
        }

        [TestMethod]
        public void ProductSizeQuantityRepositoryTests_Create()
        {
            StockRepository repository = new StockRepository();
            var model = new Stock()
            {
                Product_ID = 1,
                Quantity = 20,
                Product_Size = "S"
            };
            repository.Create(model);
            var result = repository.GetByProduct_IDandProduct_Size(1, "S");
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void ProductSizeQuantityRepositoryTests_Update()
        {
            StockRepository repository = new StockRepository();
            SqlConnection connection = new SqlConnection();
            var model = new Stock()
            {
                Product_ID = 1,
                Quantity = 100,
                Product_Size = "S"
            };
            repository.Update(model);
            var result = repository.GetByProduct_IDandProduct_Size(1, "S");
            Assert.IsTrue(result.Quantity == 100);
        }

        [TestMethod]
        public void ProductSizeQuantityRepositoryTests_Delete()
        {
            StockRepository repository = new StockRepository();
            var model = new Stock()
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
