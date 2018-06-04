using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ViewModels
{
    public class StockModel
    {
        [DisplayName("商品編號")]
        public int Product_ID { get; set; }

        [DisplayName("商品名稱")]
        public string ProductName { get; set; }

        [DisplayName("尺寸")]
        public string Size { get; set; }

        [DisplayName("顏色")]
        public string Color { get; set; }

        [DisplayName("數量")]
        [Required(ErrorMessage = "請輸入數量")]
        public int? Quantity { get; set; }
    }
}
