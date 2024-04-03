using MovieCatalog.DAL.Data.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DAL.Data.Entities
{
    public class FilmCategory
    {
        public int Id { get; set; }
        public int FilmId {  get; set; }
        public Film Film { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
