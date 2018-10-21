using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HydroMajsterWebShopProject.Models.Database;
using HydroMajsterWebShopProject.Models.Interfaces;

namespace HydroMajsterWebShopProject.Models.Repositories
{
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
