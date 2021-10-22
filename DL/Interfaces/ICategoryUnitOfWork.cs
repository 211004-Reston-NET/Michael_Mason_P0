using System;

namespace DL
{
    public interface ICategoryUnitOfWork : IDisposable
    {
        ICategoryRepository categories { get; }
        int Complete();
    }
}