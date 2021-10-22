using System;
using System.Collections.Generic;

#nullable disable

namespace DL
{
    public partial class ProdCat
    {
        public int Id { get; private set; }
        public int ProdId { get; private set; }
        public int CatId { get; private set; }

        public virtual Category Cat { get; private set; }
        public virtual Product Prod { get; private set; }
    }
}
