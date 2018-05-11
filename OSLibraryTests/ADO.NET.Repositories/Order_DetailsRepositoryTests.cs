﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class Order_DetailsRepositoryTests
    {
        [TestMethod]
        public void Order_DetailsRepositoryTests_GetAllTest()
        {
            Order_DetailsRepository repository = new Order_DetailsRepository();
            var result = repository.GetAll();
            Assert.IsTrue(result.Count() == 10);
        }

        [TestMethod]
        public void Order_DetailsRepositoryTests_GetByIDTest()
        {
            Order_DetailsRepository repository = new Order_DetailsRepository();
            var result = repository.GetByID(2);
            Assert.IsTrue(result.Order_Details_ID == 2);
        }

        [TestMethod]
        public void Order_DetailsRepositoryTests_CreateTest()
        {
            Order_DetailsRepository repository = new Order_DetailsRepository();
            var model = new Order_Details
            {
                Order_ID = 6,
                Product_ID = 2,
                Quantity = 1,
                UnitPrice = 150,
                Discount = 0,
                size = "M"
            };
            repository.Create(model);
            var result = repository.GetByID(13);
            Assert.IsTrue(result != null);
        }


        [TestMethod]
        public void Order_DetailsRepositoryTests_UpdateTest()
        {
            Order_DetailsRepository repository = new Order_DetailsRepository();
            var model = new Order_Details
            {
                Order_Details_ID = 13,
                Order_ID = 6,
                Product_ID = 2,
                Quantity = 2,
                UnitPrice = 150,
                Discount = 0,
                size = "X"
            };
            repository.Update(model);
            var result = repository.GetByID(13);
            Assert.IsTrue(result.Quantity == 2);
        }

        [TestMethod]
        public void Order_DetailsRepositoryTests_DeleteTest()
        {
            Order_DetailsRepository repository = new Order_DetailsRepository();
            var model = new Order_Details
            {
                Order_Details_ID = 14
            };
            repository.Delete(model);
            var result = repository.GetByID(14);
            Assert.IsTrue(result == null);
        }
    }
}
