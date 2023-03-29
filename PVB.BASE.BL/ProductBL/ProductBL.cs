using PVB.BASE.Common.Entitis;
using PVB.BASE.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVB.BASE.BL.ProductBL
{
    public class ProductBL : BaseBL<Product>, IProductBL
    {
        public ProductBL(IBaseDL<Product> baseDL) : base(baseDL)
        {
        }
    }
}
