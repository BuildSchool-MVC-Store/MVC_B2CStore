using OSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ADO.NET.Repositories
{
    public class EmployeesRepository
    {
        public void Create(Employees model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = "INSERT INTO Employees VALUES (@Account, @Password, @Name, @Birthday, @Email, @Phone, @Address)";
        }
    }
}
