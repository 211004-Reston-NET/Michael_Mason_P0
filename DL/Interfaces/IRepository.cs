using System.Collections.Generic;

namespace DL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(string query);

        //lambda expression
        //IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);

        void Create(TEntity entity);
        //void AddRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        //void RemoveRange(IEnumerable<TEntity> entities);

        int GetHighestKey();
    }
}