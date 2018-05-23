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
    public class Order_DetailsRepository : IRepository<Order_Details>
    {
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OSModel"].ConnectionString);

        public void Create(Order_Details model)
        {
            var sql = "INSERT INTO Order_Details (Order_ID,Product_ID,Quantity,Price,size)  VALUES (@Order_ID, @Product_ID, @Quantity, @Price, @size)";
            var exec = connection.Execute(sql, model);

        }

        public void Update(Order_Details model)
        {

            var sql = "UPDATE Order_Details SET Order_ID = @Order_ID, Product_ID = @Product_ID, Quantity = @Quantity, Price = @Price, Discount = @Discount, size = @size WHERE Order_Details_ID = @Order_Details_ID";
            var exec = connection.Execute(sql, model);

        }

        public void Delete(int Order_Details_ID)
        {
            var sql = "DELETE FROM Order_Details WHERE Order_Details_ID = @Order_Details_ID";
            var exec = connection.Execute(sql, new { Order_Details_ID });
        }

        public Order_Details GetByOrder_Details_ID(int Order_Details_ID)
        {
            var sql = "SELECT * FROM Order_Details WHERE Order_Details_ID = @Order_Details_ID";
            return connection.QueryFirstOrDefault<Order_Details>(sql, new { Order_Details_ID = Order_Details_ID });
        }

        public IEnumerable<Order_Details> GetAll()
        {

            var sql = "SELECT * FROM Order_Details";
            return connection.Query<Order_Details>(sql);
        }
        public IEnumerable<Order_Details> GetByOrderID(int OrderID)
        {
            var sql = "SELECT * FROM Order_Details WHERE Order_ID = @OrderID";
            return connection.Query<Order_Details>(sql, new { OrderID = OrderID });
        }
    }
}
