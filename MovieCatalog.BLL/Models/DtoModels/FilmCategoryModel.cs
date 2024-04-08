using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.BLL.Models.DtoModels
{
    public class FilmCategoryModel
    {
        public int FilmId {  get; set; }
        public int[] CategoryIds {  get; set; }
    }
}
