using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.AspNetCore.Mvc;
using NewApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirebaseController : ControllerBase
    {
        // 🔹 هنا التعريف
        private readonly FirebaseClient _firebaseClient;


        // 🔹 هنا الإنشاء داخل الكونستركتور
        public FirebaseController(IConfiguration config)
        {
            var settings = config.GetSection("firebasesettings").Get<firebasesetting>();

            Console.WriteLine("Firebase URL: " + settings.BaseUrl);


            _firebaseClient = new FirebaseClient(
                settings.BaseUrl,
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(settings.AuthToken)
                });
        }

        // 🔹 مثال على استخدامه
        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItem(item item)

        {
            var result = await _firebaseClient
                .Child("items")
                .PostAsync(item);

            return Ok(result.Key);
        }
    }
}

