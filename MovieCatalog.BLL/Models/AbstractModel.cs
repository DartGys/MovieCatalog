using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.BLL.Models
{
    public abstract class AbstractModel
    {
        public AbstractModel(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
