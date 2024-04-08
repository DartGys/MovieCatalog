using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCatalog.WebUI.Models;

namespace MovieCatalog.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly string? url;
        private readonly HttpClient client;

        public CategoryController(IConfiguration config)
        {
            url = config.GetValue<string>("ApiSettings:ApiUrl") + "category/";
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var categories = await client.GetFromJsonAsync<IEnumerable<CategoryVm>>("");

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryById(int id)
        {
            var category = await client.GetFromJsonAsync<CategoryVm>($"{id}");

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await client.GetFromJsonAsync<IEnumerable<CategoryNameDto>>("names");

            ViewData["CategoryName"] = new SelectList(categories, "Id", "Name");

            var category = new CategoryDto();

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto category)
        {
            var response = await client.PostAsJsonAsync("", category);

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(CategoryList));
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

        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = new CategoryDto { Id = id };

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto category)
        {
            var response = await client.PutAsJsonAsync("", category);

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(CategoryList));
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
