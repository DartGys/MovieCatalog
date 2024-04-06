using System.Text.Json.Serialization;

namespace MovieCatalog.WebUI.Models
{
    public class CategoryVm
    {
        public string Name { get; set; }
        public int FilmsCount { get; set; }
        public virtual IReadOnlyList<CategoryVm>? ChildCategories { get; set; }
    }
}
