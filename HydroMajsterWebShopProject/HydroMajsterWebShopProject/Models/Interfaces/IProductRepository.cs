﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydroMajsterWebShopProject.Models.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductsByCategory(int categoryId);
    }
}
