using System;
using System.Collections.Generic;

#nullable disable

namespace DL
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            LineItems = new HashSet<LineItem>();
            ProdCats = new HashSet<ProdCat>();
        }

        public int Id { get; set; }
        public int? ProdNumber { get; private set; }
        public string ProdName { get; private set; }
        public decimal ProdPrice { get; private set; }
        public string? ProdDescription { get; private set; }

        public virtual ICollection<Inventory> Inventories { get; private set; }
        public virtual ICollection<LineItem> LineItems { get; private set; }
        public virtual ICollection<ProdCat> ProdCats { get; private set; }
    }
}
