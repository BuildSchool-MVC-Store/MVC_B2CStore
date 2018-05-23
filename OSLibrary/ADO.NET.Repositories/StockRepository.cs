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
using System.Configuration;

namespace OSLibrary.ADO.NET.Repositories
{
    public class StockRepository : IRepository<Stock>
    {
        private SqlConnection connection = new SqlConnection(SqlConnect.str);
        public void Create(Stock model)
        {
            var sql = "INSERT INTO Stock VALUES (@Product_ID,@Quantity,@Product_Size)";
            var exec = connection.Execute(sql, model);
        }

        public void Update(Stock model)
        {
            var sql = "UPDATE Stock SET Quantity=@Quantity WHERE Product_ID = @Product_ID and Product_Size=@Product_Size";
            var exec = connection.Execute(sql, model);
        }

        public void Delete(Stock model)
        {
            var sql = "DELETE FROM Stock WHERE Product_ID = @Product_ID and Product_Size=@Product_Size";
            var exec = connection.Execute(sql, new { model.Product_ID, model.Product_Size });
        }
        public Stock GetByProduct_IDandProduct_Size(int Product_ID, string Product_Size)
        {
            var sql = "SELECT * FROM Stock WHERE Product_ID = @Product_ID and Product_Size=@Product_Size";
            return connection.QueryFirstOrDefault<Stock>(sql, new { Product_ID, Product_Size });
        }

        public IEnumerable<Stock> GetAll()
        {
            var sql = "SELECT * FROM Stock";
            return connection.Query<Stock>(sql);
        }
        public bool CheckInventory(int Product_ID, string Product_Size, int needQuantity)
        {
            var sql = "SELECT * FROM Stock WHERE Product_ID = @Product_ID AND Product_Size=@Product_Size";
            var item = connection.QueryFirstOrDefault<Stock>(sql, new { Product_ID, Product_Size });
            if (item.Quantity >= needQuantity)
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
