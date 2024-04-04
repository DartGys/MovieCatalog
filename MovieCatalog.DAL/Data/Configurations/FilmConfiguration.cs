using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieCatalog.DAL.Data.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.DAL.Data.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Director)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Release)
            .IsRequired();

            builder.HasMany(f => f.FilmCategories)
                .WithOne(fc => fc.Film)
                .HasForeignKey(fc => fc.FilmId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
