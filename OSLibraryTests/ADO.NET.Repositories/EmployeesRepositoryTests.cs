using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSLibrary.ADO.NET.Repositories;
using System.Linq;
using OSLibrary.Models;

namespace OSLibraryTests.ADO.NET.Repositories
{
    [TestClass()]
    public class EmployeesRepositoryTests
    {
        [TestMethod()]
        public void EmployeesRepositoryTests_GetAll()
        {
            EmployeesRepository repository = new EmployeesRepository();
            var result = repository.GetAll();
            Assert.IsTrue(result.Count() == 3);
        }

        [TestMethod()]
        public void EmployeesRepositoryTests_GetByAccount()
        {
            EmployeesRepository repository = new EmployeesRepository();
            var result = repository.GetByEmployeesAccount("Jackson");
            Assert.IsTrue(result.Name == "傑克森");
        }

        [TestMethod()]
        public void EmployeesRepositoryTests_Create()
        {
            EmployeesRepository repository = new EmployeesRepository();
            Employees employees = new Employees()
            {
                Account = "Ricky",
                Password = "345912",
                Name = "林瑞琪",
                Birthday = DateTime.Parse("1993-09-26"),
                Email = "r19930926@gmail.com",
                Phone = "0998731886",
                Address = "台南"
            };
            repository.Create(employees);
            var result = repository.GetByEmployeesAccount("Ricky");
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void EmployeesRepositoryTests_Update()
        {
            EmployeesRepository repository = new EmployeesRepository();
            Employees employees = new Employees()
            {
                Account = "Sam",
                Password = "456789",
                Name = "蔡山姆",
                Birthday = DateTime.Parse("1993-06-17"),
                Email = "samm617@gmail.com",
                Phone = "0978999222",
                Address = "台北"
            };
            repository.Update(employees);
            var result = repository.GetByEmployeesAccount("Sam");
            Assert.IsTrue(result.Email == "samm617@gmail.com");
        }

        [TestMethod]
        public void EmployeesRepositoryTests_Delete()
        {
            EmployeesRepository repository = new EmployeesRepository();
            var employees = new Employees()
            {
                Account = "Tom"
            };
            repository.Delete(employees);
            var result = repository.GetByEmployeesAccount("Tom");
            Assert.IsTrue(result.Account == null);
        }
    }
}
