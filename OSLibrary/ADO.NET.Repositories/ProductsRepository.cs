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
using OSLibrary.ViewModels;

namespace OSLibrary.ADO.NET.Repositories
{
    public class ProductsRepository : IRepository<Products>
    {
        static private SqlConnection connection = new SqlConnection(SqlConnect.str);
        public void Create(Products model)
        {
            var sql = ("INSERT INTO Products (Product_Name,UnitPrice,CategoryName,Gender,Online) VALUES (@Product_Name,@UnitPrice,@CategoryName,@Gender,@Online)");
            connection.Execute(sql,model);
        }
        public void Update(Products model)
        {
            var sql = ("UPDATE Products SET Product_Name=@Product_Name,UnitPrice=@UnitPrice,CategoryName=@CategoryName,Gender=@Gender,Comments=@Comments,Online=@Online WHERE Product_ID=@Product_ID");
            connection.Execute(sql,model);
        }
        public void Delete(int Product_ID)
        {
            var sql = ("DELETE FROM Products WHERE Product_ID=@Product_ID");
            connection.Execute(sql, new { Product_ID });
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

        public IEnumerable<ProductMain> GetIDandName()
        {
            var sql = "SELECT Product_ID,Product_Name FROM Products";
            return connection.Query<ProductMain>(sql);
        }

        public IEnumerable<Products> GetByProduct_Types_Name(string CategoryName)
        {
            var sql = "SELECT * FROM Products WHERE CategoryName = @CategoryName";
            return connection.Query<Products>(sql);
        }
        public string GetByProduct_Name(int Product_ID)
        {
            var sql = "SELECT * FROM Products WHERE Product_ID = @Product_ID";
            return connection.QueryFirstOrDefault<Products>(sql).Product_Name;
        }
    }
}
