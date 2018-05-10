using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary.ADO.NET.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OSLibrary.ADO.NET.Repositories.Tests
{
    [TestClass()]
    public class CustomerRepositoryTests
    {
        [TestMethod()]
        public void CustomerRepositoryTests_GetAllTest()
        {
            CustomerRepository repository = new CustomerRepository();
            var result = repository.GetAll();
            Assert.IsTrue(result.Count()==2);
        }
        [TestMethod()]
        public void CustomerRepositoryTests_GetByID()
        {
            CustomerRepository repository = new CustomerRepository();
            var result = repository.GetByID("Osborn");
            Assert.IsTrue(result.Name == "陳兆煇");
        }
        [TestMethod()]
        public void CustomerRepositoryTests_Create()
        {
            CustomerRepository repository = new CustomerRepository();
            Customers customers = new Customers()
            {
                Account = "Dann",
                Name = "典哥",
                Password = "123456",
                Email = "dannwu@gmail.com",
                Phone = "0800123789",
                Address = "台北"
            };
            repository.Create(customers);
            var result = repository.GetByID("Dann");
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void CustomerRepositoryTests_Update()
        {
            CustomerRepository repository = new CustomerRepository();
            Customers customers = new Customers()
            {
                Account = "Dann",
                Name = "典哥",
                Password = "123456789124",
                Email = "dannwu@gmail.com",
                Phone = "0800123789",
                Address = "台北"
            };
            repository.Update(customers);
            var result = repository.GetByID("Dann");
            Assert.IsTrue(result.Password == "123456789124");
        }

        [TestMethod]
        public void CustomerRepositoryTests_Delete()
        {
            CustomerRepository repository = new CustomerRepository();
            var customers = new Customers()
            {
                Account = "Dann"
            };
            repository.Delete(customers);
            var result = repository.GetByID("Dann");
            Assert.IsTrue(result.Account == null);
        }
    }
}