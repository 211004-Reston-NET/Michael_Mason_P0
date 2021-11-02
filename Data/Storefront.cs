using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

#nullable disable

namespace Data
{
    public partial class Storefront
    {
        public Storefront()
        {
            Inventories = new HashSet<Inventory>();
            SOrders = new HashSet<SOrder>();
        }

        public int StoreNumber { get; set; }
        string _storeName;
        public string StoreName
        {
            get => _storeName;
            set
            {
                if (value == null)
                {
                    throw new Exception("You must enter a name");
                }
                if (!Regex.IsMatch(value, @"^[a-z0-9.' !]+$", RegexOptions.IgnoreCase))
                {
                    throw new Exception("Store name is invalid");
                }
                _storeName = value;
            }
        }
        string _storeAddress;
        public string StoreAddress
        {
            get => _storeAddress;
            set
            {
                if (value == null)
                {
                    throw new Exception("You must enter an address");
                }
                if (!Regex.IsMatch(value, @"^[a-z0-9. ,'-]+$", RegexOptions.IgnoreCase))
                {
                    throw new Exception("Store name is invalid");
                }
                _storeAddress = value;
            }
        }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<SOrder> SOrders { get; set; }
    }
}
