using Dapper;
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
    public class ProductSizeQuantityRepository:IRepository<Product_Size_Quantity>
    {
        private string strConnection = "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;";
        public void Create(Product_Size_Quantity model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "INSERT INTO Product_Size_Quantity VALUES (@Product_ID,@Quantity,@Product_Size)";
                var exec = connection.Execute(sql, model);
            }
        }

        public void Update(Product_Size_Quantity model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "UPDATE Product_Size_Quantity SET Quantity=@Quantity WHERE Product_ID = @Product_ID and Product_Size=@Product_Size";
                var exec = connection.Execute(sql, model);
            }
        }

        public void Delete(Product_Size_Quantity model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "DELETE FROM Product_Size_Quantity WHERE Product_ID = @Product_ID and Product_Size=@Product_Size";
                var exec = connection.Execute(sql, new { model.Product_ID , model.Product_Size });
            }
        }


        public Product_Size_Quantity GetByProduct_IDandProduct_Size(int Product_ID, string Product_Size)
        {
            Product_Size_Quantity productSizeQuantity = new Product_Size_Quantity();
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Product_Size_Quantity  WHERE Product_ID = @Product_ID and Product_Size=@Product_Size";
                productSizeQuantity = connection.QueryFirstOrDefault<Product_Size_Quantity>(sql, new { Product_ID, Product_Size });
            }
            return productSizeQuantity;
        }

        public IEnumerable<Product_Size_Quantity> GetAll()
        {
            IEnumerable<Product_Size_Quantity> product_Size_Quantities = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Shopping_Cart WHERE Account = @Account";
                product_Size_Quantities = connection.Query<Product_Size_Quantity>(sql);
            }
            return product_Size_Quantities;
        }
    }
}
