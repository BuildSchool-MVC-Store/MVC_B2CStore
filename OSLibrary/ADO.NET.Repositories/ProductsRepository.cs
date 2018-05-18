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
namespace OSLibrary.ADO.NET.Repositories
{
    public class ProductsRepository : IRepository<Products>
    {
        private string strConnection = "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;";
        public void Create(Products model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = ("SET IDENTITY_INSERT Products ON INSERT INTO Products (Product_ID,Product_Name,UnitPrice,Product_Types_Name,Gender) VALUES (@Product_ID,@Product_Name,@UnitPrice,@Product_Types_Name,@Gender) SET IDENTITY_INSERT Products OFF");
                var exec = connection.Execute(sql);
            }
        }
        public void Update(Products model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = ("UPDATE Products SET Product_Name=@Product_Name,UnitPrice=@UnitPrice,Product_Types_Name=@Product_Types_Name,Gender=@Gender WHERE Product_ID=@Product_ID");
                var exec = connection.Execute(sql);
            }
        }
        public void Delete(int Product_ID)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = ("DELETE FROM Products WHERE Product_ID=@Product_ID");
                var exec = connection.Execute(sql, new { Product_ID });
            }
        }
        public Products GetByProduct_ID(int Product_ID)
        {
            Products products = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Products WHERE Product_ID=@Product_ID";
                products = connection.QueryFirstOrDefault<Products>(sql);
            }
            return products;
        }
        public IEnumerable<Products> GetAll()
        {
            IEnumerable<Products> products = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Products";
                products = connection.Query<Products>(sql);
            }
            return products;
        }
        public IEnumerable<Products> GetByProduct_Types_Name(string Product_Types_Name)
        {
            IEnumerable<Products> products = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Products WHERE Product_Types_Name = @Product_Types_Name";
                products = connection.Query<Products>(sql);
            }
            return products;
        }
    }
}
