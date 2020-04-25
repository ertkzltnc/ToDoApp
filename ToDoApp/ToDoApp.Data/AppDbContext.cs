using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Core.Models;
using ToDoApp.Data.Configurations;

namespace ToDoApp.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
                
        }
        public DbSet<Home> Housing { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Shopping> Shoppings{ get; set; }
        public DbSet<Invoice> Invoices{ get; set; }
        public DbSet<Expense> Expenses{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new HomeConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());

        }

    }
}
