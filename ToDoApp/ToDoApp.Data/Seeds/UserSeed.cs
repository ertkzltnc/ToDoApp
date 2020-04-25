using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Core.Models;

namespace ToDoApp.Data.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        private readonly int[] _ids;
        public UserSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, Name = "ert", LastName = "kzl", UserName = "ertkzl", Password = "1", IsDeleted = true, HomeId = _ids[0] },
                new User { Id = 2, Name = "erol", LastName = "ayhan", UserName = "eayhan", Password = "2", IsDeleted = true, HomeId = _ids[0] }
                );
        }
    }
}
