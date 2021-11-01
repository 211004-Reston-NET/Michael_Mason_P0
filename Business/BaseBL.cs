using System.Collections.Generic;
using System.IO;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Business
{
    public interface IBaseBL<TEntity> where TEntity : class
    {
        
        string Create(TEntity entity);
        string Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int query);
        string Save();
        string Update(TEntity entity);
    }

    public class BaseBL<TEntity> : IBaseBL<TEntity> where TEntity : class
    {
        IRepository<TEntity> smContext;
        public BaseBL(IRepository<TEntity> context)
        {
            smContext = context;
        }

        public TEntity GetById(int query)
        {
            return smContext.GetByPrimaryKey(query);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return smContext.GetAll();
        }

        public string Create(TEntity entity)
        {
            smContext.Create(entity);
            return "created";
        }
        public string Update(TEntity entity)
        {
            smContext.Update(entity);
            return "updated";
        }
        public string Delete(TEntity entity)
        {
            smContext.Delete(entity);
            return "deleted";
        }
        public string Save()
        {
            smContext.Save();
            return "saved";
        }
    }
}