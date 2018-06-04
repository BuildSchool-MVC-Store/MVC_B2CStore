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
        [DisplayName("商品編號")]
        public int ProductID { get; set; }

        [DisplayName("商品名稱")]
        [Required(ErrorMessage = "請輸入名稱")]
        public string Name { get; set; }

        [DisplayName("價格")]
        [Required(ErrorMessage = "請輸入金額")]
        public decimal Price { get; set; }

        [DisplayName("種類")]
        public string CategoryName { get; set; }

        [DisplayName("性別")]
        public string Gender { get; set; }

        [DisplayName("顯示")]
        public string Online { get; set; }

        [DisplayName("備註")]
        public string Comments { get; set; }

        public string ImageUrl { get; set; }
    }
}