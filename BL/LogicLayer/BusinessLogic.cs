using System;
using System.Collections.Generic;
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
    }
}