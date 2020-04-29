using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Models;

namespace ToDoApp.Core.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        //SingleOrDefaultAsync ile işlem yapabiliriz.sadece örnek olması için yazılmıştır.
        Boolean Login(User user);
    }
}
