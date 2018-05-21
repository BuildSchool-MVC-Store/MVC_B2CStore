using Dapper;
using OSLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSLibrary.Models;
namespace OSLibrary.ADO.NET.Repositories
{
    public class StockRepository:IRepository<Stock>
    {
        private string strConnection = "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;";
        public void Create(Stock model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "INSERT INTO Stock VALUES (@Product_ID,@Quantity,@Product_Size)";
                var exec = connection.Execute(sql, model);
            }
        }

        public void Update(Stock model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "UPDATE Stock SET Quantity=@Quantity WHERE Product_ID = @Product_ID and Product_Size=@Product_Size";
                var exec = connection.Execute(sql, model);
            }
        }

        public void Delete(Stock model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "DELETE FROM Stock WHERE Product_ID = @Product_ID and Product_Size=@Product_Size";
                var exec = connection.Execute(sql, new { model.Product_ID , model.Product_Size });
            }
        }


        public Stock GetByProduct_IDandProduct_Size(int Product_ID, string Product_Size)
        {
            Stock productSizeQuantity = new Stock();
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Stock WHERE Product_ID = @Product_ID and Product_Size=@Product_Size";
                productSizeQuantity = connection.QueryFirstOrDefault<Stock>(sql, new { Product_ID, Product_Size });
            }
            return productSizeQuantity;
        }

        public IEnumerable<Stock> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Stock";
                return connection.Query<Stock>(sql);
            }
        }
        public bool CheckInventory(int Product_ID,string Product_Size,int needQuantity)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Stock WHERE Product_ID = @Product_ID AND Product_Size=@Product_Size";

                var item = connection.QueryFirstOrDefault<Stock>(sql,new { Product_ID,Product_Size});

                if(item.Quantity>=needQuantity)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
