﻿using OSLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ADO.NET.Repositories
{
    public class Order_DetailsRepository
    {
        public void Create(Order_Details model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = "INSERT INTO Order_Details VALUES (@Order_ID, @Product_ID, @Quantity, @UnitPrice, @Discount, @size)";
            SqlCommand command = new SqlCommand(sql, connection);
            {
                command.Parameters.AddWithValue("@Order_ID", model.Order_ID);
                command.Parameters.AddWithValue("@Product_ID", model.Product_ID);
                command.Parameters.AddWithValue("@Quantity", model.Quantity);
                command.Parameters.AddWithValue("@UnitPrice", model.UnitPrice);
                command.Parameters.AddWithValue("@Discount", model.Discount);
                command.Parameters.AddWithValue("@size", model.size);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        public void Update(Order_Details model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = "UPDATE Order_Detials SET Order_ID = @Order_ID, Product_ID = @Product_ID, Quantity = @Quantity, UnitPrice = @UnitPrice, Discount = @Discount, size = @size WHERE Order_Details_ID = @Order_Details_ID";
            SqlCommand command = new SqlCommand(sql, connection);
            {
                command.Parameters.AddWithValue("@Order_ID", model.Order_ID);
                command.Parameters.AddWithValue("@Product_ID", model.Product_ID);
                command.Parameters.AddWithValue("@Quantity", model.Quantity);
                command.Parameters.AddWithValue("@UnitPrice", model.UnitPrice);
                command.Parameters.AddWithValue("@Discount", model.Discount);
                command.Parameters.AddWithValue("@size", model.size);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Delete(Order_Details model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = "DELETE FORM Order_Details WHERE Order_Details_ID = @Order_Details_ID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Order_Details_ID", model.Order_Details_ID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Order_Details GetByID(int Order_Details_ID)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = "SELECT * FROM Order_Details WHERE Order_Details_ID = @Order_Details_ID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Order_Details_ID", Order_Details_ID);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var properties = typeof(Order_Details).GetProperties();
            Order_Details order_details = null;
            while (reader.Read())
            {
                order_details = DbReaderModelBinder<Order_Details>.Bind(reader);
            }
            reader.Close();
            return order_details;
        }

        public IEnumerable<Order_Details> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = "SELECT * FROM Order_Details";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var Order_Details = new List<Order_Details>();
            while (reader.Read())
            { 
                var order_details = DbReaderModelBinder<Order_Details>.Bind(reader);
                Order_Details.Add(order_details);
            }
            reader.Close();
            return Order_Details;
        }
    }
}
