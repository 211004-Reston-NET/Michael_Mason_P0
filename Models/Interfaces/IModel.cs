using System;
namespace Models
{
    public interface IModel<TEntity> where TEntity : class
    {
        string ToString();
    }
}