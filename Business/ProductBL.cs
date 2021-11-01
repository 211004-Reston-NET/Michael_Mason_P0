using System.Collections.Generic;
using System.Linq;
using Data;

namespace Business
{
    public interface IProductBL : IBaseBL<Product>
    {
        IEnumerable<Product> GetProductByName(string query);
        IEnumerable<Product> GetProductsByCategory(string query);
        IEnumerable<Product> GetProductsByDescription(string query);
    }

    public class ProductBL : BaseBL<Product>, IProductBL
    {
        public ProductBL(IRepository<Product> context) : base(context)
        {
        }


        public IEnumerable<Product> GetProductByName(string query)
        {
            return base.GetAll().Where(p => p.ProdName.Contains(query));
        }

        public IEnumerable<Product> GetProductsByDescription(string query)
        {
            return base.GetAll().Where(p => p.ProdDescription.Contains(query));
        }

        public IEnumerable<Product> GetProductsByCategory(string query)
        {
            return base.GetAll().Where(p => p.ProdCategory.Contains(query));
        }
    }
}