using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Models;

namespace ToDoApp.Core.Repositories
{
    public interface IHomeRepository:IRepository<Home>
    {
        Task<Home> GetWithUserById(int id); 
    }
}
