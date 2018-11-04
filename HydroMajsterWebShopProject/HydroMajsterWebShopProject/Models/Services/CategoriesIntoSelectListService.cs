using HydroMajsterWebShopProject.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HydroMajsterWebShopProject.Models.UnitOfWork;

namespace HydroMajsterWebShopProject.Models.Services
{
    public class CategoriesIntoSelectListService
    {
        private DatabaseContext _databaseContext;
        private List<SelectListItem> list;
        public CategoriesIntoSelectListService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
            list = new List<SelectListItem>();
            using (Models.UnitOfWork.UnitOfWork unitOfWork = new Models.UnitOfWork.UnitOfWork(_databaseContext))
            {
                var categories = unitOfWork.CategoryRepository.GetAll();
                foreach (var category in categories)
                {
                    list.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
                }
            }
        }
        public List<SelectListItem> getCategoriesSelectList()
        { 
                return list;
        }
    }
}
