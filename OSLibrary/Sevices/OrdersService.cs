using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.Sevices
{
    public class OrdersService
    {
        public string CreateOrder(string Account,string Pay,string Transport,decimal TranMoney)
        {
            ShoppingCartRepository cart_R = new ShoppingCartRepository();
            OrdersRepository orders_R = new OrdersRepository();
            Order_DetailsRepository order_Details_R = new Order_DetailsRepository();
            StockRepository stock_R = new StockRepository();

            var now_time = DateTime.Now;
            orders_R.Create(new Orders
            {
                Account = Account,
                Order_Check ="NEW",
                Order_Date = now_time,
                Pay = Pay,
                TranMoney = TranMoney,
                Transport = Transport
                
            });
            string errorMessage = "";
            var order = orders_R.GetLatestByAccount(Account);
            var items = cart_R.GetByAccount(Account);
            foreach (var item in items)
            {
                if(stock_R.CheckInventory(item.Product_ID, item.size, item.Quantity)==false)
                {
                    errorMessage += "產品 :" + item.Products.Product_Name + " 庫存不足\n";
                    return errorMessage;
                }
                order_Details_R.Create(new Order_Details()
                {
                    Order_ID = order.Order_ID,
                    Product_ID = item.Product_ID,
                    Quantity = (short)item.Quantity,
                    size = item.size
                });
            }
            return "完成訂單";
            //if (errorMessage.Length <=1)
            //{
            //    return "完成訂單";
            //}
            //else
            //{
            //    return errorMessage;
            //}
        }
    }
}
