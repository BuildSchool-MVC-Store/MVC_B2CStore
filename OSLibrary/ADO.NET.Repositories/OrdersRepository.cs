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
    public class OrdersRepository
    {
        public void Create(Orders model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password=123456789;"
                );
            var sql = "INSERT INTO Orders (Order_Date, Account, Pay, Transport, Order_Check, Total, TranMoney) VALUES (@Order_Date, @Account, @Pay, @Transport, @Order_Check, @Total, @TranMoney)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("Order_Date", model.Order_Date);
            command.Parameters.AddWithValue("Account", model.Account);
            command.Parameters.AddWithValue("Pay", model.Pay);
            command.Parameters.AddWithValue("Transport", model.Transport);
            command.Parameters.AddWithValue("Order_Check", model.Order_Check);
            command.Parameters.AddWithValue("Total", model.Total);
            command.Parameters.AddWithValue("TranMoney", model.TranMoney);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Orders model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password=123456789;"
                );
            var sql = "SET IDENTITY_INSERT Orders ON UPDATE Orders SET Order_Date = @Order_Date, Account = @Account, Pay = @Pay, Transport = @Transport, Order_Check = @Order_Check, Total = @Total, TranMoney = @TranMoney WHERE Order_ID = @Order_ID SET IDENTITY_INSERT Orders OFF";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("Order_ID", model.Order_ID);
            command.Parameters.AddWithValue("Order_Date", model.Order_Date);
            command.Parameters.AddWithValue("Account", model.Account);
            command.Parameters.AddWithValue("Pay", model.Pay);
            command.Parameters.AddWithValue("Transport", model.Transport);
            command.Parameters.AddWithValue("Order_Check", model.Order_Check);
            command.Parameters.AddWithValue("Total", model.Total);
            command.Parameters.AddWithValue("TranMoney", model.TranMoney);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Orders model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password=123456789;"
                );
            var sql = "DELETE FROM Orders WHERE Order_ID = @Order_ID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Order_ID", model.Order_ID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Orders GetByOrder_ID(int Order_ID)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "SELECT * FROM Orders WHERE Order_ID = @Order_ID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Order_ID", Order_ID);

            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            var properties = typeof(Orders).GetProperties();

            Orders Order = null;
            while(reader.Read())
            {
                Order = DbReaderModelBinder<Orders>.Bind(reader);
            }
            reader.Close();
            return Order;
        }

        public IEnumerable<Orders> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "SELECT * FROM Orders";
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<Orders> Orders = new List<Orders>();
            while (reader.Read())
            {
                var Order = DbReaderModelBinder<Orders>.Bind(reader);
                Orders.Add(Order);
            }
            reader.Close();
            return Orders;
        }
        public IEnumerable<Orders> GetByOrder_Date(DateTime from , DateTime to)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "SELECT * FROM Orders WHERE Order_Date >= @from AND Order_Date<=to";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@from", from);
            command.Parameters.AddWithValue("@to", to);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<Orders> Orders = new List<Orders>();
            while (reader.Read())
            {
                var Order = DbReaderModelBinder<Orders>.Bind(reader);
                Orders.Add(Order);
            }
            reader.Close();
            return Orders;
        }
        public IEnumerable<Orders> GetByAccount(string Account)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "SELECT * FROM Orders WHERE Account == @Account";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Account", Account);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<Orders> Orders = new List<Orders>();
            while (reader.Read())
            {
                var Order = DbReaderModelBinder<Orders>.Bind(reader);
                Orders.Add(Order);
            }
            reader.Close();
            return Orders;
        }

    }
}
