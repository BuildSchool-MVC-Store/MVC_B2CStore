﻿using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.Sevices
{
    public class Order_DetailsService
    {
        public IEnumerable<Order_Details> BackStageGetByOrderID(int OrderID)
        {
            return new Order_DetailsRepository().GetByOrderID(OrderID);
        }

        public IEnumerable<Order_Details> BackStageGetAllOrderDetails()
        {
            Order_DetailsRepository detailsRepository = new Order_DetailsRepository();
            var details = new List<Order_Details>();
            foreach(var item in detailsRepository.GetAll())
            {
                var detail = new Order_Details
                {
                    Order_Details_ID = item.Order_Details_ID,
                    Order_ID = item.Order_ID,
                    Product_ID = item.Product_ID,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    size = item.size,
                    Color = item.Color
                };
                details.Add(detail);
            }
            return details;
        }
    }
}
