using System;
using System.Collections.Generic;

#nullable disable

namespace DL
{
    public partial class Storefront
    {
        public Storefront()
        {
            Inventories = new HashSet<Inventory>();
            SOrders = new HashSet<SOrder>();
        }

        public int Id { get; private set; }
        public string StoreName { get; private set; }
        public string StoreAddress { get; private set; }
        public int StorePhone { get; private set; }

        public virtual ICollection<Inventory> Inventories { get; private set; }
        public virtual ICollection<SOrder> SOrders { get; private set; }
    }
}
