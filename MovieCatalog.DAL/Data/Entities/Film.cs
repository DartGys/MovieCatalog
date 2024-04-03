using MovieCatalog.DAL.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DAL.Data.Entitie
{
    [Table("films")]
    public class Film
    {
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("director")]
        public string Director { get; set; }
        [Column("release")]
        public DateTime Release { get; set; }
        public virtual ICollection<FilmCategory> FilmCategories { get; set; }
    }
}
