using Data;

namespace Models
{
    public class InventoryM : Inventory
    {
        public InventoryM(Inventory entity)
        {
            this.StoreNumber = entity.StoreNumber;
            this.ProdId = entity.ProdId;
            this.Quantity= entity.Quantity;
            this.Prod = entity.Prod;
            this.StoreNumberNavigation = entity.StoreNumberNavigation;
        }

        public override string ToString()
        {
            var output = $@"Product:
store: {this.StoreNumber}
id: {this.ProdId}
quantity: {this.Quantity}
";
        return output;
        }

        public string ToList()
        {
            
            return $"{this.StoreNumber} . {this.ProdId} . {this.Quantity}";
        }
        
        
    }
}