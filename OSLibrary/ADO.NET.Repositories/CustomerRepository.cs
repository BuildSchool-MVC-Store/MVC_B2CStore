using Dapper;
using OSLibrary.Utils;
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
        private string strConnection = "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;";
        public void Create(Customers model)
        {
            using (SqlConnection Connection = new SqlConnection(strConnection))
            {
                var sql = "INSERT INTO Customers VALUES (@Account, @Name, @Password, @Email, @Phone, @Address)";
                var exec = Connection.Execute(sql, model);
            }
        }
        public void Update(Customers model)
        {
            using (SqlConnection Connection = new SqlConnection(strConnection))
            {
                var sql = "UPDATE Customers SET Account = @Account, Name = @Name ,Password =  @Password,Email = @Email,Phone = @Phone,Address = @Address WHERE Account = @Account";
                var exect = Connection.Execute(sql, model);
            }
        }
        public void Delete(string Account)
        {
            using (SqlConnection Connection = new SqlConnection(strConnection))
            {
                var sql = "DELETE FROM Customers WHERE Account = @Account";
                var exec = Connection.Execute(sql, new { Account });
            }
        }
        public Customers GetByAccount(string account)
        {
            Customers customer = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var strSql = "SELECT * FROM Customers WHERE Account = @Account";
                customer = connection.QueryFirst<Customers>(strSql,new {Account = account});
            }
            return customer;

            //SqlCommand command = new SqlCommand(sql, connection);
            //command.Parameters.AddWithValue("@Account", Account);

            //connection.Open();
            //var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            //var properties = typeof(Customers).GetProperties();
            //Customers customer = new Customers();
            //while (reader.Read())
            //{
            //    customer = DbReaderModelBinder<Customers>.Bind(reader);

            //    //customer = new Customers();
            //    //for (var i = 0; i < reader.FieldCount; i++)
            //    //{
            //    //    var fieldname = reader.GetName(i);
            //    //    var property = properties.FirstOrDefault(x => x.Name == fieldname);
            //    //    if (property == null)
            //    //        continue;
            //    //    if (!reader.IsDBNull(i))
            //    //        property.SetValue(customer, reader.GetValue(i));

            //    //}

            //    //customer.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
            //    //customer.Name = reader.GetValue(reader.GetOrdinal("Name")).ToString();
            //    //customer.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
            //    //customer.Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
            //    //customer.Phone = reader.GetValue(reader.GetOrdinal("Phone")).ToString();
            //    //customer.Address = reader.GetValue(reader.GetOrdinal("Address")).ToString();
            //}
            //reader.Close();
            //return customer;
        }
        public IEnumerable<Customers> GetAll()
        {
            IEnumerable<Customers> customers = new List<Customers>();
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Customers";
                customers = connection.Query<Customers>(sql);
            }
            return customers;
                
            //SqlCommand command = new SqlCommand(sql, connection);
            //connection.Open();
            //var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            //List<Customers> customers = new List<Customers>();
            //while (reader.Read())
            //{

            //    //var customer = new Customers();
            //    //var properties = typeof(Customers).GetProperties();

            //    var customer = DbReaderModelBinder<Customers>.Bind(reader);
            //    //for (var i = 0; i < reader.FieldCount; i++)
            //    //{
            //    //    var fieldname = reader.GetName(i);
            //    //    var property = properties.FirstOrDefault(x => x.Name == fieldname);
            //    //    if (property == null)
            //    //        continue;
            //    //    if (!reader.IsDBNull(i))
            //    //        property.SetValue(customer, reader.GetValue(i));
            //    //}
            //    customers.Add(customer);

            //    //customer.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
            //    //customer.Name = reader.GetValue(reader.GetOrdinal("Name")).ToString();
            //    //customer.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
            //    //customer.Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
            //    //customer.Phone = reader.GetValue(reader.GetOrdinal("Phone")).ToString();
            //    //customer.Address = reader.GetValue(reader.GetOrdinal("Address")).ToString();
            //    //customers.Add(customer);
            //}
            //reader.Close();
            //return customers;
        }
    }
}
