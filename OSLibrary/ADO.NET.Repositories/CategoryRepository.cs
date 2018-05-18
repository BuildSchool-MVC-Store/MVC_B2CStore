using Dapper;
using OSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ADO.NET.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private string strConnection = "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;";
        public void Create(Category model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = ("INSERT INTO Category VALUES (@CategoryName)");
                var exec = connection.Execute(sql);
            }
        }

        public IEnumerable<Category> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = ("SELECT * FROM Category");
                return connection.Query<Category>(sql);
            }
        }
    }
}
