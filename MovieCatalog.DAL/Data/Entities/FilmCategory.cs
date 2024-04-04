using MovieCatalog.DAL.Data.Entitie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DAL.Data.Entities
{
    [Table("film_categories")]
    public class FilmCategory
    {
        public int Id { get; set; }
        [Column("film_id")]
        public int FilmId {  get; set; }
        public Film Film { get; set; }
        [Column("category_id")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
