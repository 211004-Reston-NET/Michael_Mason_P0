using Data;
using Business;
namespace Models
{
    public interface IBaseM<TEntity> where TEntity : class
    {
        
    }
    public class BaseM<TEntity> where TEntity : class
    {
        IRepository<TEntity> smContext;
        public BaseM(IRepository<TEntity> context)
        {
            smContext = context;
        }
    }
}