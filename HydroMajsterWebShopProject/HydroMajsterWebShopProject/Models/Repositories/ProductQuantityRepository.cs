using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HydroMajsterWebShopProject.Models.Database;
using HydroMajsterWebShopProject.Models.Interfaces;

namespace HydroMajsterWebShopProject.Models.Repositories
{
    public class ProductQuantityRepository : GenericRepository<ProductQuantity>, IProductQuantityRepository
    {
        public ProductQuantityRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public ProductQuantity GetProductQuantityById(int productId)
        {
            return this.DatabaseContext.ProductQuantities.FirstOrDefault(x => x.ProductId == productId);
        }
    }
}
