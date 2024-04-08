using Microsoft.Extensions.DependencyInjection;
using MovieCatalog.BLL.Common;
using MovieCatalog.BLL.Interfaces;
using MovieCatalog.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutomapperProfile).Assembly);

            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
