using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVB.BASE.BL;
using PVB.BASE.Common.Entitis;

namespace PVB.BASE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController<Product>
    {
        public ProductsController(IBaseBL<Product> baseBL) : base(baseBL)
        {
        }
    }
}
