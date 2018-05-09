using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ADO.NET.Repositories
{
    public class ProductsRepository
    {
        public void Create(Products model)
        {
            SqlConnection connection = new SqlConnection(
               "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
                );  
            var sql=("INSERT ")



        }
        public void Update()
        { }
        public void Delete() { }

        public void GetById() { }
        public void GetAll() { }
    }
}
