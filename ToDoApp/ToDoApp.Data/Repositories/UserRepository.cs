using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public  Boolean Login(User user)
        {
             User userLogin =_appDbContext.Users.FirstOrDefault(x => x.UserName == user.UserName);
            if (userLogin!=null && userLogin.Password==user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
