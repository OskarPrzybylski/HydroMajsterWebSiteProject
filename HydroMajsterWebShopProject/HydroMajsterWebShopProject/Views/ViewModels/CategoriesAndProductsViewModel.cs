using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HydroMajsterWebShopProject.Models;

namespace HydroMajsterWebShopProject.Views.ViewModels
{
    public class CategoriesAndProductsViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
