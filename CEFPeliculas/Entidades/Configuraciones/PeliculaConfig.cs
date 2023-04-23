using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CEFPeliculas.Entidades.Configuraciones
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.Property(p => p.Titulo)
              .HasMaxLength(250)
              .IsRequired()
              ;
            builder.Property(p => p.PosterURL)
              .HasMaxLength(500)
              .IsUnicode(false)
              ;
        }
    }
}
