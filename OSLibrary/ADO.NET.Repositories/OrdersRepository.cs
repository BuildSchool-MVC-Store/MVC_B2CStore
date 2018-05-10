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
            var sql = "INSERT INTO FROM Orders VALUES (@Order_Date, @Account, @Pay, @Transport, @Order_Check, @Total, @TranMoney)";
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
            var sql = "UPDATE Orders SET Order_Date = @Order_Date, Account = @Account, Pay = @Pay, Transport = @Transport, Order_Check = @Order_Check, Total = @Total, TranMoney = @TranMoney WHERE Order_ID = @Order_ID";
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

        public Orders GetByID(int Order_ID)
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

                //Order = new Orders();
                //for(var i = 0; i < reader.FieldCount; i++)
                //{
                //    var fieldName = reader.GetName(i);
                //    var property = properties.FirstOrDefault((x) => x.Name == fieldName);

                //    if (property == null)
                //        continue;

                //    if (!reader.IsDBNull(i))
                //        property.SetValue(Order, reader.GetValue(i));
                //}

                //Order.Order_ID = int.Parse(reader.GetValue(reader.GetOrdinal("Order_ID")).ToString());
                //Order.Order_Date = DateTime.Parse(reader.GetValue(reader.GetOrdinal("Order_Date")).ToString());
                //Order.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                //Order.Pay = reader.GetValue(reader.GetOrdinal("Pay")).ToString();
                //Order.Transport = reader.GetValue(reader.GetOrdinal("Transport")).ToString();
                //Order.Order_Check = reader.GetValue(reader.GetOrdinal("Order_Check")).ToString();
                //Order.Total = decimal.Parse(reader.GetValue(reader.GetOrdinal("Total")).ToString());
                //Order.TranMoney = decimal.Parse(reader.GetValue(reader.GetOrdinal("TranMoney")).ToString());
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

                //var Order = new Orders();
                //var properties = typeof(Orders).GetProperties();
                //for (var i = 0; i < reader.FieldCount; i++)
                //{
                //    var fieldname = reader.GetName(i);
                //    var property = properties.FirstOrDefault(x => x.Name == fieldname);
                //    if (property == null)
                //        continue;
                //    if (!reader.IsDBNull(i))
                //        property.SetValue(Order, reader.GetValue(i));
                //}
                //Orders.Add(Order);

                //Order.Order_ID = int.Parse(reader.GetValue(reader.GetOrdinal("Order_ID")).ToString());
                //Order.Order_Date = DateTime.Parse(reader.GetValue(reader.GetOrdinal("Order_Date")).ToString());
                //Order.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                //Order.Pay = reader.GetValue(reader.GetOrdinal("Pay")).ToString();
                //Order.Transport = reader.GetValue(reader.GetOrdinal("Transport")).ToString();
                //Order.Order_Check = reader.GetValue(reader.GetOrdinal("Order_Check")).ToString();
                //Order.Total = decimal.Parse(reader.GetValue(reader.GetOrdinal("Total")).ToString());
                //Order.TranMoney = decimal.Parse(reader.GetValue(reader.GetOrdinal("TranMoney")).ToString());
            }
            reader.Close();
            return Orders;
        }
    }
}
