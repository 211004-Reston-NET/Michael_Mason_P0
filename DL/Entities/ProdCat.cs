using System;
using System.Collections.Generic;

#nullable disable

namespace DL
{
    public partial class ProdCat
    {
        public int Id { get; set; }
        public int ProdId { get; set; }
        public int CatId { get; set; }

        public virtual Category Cat { get; set; }
        public virtual Product Prod { get; set; }
    }
}
