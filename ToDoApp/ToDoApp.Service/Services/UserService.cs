using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;
using ToDoApp.Core.Services;
using ToDoApp.Core.UnitOfWorks;

namespace ToDoApp.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
       
        public UserService(IUnitOfWork unitOfWork, IRepository<User> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<User> Login(string userName, string password)
        {
            return await _unitOfWork.Users.Login(userName, password);
        }
    }
}
