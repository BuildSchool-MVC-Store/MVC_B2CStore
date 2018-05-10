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
    public class Order_DetailsRepositoryTests
    {
        [TestMethod]
        public void Order_DetailsRepositoryTests_GetAllTest()
        {
            Order_DetailsRepository repository = new Order_DetailsRepository();
            var result = repository.GetAll();
            Assert.IsTrue(result.Count() == 1);
        }

        [TestMethod]
        public void Order_DetailsRepositoryTests_GetByIDTest()
        {
            Order_DetailsRepository repository = new Order_DetailsRepository();
            var result = repository.GetByID(2);
            Assert.IsTrue(result.Order_Details_ID == 2);
        }
    }
}
