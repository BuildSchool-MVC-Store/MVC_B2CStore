using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ViewModels
{
    public class StockDetail
    {
        [Required]
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Size { get; set; }
        public int Quantity { get; set; }
    }
}
