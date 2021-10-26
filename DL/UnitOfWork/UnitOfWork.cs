using System;

namespace DL
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class
    {
        public readonly Repository<TEntity> repository;
        public UnitOfWork(Repository<TEntity> context)
        {
            repository = context;
        }

        public int Complete()
        {
            return repository._context.SaveChanges();
        }

        public void Dispose()
        {
            repository._context.Dispose();
        }
    }
}