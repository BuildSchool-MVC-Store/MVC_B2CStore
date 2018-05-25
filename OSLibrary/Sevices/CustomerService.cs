using OSLibrary.ADO.NET.Repositories;
using OSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.Sevices
{
    public class CustomerService
    {
        public bool SearchAccount(string account)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            if(customerRepository.GetByAccount(account) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
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
        public bool CreateAccount(string Account,string Email , string Password)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            if(customerRepository.GetByAccount(Account) == null)
            {
                try
                {
                    Customers customers = new Customers()
                    {
                        Account = Account,
                        Password = Password,
                        Email = Email,
                    };
                    customerRepository.Create(customers);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
