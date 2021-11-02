using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

#nullable disable

namespace Data
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            LineItems = new HashSet<LineItem>();
        }

        public int ProdId { get; set; }
        string _prodName;
        public string ProdName
        {
            get => _prodName;
            set
            {
                if (value == null)
                {
                    throw new Exception("You must enter a product name");
                }
                if (!Regex.IsMatch(value, @"^[a-z0-9.' !-]+$", RegexOptions.IgnoreCase))
                {
                    throw new Exception("Product name is invalid");
                }
                _prodName = value;
            }
        }
        public decimal ProdPrice { get; set; }
        string _prodDescription;
        public string ProdDescription 
        {
            get => _prodDescription;
            set
            {
                if (value == null)
                {
                    throw new Exception("You must enter an description");
                }
                if (!Regex.IsMatch(value, @"^[a-z0-9.' !-]+$", RegexOptions.IgnoreCase))
                {
                    throw new Exception("Description is invalid");
                }
                _prodDescription = value;
            }
        }
        string _prodCategory;
        public string ProdCategory
        {
            get => _prodCategory;
            set
            {
                if (value == null)
                {
                    throw new Exception("You must enter an category");
                }
                if (!Regex.IsMatch(value, @"^[a-z ]+$", RegexOptions.IgnoreCase))
                {
                    throw new Exception("Category is invalid");
                }
                _prodCategory = value;
            }
        }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
