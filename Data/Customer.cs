using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

#nullable disable

namespace Data
{
    public partial class Customer
    {
        public Customer()
        {
            SOrders = new HashSet<SOrder>();
        }

        public int CustNumber { get; set; }
        string _custEmail;

        public string CustEmail
        {
            get => _custEmail;
            set
            {
                if (value == null)
                {
                    throw new Exception("You must enter an email");
                }
                if (!Regex.IsMatch(value, @"^[a-z.+@]+$", RegexOptions.IgnoreCase))
                {
                    throw new Exception("Email address is invalid");
                }
                _custEmail = value;
            }
        }
        string _custName;

        public string CustName
        {
            get => _custName;
            set
            {
                if (value == null)
                {
                    throw new Exception("You must enter an email");
                }
                if (!Regex.IsMatch(value, @"^[a-z]+$", RegexOptions.IgnoreCase))
                {
                    throw new Exception("Email address is invalid");
                }
                _custName = value;
            }
        }
        string _custAddress;
        public string CustAddress
        {
            get => _custAddress;
            set
            {
                if (value == null)
                {
                    throw new Exception("You must enter an address");
                }
                if (!Regex.IsMatch(value, @"^[a-z0-9. ,-]+$", RegexOptions.IgnoreCase))
                {
                    throw new Exception("Email address is invalid");
                }
                _custAddress = value;
            }
        }
        public int CustPhone { get; set; }

        public virtual ICollection<SOrder> SOrders { get; set; }
    }
}
