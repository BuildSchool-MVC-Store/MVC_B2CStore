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
    public class ProductsRepository
    {
        public void Create(Products model)
        {
            SqlConnection connection = new SqlConnection(
               "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = ("SET IDENTITY_INSERT Products ON INSERT INTO Products (Product_ID,Product_Name,UnitPrice,Product_Types_Name,Gender) VALUES (@Product_ID,@Product_Name,@UnitPrice,@Product_Types_Name,@Gender) SET IDENTITY_INSERT Products OFF");
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
        public void Update(Products model)
        {
            SqlConnection connection = new SqlConnection(
             "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
              );
            var sql = ("UPDATE Products SET Product_Name=@Product_Name,UnitPrice=@UnitPrice,Product_Types_Name=@Product_Types_Name,Gender=@Gender WHERE Product_ID=@Product_ID");
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



        public Products GetByProduct_ID(int Product_ID)
        {
            SqlConnection connection = new SqlConnection(
                     "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = "SELECT * FROM Products WHERE Product_ID=@Product_ID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Product_ID", Product_ID);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            //      var product = new Products();
            var properties = typeof(Products).GetProperties();
            Products products = null;
            while (reader.Read())
            {
               products = DbReaderModelBinder<Products>.Bind(reader);
                //products = new Products();
                //for (var i = 0; i < reader.FieldCount; i++)
                //{
                //    var fieldName = reader.GetName(i);
                //    var property = properties.FirstOrDefault((x) => x.Name == fieldName);
                //    if (property == null)
                //        continue;
                //    if (!reader.IsDBNull(i))
                //        property.SetValue(products, reader.GetValue(i));
                //}

                //product.Product_ID =Convert.ToInt32( reader.GetValue(reader.GetOrdinal("Product_ID")).ToString());
                //product.Product_Name = (reader.GetValue(reader.GetOrdinal("Product_Name")).ToString());
                //product.UnitPrice= Convert.ToInt32(reader.GetValue(reader.GetOrdinal("UnitPrice")).ToString());
                //product.Product_Types_Name = reader.GetValue(reader.GetOrdinal("Product_Types_Name")).ToString();
                //product.Gender =reader.GetValue(reader.GetOrdinal("Gender")).ToString();

            }
            reader.Close();
            return products;

        }
        public IEnumerable<Products> GetAll()
        {
            SqlConnection connection = new SqlConnection(
               "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );
            var sql = "SELECT * FROM Products";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            //var products = new List<Products>();
            List<Products> products = new List<Products>();
            while (reader.Read())
            {
                var product = DbReaderModelBinder<Products>.Bind(reader);
                //var product = new Products();
                //var properties = typeof(Products).GetProperties();

                //for (var i = 0; i < reader.FieldCount; i++)
                //{
                //    var fieldName = reader.GetName(i);
                //    var property = properties.FirstOrDefault((x) => x.Name == fieldName);
                //    if (property == null)
                //        continue;
                //    if (!reader.IsDBNull(i))
                //        property.SetValue(product, reader.GetValue(i));

                //}
                products.Add(product);
                //    var product = new Products();
                //    product.Product_ID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Product_ID")).ToString());
                //    product.Product_Name = (reader.GetValue(reader.GetOrdinal("Product_Name")).ToString());
                //    product.UnitPrice = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("UnitPrice")).ToString());
                //    product.Product_Types_Name = reader.GetValue(reader.GetOrdinal("Product_Types_Name")).ToString();
                //    product.Gender = reader.GetValue(reader.GetOrdinal("Gender")).ToString();
                //    products.Add(product);

            }
            reader.Close();
            return products;

        }
    }
}
