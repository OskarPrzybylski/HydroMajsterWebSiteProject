using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HydroMajsterWebShopProject.Views.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }
    }
}
