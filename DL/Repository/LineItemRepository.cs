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

        //public override IEnumerable<LineItem> Find(string query)
        //{
        //    IEnumerable<LineItem> dbQuery = (from l in StoreManagerContext.LineItems
        //                    where l.Order.Contains(query)
        //                    select c);
        //    return dbQuery;
        //}
    }
}