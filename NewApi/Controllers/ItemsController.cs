using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewApi.Data;
using NewApi.Models;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using NewApi.NewFolder;

namespace NewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly AppDbContext _context;      //db

        public ItemsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var items = await _context.items.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Getitems(int id)
        {
            var item = await _context.items.SingleOrDefaultAsync(x => x.id == id);
            if (item == null)
            {
                return NotFound($"ItemId {id} not exist");
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(mdlitem mdl)
        {
            var item = new item()
            {
                Name = mdl.Name,
                //categoryid = mdl.categoryid,
                price = mdl.price
            };

            await _context.items.AddAsync(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

    }
}


   