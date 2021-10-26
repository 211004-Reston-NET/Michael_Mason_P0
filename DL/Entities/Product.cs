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
        public int? ProdNumber { get; set; }
        public string ProdName { get; set; }
        public decimal ProdPrice { get; set; }
        public string ProdDescription { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
        public virtual ICollection<ProdCat> ProdCats { get; set; }
    }
}
