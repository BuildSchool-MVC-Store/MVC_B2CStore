using OSLibrary.Models;
using OSLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace OSLibrary.ADO.NET.Repositories
{
    public class EmployeesRepository
    {
        private string strConnection = "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;";
        public void Create(Employees model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "INSERT INTO Employees VALUES (@Account, @Password, @Name, @Birthday, @Email, @Phone, @Address)";
                var exec = connection.Execute(sql, model);
            }
        }
        public void Update(Employees model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "UPDATE Employees SET Account = @Account, Password = @Password, Name = @Name, Birthday = @Birthday, Email = @Email, Phone = @Phone, Address = @Address WHERE Account = @Account";
                var exec = connection.Execute(sql, model);
            }
        }
        public void Delete(string Account)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "DELETE FROM Employees WHERE Account = @Account";
                var exec = connection.Execute(sql, new { Account = Account});
            }
        }
        public Employees GetByEmployeesAccount(string account)
        {
            Employees employees = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Employees WHERE Account = @Account";
                employees = connection.QueryFirstOrDefault<Employees>(sql, new { Account = account });
            }
            return employees;
        }
        public IEnumerable<Employees> GetAll()
        {
            IEnumerable<Employees> employees = new List<Employees>();
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Employees";
                employees = connection.Query<Employees>(sql);
            }
            return employees;
        }
    }
}
