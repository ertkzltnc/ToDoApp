using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Core.UnitOfWorks
{
    public interface IUnitOfWork 
    {
        IUserRepository Users { get; }

        IRepository<TEntity> GetRepository<TEntity>() where TEntity:class;
        Task CommitAsync();
        void Commit();
    }
}
