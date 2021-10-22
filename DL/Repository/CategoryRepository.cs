using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreManagerContext context) : base(context)
        {}
        
        public StoreManagerContext StoreManagerContext
        {
            get { return _context as StoreManagerContext; }
        }
    }
}