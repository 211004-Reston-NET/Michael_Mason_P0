using System;
using System.Collections.Generic;

#nullable disable

namespace DL
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int ProdId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Prod { get; set; }
        public virtual Storefront Store { get; set; }
    }
}
