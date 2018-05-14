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
                
            //    SqlConnection connection = new SqlConnection(
            //    "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            //    );
            
            //SqlCommand command = new SqlCommand(sql, connection);
            //command.Parameters.AddWithValue("@Account", model.Account);
            //command.Parameters.AddWithValue("@Password", model.Password);
            //command.Parameters.AddWithValue("@Name", model.Name);
            //command.Parameters.AddWithValue("@Birthday", model.Birthday);
            //command.Parameters.AddWithValue("@Email", model.Email);
            //command.Parameters.AddWithValue("@Phone", model.Phone);
            //command.Parameters.AddWithValue("@Address", model.Address);

            //connection.Open();
            //command.ExecuteNonQuery();
            //connection.Close();
        }

        public void Update(Employees model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = "UPDATE Employees SET Account = @Account, Password = @Password, Name = @Name, Birthday = @Birthday, Email = @Email, Phone = @Phone, Address = @Address WHERE Account = @Account";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Account", model.Account);
            command.Parameters.AddWithValue("@Password", model.Password);
            command.Parameters.AddWithValue("@Name", model.Name);
            command.Parameters.AddWithValue("@Birthday", model.Birthday);
            command.Parameters.AddWithValue("@Email", model.Email);
            command.Parameters.AddWithValue("@Phone", model.Phone);
            command.Parameters.AddWithValue("@Address", model.Address);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Employees model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = "DELETE FROM Employees WHERE Account = @Account";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Account", model.Account);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Employees GetByEmployeesAccount(string Account)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = "SELECT * FROM Employees WHERE Account = @Account";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Account", Account);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var properties = typeof(Employees).GetProperties();
            Employees employees = new Employees();
            while (reader.Read())
            {
                employees = DbReaderModelBinder<Employees>.Bind(reader);
            }
            reader.Close();
            return employees;
        }

        public IEnumerable<Employees> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = "SELECT * FROM Employees";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            List<Employees> employees = new List<Employees>();
            while (reader.Read())
            {
                var employee = DbReaderModelBinder<Employees>.Bind(reader);
                employees.Add(employee);
            }
            reader.Close();
            return employees;
        }
    }
}
