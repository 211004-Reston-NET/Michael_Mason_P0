using System;
using System.Collections.Generic;
using System.Linq;
using DL;
using Models;

namespace BL
{
    public class BusinessLogic<TEntity> : IBusinessLogic<TEntity> where TEntity : class
    {
        public readonly Repository<TEntity> _context;
        public BusinessLogic(Repository<TEntity> context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Find(string query)
        {
            return _context.Find(query);
        }

        public TEntity Get(int id)
        {
            return _context.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.GetAll();
        }

        public void Create(TEntity entity)
        {
            _context.Create(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Delete(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}