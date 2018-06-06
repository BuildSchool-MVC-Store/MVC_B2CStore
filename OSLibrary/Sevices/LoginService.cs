using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.Sevices
{
    public class LoginService
    {
        public string LoginCheck(string account, string password)
        {
            var Employee = new EmployeesRepository();
            var check = Employee.GetByEmployeesAccount(account);
            //判斷有無此會員
            if(check != null)
            {
                //驗證信if(String.IsNullOrWhiteSpace(check.AuthCode))
                //帳密確認
                if(PasswordCheck(check, password))
                {
                    return "";
                }
                else
                {
                    return "密碼錯誤";
                }
            }
            else
            {
                return "查無此帳號，請去申請";
            }
        }

        public bool PasswordCheck(Employees checkemployee, string password)
        {
            bool result = checkemployee.Password.Equals(password);//hashpassword(password)??
            return result;
        }
    }
}
