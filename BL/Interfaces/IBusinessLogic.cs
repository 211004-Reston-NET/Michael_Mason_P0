using System;
using System.Collections.Generic;
using Models;

namespace BL
{
    public interface IBusinessLogic<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Find(string query);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
    }
}