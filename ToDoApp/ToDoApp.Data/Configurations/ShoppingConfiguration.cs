using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Core.Models;

namespace ToDoApp.Data.Configurations
{
    public class ShoppingConfiguration : IEntityTypeConfiguration<Shopping>
    {
        public void Configure(EntityTypeBuilder<Shopping> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.HomeId).IsRequired();
            builder.ToTable("Shoppings");
        }
    }
}
