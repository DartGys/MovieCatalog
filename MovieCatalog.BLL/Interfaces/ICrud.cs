using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.BLL.Interfaces
{
    public interface ICrud<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAllAsync();

        Task<TModel> GetByIdAsync(int id);

        Task<Guid> AddAsync(int model);

        Task<TModel> UpdateAsync(TModel model);

        Task DeleteAsync(int modelId);
    }
}
