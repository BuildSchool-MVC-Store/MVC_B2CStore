using OSLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSLibrary.Models;
using System.Configuration;

namespace OSLibrary.ADO.NET.Repositories
{
    public class OrdersRepository : IRepository<Orders>
    {
        private string strConnection = "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password=123456789;";
        public void Create(SqlConnection connection , Orders model , IDbTransaction transaction)
        {
            var sql = "INSERT INTO Orders (Order_Date, Account, Pay, Transport, Order_Check, Total, TranMoney) VALUES (@Order_Date, @Account, @Pay, @Transport, @Order_Check, @Total, @TranMoney)";
            connection.Execute(sql, model, transaction);
        }
        public void Update(Orders model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "UPDATE Orders SET Order_Date = @Order_Date, Account = @Account, Pay = @Pay, Transport = @Transport, Order_Check = @Order_Check, Total = @Total, TranMoney = @TranMoney WHERE Order_ID = @Order_ID";
                var exec = connection.Execute(sql, model);
            }
        }
        public void Delete(int Order_ID)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "DELETE FROM Orders WHERE Order_ID = @Order_ID";
                var exec = connection.Execute(sql, new { Order_ID });
            }
        }

        public Orders GetByOrder_ID(int Order_ID)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Orders WHERE Order_ID = @Order_ID";
                return connection.QueryFirst<Orders>(sql, new { Order_ID });
            }
        }

        public IEnumerable<Orders> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {

                var sql = "SELECT * FROM Orders";
                return connection.Query<Orders>(sql);
            }

        }
        public IEnumerable<Orders> GetByOrder_Date(DateTime from, DateTime to)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Orders WHERE Order_Date >= @from AND Order_Date<=@to";
                return connection.Query<Orders>(sql, new { from, to });
            }
        }
        public IEnumerable<Orders> GetByAccount(string Account)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Orders WHERE Account = @Account";
                return connection.Query<Orders>(sql, new { Account });
            }
        }
        public Orders GetLatestByAccount(SqlConnection connection,string Account,IDbTransaction transaction)
        {
            string sql = "SELECT TOP 1 * FROM Orders WHERE Account = @Account ORDER BY Order_Date DESC";
            return connection.QueryFirstOrDefault<Orders>(sql, new { Account },transaction);
        }
        public Orders GetLatestByAccount(SqlConnection connection, string Account)
        {
            string sql = "SELECT TOP 1 * FROM Orders WHERE Account = @Account ORDER BY Order_Date DESC";
            return connection.QueryFirstOrDefault<Orders>(sql, new { Account });
        }

        public void Update(int order_ID, decimal totalmoney, SqlConnection connection, SqlTransaction transaction)
        {
            var sql = "UPDATE Orders SET Total = @Total WHERE Order_ID = @Order_ID";
            connection.Execute(sql, new { Total = totalmoney , order_ID }, transaction);
        }

        public Orders GetOrderTotal(string Account)////
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT o.Order_ID, o.Order_Date, SUM(od.Price * od.Quantity) + o.TranMoney AS Total, o.Transport, o.TranMoney FROM Orders o INNER JOIN Order_Details od ON o.Order_ID = od.Order_ID WHERE Account = @Account GROUP BY o.Order_ID, o.Order_Date, o.TranMoney, o.Transport";
                return connection.QueryFirstOrDefault<Orders>(sql, new { Account });
            }
        }

        public IEnumerable<Orders> GetOrderByOrder_CheckIs0()
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Orders WHERE Order_Check =0";
                return connection.Query<Orders>(sql);
            }

        }

        public IEnumerable<Orders> GetOrderByOrder_CheckIs1()
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Orders WHERE Order_Check =1";
                return connection.Query<Orders>(sql);
            }

        }
        public IEnumerable<Orders> GetOrderByOrder_CheckIs2()
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Orders WHERE Order_Check =2";
                return connection.Query<Orders>(sql);
            }

        }
        public IEnumerable<Orders> GetOrderByOrder_CheckIs3()
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Orders WHERE Order_Check =3";
                return connection.Query<Orders>(sql);
            }

        }
        public IEnumerable<Orders> GetOrderByOrder_CheckIs4()
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Orders WHERE Order_Check =4";
                return connection.Query<Orders>(sql);
            }

        }
        public IEnumerable<Orders> GetOrderByOrder_CheckIs5()
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Orders WHERE Order_Check =-1";
                return connection.Query<Orders>(sql);
            }

        }
    }
}
