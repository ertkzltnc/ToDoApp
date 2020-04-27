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
    public class HomeService : Service<Home>, IHomeService
    {
        public HomeService(IUnitOfWork unitOfWork, IRepository<Home> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Home> GetWithUserById(int id)
        {
            return await _unitOfWork.Housing.GetWithUserById(id);
        }
    }
}
