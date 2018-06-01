using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;
using OSLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.Sevices
{
    public class EmployeeService
    {
        public EmployeeModel BackStageGetEmployeeByAccount(string Account)
        {
            EmployeesRepository repository = new EmployeesRepository();
            var model = repository.GetByEmployeesAccount(Account);
            return new EmployeeModel()
            {
                Name = model.Name,
                Account = model.Account,
                Password = model.Password,
                Birthday = model.Birthday,
                Phone = model.Phone,
                Email = model.Email,
                Address = model.Address
            };
        }

        public IEnumerable<EmployeeModel> BackStageGetEmployeeByAll()
        {
            EmployeesRepository repository = new EmployeesRepository();
            var Employees = new List<EmployeeModel>();
            var model = repository.GetAll();
            foreach (var item in model)
            {
                var Employee = new EmployeeModel()
                {
                    Name = item.Name,
                    Account = item.Account,
                    Password = item.Password,
                    Phone = item.Phone,
                    Email = item.Email,
                    Address = item.Address,
                    Birthday = item.Birthday
                };
                Employees.Add(Employee);
            }
            return Employees;
        }


        public bool ChangeEmployee(string Name, string Account, string Password, DateTime Birthday,
            string Email, string Phone, string Address)
        {

            var Employee = new Employees()
            {
                Name = Name,
                Account = Account,
                Password = Password,
                Birthday = Birthday,
                Email = Email,
                Phone = Phone,
                Address = Address
                
            };

            EmployeesRepository employeesRepository = new EmployeesRepository();
            try
            {
                employeesRepository.Update(Employee);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
