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
namespace OSLibrary.ADO.NET.Repositories
{
    public class Order_DetailsRepository : IRepository<Order_Details>
    {
        private string strConnection = "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;";
        public void Create(Order_Details model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "INSERT INTO Order_Details VALUES (@Order_ID, @Product_ID, @Quantity, @UnitPrice, @Discount, @size)";
                var exec = connection.Execute(sql, model);
            }
        }

        public void Update(Order_Details model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "UPDATE Order_Details SET Order_ID = @Order_ID, Product_ID = @Product_ID, Quantity = @Quantity, UnitPrice = @UnitPrice, Discount = @Discount, size = @size WHERE Order_Details_ID = @Order_Details_ID";
                var exec = connection.Execute(sql, model);
            }
        }

        public void Delete(string Order_Details_ID)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "DELETE FROM Order_Details WHERE Order_Details_ID = @Order_Details_ID";
                var exec = connection.Execute(sql, new { Order_Details_ID });
            }
        }

        public Order_Details GetByOrder_Details_ID(int Order_Details_ID)
        {
            Order_Details order_details = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Order_Details WHERE Order_Details_ID = @Order_Details_ID";
                order_details = connection.QueryFirstOrDefault<Order_Details>(sql, new { Order_Details_ID = Order_Details_ID });
            }
            return order_details;
        }

        public IEnumerable<Order_Details> GetAll()
        {

            IEnumerable<Order_Details> Order_Details = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Order_Details";
                Order_Details = connection.Query<Order_Details>(sql);
            }
            return Order_Details;
        }
        public IEnumerable<Order_Details> GetByOrderID(int OrderID)
        {
            IEnumerable<Order_Details> Order_Details = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Order_Details WHERE Order_ID = @OrderID";
                Order_Details = connection.Query<Order_Details>(sql,new { OrderID = OrderID});
            }
            return Order_Details;
        }
    }
}
