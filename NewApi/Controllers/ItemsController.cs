using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewApi.Data;
using NewApi.Models;
using NewApi.NewFolder;

namespace NewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public ItemsController(AppDbContext db)
        {
            _db = db;
        }
        private readonly AppDbContext _db;



        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var items = await _db.items.ToListAsync();
            return Ok(items);

        }


        [HttpGet("id")]
        public async Task<IActionResult> Getitems(int id)
        {
            var items = await _db.items.SingleOrDefaultAsync(x => x.id == id);
            if (items == null)
            {
                return NotFound($"ItemId{id} not exist");

            }
            return Ok(items);

        }
        [HttpPost]
        public async Task<IActionResult> AddItem(mdlitem mdl)
        {
            using var system = new MemoryStream();

            await mdl.image.CopyToAsync(system);

            var item = new item()
            {
                Name = mdl.Name,
                image = system.ToArray(),
                categoryid = mdl.categoryid,
                price = mdl.price
            };

            await _db.items.AddAsync(item);
            await _db.SaveChangesAsync();

            return Ok(item);
        }




    }
}
