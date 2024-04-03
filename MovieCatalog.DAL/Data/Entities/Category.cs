using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DAL.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
        // Навігаційна властивість для відношення "батьківська категорія"
        public virtual Category ParentCategory { get; set; }

        // Навігаційна властивість для відношення "дочірні категорії"
        public virtual ICollection<Category> ChildCategories { get; set; }
        public virtual ICollection<FilmCategory> FilmCategories { get; set; }
    }
}
