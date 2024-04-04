using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.BLL.Models.ViewModels
{
    public class FilmModel : AbstractModel
    {
        public FilmModel(int id, string name, string director, DateTime release, List<string> categories) : base(id)
        {
            Name = name;
            Director = director;
            Release = release;
            Categories = categories;
        }

        public string Name { get; set; }
        public string Director { get; set; }
        public DateTime Release { get; set; }
        public List<string> Categories { get; set; }

    }
}
