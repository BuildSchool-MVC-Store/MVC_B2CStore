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
    public class OrdersRepositoryTests
    {
        [TestMethod]
        public void OrdersRepositoryTests_GetAll()
        {
            OrdersRepository repository = new OrdersRepository();
            var result = repository.GetAll();
            Assert.IsTrue(result.Count() == 1);
        }

        [TestMethod]
        public void OrdersRepositoryTests_GetByID()
        {
            OrdersRepository repository = new OrdersRepository();
            var result = repository.GetByID(2);
            Assert.IsTrue(result.Account == "Osborn");
        }
    }
}
