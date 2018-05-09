﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ADO.NET.Repositories
{
    public class ProductsRepository
    {
        public void Create(Products model)
        {
            SqlConnection connection = new SqlConnection(
               "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = ("INSERT INTO Porducts VALUES (@Product_ID,@Product_Name,@UnitPrice,@Product_Types_Name,@Gender)");
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Product_ID", model.Product_ID);
            command.Parameters.AddWithValue("@Product_Name", model.Product_ID);
            command.Parameters.AddWithValue("@UnitPrice", model.Product_ID);
            command.Parameters.AddWithValue("@Product_Types_Name", model.Product_ID);
            command.Parameters.AddWithValue("@Gender", model.Product_ID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(Products model)
        {
            SqlConnection connection = new SqlConnection(
             "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
              );
            var sql = ("UPDATE Porducts SET Product_ID=@Product_ID,Product_Name=@Product_Name,UnitPrice=@UnitPrice,Product_Types_Name=@Product_Types_Name,Gender=@Gender");
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Product_ID", model.Product_ID);
            command.Parameters.AddWithValue("@Product_Name", model.Product_Name);
            command.Parameters.AddWithValue("@UnitPrice", model.UnitPrice);
            command.Parameters.AddWithValue("@Product_Types_Name", model.Product_Types_Name);
            command.Parameters.AddWithValue("@Gender", model.Gender);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(Products model)
        {
            SqlConnection connection = new SqlConnection(
                     "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = ("DELETE FROM Products WHERE Product_ID=@Product_ID");
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Product_ID", model.Product_ID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }



        public Products GetByProduct_ID() {
            SqlConnection connection = new SqlConnection(
                     "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = "SELECT * FROM Product WHERE Product_ID=@Product_ID";
            SqlCommand command = new SqlCommand(sql,connection);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var product = new Products();
            while (reader.Read()) {
              
                product.Product_ID =int.Parse( reader.GetValue(reader.GetOrdinal("Product_ID")).ToString());
                product.Product_Name = (reader.GetValue(reader.GetOrdinal("Product_Name")).ToString());
                product.UnitPrice= int.Parse(reader.GetValue(reader.GetOrdinal("UnitPrice")).ToString());
                product.Product_Types_Name = reader.GetValue(reader.GetOrdinal("Product_Types_Name")).ToString();
                product.Gender =reader.GetValue(reader.GetOrdinal("Gender")).ToString();
                
            }
            reader.Close();
            return product;

        }
        public IEnumerable<Products> GetAll() {
            SqlConnection connection = new SqlConnection(
               "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = "SELECT * FROM Product ";
            SqlCommand command = new SqlCommand(sql,connection);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var products = new List<Products>();
            while (reader.Read())
            {
                var product = new Products();
                product.Product_ID = int.Parse(reader.GetValue(reader.GetOrdinal("Product_ID")).ToString());
                product.Product_Name = (reader.GetValue(reader.GetOrdinal("Product_Name")).ToString());
                product.UnitPrice = int.Parse(reader.GetValue(reader.GetOrdinal("UnitPrice")).ToString());
                product.Product_Types_Name = reader.GetValue(reader.GetOrdinal("Product_Types_Name")).ToString();
                product.Gender = reader.GetValue(reader.GetOrdinal("Gender")).ToString();
                products.Add(product);
            }
            reader.Close();
            return products;

        }
    }
}