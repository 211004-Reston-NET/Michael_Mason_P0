using System;
using System.Collections.Generic;

#nullable disable

namespace DL
{
    public partial class Category
    {
        public Category()
        {
            ProdCats = new HashSet<ProdCat>();
        }

        public int Id { get; }
        public string CatName 
        { get; set; }

        public virtual ICollection<ProdCat> ProdCats { get; set; }
    }
}
