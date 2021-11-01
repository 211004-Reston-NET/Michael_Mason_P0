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
                    throw new Exception("You must enter an email");
                }
                if (!Regex.IsMatch(value, @"^[a-z.' !]+$", RegexOptions.IgnoreCase))
                {
                    throw new Exception("Store name is invalid");
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
                    throw new Exception("You must enter an email");
                }
                if (!Regex.IsMatch(value, @"^[a-z.' )!(]+$", RegexOptions.IgnoreCase))
                {
                    throw new Exception("Store name is invalid");
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
                    throw new Exception("You must enter an email");
                }
                if (!Regex.IsMatch(value, @"^[a-z ]+$", RegexOptions.IgnoreCase))
                {
                    throw new Exception("Store name is invalid");
                }
                _prodCategory = value;
            }
        }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
