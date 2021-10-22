using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }
        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
    }
}