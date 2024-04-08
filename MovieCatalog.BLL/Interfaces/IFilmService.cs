using MovieCatalog.BLL.Models;
using MovieCatalog.BLL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.BLL.Interfaces
{
    public interface IFilmService : ICrud<AbstractModel>
    {
        Task<IEnumerable<int>> AddCategoryToFilm(int filmId, int[] categoryIds);
        Task DeleteCategoryFromFilm(int filmId, int[] categoryIds);
    }
}
