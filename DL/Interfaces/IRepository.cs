using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> Find(string query);
        IQueryable<TEntity> Find(int id);

        //lambda expression
        //IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);

        void Create(TEntity entity);
        //void AddRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        //void RemoveRange(IEnumerable<TEntity> entities);
    }
}