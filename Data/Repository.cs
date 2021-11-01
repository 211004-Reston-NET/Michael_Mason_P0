using System.Collections.Generic;

namespace Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly StoreManagerContext _context;
        public Repository(StoreManagerContext context)
        {
            _context = context;
        }
        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetByPrimaryKey(int query)
        {
            return _context.Set<TEntity>().Find(query);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}