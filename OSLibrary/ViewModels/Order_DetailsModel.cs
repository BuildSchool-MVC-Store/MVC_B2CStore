using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ViewModels
{
    public class Order_DetailsModel
    {
        public int Order_Details_ID { get; set; }
        public int Order_ID { get; set; }
        public int Product_ID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public float? Discount { get; set; }
        public string size { get; set; }
        public string Color { get; set; }
    }
}
