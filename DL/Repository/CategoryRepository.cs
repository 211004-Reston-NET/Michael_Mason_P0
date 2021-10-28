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

        public override IQueryable<Category> Find(string query)
        {
            IQueryable<Category> dbQuery = (from c in StoreManagerContext.Categories
                            where c.CatName.Contains(query)
                            select c);
            return dbQuery;
        }

        public override IQueryable<Category> Find(int query)
        {
            throw new System.NotImplementedException();
        }
    }
}