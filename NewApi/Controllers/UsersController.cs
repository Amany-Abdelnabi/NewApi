using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NewApi.Data;
using NewApi.Models;
using NewApi.NewFolder;

namespace NewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public UsersController(AppDbContext db)
        {
            _db = db;
        }

        private readonly AppDbContext _db;


        [HttpGet]
        public async Task<IActionResult> Getcats()
        {
            var cat = await _db.cats.ToListAsync();
            return Ok(cat);
        }


        [HttpGet ("{id}")]
        public async Task<IActionResult> GetcatsId(int id)
        {
            var cat = await _db.cats.SingleOrDefaultAsync(x=>x.Id==id);

            if(cat==null)
            {
                return NotFound($"catid{id}not exist");
            }
            return Ok(cat);
        }

        [HttpPost]
        public async Task<IActionResult> Addcat(mdluser cat)
        {
            User c = new()
            {
                 First_Name=cat.First_Name,
                Last_Name = cat.Last_Name,
                //phone =cat.phone,
                 email=cat.Email,
                 pass=cat.PassWord,
                 //role=cat.role,


            };


            await _db.cats.AddAsync(c);
            await _db.SaveChangesAsync();
            return Ok(c);
        }


    }
}
