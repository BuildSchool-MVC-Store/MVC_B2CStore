using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using OSLibrary.Utils;
using Dapper;

namespace OSLibrary.ADO.NET.Repositories
{
    public class ProductImageRepository
    {
        private string strConnection = "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password=123456789;";
        public void Create(Product_Image model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "INSERT INTO Product_Image VALUES (@Product_ID, @Picture, @Product_Image_Only)";
                var exec = connection.Execute(sql, model);
            }
        }

        public void Update(Product_Image model)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "UPDATE Product_Image SET Product_ID = @Product_ID, Picture = @Picture, Product_Image_Only = @Product_Image_Only WHERE Product_Image_ID = @Product_Image_ID";
                var exec = connection.Execute(sql, model);
            }
        }

        public void Delete(int Product_Image_ID)
        {
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "DELETE FROM Product_Image WHERE Product_Image_ID = @Product_Image_ID";
                var exec = connection.Execute(sql, new { Product_Image_ID });
            }
        }

        public IEnumerable<Product_Image> GetByProduct_ID(int Product_ID)
        {
            IEnumerable<Product_Image> product_Images = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Product_Image WHERE Product_ID = @Product_ID";
                product_Images = connection.Query<Product_Image>(sql);
            }
            return product_Images;
        }
        public IEnumerable<Product_Image> GetAll()
        {
            IEnumerable<Product_Image> product_Images = null;
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                var sql = "SELECT * FROM Product_Image";
                product_Images = connection.Query<Product_Image>(sql);
            }
            return product_Images;
        }
        private byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
