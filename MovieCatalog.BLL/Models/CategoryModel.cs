using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.BLL.Models
{
    public class CategoryModel
    {
        public CategoryModel(int id, string name, int filmsCount, IReadOnlyList<CategoryModel> categories)
        {
            Id = id;
            Name = name;
            FilmsCount = filmsCount;
            Categories = categories;

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int FilmsCount { get; set; }
        public IReadOnlyList<CategoryModel> Categories { get; set; }
    }
}
