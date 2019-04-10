using Microsoft.EntityFrameworkCore;
using OptimusZQ.DAL.Abstract;
using OptimusZQ.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OptimusZQ.DAL.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected DbContext DbContext;

        public BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public TEntity Add(TEntity entity)
        {
            return DbContext.Add(entity).Entity;
        }

        public IEnumerable<TEntity> Add(IReadOnlyCollection<TEntity> entities)
        {
            return DbContext.Add(entities).Entity;
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return DbContext.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbContext.Attach(entity);
            }

            DbContext.Remove(entity);
        }

        public void Delete(IReadOnlyCollection<TEntity> entities)
        {
            if (DbContext.Entry(entities).State == EntityState.Detached)
            {
                DbContext.Attach(entities);
            }

            DbContext.Remove(entities);
        }

        public TEntity Find(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(Expression<Func<TEntity>> condition)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> AddRange(IReadOnlyCollection<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity>> condition)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IReadOnlyCollection<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
