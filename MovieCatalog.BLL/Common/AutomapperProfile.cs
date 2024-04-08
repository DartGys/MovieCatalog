using AutoMapper;
using MovieCatalog.BLL.Models.DtoModels;
using MovieCatalog.BLL.Models.ViewModels;
using MovieCatalog.DAL.Data.Entitie;
using MovieCatalog.DAL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.BLL.Common
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Film, FilmModel>()
                .ForMember(fm => fm.Categories, f => f.MapFrom(x => x.FilmCategories.Select(fc => fc.Category.Name) ?? null));

            CreateMap<Category, CategoryModel>()
                .ForMember(cm => cm.FilmsCount, f => f.MapFrom(x => x.FilmCategories.Count));

            CreateMap<CategoryInputModel, Category>();

            CreateMap<FilmInputModel, Film>();

            CreateMap<Category, CategoryNameModel>();
        }
    }
}
