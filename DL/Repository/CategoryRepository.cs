using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreManagerContext context) : base(context)
        {
        }
        
        public StoreManagerContext StoreManagerContext
        {
            get { return _context as StoreManagerContext; }
        }

        public override IEnumerable<Category> Find(string query)
        {
            IEnumerable<Category> dbQuery = (from c in StoreManagerContext.Categories
                            where c.CatName.Contains(query)
                            select c);
            return dbQuery;
        }
    }
}