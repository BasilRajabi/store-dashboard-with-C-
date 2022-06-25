using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSprojectP3
{
     public class Mycontext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<TransactionItem> transactionItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-D23DN9V;Database=Storedb;Trusted_Connection=True;");
        }


    }
}
