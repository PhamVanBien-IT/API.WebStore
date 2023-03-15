using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PVB.BASE.BL;
using PVB.BASE.Common.Entitis;

namespace PVB.BASE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : BaseController<Category>
    {
        public CategorysController(IBaseBL<Category> baseBL) : base(baseBL)
        {
        }
    }
}
