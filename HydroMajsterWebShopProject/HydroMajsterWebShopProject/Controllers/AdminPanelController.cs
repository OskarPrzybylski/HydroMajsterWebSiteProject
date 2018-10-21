using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HydroMajsterWebShopProject.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult NewProduct()
        {
            return View();
        }

        public IActionResult AddPhoto()
        {
            return View();
        }

        public IActionResult DeleteProduct()
        {
            return View();
        }

        public IActionResult UpdateProduct()
        {
            return View();
        }
    }
}