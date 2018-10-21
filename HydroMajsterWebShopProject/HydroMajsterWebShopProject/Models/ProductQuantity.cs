using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydroMajsterWebShopProject.Models
{
    public class ProductQuantity : DbModel
    {
        #region Properties
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        #endregion
    }
}
