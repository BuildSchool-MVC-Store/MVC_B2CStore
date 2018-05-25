using OSLibrary.ADO.NET.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.Sevices
{
    public class CustomerService
    {
        public bool CheckAccount(string Account, string Password)
        {
            CustomerRepository repository = new CustomerRepository();
            try
            {
                if (repository.GetByAccount(Account).Password == Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string GetName(string Account)
        {
            CustomerRepository repository = new CustomerRepository();
            return repository.GetByAccount(Account).Name;
        }
    }
}
