using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HydroMajsterWebShopProject.Models;

namespace HydroMajsterWebShopProject.Views.ViewModels
{
    public class CategoriesAndProductWithQuantityViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Product Product { get; set; }
        public ProductQuantity ProductQuantity { get; set; }

    }
}
