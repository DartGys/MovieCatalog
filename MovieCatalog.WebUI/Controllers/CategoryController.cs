using Microsoft.AspNetCore.Mvc;
using MovieCatalog.WebUI.Models;

namespace MovieCatalog.WebUI.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly string? url;
        private readonly HttpClient client;

        public CategoryController(IConfiguration config)
        {
            url = config.GetValue<string>("ApiSettings:ApiUrl") + "category";
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var categories = await client.GetFromJsonAsync<IEnumerable<CategoryVm>>("");

            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto category)
        {
            var response = await client.PatchAsJsonAsync("", category);

            if(response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await client.DeleteAsync($"{id}");

            if(response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto category)
        {
            var response = await client.PutAsJsonAsync("", category);

            if(response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
