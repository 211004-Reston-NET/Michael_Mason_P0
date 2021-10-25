using System.Collections.Generic;

namespace DL
{
    public interface ICategoryRepository : IRepository<Category>
    {
        int GetHighestCatNum();
    }
}