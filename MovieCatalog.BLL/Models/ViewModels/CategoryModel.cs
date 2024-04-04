﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.BLL.Models.ViewModels
{
    public class CategoryModel : AbstractModel
    {
        public CategoryModel(int id, string name, int filmsCount, IReadOnlyList<CategoryModel> childcategories, CategoryModel parentCategory) : base(id)
        {
            Name = name;
            FilmsCount = filmsCount;
            ChildCategories = childcategories;
            ParentCategory = parentCategory;
        }
        public string Name { get; set; }
        public int FilmsCount { get; set; }
        public CategoryModel ParentCategory { get; set; }
        public IReadOnlyList<CategoryModel> ChildCategories { get; set; }
    }
}
