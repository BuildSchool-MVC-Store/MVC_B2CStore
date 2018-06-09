using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;
using OSLibrary.ViewModels;
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
            SqlConnection connection = new SqlConnection(SqlConnect.str);
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                orders_R.Create(connection, new Orders
                {
                    Account = Account,
                    Order_Check = "NEW",
                    Order_Date = now_time,
                    Pay = Pay,
                    TranMoney = TranMoney,
                    Transport = Transport
                }, transaction);

                string errorMessage = "";
                var order = orders_R.GetLatestByAccount(connection, Account, transaction);
                var items = cart_R.GetByAccount(connection, Account, transaction);
                decimal totalmoney = 0;
                foreach (var item in items)
                {
                    if (stock_R.CheckInventory(item.Product_ID, item.size, item.Color, item.Quantity) == false)
                    {
                        errorMessage += "產品 :" + products_R.GetByProduct_ID(item.Product_ID).Product_Name + " 庫存不足\n";
                    }
                    else
                    {
                        totalmoney += item.Quantity * products_R.GetByProduct_ID(item.Product_ID).UnitPrice;
                        order_Details_R.Create(connection, new Order_Details()
                        {
                            Order_ID = order.Order_ID,
                            Product_ID = item.Product_ID,
                            Quantity = (short)item.Quantity,
                            size = item.size,
                            Price = item.Quantity * products_R.GetByProduct_ID(item.Product_ID).UnitPrice,
                            Color = item.Color
                        }, transaction);
                        stock_R.Update(connection, new Stock()
                        {
                            Product_ID = item.Product_ID,
                            Size = item.size,
                            Quantity = stock_R.GetByPK(item.Product_ID, item.size, item.Color).Quantity - item.Quantity,
                            Color = item.Color
                        }, transaction);
                    }
                }
                if (errorMessage.Length <= 1)
                {
                    cart_R.DeleteByAccount(Account);
                    orders_R.Update(order.Order_ID, totalmoney, connection, transaction);
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



        public IEnumerable<Orders> BackStageGetAllOrders()
        {
            OrdersRepository Orders_R = new OrdersRepository();
            return Orders_R.GetAll();
           
        }

        public IEnumerable<Orders> BackStageGetAccountOrders(string Account)
        {
            //OrdersRepository Orders_R = new OrdersRepository();

            //return Orders_R.GetByAccount(Account);
            return new OrdersRepository().GetByAccount(Account);
        }


        public Orders BackStageGetOrderByOrder_ID(int Order_ID)
        {
            OrdersRepository Orders_R = new OrdersRepository();
            return Orders_R.GetByOrder_ID(Order_ID);
        }

        public IEnumerable<Orders> BackStageGetOrder_CheckIs0()
        {
            return new OrdersRepository().GetOrderByOrder_CheckIs0();
        }
        public IEnumerable<Orders> BackStageGetOrder_CheckIs1()
        {
            return new OrdersRepository().GetOrderByOrder_CheckIs1();
        }
        public IEnumerable<Orders> BackStageGetOrder_CheckIs2()
        {
            return new OrdersRepository().GetOrderByOrder_CheckIs2();
        }
        public IEnumerable<Orders> BackStageGetOrder_CheckIs3()
        {
            return new OrdersRepository().GetOrderByOrder_CheckIs3();
        }
        public IEnumerable<Orders> BackStageGetOrder_CheckIs4()
        {
            return new OrdersRepository().GetOrderByOrder_CheckIs4();
        }
        public IEnumerable<Orders> BackStageGetOrder_CheckIs5()
        {
            return new OrdersRepository().GetOrderByOrder_CheckIs5();
        }

    }
}
