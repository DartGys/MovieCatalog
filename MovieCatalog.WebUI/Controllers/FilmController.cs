using Microsoft.AspNetCore.Mvc;
using MovieCatalog.WebUI.Models;

namespace MovieCatalog.WebUI.Controllers
{
    public class FilmController : Controller
    {
        private readonly string? url;
        private readonly HttpClient client;

        public FilmController(IConfiguration config)
        {
            url = config.GetValue<string>("ApiSettings:ApiUrl") + "film/";
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
        }

        [HttpGet]
        public async Task<IActionResult> FilmList()
        {
            var films = await client.GetFromJsonAsync<IEnumerable<FilmVm>>("");

            return View(films);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FilmById([FromRoute] int id)
        {
            var film = await client.GetFromJsonAsync<FilmVm>($"{id}");

            return View(film);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var request = new FilmDto();

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FilmDto film)
        {
            var response = await client.PostAsJsonAsync("", film);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(FilmList));
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
        public async Task<IActionResult> Update(int id)
        {
            var film = await client.GetFromJsonAsync<FilmDto>($"{id}");

            return View(film);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FilmDto film)
        {
            var response = await client.PutAsJsonAsync("", film);

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(FilmList));
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
