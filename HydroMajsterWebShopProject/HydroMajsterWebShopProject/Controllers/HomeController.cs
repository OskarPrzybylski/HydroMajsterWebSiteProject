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
                return View(new CategoriesAndProductsViewModel{Categories = categoryList, Products = products});
            }
            
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
