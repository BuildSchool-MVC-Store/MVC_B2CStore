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
        private SqlConnection connection = new SqlConnection(SqlConnect.str);
        public void Create(Orders model, IDbTransaction transaction)
        {

            var sql = "INSERT INTO Orders (Order_Date, Account, Pay, Transport, Order_Check, Total, TranMoney) VALUES (@Order_Date, @Account, @Pay, @Transport, @Order_Check, @Total, @TranMoney)";
            var exec = connection.Execute(sql, model, transaction);
        }

        public void Update(Orders model)
        {

            var sql = "UPDATE Orders SET Order_Date = @Order_Date, Account = @Account, Pay = @Pay, Transport = @Transport, Order_Check = @Order_Check, Total = @Total, TranMoney = @TranMoney WHERE Order_ID = @Order_ID";
            var exec = connection.Execute(sql, model);
        }

        public void Delete(int Order_ID)
        {

            var sql = "DELETE FROM Orders WHERE Order_ID = @Order_ID";
            var exec = connection.Execute(sql, new { Order_ID });

        }

        public Orders GetByOrder_ID(int Order_ID)
        {

            var sql = "SELECT * FROM Orders WHERE Order_ID = @Order_ID";
            return connection.QueryFirst<Orders>(sql, new { Order_ID });

        }

        public IEnumerable<Orders> GetAll()
        {

            var sql = "SELECT * FROM Orders";
            return connection.Query<Orders>(sql);

        }
        public IEnumerable<Orders> GetByOrder_Date(DateTime from, DateTime to)
        {
            var sql = "SELECT * FROM Orders WHERE Order_Date >= @from AND Order_Date<=@to";
            return connection.Query<Orders>(sql, new { from, to });
        }
        public IEnumerable<Orders> GetByAccount(string Account)
        {

            var sql = "SELECT * FROM Orders WHERE Account = @Account";
            return connection.Query<Orders>(sql, new { Account });
        }
        public Orders GetLatestByAccount(string Account)
        {
            var sql = "SELECT TOP 1 * FROM Orders WHERE Account = @Account ORDER BY Order_Date DESC";
            return connection.QueryFirstOrDefault<Orders>(sql, new { Account });
        }
    }
}
