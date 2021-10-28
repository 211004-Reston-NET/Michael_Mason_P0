using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class LineItemRepository : Repository<LineItem>, ILineItemRepository
    {
        public LineItemRepository(StoreManagerContext context) : base(context)
        {
        }
        
        public StoreManagerContext StoreManagerContext
        {
            get { return _context as StoreManagerContext; }
        }

        public override IQueryable<LineItem> Find(string query)
        {
            throw new System.NotImplementedException();
        }

        public override IQueryable<LineItem> Find(int query)
        {
            throw new System.NotImplementedException();
        }
    }
}