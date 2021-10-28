using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace BL
{
    public interface IBusinessLogic<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Find(string query);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
    }
}