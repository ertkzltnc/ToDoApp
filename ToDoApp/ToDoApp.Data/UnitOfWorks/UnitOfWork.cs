using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Repositories;
using ToDoApp.Core.UnitOfWorks;
using ToDoApp.Data.Repositories;

namespace ToDoApp.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private UserRepository _userRepository; 
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);
       
        public void Commit()
        {
            _context.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
