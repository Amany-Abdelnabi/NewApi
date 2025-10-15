using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NewApi.Models;

namespace NewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly FirebaseClient _firebaseClient;

        public CategoriesController()
        {
            // 🔗 ضع هنا رابط الـ Firebase Realtime Database  بك
            _firebaseClient = new FirebaseClient("https://fir-b5c4c-default-rtdb.firebaseio.com/");
        }

        // ✅ Get all categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _firebaseClient
                .Child("Categories")
                .OnceAsync<Category>();

            var list = categories.Select(c => new Category
            {
                Id = c.Object.Id,
                Name = c.Object.Name
            }).ToList();

            return Ok(list);
        }

        // ✅ Get category by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var categories = await _firebaseClient
                .Child("Categories")
                .OnceAsync<Category>();

            var category = categories.FirstOrDefault(c => c.Object.Id == id);

            if (category == null)
                return NotFound($"Category with ID {id} not found.");

            return Ok(category.Object);
        }

        // ✅ Add new category
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            await _firebaseClient
                .Child("Categories")
                .PostAsync(category);

            return Ok(category);
        }

        // ✅ Update category (PUT)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            var existing = (await _firebaseClient
                .Child("Categories")
                .OnceAsync<Category>())
                .FirstOrDefault(c => c.Object.Id == id);

            if (existing == null)
                return NotFound($"Category with ID {id} not found.");

            await _firebaseClient
                .Child("Categories")
                .Child(existing.Key)
                .PutAsync(category);

            return Ok(category);
        }

        // ✅ Partial update (PATCH)
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCategoryPatch(int id, [FromBody] JsonPatchDocument<Category> patch)
        {
            var existing = (await _firebaseClient
                .Child("Categories")
                .OnceAsync<Category>())
                .FirstOrDefault(c => c.Object.Id == id);

            if (existing == null)
                return NotFound($"Category with ID {id} not found.");

            var updatedCategory = existing.Object;
            patch.ApplyTo(updatedCategory);

            await _firebaseClient
                .Child("Categories")
                .Child(existing.Key)
                .PutAsync(updatedCategory);

            return Ok(updatedCategory);
        }

        // ✅ Delete category
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var existing = (await _firebaseClient
                .Child("Categories")
                .OnceAsync<Category>())
                .FirstOrDefault(c => c.Object.Id == id);

            if (existing == null)
                return NotFound($"Category with ID {id} not found.");

            await _firebaseClient
                .Child("Categories")
                .Child(existing.Key)
                .DeleteAsync();

            return Ok($"Category {id} deleted successfully.");
        }
    }
}
