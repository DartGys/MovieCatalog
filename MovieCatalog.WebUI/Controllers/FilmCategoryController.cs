using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MovieCatalog.WebUI.Models;
using System.Net.Http.Json;

namespace MovieCatalog.WebUI.Controllers
{
    public class FilmCategoryController : Controller
    {
        private readonly string? url;
        private readonly HttpClient client;

        public FilmCategoryController(IConfiguration config)
        {
            url = config.GetValue<string>("ApiSettings:ApiUrl");
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int filmId)
        {
            var categories = await client.GetFromJsonAsync<IEnumerable<CategoryNameDto>>($"category/notinfilm/{filmId}");

            ViewData["CategoryName"] = new SelectList(categories, "Id", "Name");
            ViewBag.filmId = filmId;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(int filmId, int[] categories)
        {
            var requestData = new
            {
                FilmId = filmId,
                CategoryIds = categories
            };

            var response = await client.PostAsJsonAsync($"film/add-category", requestData);

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("FilmById", "Film", new { id = filmId });
            }    
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int filmId)
        {
            var categories = await client.GetFromJsonAsync<IEnumerable<CategoryNameDto>>($"category/infilm/{filmId}");

            ViewData["CategoryName"] = new SelectList(categories, "Id", "Name");
            ViewBag.filmId = filmId;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int filmId, int[] categories)
        {
            var url = $"film/delete-category/{filmId}/{string.Join(",", categories)}";
            var response = await client.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("FilmById", "Film", new { id = filmId });
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
