﻿using Dapper;
using OSLibrary.Models;
using OSLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ADO.NET.Repositories
{
    public class ShoppingCartRepository : IRepository<Shopping_Cart>
    {
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OSModel"].ConnectionString);

        public void Create(Shopping_Cart model)
        {

            var sql = "INSERT INTO Shopping_Cart VALUES (@Account,@Product_ID,@Quantity,@UnitPrice,@Discount,@size)";
            var exec = connection.Execute(sql, model);

        }
        public void Update(int Shopping_Cart_ID, int Quantity)
        {

            var sql = "UPDATE Shopping_Cart SET Quantity=@Quantity WHERE Shopping_Cart_ID = @Shopping_Cart_ID";
            var exec = connection.Execute(sql, new { Quantity, Shopping_Cart_ID });

        }
        public void Delete(int Shopping_Cart_ID)
        {

            var sql = "DELETE FROM Shopping_Cart WHERE Shopping_Cart_ID = @Shopping_Cart_ID";
            var exec = connection.Execute(sql, new { Shopping_Cart_ID });

        }
        public void DeleteByAccount(string Account)
        {

            var sql = "DELETE FROM Shopping_Cart WHERE Account = @Account";
            var exec = connection.Execute(sql, new { Account });

        }
        public IEnumerable<Shopping_Cart> GetByAccount(string Account)
        {

            var sql = "SELECT * FROM Shopping_Cart WHERE Account = @Account";
            return connection.Query<Shopping_Cart>(sql, new { Account });

        }

        public IEnumerable<Shopping_Cart> GetAll()
        {
            var sql = "SELECT * FROM Shopping_Cart";
            return connection.Query<Shopping_Cart>(sql);
        }
    }
}
