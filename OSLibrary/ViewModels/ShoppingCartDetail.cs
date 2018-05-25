using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ViewModels
{
    public class ShoppingCartDetail
    {
        public List<int> ShoppingCartID { get; set; }
        public List<string> Account { get; set; }
        public List<int> ProductID { get; set; }
        public List<int> Quantity { get; set; }
        public List<decimal> UnitPrice { get; set; }
        public List<decimal> RowPrice { get; set; }
        public decimal Total { get; set; }
        public List<string> Size { get; set; }
        public List<string> Color { get; set; }

    }
}
