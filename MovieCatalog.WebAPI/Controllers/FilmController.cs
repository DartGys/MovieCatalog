using Microsoft.AspNetCore.Mvc;
using MovieCatalog.BLL.Interfaces;
using MovieCatalog.BLL.Models;
using MovieCatalog.WebAPI.Validation;

namespace MovieCatalog.WebAPI.Controllers
{
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
        public async Task<ActionResult<int>> Add([FromBody] FilmModel model)
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
        public async Task<ActionResult> Update([FromBody] FilmModel model)
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
    }
}
