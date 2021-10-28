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

        string _catName;
        public int Id { get; }
        public string CatName 
        {
            get { return _catName; }
            set {

                if (value.Length == 0 || value.Length > 50)
                {
                    throw new Exception("Category name cannot be empty and must be less than 50 characers");
                }

                _catName = value;
            }
        }

        public virtual ICollection<ProdCat> ProdCats { get; set; }
    }
}
