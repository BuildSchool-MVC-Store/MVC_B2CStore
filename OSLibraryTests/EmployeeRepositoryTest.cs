using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;

namespace OSLibraryTests.ADO.NET.Repositories
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        [TestMethod]
        public void Create()
        {
            EmployeesRepository test = new EmployeesRepository();
            Employees e1 = new Employees()
            {
                Account = "osborn",
                Password = "123456789",
                Address = "台中",
                Email = "123@gmail.com",
                Birthday = new DateTime(1996, 4, 25),
                Name = "陳兆煇",
                Phone = "0918"
            };
            test.Create(e1);
        }
    }
}
