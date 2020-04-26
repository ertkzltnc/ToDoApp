using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public UserRepository(DbContext context) : base(context)
        {
        }

        public async Task<User> Login(string userName, string password)
        {
            return await appDbContext.Users.SingleOrDefaultAsync
                (x => x.UserName == userName && x.Password == password);
        }
    }
}
