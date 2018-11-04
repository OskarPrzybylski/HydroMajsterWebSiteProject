using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HydroMajsterWebShopProject.Models;
using HydroMajsterWebShopProject.Models.Database;
using HydroMajsterWebShopProject.Models.UnitOfWork;
using HydroMajsterWebShopProject.Views.ViewModels;

namespace HydroMajsterWebShopProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public HomeController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                var categoryList = unitOfWork.CategoryRepository.GetAll();
                var products = unitOfWork.ProductRepository.GetAll();
                foreach (var product in products)
                {
                    if (product.Description != null)
                    {
                        if (product.Description.Length > 50)
                        {
                            product.Description = product.Description.Substring(0, 50) + "...";
                        }
                    }
                }
                return View(new CategoriesAndProductsViewModel { Categories = categoryList, Products = products });
            }
            
        }
        
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
