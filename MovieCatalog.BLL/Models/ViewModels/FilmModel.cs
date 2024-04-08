using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.BLL.Models.ViewModels
{
    public class FilmModel : AbstractModel
    {
        public FilmModel(int id, string name, string director, DateTime release) : base(id)
        {
            Name = name;
            Director = director;
            Release = release;
        }

        public string Name { get; set; }
        public string Director { get; set; }
        public DateTime Release { get; set; }
        public virtual IReadOnlyList<string>? Categories { get; set; }

    }
}
