using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Containers;
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
        public Person_OrderDetail GetByOrderDetail_ID(int OrderDetail_ID)
        {
            return RepositoryContainer.GetInstance<Order_DetailsRepository>().GetByOrderDetail_IDOfView(OrderDetail_ID);
        }

        public bool UpdateOrderDetail(Person_OrderDetail person_OrderDetail)
        {
            try
            {
                var products = RepositoryContainer.GetInstance<ProductsRepository>().GetByProduct_ID(person_OrderDetail.Product_ID);
                var od = RepositoryContainer.GetInstance<Order_DetailsRepository>();
                od.Update(new Models.Order_Details {
                    Order_Details_ID = person_OrderDetail.Order_Details_ID,
                    Color = person_OrderDetail.Color,
                    Product_ID = person_OrderDetail.Product_ID,
                    Price = products.UnitPrice * person_OrderDetail.Quantity,
                    Quantity = person_OrderDetail.Quantity,
                    size = person_OrderDetail.size,
                });
                var order_ID = od.GetByOrder_Details_ID(person_OrderDetail.Order_Details_ID).Order_ID;
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
