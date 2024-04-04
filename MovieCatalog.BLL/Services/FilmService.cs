using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieCatalog.BLL.Interfaces;
using MovieCatalog.BLL.Models.ViewModels;
using MovieCatalog.DAL.Data;
using MovieCatalog.DAL.Data.Entitie;
using MovieCatalog.DAL.Data.Entities;

namespace MovieCatalog.BLL.Services
{
    public class FilmService : IFilmService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public FilmService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddAsync(FilmModel model)
        {
            var entitiy = _mapper.Map<Film>(model);

            await _context.Film.AddAsync(entitiy);
            await _context.SaveChangesAsync();

            return entitiy.Id;
        }

        public async Task DeleteAsync(int modelId)
        {
            var entity = new Film() { Id = modelId};

            _context.Film.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FilmModel>> GetAllAsync()
        {
            var entities = await _context.Film
                .AsNoTracking()
                .Include(e => e.FilmCategories)
                    .ThenInclude(fc => fc.Category)
                .ToListAsync();

            var models = _mapper.Map<IEnumerable<FilmModel>>(entities);

            return models;
        }

        public async Task<FilmModel> GetByIdAsync(int id)
        {
            var entitiy = await _context.Film
                .AsNoTracking()
                .Include(e => e.FilmCategories)
                    .ThenInclude(fc => fc.Category)
                .FirstOrDefaultAsync(e => e.Id == id);

            var model = _mapper.Map<FilmModel>(entitiy);

            return model;
        }

        public async Task UpdateAsync(FilmModel model)
        {
            var entity = await _context.Film
                .Where(e => e.Id == model.Id)
                .ExecuteUpdateAsync(e => e
                .SetProperty(x => x.Name, model.Name)
                .SetProperty(x => x.Director, model.Director)
                .SetProperty(x => x.Release, model.Release));

            await _context.SaveChangesAsync();
        }

        public async Task<int> AddCategoryToFilm(int filmId, int categoryId)
        {
            var film = await _context.Film.FindAsync(filmId);

            if(film == null)
            {
                throw new Exception("Film doesnt exist");
            }

            var category = await _context.Categories.FindAsync(categoryId);

            if(category == null)
            {
                throw new Exception("Category doesnt exist");
            }

            var filmCategoryEntity = new FilmCategory()
            {
                CategoryId = categoryId,
                FilmId = filmId
            };

            await _context.FilmCategories.AddAsync(filmCategoryEntity);
            await _context.SaveChangesAsync();

            return filmCategoryEntity.Id;
        }

        public async Task DeleteCategoryFromFilm(int filmId, int categoryId)
        {
            var filmCategoryEntity = await _context.FilmCategories
                .FirstOrDefaultAsync(x => x.CategoryId == categoryId && x.FilmId == filmId);

            if(filmCategoryEntity != null)
            {
                _context.FilmCategories.Remove(filmCategoryEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
