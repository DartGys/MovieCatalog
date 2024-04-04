using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DAL.Data.Entities
{
    [Table("categories")]
    public class Category
    {
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("parent_category_id")]
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }
        public virtual ICollection<FilmCategory> FilmCategories { get; set; }
    }
}
