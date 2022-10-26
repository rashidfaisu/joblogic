using JobLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobLogic.Services
{
    public interface ICustomerService
    {
        public List<Customers> GetCustomers(int id=0);
        public bool AddCustomer(Customers Customer);
        public bool DeleteCustomer(int id = 0);
    }
}
