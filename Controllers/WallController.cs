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
        public IActionResult AddItem([FromBody] Item item)
        {
            if(item == null)
            {
                return BadRequest();
            }

            context.WallItems.Add(item);
            context.SaveChanges();

            return CreatedAtRoute("GetItem", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Item item)
        {
            if(item == null || item.Id != id)
            {
                return BadRequest();
            }

            var target = context.WallItems.FirstOrDefault(i => i.Id == id);
            if(target == null)
            {
                return NotFound();
            }

            target.IsChecked = item.IsChecked;
            target.Name = item.Name;

            context.WallItems.Update(target);
            context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var item = context.WallItems.FirstOrDefault(i => i.Id == id);
            if(item == null)
            {
                return NotFound();
            }

            context.WallItems.Remove(item);
            context.SaveChanges();
            return new NoContentResult();
        }
    }
}