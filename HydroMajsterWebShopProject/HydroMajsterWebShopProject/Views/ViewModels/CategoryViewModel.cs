﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydroMajsterWebShopProject.Views.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        [Display(Name = "Nazwa kategorii")]
        public string Name { get; set; }
    }
}
