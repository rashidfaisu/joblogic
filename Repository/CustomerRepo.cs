using JobLogic.Context;
using JobLogic.Models;
using JobLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobLogic.Repository
{
    public class CustomerRepo:ICustomerService
    {
        private readonly CustomerDbContext context;

        public CustomerRepo(CustomerDbContext context)
        {
            this.context = context;
        }
        public List<Customers> GetCustomers(int id=0)
        {
            var data = new List<Customers>();
            try
            {
                data = context.Customers.Where(a => a.CustomerId == id || id == 0).ToList();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            return data;
        }

        public bool AddCustomer(Customers Customer)
        {
            try
            {
                if (Customer.CustomerId > 0)
                {
                    context.Update(Customer);
                }
                else

                {
                    context.Add(Customer);
                }
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DeleteCustomer(Customers Customer)
        {
            try
            {
                context.Database.BeginTransaction();
                if (Customer.CustomerId > 0)
                {
                    context.Remove(Customer);
                    context.SaveChanges();
                }
                context.Database.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
