using System;
using System.Collections.Generic;

#nullable disable

namespace DL
{
    public partial class LineItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProdId { get; set; }
        public int Quantity { get; set; }

        public virtual SOrder Order { get; set; }
        public virtual Product Prod { get; set; }
    }
}
