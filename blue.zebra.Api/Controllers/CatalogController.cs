using Microsoft.AspNetCore.Mvc;
using blue.zebra.Domain.Catalog;

namespace blue.zebra.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CatalogController : ControllerBase{
        [HttpGet]
        public IActionResult GetItems(){
            return Ok("Hello World!");
        }

    }
}