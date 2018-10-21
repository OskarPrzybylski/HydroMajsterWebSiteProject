using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HydroMajsterWebShopProject.Models.Database;
using HydroMajsterWebShopProject.Models.Interfaces;

namespace HydroMajsterWebShopProject.Models.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return this.DatabaseContext.Products.Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}
