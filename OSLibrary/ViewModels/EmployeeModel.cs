using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ViewModels
{
    public class EmployeeModel
    {
        [DisplayName("帳號")]
        [Required(ErrorMessage = "請輸入帳號")]
        public string Account { get; set; }
        
        [DisplayName("密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        [StringLength(10)]
        public string Password { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "請輸入名稱")]
        [StringLength(10)]
        public string Name { get; set; }

        [DisplayName("生日")]
        [Required(ErrorMessage = "請輸入生日(格式:yyyy/mm/dd)")]
        public DateTime Birthday { get; set; }

        [DisplayName("手機")]
        [Required(ErrorMessage = "請輸入電話號碼")]
        public string Phone { get; set; }

        [DisplayName("信箱")]
        [Required(ErrorMessage = "請輸入信箱")]
        public string Email { get; set; }

        [DisplayName("地址")]
        [Required(ErrorMessage = "請輸入地址")]
        public string Address { get; set; }
    }
}
