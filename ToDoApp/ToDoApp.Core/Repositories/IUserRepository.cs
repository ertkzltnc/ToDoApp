using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Models;

namespace ToDoApp.Core.Repositories
{
    interface IUserRepository:IRepository<User>
    {
        Task<User> Login(string userName, string password);
    }
}
