using OSLibrary.ADO.NET.Repositories;
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
        public IEnumerable<Order_Details> BackStageGetByOrderID(int OrderID)
        {
            return new Order_DetailsRepository().GetByOrderID(OrderID);
        }

        public IEnumerable<OrderDetailsModel> BackStageGetAllOrderDetails()
        {
            Order_DetailsRepository detailsRepository = new Order_DetailsRepository();
            var productsrepository = new ProductsRepository();
            var details = new List<OrderDetailsModel>();
            
            foreach (var item in detailsRepository.GetAll())
            {
                var detail = new OrderDetailsModel
                {
                    Order_Details_ID = item.Order_Details_ID,
                    Order_ID = item.Order_ID,
                    Product_ID = item.Product_ID,
                    ProductName = productsrepository.GetByProduct_ID(item.Product_ID).Product_Name,
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
