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
        [Required]
        public string Account { get; set; }
        
        [DisplayName("密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }

        [DisplayName("姓名")]
        [Required]
        public string Name { get; set; }

        [DisplayName("生日")]
        [Required]
        public DateTime Birthday { get; set; }

        [DisplayName("手機")]
        [Required]
        public string Phone { get; set; }

        [DisplayName("信箱")]
        [Required]
        public string Email { get; set; }

        [DisplayName("地址")]
        [Required]
        public string Address { get; set; }
    }
}
