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
    }
}
