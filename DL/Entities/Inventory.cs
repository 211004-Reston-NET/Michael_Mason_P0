using System;
using System.Collections.Generic;

#nullable disable

namespace DL
{
    public partial class Inventory
    {
        public int Id { get; private set; }
        public int StoreId { get; private set; }
        public int ProdId { get; private set; }
        public int Quantity { get; private set; }

        public virtual Product Prod { get; private set; }
        public virtual Storefront Store { get; private set; }
    }
}
