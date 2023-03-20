using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVB.BASE.BL;
using PVB.BASE.Common.Entitis;

namespace PVB.BASE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : BaseController<Supplier>
    {
        public SuppliersController(IBaseBL<Supplier> baseBL) : base(baseBL)
        {
        }
    }
}
