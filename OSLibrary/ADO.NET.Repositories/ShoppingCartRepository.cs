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
    public class ShoppingCartRepository : IRepository<Shopping_Cart>
    {
        private string strConnection = "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;";

        public void Create(Shopping_Cart model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "INSERT INTO Shopping_Cart VALUES (@Account,@Product_ID,@Quantity,@UnitPrice,@Discount,@size)";
                var exec = connection.Execute(sql, model);
            }
        }
        public void Update(Shopping_Cart model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "UPDATE Shopping_Cart SET Account=@Account,Product_ID=@Product_ID,Quantity=@Quantity,UnitPrice=@UnitPrice,Discount=@Discount,size=@size WHERE Shopping_Cart_ID = @Shopping_Cart_ID";
                var exec = connection.Execute(sql, model);
            }
        }
        public void Delete(int Shopping_Cart_ID)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "DELETE FROM Shopping_Cart WHERE Shopping_Cart_ID = @Shopping_Cart_ID";
                var exec = connection.Execute(sql, new { Shopping_Cart_ID });
            }
        }

        public IEnumerable<Shopping_Cart> GetByAccount(string Account)
        {
            IEnumerable<Shopping_Cart> shoppingCarts = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Shopping_Cart WHERE Account = @Account";
                shoppingCarts = connection.Query<Shopping_Cart>(sql, new { Account });
            }
            return shoppingCarts;
        }

        public IEnumerable<Shopping_Cart> GetAll()
        {
            IEnumerable<Shopping_Cart> shoppingCarts = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Shopping_Cart";
                shoppingCarts = connection.Query<Shopping_Cart>(sql);
            }
            return shoppingCarts;
        }
    }
}
