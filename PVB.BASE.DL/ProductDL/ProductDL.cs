using PVB.BASE.Common.Database;
using PVB.BASE.Common.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVB.BASE.DL.ProductDL
{
    public class ProductDL : BaseDL<Product>, IProductDL
    {
        public ProductDL(IDatabase database) : base(database)
        {
        }
    }
}
