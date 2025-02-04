﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieCatalog.BLL.Interfaces;
using MovieCatalog.BLL.Models;
using MovieCatalog.BLL.Models.DtoModels;
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
        public async Task<int> AddAsync(AbstractModel model)
        {
            var filmModel = (FilmInputModel)model;

            var entitiy = _mapper.Map<Film>(filmModel);

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

        public async Task<IEnumerable<AbstractModel>> GetAllAsync()
        {
            var entities = await _context.Film
                .AsNoTracking()
                .Include(e => e.FilmCategories)
                    .ThenInclude(fc => fc.Category)
                .ToListAsync();

            var models = _mapper.Map<IEnumerable<FilmModel>>(entities);

            return models;
        }

        public async Task<AbstractModel> GetByIdAsync(int id)
        {
            var entitiy = await _context.Film
                .AsNoTracking()
                .Include(e => e.FilmCategories)
                    .ThenInclude(fc => fc.Category)
                .FirstOrDefaultAsync(e => e.Id == id);

            var model = _mapper.Map<FilmModel>(entitiy);

            return model;
        }

        public async Task UpdateAsync(AbstractModel model)
        {
            var filmModel = (FilmInputModel)model;

            var entity = await _context.Film
                .Where(e => e.Id == model.Id)
                .ExecuteUpdateAsync(e => e
                .SetProperty(x => x.Name, filmModel.Name)
                .SetProperty(x => x.Director, filmModel.Director)
                .SetProperty(x => x.Release, filmModel.Release));

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<int>> AddCategoryToFilm(int filmId, int[] categoryIds)
        {
            var film = await _context.Film.FindAsync(filmId);

            if(film == null)
            {
                throw new Exception("Film doesnt exist");
            }

            var FilmCategories = new List<FilmCategory>();

            foreach (int categoryId in categoryIds)
            {
                var category = await _context.Categories.FindAsync(categoryId);

                if (category == null)
                {
                    throw new Exception("Category doesnt exist");
                }

                var filmCategoryEntity = new FilmCategory()
                {
                    CategoryId = categoryId,
                    FilmId = filmId
                };

                FilmCategories.Add(filmCategoryEntity);
            }

            await _context.FilmCategories.AddRangeAsync(FilmCategories);
            await _context.SaveChangesAsync();

            return FilmCategories.Select(f => f.Id);
        }

        public async Task DeleteCategoryFromFilm(int filmId, int[] categoryIds)
        {
            var filmCategoryEntities = await _context.FilmCategories
                .Where(e => e.FilmId == filmId && categoryIds.Contains(e.CategoryId))
                .ToListAsync();

            _context.FilmCategories.RemoveRange(filmCategoryEntities);
            await _context.SaveChangesAsync();
        }
    }
}
