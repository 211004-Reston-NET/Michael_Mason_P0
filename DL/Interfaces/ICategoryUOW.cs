using System;
using System.Collections.Generic;

namespace DL
{
    public interface ICategoryUOW : IUnitOfWork<Category>
    {
        ICategoryRepository categories { get; }
    }
}