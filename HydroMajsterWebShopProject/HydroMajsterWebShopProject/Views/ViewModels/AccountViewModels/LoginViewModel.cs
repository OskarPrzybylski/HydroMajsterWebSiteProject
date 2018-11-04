using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydroMajsterWebShopProject.Views.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Twój email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Twoje hasło")]
        public string Password { get; set; }

        [Display(Name = "zapamiętać dane?")]
        public bool RememberMe { get; set; }
    }
}
