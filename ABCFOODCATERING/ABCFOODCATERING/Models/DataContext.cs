using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ABCFOODCATERING.Models
{
    public class DataContext : DbContext
    {
        public DataContext(): base("conn") { }
        public DbSet<Order> ORDERTABLE { get; set; }
        public DbSet<CustomerLogin> CUSTOMERLOGINTABLE { get; set; }
    }
}