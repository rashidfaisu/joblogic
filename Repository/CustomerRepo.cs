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
        public List<Customers> GetCustomers(int id=0)
        {
            var data = new List<Customers>();
            try
            {
                using (var dbContext = new CustomerDbContext())
                {
                    data = dbContext.Customers.Where(a => a.CustomerId == id || id == 0 ).ToList();
                }

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
                using (var dbContext = new CustomerDbContext())
                {

                    if (Customer.CustomerId > 0)
                    {
                        dbContext.Update(Customer);
                    }
                    else

                    {
                        dbContext.Add(Customer);
                    }
                    dbContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DeleteCustomer(int id = 0)
        {
            try
            {
                using (var dbContext = new CustomerDbContext())
                {
                    dbContext.Database.BeginTransaction();
                    if (id > 0)
                    {
                        var thisdata = dbContext.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
                        dbContext.Customers.Remove(thisdata);
                        dbContext.SaveChanges();
                    }
                    dbContext.Database.CommitTransaction();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
