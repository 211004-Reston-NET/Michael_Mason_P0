using System;

namespace DL
{
    public interface IUnitOfWork<TEntity> : IDisposable where TEntity : class
    {
        int Complete();
    }
}