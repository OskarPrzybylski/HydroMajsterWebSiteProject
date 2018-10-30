using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HydroMajsterWebShopProject.Models;
using HydroMajsterWebShopProject.Models.Database;
using HydroMajsterWebShopProject.Models.UnitOfWork;
using HydroMajsterWebShopProject.Views.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace HydroMajsterWebShopProject.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly DatabaseContext _databaseContext;

        public AdminPanelController(IHostingEnvironment environment, DatabaseContext databaseContext)
        {
            _environment = environment;
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction(nameof(AccountController.Login), "Account");
            }
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction(nameof(AccountController.Login), "Account");
            }
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel product)
        {
            var newFileName = string.Empty;
            var PathDB = string.Empty;
            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                var files = HttpContext.Request.Form.Files;
                foreach (var file in files)
                {
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                    var fileExtension = Path.GetExtension(fileName);
                    newFileName = myUniqueFileName + fileExtension;
                    fileName = Path.Combine(_environment.WebRootPath, "images") + $@"\{newFileName}";
                    PathDB = "images/" + newFileName;
                    using (var fs = System.IO.File.Create(fileName))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }
            }
            using (var unitOfWork = new UnitOfWork(this._databaseContext))
            {
                var prod = new Product
                {
                    CategoryId = product.CategoryId, Description = product.Description, Name = product.Name,
                    Price = product.Price, PhotoUrl = PathDB
                };
                unitOfWork.ProductRepository.Add(prod);
                unitOfWork.Save();
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction(nameof(AccountController.Login), "Account");
            }
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel category)
        {
            var newFileName = string.Empty;
            var PathDB = string.Empty;
            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                var files = HttpContext.Request.Form.Files;
                foreach (var file in files)
                {
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                    var fileExtension = Path.GetExtension(fileName);
                    newFileName = myUniqueFileName + fileExtension;
                    fileName = Path.Combine(_environment.WebRootPath, "images") + $@"\{newFileName}";
                    PathDB = "images/" + newFileName;
                    using (var fs = System.IO.File.Create(fileName))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }
            }
            using(UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                unitOfWork.CategoryRepository.Add(new Category { Name = category.Name, PhotoUrl = PathDB });
                unitOfWork.Save();
            }
            TempData["Info"] = "Kategoria dodana prawidłowo!";
            return RedirectToAction(nameof(AdminPanelController.Index), "AdminPanel");
        }
        
        [HttpGet]
        public IActionResult DeleteProduct()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
                {
                    var products = unitOfWork.ProductRepository.GetAll();
                    return View(products);
                }
            }
            else
            {
                return RedirectToAction(nameof(AccountController.Login), "Account");
            }
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            using(UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                unitOfWork.ProductRepository.Remove(unitOfWork.ProductRepository.Get(productId));
                unitOfWork.Save();
            }
            TempData["Info"] = "Produkt usunięty prawidłowo!";
            return RedirectToAction(nameof(AdminPanelController.Index), "AdminPanel");
        }

        [HttpGet]
        public IActionResult DeleteCategory()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
                {
                    var categories = unitOfWork.CategoryRepository.GetAll();
                    return View(categories);
                }
            }
            else
            {
                return RedirectToAction(nameof(AccountController.Login), "Account");
            } 
        }

        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                var products = unitOfWork.ProductRepository.GetProductsByCategory(categoryId);
                if(products.Count() > 0)
                {
                    TempData["Info"] = "Nie można usunąć podanej kategorii, gdyż istnieją nadal produkty, które do niej należą! Usuń te produkty w pierwszej kolejności!";
                }
                else
                {
                    TempData["Info"] = "Kategoria usunięta prawidłowo!";
                    unitOfWork.CategoryRepository.Remove(unitOfWork.CategoryRepository.Get(categoryId));
                    unitOfWork.Save();
                    var categories = unitOfWork.CategoryRepository.GetAll();
                }
                return RedirectToAction(nameof(AdminPanelController.Index), "AdminPanel");
            }
        }
    }
}