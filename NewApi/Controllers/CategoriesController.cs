using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewApi.Data;
using NewApi.Models;

namespace NewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public CategoriesController(AppDbContext db)
        {
            _db = db;
        }
        private readonly AppDbContext _db;

        //for categories

        [HttpGet]
        public async Task<IActionResult>GetCategories()
        {
            var cats = await _db.categories.ToListAsync();
            return Ok(cats);

        }



        [HttpGet("id")]
        public async Task<IActionResult> GetCategories(int id)
        {
            var cats = await _db.categories.SingleOrDefaultAsync(x => x.Id == id);
            if (cats == null)
            {
                return NotFound($"CategoryId{id} not exist");

            }
            return Ok(cats);

        }



        [HttpPost]
        public async Task<IActionResult> addcategory(string category)
        {
            Category c = new() { Name = category };
            await _db.categories.AddAsync(c);
            _db.SaveChanges();
            return Ok(c);

        }

        [HttpPut]
        public async Task<IActionResult>updatecategory(Category category)
        {
            var c = await _db.categories.SingleOrDefaultAsync(x => x.Id == category.Id);
            if(c==null)
            {
                return NotFound($"CategoryId{category.Id} not exist");

            }
            c.Name = category.Name;
            _db.SaveChanges();
            return Ok(c);
        }

        [HttpPatch("{id}")]

        public async Task<IActionResult>updatecategorypatch ([FromBody]JsonPatchDocument<Category> category ,[FromRoute] int id)
        {
            var c = await _db.categories.SingleOrDefaultAsync(x => x.Id ==id);
            if (c == null)
            {
                return NotFound($"CategoryId{id} not exist");

            }
            category.ApplyTo(c);
           await _db.SaveChangesAsync();
            return Ok(c);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult>removecategory(int id)
        {
            var c = await _db.categories.SingleOrDefaultAsync(x => x.Id ==id);
            if (c == null)
            {
                return NotFound($"CategoryId{id} not exist");

            }
            _db.categories.Remove(c);
            _db.SaveChanges();
            return Ok(c);
        }


    }
}
