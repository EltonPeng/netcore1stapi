using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using netcore1stapi.Models;

namespace netcore1stapi.Controllers
{
    [Route("api/[controller]")]
    public class WallController : Controller
    {
        private readonly WallContext context;

        public WallController(WallContext wallContext)
        {
            context = wallContext;

            if (context.WallItems.Count() ==  0)
            {
                context.WallItems.Add(new Item { Name = "first item" });
                context.SaveChanges();                
            }
        }

        [HttpGet]
        public IEnumerable<Item> GetAll()
        {
            return context.WallItems.ToList();
        }

        [HttpGet("{id}", Name = "GetItem")]
        public IActionResult GetItemById(long id)
        {
            var item = context.WallItems.FirstOrDefault(i => i.Id == id);
            if(item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult AddItem(Item item)
        {
            if(item == null)
            {
                return BadRequest();
            }

            context.WallItems.Add(item);
            context.SaveChanges();

            return CreatedAtRoute("GetItem", new { id = item.Id }, item);
        }
    }
}