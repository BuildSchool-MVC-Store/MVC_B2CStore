using OSLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ADO.NET.Repositories
{
    public class OrdersRepository : IRepository<Orders>
    {
        private string strConnection = "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password=123456789;";
        public void Create(Orders model)
        {
            using (SqlConnection Connection = new SqlConnection(strConnection))
            {
                var sql = "INSERT INTO Orders (Order_Date, Account, Pay, Transport, Order_Check, Total, TranMoney) VALUES (@Order_Date, @Account, @Pay, @Transport, @Order_Check, @Total, @TranMoney)";
                var exec = Connection.Execute(sql, model);
            }
        }

        public void Update(Orders model)
        {
            using (SqlConnection Connection = new SqlConnection(strConnection))
            {
                var sql = "SET IDENTITY_INSERT Orders ON UPDATE Orders SET Order_Date = @Order_Date, Account = @Account, Pay = @Pay, Transport = @Transport, Order_Check = @Order_Check, Total = @Total, TranMoney = @TranMoney WHERE Order_ID = @Order_ID SET IDENTITY_INSERT Orders OFF";
                var exec = Connection.Execute(sql, model);
            }
        }

        public void Delete(int Order_ID)
        {
            using (SqlConnection Connection = new SqlConnection(strConnection))
            {
                var sql = "DELETE FROM Orders WHERE Order_ID = @Order_ID";
                var exec = Connection.Execute(sql, new { Order_ID });
            }
        }

        public Orders GetByOrder_ID(int Order_ID)
        {
            Orders Order = null;
            using (SqlConnection Connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Orders WHERE Order_ID = @Order_ID";
                Order = Connection.QueryFirst<Orders>(sql, new { Order_ID = Order_ID });
            }
            return Order;
        }

        public IEnumerable<Orders> GetAll()
        {
            IEnumerable<Orders> orders = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Orders";
                orders = connection.Query<Orders>(sql);
            }
            return orders;
        }
        public IEnumerable<Orders> GetByOrder_Date(DateTime from , DateTime to)
        {
            IEnumerable<Orders> orders = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Orders WHERE Order_Date >= @from AND Order_Date<=to";
                orders = connection.Query<Orders>(sql);
            }
            return orders;
        }
        public IEnumerable<Orders> GetByAccount(string Account)
        {
            IEnumerable<Orders> orders = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Orders WHERE Account == @Account";
                orders = connection.Query<Orders>(sql);
            }
            return orders;
        }

    }
}
