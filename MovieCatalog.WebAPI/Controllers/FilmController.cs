using Microsoft.AspNetCore.Mvc;
using MovieCatalog.BLL.Interfaces;
using MovieCatalog.BLL.Models.DtoModels;
using MovieCatalog.BLL.Models.ViewModels;
using MovieCatalog.WebAPI.Validation;

namespace MovieCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmModel>>> Get()
        {
            var models = await _filmService.GetAllAsync();

            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FilmModel>> GetById(int id)
        {
            var model = await _filmService.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] FilmInputModel model)
        {
            var valid = FilmValidator.Validation(model);

            if (valid != string.Empty)
            {
                return BadRequest(valid);
            }

            var id = await _filmService.AddAsync(model);

            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] FilmInputModel model)
        {
            var valid = FilmValidator.Validation(model);

            if (valid != string.Empty)
            {
                return BadRequest(valid);
            }

            await _filmService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _filmService.DeleteAsync(id);

            return Ok();
        }

        [HttpPost("add-category")]
        public async Task<ActionResult<int>> AddCategoryToFilm(FilmCategoryModel filmCategory)
        {
            try
            {
                var filmCategoryEntityIds = await _filmService.AddCategoryToFilm(filmCategory.FilmId, filmCategory.CategoryIds);
                return Ok(filmCategoryEntityIds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-category/{filmId}/{categoryIds}")]
        public async Task<ActionResult> DeleteCategoryFromFilm([FromRoute] int filmId, [FromRoute] string categoryIds)
        {
            var categoryIdsArray = categoryIds.Split(',').Select(int.Parse).ToArray();

            await _filmService.DeleteCategoryFromFilm(filmId, categoryIdsArray);

            return Ok();
        }
    }
}
