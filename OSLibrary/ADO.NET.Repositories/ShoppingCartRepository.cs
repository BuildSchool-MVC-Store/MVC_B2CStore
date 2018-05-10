using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ADO.NET.Repositories
{
    public class ShoppingCartRepository
    {
        public void Create(Shopping_Cart model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "INSERT INTO Shopping_Cart VALUES (@Account,@Product_ID,@Quantity,@UnitPrice,@Discount,@size)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Account", model.Account);
            command.Parameters.AddWithValue("@Product_ID", model.Product_ID);
            command.Parameters.AddWithValue("@Quantity", model.Quantity);
            command.Parameters.AddWithValue("@UnitPrice", model.UnitPrice);
            command.Parameters.AddWithValue("@Discount", model.Discount);
            command.Parameters.AddWithValue("@size", model.size);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Update(Shopping_Cart model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "UPDATE Shopping_Cart SET Account=@Account,Product_ID=@Product_ID,Quantity=@Quantity,UnitPrice=@UnitPrice,Discount=@Discount,size=@size WHERE Shopping_Cart_ID = @Shopping_Cart_ID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Shopping_Cart_ID", model.Shopping_Cart_ID);
            command.Parameters.AddWithValue("@Account", model.Account);
            command.Parameters.AddWithValue("@Product_ID", model.Product_ID);
            command.Parameters.AddWithValue("@Quantity", model.Quantity);
            command.Parameters.AddWithValue("@UnitPrice", model.UnitPrice);
            command.Parameters.AddWithValue("@Discount", model.Discount);
            command.Parameters.AddWithValue("@size", model.size);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(Shopping_Cart model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "DELETE FROM Shopping_Cart WHERE Shopping_Cart_ID = @Shopping_Cart_ID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Shopping_Cart_ID", model.Shopping_Cart_ID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Shopping_Cart GetByID(int Shopping_Cart_ID)
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "SELECT * FROM Shopping_Cart WHERE Shopping_Cart_ID = @Shopping_Cart_ID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Shopping_Cart_ID", Shopping_Cart_ID);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
     //       var shoppingCart = new Shopping_Cart();

            var properties = typeof(Shopping_Cart).GetProperties();
            Shopping_Cart shoppingCart = null;

            while (reader.Read())
            {
                shoppingCart = new Shopping_Cart();
                for(var i=0;i<reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault(
                        p => p.Name == fieldName);

                    if (property == null)
                        continue;

                    if (!reader.IsDBNull(i))
                        property.SetValue(shoppingCart,
                            reader.GetValue(i));
                }


                //shoppingCart.Shopping_Cart_ID = Convert.ToInt32( reader.GetValue(reader.GetOrdinal("Shopping_Cart_ID")).ToString());
                //shoppingCart.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                //shoppingCart.Product_ID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Product_ID")));
                //shoppingCart.Quantity = Convert.ToInt16(reader.GetValue(reader.GetOrdinal("Quantity")).ToString());
                //shoppingCart.UnitPrice = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("UnitPrice")).ToString());
                //shoppingCart.Discount = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Discount")).ToString());
                //shoppingCart.size = reader.GetValue(reader.GetOrdinal("size")).ToString();
                
            }


            reader.Close();
            return shoppingCart;
        }

        public IEnumerable<Shopping_Cart> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=140.126.146.49,7988;Database=2018Build;User Id=Build;Password = 123456789;"
            );
            var sql = "SELECT * FROM Shopping_Cart";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var shoppingCarts = new List<Shopping_Cart>();
            while (reader.Read())
            {
                //var shoppingCart = new Shopping_Cart();
                //shoppingCart.Shopping_Cart_ID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Shopping_Cart_ID")).ToString());
                //shoppingCart.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                //shoppingCart.Product_ID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Product_ID")));
                //shoppingCart.Quantity = Convert.ToInt16(reader.GetValue(reader.GetOrdinal("Quantity")).ToString());
                //shoppingCart.UnitPrice = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("UnitPrice")).ToString());
                //shoppingCart.Discount = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Discount")).ToString());
                //shoppingCart.size = reader.GetValue(reader.GetOrdinal("size")).ToString();

                var properties = typeof(Shopping_Cart).GetProperties();
                Shopping_Cart shoppingCart = null;
                shoppingCart = new Shopping_Cart();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var fieldName = reader.GetName(i);
                    var property = properties.FirstOrDefault(
                        p => p.Name == fieldName);

                    if (property == null)
                        continue;

                    if (!reader.IsDBNull(i))
                        property.SetValue(shoppingCart,
                            reader.GetValue(i));
                }
                
                shoppingCarts.Add(shoppingCart);
            }
            reader.Close();
            return shoppingCarts;
        }
    }
}
