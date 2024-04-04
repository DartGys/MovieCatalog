using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieCatalog.DAL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DAL.Data.Configurations
{
    public class FilmCategoryConfiguration : IEntityTypeConfiguration<FilmCategory>
    {
        public void Configure(EntityTypeBuilder<FilmCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(fc => fc.Film)
            .WithMany(f => f.FilmCategories)
            .HasForeignKey(fc => fc.FilmId);

            builder.HasOne(fc => fc.Category)
                .WithMany(c => c.FilmCategories)
                .HasForeignKey(fc => fc.CategoryId);
        }
    }
}
