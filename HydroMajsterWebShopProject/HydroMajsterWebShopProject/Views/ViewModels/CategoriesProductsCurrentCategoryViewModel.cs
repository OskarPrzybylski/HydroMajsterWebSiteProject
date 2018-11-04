using HydroMajsterWebShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydroMajsterWebShopProject.Views.ViewModels
{
    public class CategoriesProductsCurrentCategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Category Category { get; set; }
    }
}
