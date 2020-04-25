using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Core.Models;

namespace ToDoApp.Data.Seeds
{
    public class HomeSeed : IEntityTypeConfiguration<Home>
    {
        private readonly int[] _ids;
        public HomeSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Home> builder)
        {
            builder.HasData(
                new Home { Id = _ids[0], Name = "ev1", IsDeleted = true }
                );        
        }
    }
}
