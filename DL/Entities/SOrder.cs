using System;
using System.Collections.Generic;

#nullable disable

namespace DL
{
    public partial class SOrder
    {
        public SOrder()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int Id { get; private set; }
        public int StoreId { get; private set; }
        public int CustId { get; private set; }
        public int OrderNumber { get; private set; }
        public decimal TotalPrice { get; private set; }

        public virtual Customer Cust { get; private set; }
        public virtual Storefront Store { get; private set; }
        public virtual ICollection<LineItem> LineItems { get; private set; }
    }
}
