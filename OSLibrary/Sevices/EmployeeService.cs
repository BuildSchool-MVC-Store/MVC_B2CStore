using OSLibrary.ADO.NET.Repositories;
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
        public EmployeeModel BackStageGetEmployeeByAccount(string account)
        {
            EmployeesRepository repository = new EmployeesRepository();
            var model = repository.GetByEmployeesAccount(account);
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
    }
}
