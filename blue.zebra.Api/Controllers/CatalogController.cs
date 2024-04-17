using Microsoft.AspNetCore.Mvc;
using blue.zebra.Domain.Catalog;
using System.Net.Http.Headers;

namespace blue.zebra.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CatalogController : ControllerBase{
        [HttpGet]
        public IActionResult GetItems(){
            var items = new List<Item>(){
                new Item("Shirt", "Ohio State Shirt", "Nike", 29.99m),
                new Item("Shorts", "Ohio State Shorts", "Nike", 44.99m)
            };
            return Ok(items);
        }

    }
}