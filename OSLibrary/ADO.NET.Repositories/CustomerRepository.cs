using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ADO.NET.Repositories
{
    public class CustomerRepository
    {
        public void Create(Customers model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "INSERT INTO Customers VALUES (@Account, @Name, @Password, @Email, @Phone, @Address)";
            SqlCommand command = new SqlCommand(sql,connection);
            command.Parameters.AddWithValue("@Account", model.Account);
            command.Parameters.AddWithValue("@Name", model.Account);
            command.Parameters.AddWithValue("@Password", model.Account);
            command.Parameters.AddWithValue("@Email", model.Account);
            command.Parameters.AddWithValue("@Phone", model.Account);
            command.Parameters.AddWithValue("@Address", model.Account);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(Customers model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "UPDATE Customers SET Acount = @Account, Name = @Name ,Password =  @Password,Email = @Email,Phone = @Phone,Address = @Address WHERE Account = @Account";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Account", model.Account);
            command.Parameters.AddWithValue("@Name", model.Name);
            command.Parameters.AddWithValue("@Password", model.Password);
            command.Parameters.AddWithValue("@Email", model.Email);
            command.Parameters.AddWithValue("@Phone", model.Phone);
            command.Parameters.AddWithValue("@Address", model.Address);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close(); 
        }
        public void Delete(Customers model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "DELETE FROM Customers WHERE Account = @Account";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Account", model.Account);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Customers GetByID(string Account)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "SELECT * FROM Customers WHERE Account = @Account";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Account", Account);

            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var properties = typeof(Customers).GetProperties();
            Customers customer = null;
            while (reader.Read())
            {
                customer = new Customers();
                for (var i = 0;i<reader.FieldCount;i++)
                {
                    var fieldname = reader.GetName(i);
                    var property = properties.FirstOrDefault(x => x.Name == fieldname);
                    if (property == null)
                        continue;
                    if (!reader.IsDBNull(i))
                        property.SetValue(customer, reader.GetValue(i));

                }
                //customer.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                //customer.Name = reader.GetValue(reader.GetOrdinal("Name")).ToString();
                //customer.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
                //customer.Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
                //customer.Phone = reader.GetValue(reader.GetOrdinal("Phone")).ToString();
                //customer.Address = reader.GetValue(reader.GetOrdinal("Address")).ToString();
            }
            reader.Close();
            return customer;
        }
        public IEnumerable<Customers> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "SELECT * FROM Customers";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            List<Customers> customers = new List<Customers>();
            while(reader.Read())
            {

                var customer = new Customers();
                var properties = typeof(Customers).GetProperties();

                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldname = reader.GetName(i);
                    var property = properties.FirstOrDefault(x => x.Name == fieldname);
                    if (property == null)
                        continue;
                    if (!reader.IsDBNull(i))
                        property.SetValue(customer, reader.GetValue(i));
                }
                customers.Add(customer);

                //customer.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                //customer.Name = reader.GetValue(reader.GetOrdinal("Name")).ToString();
                //customer.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
                //customer.Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
                //customer.Phone = reader.GetValue(reader.GetOrdinal("Phone")).ToString();
                //customer.Address = reader.GetValue(reader.GetOrdinal("Address")).ToString();
                //customers.Add(customer);
            }
            reader.Close();
            return customers;
        }
    }
}
