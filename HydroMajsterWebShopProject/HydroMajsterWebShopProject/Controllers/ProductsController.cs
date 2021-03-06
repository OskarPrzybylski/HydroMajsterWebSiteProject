﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HydroMajsterWebShopProject.Models;
using HydroMajsterWebShopProject.Models.Database;
using HydroMajsterWebShopProject.Models.UnitOfWork;
using HydroMajsterWebShopProject.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HydroMajsterWebShopProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public ProductsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Category(int categoryId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                var products = unitOfWork.ProductRepository.GetProductsByCategory(categoryId);
                var categories = unitOfWork.CategoryRepository.GetAll();
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
                return View(new CategoriesProductsCurrentCategoryViewModel { Categories = categories, Products = products, Category = unitOfWork.CategoryRepository.Get(categoryId)});
            }

            
        }

        public IActionResult Product(int productId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                var product = unitOfWork.ProductRepository.Get(productId);
                var categories = unitOfWork.CategoryRepository.GetAll();
                var productQuantity = unitOfWork.ProductQuantityRepository.GetProductQuantityById(productId);
                return View(new CategoriesAndProductWithQuantityViewModel { Categories = categories, Product = product, ProductQuantity = productQuantity});
            }
           
        }
    }
}