using OptimusZQ.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OptimusZQ.DAL.Abstract
{
    public interface IRepository<TEntity> where TEntity: Entity
    {
        TEntity Add(TEntity entity);
        TEntity Find(int id);
        TEntity Find(Expression<Func<TEntity>> condition);
        void Update(int id, TEntity entity);
        IEnumerable<TEntity> AddRange(IReadOnlyCollection<TEntity> entities);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity>> condition);
        void Delete(TEntity entity);
        void DeleteRange(IReadOnlyCollection<TEntity> entities);
    }
}

