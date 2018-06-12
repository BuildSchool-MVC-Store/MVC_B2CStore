﻿using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Containers;
using OSLibrary.Models;
using OSLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.Sevices
{
    public class Order_DetailsService
    {
        static Order_DetailsRepository Order_DetailsRepository = RepositoryContainer.GetInstance<Order_DetailsRepository>();
        public Person_OrderDetail GetByOrderDetail_ID(int OrderDetail_ID)
        {
            return Order_DetailsRepository.GetByOrderDetail_IDOfView(OrderDetail_ID);
        }

        public bool UpdateOrderDetail(Person_OrderDetail person_OrderDetail)
        {
            try
            {
                var products = RepositoryContainer.GetInstance<ProductsRepository>().GetByProduct_ID(person_OrderDetail.Product_ID);
                Order_DetailsRepository.Update(new Models.Order_Details {
                    Order_Details_ID = person_OrderDetail.Order_Details_ID,
                    Color = person_OrderDetail.Color,
                    Product_ID = person_OrderDetail.Product_ID,
                    Price = products.UnitPrice * person_OrderDetail.Quantity,
                    Quantity = person_OrderDetail.Quantity,
                    size = person_OrderDetail.size,
                });
                var order_ID = Order_DetailsRepository.GetByOrder_Details_ID(person_OrderDetail.Order_Details_ID).Order_ID;
                var o = RepositoryContainer.GetInstance<OrdersRepository>();
                o.UpdateTotalMoney(order_ID);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOrderDetail(int order_Detail_ID)
        {
            try
            {
                Order_DetailsRepository.Delete(order_Detail_ID);
                var order_ID = Order_DetailsRepository.GetByOrder_Details_ID(order_Detail_ID).Order_ID;
                var o = RepositoryContainer.GetInstance<OrdersRepository>();
                o.UpdateTotalMoney(order_ID);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CreateOrderDetail(Order_Details order_Details)
        {
            try
            {
                Order_DetailsRepository.Create(order_Details);
                var order_ID = Order_DetailsRepository.GetByOrder_Details_ID(order_Detail_ID).Order_ID;
                var o = RepositoryContainer.GetInstance<OrdersRepository>();
                o.UpdateTotalMoney(order_ID);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
