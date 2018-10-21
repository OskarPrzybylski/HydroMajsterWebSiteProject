using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydroMajsterWebShopProject.Models
{
    public class Product : DbModel
    {
        #region Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string Price { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        #endregion
    }
}
