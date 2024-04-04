﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.BLL.Models.DtoModels
{
    public class CategoryInputModel : AbstractModel
    {
        public CategoryInputModel(int id, string name, int parentCategoryId, ICollection<int> childCategoryIds) : base(id)
        {
            Name = name;
            ParentCategoryId = parentCategoryId;
            ChildCategoryIds = childCategoryIds;
        }

        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
        public virtual ICollection<int> ChildCategoryIds { get; set; }
    }
}
