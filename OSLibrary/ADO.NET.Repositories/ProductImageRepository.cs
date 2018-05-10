using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using OSLibrary.Utils;

namespace OSLibrary.ADO.NET.Repositories
{
    public class ProductImageRepository
    {
        public void Create(Product_Image model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password=123456789;"
                );
            var sql = "INSERT INTO FROM Product_Image VALUES (@Product_ID, @Picture, @Product_Image_Only)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("Product_ID", model.Product_ID);
            command.Parameters.AddWithValue("Picture", model.Pictrue);
            command.Parameters.AddWithValue("Product_Image_Only", model.Product_Image_Only);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Product_Image model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password=123456789;"
                );
            var sql = "UPDETE Product_Image SET Product_ID = @Product_ID, Picture = @Picture, Product_Image_Only = @Product_Image_Only WHERE Product_Image_ID = @Product_Image_ID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("Product_ID", model.Product_ID);
            command.Parameters.AddWithValue("Picture", model.Pictrue);
            command.Parameters.AddWithValue("Product_Image_Only", model.Product_Image_Only);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Product_Image model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password=123456789;"
                );
            var sql = "DELETE FROM Product_Image WHERE Product_Image_ID = @Product_Image_ID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Product_Image_ID", model.Product_Image_ID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<Product_Image> GetByProduct_ID(int Product_ID)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "SELECT * FROM Product_Image WHERE Product_ID = @Product_ID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Product_ID", Product_ID);

            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            List<Product_Image> productImages = new List<Product_Image>();
            
            while (reader.Read())
            {
                var productImage = new Product_Image();
                var properties = typeof(Product_Image).GetProperties();

                for(var i = 0; i<reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault((x) => x.Name == fieldName);

                    if(property == null)
                    {
                        continue;
                    }
                    if (!reader.IsDBNull(i))
                    {
                        property.SetValue(productImage, reader.GetValue(i));
                    }
                }
                productImages.Add(productImage);
            }
            
            reader.Close();
            return productImages;
        }
        public IEnumerable<Product_Image> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "SELECT * FROM Product_Image";
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var ProductImages = new List<Product_Image>();
            while (reader.Read())
            {

                var ProductImage =DbReaderModelBinder<Product_Image>.Bind(reader);
                //ProductImage.Product_Image_ID = int.Parse(reader.GetValue(reader.GetOrdinal("Product_Image_ID")).ToString());
                //ProductImage.Product_ID = int.Parse(reader.GetValue(reader.GetOrdinal("Product_ID")).ToString());
                //ProductImage.Pictrue = ObjectToByteArray(reader.GetValue(reader.GetOrdinal("Pictrue")));
                //ProductImage.Product_Image_Only = reader.GetValue(reader.GetOrdinal("Product_Image_Only")).ToString();
                ProductImages.Add(ProductImage);
            }
            reader.Close();
            return ProductImages;
        }
        private byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
