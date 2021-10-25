using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class BusinessLogic<TEntity> : IBusinessLogic<TEntity> where TEntity : class
    {
        private Repository<TEntity> _context;
        public BusinessLogic(Repository<TEntity> context)
        {
            _context = context;
        }

        public int GetHighestKey()
        {
            return _context.GetHighestKey();
        }

        public virtual void Create(TEntity entity)
        {
            _context.Create(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Delete(entity);
        }

        public IEnumerable<TEntity> Find(string query)
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

        public virtual TEntity ModelMap(TEntity entity, TEntity model)
        {
            return model;
        }
    }
}