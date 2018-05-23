using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.Sevices
{
    public class OrdersService
    {
        public IEnumerable<Orders> GetOrderByAccount(string Account)
        {
            return new OrdersRepository().GetByAccount(Account);
        }

        public string CreateOrder(string Account, string Pay, string Transport, decimal TranMoney)
        {
            ShoppingCartRepository cart_R = new ShoppingCartRepository();
            OrdersRepository orders_R = new OrdersRepository();
            Order_DetailsRepository order_Details_R = new Order_DetailsRepository();
            StockRepository stock_R = new StockRepository();
            ProductsRepository products_R = new ProductsRepository();

            var now_time = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(SqlConnect.str))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        orders_R.Create(connection , new Orders
                        {
                            Account = Account,
                            Order_Check = "NEW",
                            Order_Date = now_time,
                            Pay = Pay,
                            TranMoney = TranMoney,
                            Transport = Transport
                        },transaction);

                        string errorMessage = "";
                        var order = orders_R.GetLatestByAccount(Account);
                        var items = cart_R.GetByAccount(Account);

                        foreach (var item in items)
                        {
                            if (stock_R.CheckInventory(item.Product_ID, item.size, item.Quantity) == false)
                            {
                                errorMessage += "產品 :" + "數量" + " 庫存不足\n";
                            }
                            else
                            {
                                order_Details_R.Create(new Order_Details()
                                {
                                    Order_ID = order.Order_ID,
                                    Product_ID = item.Product_ID,
                                    Quantity = (short)item.Quantity,
                                    size = item.size,
                                    Price = item.Quantity * products_R.GetByProduct_ID(item.Product_ID).UnitPrice,
                                    Discount = 1
                                });
                                stock_R.Update(new Stock()
                                {
                                    Product_ID = item.Product_ID,
                                    Product_Size = item.size,
                                    Quantity = stock_R.GetByProduct_IDandProduct_Size(item.Product_ID, item.size).Quantity - item.Quantity
                                });
                            }
                        }
                        if (errorMessage.Length <= 1)
                        {
                            cart_R.DeleteByAccount(Account);
                            transaction.Commit();
                            return "完成訂單";
                        }
                        else
                        {
                            throw new Exception(errorMessage);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        //出现异常，事务Rollback
                        transaction.Rollback();
                        return ex.Message;
                    }
                }
            }
        }
    }
}
