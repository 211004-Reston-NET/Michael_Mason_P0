using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class ProdCatRepository : Repository<ProdCat>, IProdCatRepository
    {
        public ProdCatRepository(StoreManagerContext context) : base(context)
        {
        }
        
        public StoreManagerContext StoreManagerContext
        {
            get { return _context as StoreManagerContext; }
        }

        public override IQueryable<ProdCat> Find(string query)
        {
            throw new System.NotImplementedException();
        }

        public override IQueryable<ProdCat> Find(int query)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<ProdCat> FindProdCatsByProdId(int query)
        {
            return (from pc in StoreManagerContext.ProdCats
                    where pc.ProdId == query
                    select pc).ToList();
        }

        public IQueryable<string> FindAndJoinCategories(int query)
        {
            var dbQuery = (from cat in StoreManagerContext.Categories
                            join pc in StoreManagerContext.ProdCats
                            on cat.Id equals pc.CatId
                            where pc.ProdId == query
                            select cat.CatName);
            return dbQuery;
        }

        public IQueryable<string> FindAndJoinProducts(int query)
        {
            var dbQuery = (from prod in StoreManagerContext.Products
                            join pc in StoreManagerContext.ProdCats
                            on prod.Id equals pc.ProdId
                            where pc.CatId == query
                            select prod.ProdName);
            return dbQuery;
        }

        public string FindProductName(int id)
        {
            var dbQuery = (from prod in StoreManagerContext.Products
                        where prod.Id == id
                        select prod.ProdName);
            return dbQuery.First();
        }
    }
}