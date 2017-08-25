
using Microsoft.AspNetCore.Mvc;
using wedding_wishlist.Models;
using System.Collections.Generic;
using System.Linq;

namespace wedding_wishlist.Controllers
{
    [Route("api/[controller]")]
    public class WishlistController : Controller
    {
        private readonly WishlistContext _context;

        public WishlistController(WishlistContext context)
        {
            _context = context;

            if (_context.Wishes.Count() == 0)
            {
                var wish = new Wish
                {
                    Name = "Sonos Playbar lydplanke",
                    Price = 6998,
                    Url = "http://www.vg.no",
                    NumberBought = 0,
                    NumberWished = 1
                };

                _context.Wishes.Add(wish);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Wish> GetAll()
        {
            return _context.Wishes.ToList();
        }

        [HttpGet("{id}", Name = "GetWish")]
        public IActionResult GetById(long id)
        {
            var wish = _context.Wishes.FirstOrDefault(w => w.Id == id);
            if (wish == null)
            {
                return NotFound();
            }
            return new ObjectResult(wish);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Wish item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Wishes.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetWish", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Wish item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var wish = _context.Wishes.FirstOrDefault(t => t.Id == id);
            if (wish == null)
            {
                return NotFound();
            }

            wish.Price = item.Price;
            wish.Name = item.Name;
            wish.NumberBought = item.NumberBought;
            wish.NumberWished = item.NumberWished;
            wish.Url = item.Url;

            _context.Wishes.Update(wish);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var wish = _context.Wishes.FirstOrDefault(t => t.Id == id);
            if (wish == null)
            {
                return NotFound();
            }

            _context.Wishes.Remove(wish);
            _context.SaveChanges();
            return new NoContentResult();
        }



    }
}