using Dapper;
using OSLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSLibrary.Models;
using System.Configuration;

namespace OSLibrary.ADO.NET.Repositories
{
    public class CustomerRepository : IRepository<Customers>
    {
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OSModel"].ConnectionString);
        public void Create(Customers model)
        {
            var sql = "INSERT INTO Customers VALUES (@Account, @Name, @Password, @Email, @Phone, @Address)";
            var exec = connection.Execute(sql, model);
        }
        public void Update(Customers model)
        {
            var sql = "UPDATE Customers SET Account = @Account, Name = @Name ,Password =  @Password,Email = @Email,Phone = @Phone,Address = @Address WHERE Account = @Account";
            var exect = connection.Execute(sql, model);
        }
        public void Delete(string Account)
        {
            var sql = "DELETE FROM Customers WHERE Account = @Account";
            var exec = connection.Execute(sql, new { Account });
        }
        public Customers GetByAccount(string account)
        {
            var strSql = "SELECT * FROM Customers WHERE Account = @Account";
            return connection.QueryFirst<Customers>(strSql, new { Account = account });
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
            var sql = "SELECT * FROM Customers";
            return connection.Query<Customers>(sql);

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
