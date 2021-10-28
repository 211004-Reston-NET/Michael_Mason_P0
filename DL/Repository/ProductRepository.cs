using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DL
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(StoreManagerContext context) : base(context)
        {
        }
        
        public StoreManagerContext StoreManagerContext
        {
            get { return _context as StoreManagerContext; }
        }

        public override IQueryable<Product> Find(string query)
        {
            IQueryable<Product> dbQuery = (from p in StoreManagerContext.Products
                                            where p.ProdName.Contains(query)
                                            select p);
            return dbQuery;
        }

        public override IQueryable<Product> Find(int query)
        {
            IQueryable<Product> dbQuery = (from p in StoreManagerContext.Products
                                            where p.ProdNumber.ToString().Contains(query.ToString())
                                            select p);
            return dbQuery;
        }

        public IQueryable<ProdCat> FindProdCatByProdId(int id)
        {
            return (from pc in StoreManagerContext.ProdCats
                    where pc.ProdId == id
                    select pc);
        }

        public ICollection<string> GetProdCatNames(List<int> idList)
        {
            {
                ICollection<string> result = new List<string>();
                foreach (var item in idList)
                {
                    result.Add((from cat in StoreManagerContext.Categories
                        join pc in StoreManagerContext.ProdCats
                        on cat.Id equals pc.CatId
                        where pc.CatId == item
                        select cat.CatName).First());
                };
                return result;
            }
        }
    }
}