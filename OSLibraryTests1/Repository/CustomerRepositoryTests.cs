﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OSLibraryTests.ADO.NET.Repositories
{
    [TestClass()]
    public class CustomerRepositoryTests
    {
        [TestMethod()]
        public void CustomerRepositoryTests_GetAll()
        {
            CustomerRepository repository = new CustomerRepository();
            var result = repository.GetAll();
            Assert.IsTrue(result.Count()==2);
        }

        [TestMethod()]
        public void CustomerRepositoryTests_GetByAccount()
        {
            CustomerRepository repository = new CustomerRepository();
            var result = repository.GetByAccount("Osborn");
            Assert.IsTrue(result.Name == "陳兆煇");
        }

        [TestMethod()]
        public void CustomerRepositoryTests_Create()
        {
            CustomerRepository repository = new CustomerRepository();
            Customers customers = new Customers()
            {
                Account = "Dann",
                Password = "123456",
                Email = "dannwu@gmail.com",
            };
            repository.Create(customers);
            var result = repository.GetByAccount("Dann");
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
            var result = repository.GetByAccount("Dann");
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
            repository.Delete("Dann");
            var result = repository.GetByAccount("Dann");
            Assert.IsTrue(result.Account == null);
        }
    }
}