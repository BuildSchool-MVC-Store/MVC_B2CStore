using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ADO.NET.Repositories
{
    public class CustomerRepository
    {
        public void Create(Customers model)
        {
            SqlConnection connection = new SqlConnection(
            "data source=140.126.146.49,7988;initial catalog=2018Build;user id=Build;password=123456789;integrated security=true"
            );
            var sql = "INSERT INTO Customers VALUES (@id, @name, @cname, @ctitle, @address, @city, @region, @postalcode, @country, @phone, @fax)";
        }

    }
}
