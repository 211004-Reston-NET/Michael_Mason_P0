using Data;

namespace Models
{
    public class SOrderM : SOrder
    {
        public SOrderM(SOrder entity)
        {
            this.OrderId = entity.OrderId;
            this.StoreNumber = entity.StoreNumber;
            this.CustNumber = entity.CustNumber;
            this.TotalPrice = entity.TotalPrice;
            this.CustNumberNavigation = entity.CustNumberNavigation;
            this.StoreNumberNavigation = entity.StoreNumberNavigation;
            this.LineItems = entity.LineItems;
        }

        public override string ToString()
        {
            var output = $@"Order #{this.OrderId} | Total: {this.TotalPrice}
{this.LineItems}
--

            
            ";
            return output;
        }
    }
}