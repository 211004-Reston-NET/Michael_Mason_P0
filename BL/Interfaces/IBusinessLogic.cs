using System;
using System.Collections.Generic;
using Models;

namespace BL
{
    public interface IBusinessLogic<TEntity> where TEntity : class
    {
        int GetHighestKey();
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(string query);
        void Create(TEntity entity);
        void Delete(TEntity entity);
        TEntity ModelMap(TEntity entity, TEntity model);
    }
}