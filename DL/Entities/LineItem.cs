using System;
using System.Collections.Generic;

#nullable disable

namespace DL
{
    public partial class LineItem
    {
        public int Id { get; private set; }
        public int OrderId { get; private set; }
        public int ProdId { get; private set; }
        public int Quantity { get; private set; }

        public virtual SOrder Order { get; private set; }
        public virtual Product Prod { get; private set; }
    }
}
