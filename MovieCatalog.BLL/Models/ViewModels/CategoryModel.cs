using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieCatalog.BLL.Models.ViewModels
{
    public class CategoryModel : AbstractModel
    {
        public CategoryModel(int id, string name) : base(id)
        {
            Name = name;
        }
        public string Name { get; set; }
        public int FilmsCount { get; set; }
        [JsonIgnore]
        public CategoryModel? ParentCategory { get; set; }
        public virtual IReadOnlyList<CategoryModel>? ChildCategories { get; set; }
    }
}
