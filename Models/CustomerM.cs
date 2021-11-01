using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class CustomerM
    {
        public int CustNumber { get; set; }
        public string CustName {get;set;}
        public string CustAddress {get;set;}
        public string CustEmail {get;set;}
        public int CustPhone {get;set;}
        public IEnumerable<SOrder> SOrders { get; set; }

        public CustomerM(Customer entity)
        {
            this.CustNumber = entity.CustNumber;
            this.CustName = entity.CustName;
            this.CustAddress= entity.CustAddress;
            this.CustEmail= entity.CustEmail;
            this.CustPhone = entity.CustPhone;
            this.SOrders = entity.SOrders;
        }
            
        

        public override string ToString()
        {
            var output = $@"Customer
-----
Name: {this.CustName}
Address: {this.CustAddress}
Email: {this.CustEmail}
Phone: {this.CustPhone}
-----";
        foreach (var item in SOrders)
        {
            output += $"order #{item.OrderId} . store id: {item.StoreNumber} . {item.TotalPrice}\n";
        }

        output += "-----";
        return output;

        }

        public string ToList()
        {
            return $"[{this.CustNumber}] | {this.CustName} | {this.CustAddress} | {this.CustEmail} | {this.CustPhone}";
        }
    }
}