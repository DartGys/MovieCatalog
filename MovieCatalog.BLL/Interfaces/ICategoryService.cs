using MovieCatalog.BLL.Models;
using MovieCatalog.BLL.Models.DtoModels;
using MovieCatalog.BLL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.BLL.Interfaces
{
    public interface ICategoryService : ICrud<AbstractModel>
    {
        Task<IEnumerable<CategoryNameModel>> GetCategoryName();
    }
}
