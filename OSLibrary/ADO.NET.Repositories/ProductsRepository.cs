using OSLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSLibrary.Models;
using System.Configuration;

namespace OSLibrary.ADO.NET.Repositories
{
    public class ProductsRepository : IRepository<Products>
    {
        private SqlConnection connection = new SqlConnection(SqlConnect.str);
        public void Create(Products model)
        {
            var sql = ("SET IDENTITY_INSERT Products ON INSERT INTO Products (Product_ID,Product_Name,UnitPrice,Product_Types_Name,Gender) VALUES (@Product_ID,@Product_Name,@UnitPrice,@Product_Types_Name,@Gender) SET IDENTITY_INSERT Products OFF");
            var exec = connection.Execute(sql);
        }
        public void Update(Products model)
        {
            var sql = ("UPDATE Products SET Product_Name=@Product_Name,UnitPrice=@UnitPrice,Product_Types_Name=@Product_Types_Name,Gender=@Gender WHERE Product_ID=@Product_ID");
            var exec = connection.Execute(sql);
        }
        public void Delete(int Product_ID)
        {
            var sql = ("DELETE FROM Products WHERE Product_ID=@Product_ID");
            var exec = connection.Execute(sql, new { Product_ID });
        }
        public Products GetByProduct_ID(int Product_ID)
        {
            var sql = "SELECT * FROM Products WHERE Product_ID=@Product_ID";
            return connection.QueryFirstOrDefault<Products>(sql, new { Product_ID });
        }
        public IEnumerable<Products> GetAll()
        {
            var sql = "SELECT * FROM Products";
            return connection.Query<Products>(sql);
        }
        public IEnumerable<Products> GetByProduct_Types_Name(string Product_Types_Name)
        {

            var sql = "SELECT * FROM Products WHERE Product_Types_Name = @Product_Types_Name";
            return connection.Query<Products>(sql);
        }
    }
}
