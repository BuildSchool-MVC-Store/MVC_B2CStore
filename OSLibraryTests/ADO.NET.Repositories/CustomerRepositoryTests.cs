﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.IsTrue(result.Count()==1);
        }
    }
}