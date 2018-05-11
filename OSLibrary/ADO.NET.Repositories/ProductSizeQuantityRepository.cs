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
    public class ProductSizeQuantityRepository
    {
        public void Create(Product_Size_Quantity model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "INSERT INTO Product_Size_Quantity VALUES (@Product_ID,@Quantity,@Product_Size)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Product_ID", model.Product_ID);
            command.Parameters.AddWithValue("@Quantity", model.Quantity);
            command.Parameters.AddWithValue("@Product_Size", model.Product_Size);
            
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Product_Size_Quantity model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "UPDATE Product_Size_Quantity SET Quantity=@Quantity WHERE Product_ID = @Product_ID and Product_Size=@Product_Size";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Product_ID", model.Product_ID);
            command.Parameters.AddWithValue("@Quantity", model.Quantity);
            command.Parameters.AddWithValue("@Product_Size", model.Product_Size);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Product_Size_Quantity model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "DELETE FROM Product_Size_Quantity WHERE Product_ID = @Product_ID and Product_Size=@Product_Size";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Product_ID", model.Product_ID);
             command.Parameters.AddWithValue("@Product_Size", model.Product_Size);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }


        public Product_Size_Quantity GetByID(int Product_ID, string Product_Size)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "SELECT * FROM Product_Size_Quantity  WHERE Product_ID = @Product_ID and Product_Size=@Product_Size";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Product_ID", Product_ID);
            command.Parameters.AddWithValue("@Product_Size", Product_Size);

            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            var properties = typeof(Product_Size_Quantity).GetProperties();
            Product_Size_Quantity productSizeQuantity = new Product_Size_Quantity();
            while (reader.Read())
            {
                productSizeQuantity = DbReaderModelBinder<Product_Size_Quantity>.Bind(reader);
            }
            reader.Close();
            return productSizeQuantity;
        }

        public IEnumerable<Product_Size_Quantity> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "SELECT * FROM Product_Size_Quantity";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var productSizeQuantitys = new List<Product_Size_Quantity>();
            while (reader.Read())
            {
                var productSizeQuantity = DbReaderModelBinder<Product_Size_Quantity>.Bind(reader);

                productSizeQuantitys.Add(productSizeQuantity);
            }
            reader.Close();
            return productSizeQuantitys;
        }



























    }
}
