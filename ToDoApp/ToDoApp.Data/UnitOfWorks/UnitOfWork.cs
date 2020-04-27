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
        private HomeRepository _homeRepository;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);
        public IHomeRepository Housing=> _homeRepository = _homeRepository ?? new HomeRepository(_context);
       

        public void Commit()
        {
            _context.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return  new Repository<TEntity>(_context);
            
        }
    }
}
