using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.BLL.Models.DtoModels
{
    public class FilmInputModel : AbstractModel
    {
        public FilmInputModel(int id, string name, string director) : base(id)
        {
            Name = name;
            Director = director;
            Release = DateTime.UtcNow;
        }
        public string Name { get; set; }
        public string Director { get; set; }
        public DateTime Release { get; }
    }
}
