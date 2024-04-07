using Microsoft.AspNetCore.Mvc;
using MovieCatalog.BLL.Interfaces;
using MovieCatalog.BLL.Models.DtoModels;
using MovieCatalog.BLL.Models.ViewModels;
using MovieCatalog.BLL.Services;
using MovieCatalog.WebAPI.Validation;

namespace MovieCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> Get()
        {
            var models = await _categoryService.GetAllAsync();

            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetById(int id)
        {
            var model = await _categoryService.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpGet("names")]
        public async Task<ActionResult<CategoryNameModel>> GetNames()
        {
            var models = await _categoryService.GetCategoryName();

            return Ok(models);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] CategoryInputModel model)
        {
            var valid = CategoryValidator.Validation(model);

            if (valid != string.Empty)
            {
                return BadRequest(valid);
            }

            var id = await _categoryService.AddAsync(model);

            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] CategoryInputModel model)
        {
            var valid = CategoryValidator.Validation(model);

            if (valid != string.Empty)
            {
                return BadRequest(valid);
            }

            await _categoryService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _categoryService.DeleteAsync(id);

            return Ok();
        }
    }
}
