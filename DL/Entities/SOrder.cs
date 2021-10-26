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

        public int Id { get; set; }
        public int StoreId { get; set; }
        public int CustId { get; set; }
        public int OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual Storefront Store { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
