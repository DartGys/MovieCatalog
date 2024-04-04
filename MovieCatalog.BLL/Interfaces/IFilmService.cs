using MovieCatalog.BLL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.BLL.Interfaces
{
    public interface IFilmService : ICrud<FilmModel>
    {
        Task<int> AddCategoryToFilm(int filmId, int categoryId);
        Task DeleteCategoryFromFilm(int filmId, int categoryId);
    }
}
