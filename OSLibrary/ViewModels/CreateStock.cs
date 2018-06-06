using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ViewModels
{
    public class CreateStock
    {
        [Required]
        [Display(Name ="尺寸")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "請輸入 1 到 4 個字")]
        public string Size { get; set; }
        [Required]
        public int Product_ID { get; set; }
        [Required]
        [Display(Name = "顏色")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "請輸入 1 到 4 個字")]
        public string Color { get; set; }
        [Display(Name = "數量")]
        [Range(0, 1000)]
        public int Quantity { get; set; }
    }
    public class ProductMain
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
    }
}
