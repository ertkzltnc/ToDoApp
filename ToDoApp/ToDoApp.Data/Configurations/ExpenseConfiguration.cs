using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Core.Models;

namespace ToDoApp.Data.Configurations
{
    public class ExpenseConfiguration:IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.ShoppingId).IsRequired();
            builder.Property(x => x.Amount).IsRequired().HasColumnType("decimal(13,3)");
            builder.ToTable("Expenses");

        }
    }
}
