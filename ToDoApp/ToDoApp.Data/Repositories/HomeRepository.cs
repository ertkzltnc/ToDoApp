using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Data.Repositories
{
    public class HomeRepository : Repository<Home>, IHomeRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public HomeRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<Home> GetWithUserById(int id)
        {
            return await _appDbContext.Housing.SingleOrDefaultAsync(x => x.Id == id);

        }
    }
}
