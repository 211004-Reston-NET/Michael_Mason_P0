﻿using System;
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

        public int Id { get; private set; }
        public int CatNumber { get; private set; }
        public string CatName { get; private set; }

        public virtual ICollection<ProdCat> ProdCats { get; private set; }
    }
}