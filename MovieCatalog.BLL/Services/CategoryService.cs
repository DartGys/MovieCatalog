using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieCatalog.BLL.Interfaces;
using MovieCatalog.BLL.Models;
using MovieCatalog.DAL.Data;
using MovieCatalog.DAL.Data.Entities;


namespace MovieCatalog.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CategoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(CategoryModel model)
        {
            var entity = _mapper.Map<Category>(model);

            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int modelId)
        {
            var entity = new Category { Id = modelId };

            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            var entities = await _context.Categories
                .AsNoTracking()
                .Include(e => e.FilmCategories)
                .Include(e => e.ChildCategories)
                .Include(e => e.ParentCategory)
                .ToListAsync();

            var models = _mapper.Map<IEnumerable<CategoryModel>>(entities);

            return models;
        }

        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            var entity = await _context.Categories
                .AsNoTracking()
                .Include(e => e.FilmCategories)
                .Include(e => e.ChildCategories)
                .Include(e => e.ParentCategory)
                .FirstOrDefaultAsync(e => e.Id == id);

            var model = _mapper.Map<CategoryModel>(entity);

            return model;
        }

        public async Task UpdateAsync(CategoryModel model)
        {
            var entity = await _context.Categories
                .Where(e => e.Id == model.Id)
                .ExecuteUpdateAsync(e => e
                .SetProperty(x => x.Name, model.Name));

            await _context.SaveChangesAsync();
        }
    }
}
