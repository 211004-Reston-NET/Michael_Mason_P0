using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace DL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        //lambda expression
        //IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);

        //void Add(TEntity entity);
        //void AddRange(IEnumerable<TEntity> entities);

        //void Remove(TEntity entity);
        //void RemoveRange(IEnumerable<TEntity> entities);
    }
}