using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Repositories;
using ToDoApp.Core.Services;
using ToDoApp.Core.UnitOfWorks;
using ToDoApp.Data.UnitOfWorks;

namespace ToDoApp.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        public readonly IUnitOfWork _unitOfWork;
        //private readonly IRepository<Tentity> _repository;
        public Service(IUnitOfWork unitOfWork,IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            //_repository = repository;
        }
            
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            
            await _unitOfWork.GetRepository<TEntity>().AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;

        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _unitOfWork.GetRepository<TEntity>().AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
               
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<TEntity>().GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _unitOfWork.GetRepository<TEntity>().Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _unitOfWork.GetRepository<TEntity>().RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.GetRepository<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity updateEntity = _unitOfWork.GetRepository<TEntity>().Update(entity);
            return updateEntity;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.GetRepository<TEntity>().Where(predicate);
        }
    }
}
