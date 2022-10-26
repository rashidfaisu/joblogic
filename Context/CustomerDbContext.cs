using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace JobLogic.Context
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext()
        {
        }

        public CustomerDbContext(DbContextOptions options) : base(options) 
        {
        }
        public DbSet<Customers> Customers { get; set; }
    }
}
