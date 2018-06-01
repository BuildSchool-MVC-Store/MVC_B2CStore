using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OSLibrary.ViewModels
{
    public class ProductModel
    {
        public int ProductID { get; set; }

        [DisplayName("商品名稱")]
        [Required(ErrorMessage = "請輸入名稱")]
        public string Name { get; set; }

        [DisplayName("價格")]
        [Required(ErrorMessage = "請輸入金額")]
        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public string Gender { get; set; }

        public string ImageUrl { get; set; }
    }
}