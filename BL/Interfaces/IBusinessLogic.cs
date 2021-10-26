using System;
using System.Collections.Generic;
using Models;

namespace BL
{
    public interface IBusinessLogic<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(string query);
    }
}