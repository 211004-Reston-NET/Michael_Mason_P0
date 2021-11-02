using Data;

namespace Models
{
    public class StorefrontM : Storefront
    {
        public StorefrontM(Storefront entity)
        {
            this.StoreNumber = entity.StoreNumber;
            this.StoreName = entity.StoreName;
            this.StoreAddress = entity.StoreAddress;
        }

        public override string ToString()
        {
            var output = $@"Store {this.StoreNumber}
Name: {this.StoreName}
Address: {this.StoreAddress}            
";
        return output;
        }

        public string ListView()
        {
            return $"[{this.StoreNumber}] {this.StoreName} | {this.StoreAddress}";
        }
    }
}
