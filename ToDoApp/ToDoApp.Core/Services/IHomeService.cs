using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Models;

namespace ToDoApp.Core.Services
{
    public interface IHomeService:IService<Home>
    {
        Task<Home> GetWithUserById(int id);
    }
}
