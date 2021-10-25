using System;
using System.Collections.Generic;

namespace DL
{
    public interface ICategoryUnitOfWork : IDisposable
    {
        ICategoryRepository categories { get; }

        int Complete();
    }
}