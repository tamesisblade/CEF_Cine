using CEFPeliculas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CEFPeliculas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        //Convenciones
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }
        //api fluente
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Genero API FLUENTE
            modelBuilder.Entity<Genero>().HasKey(p => p.Id);
            modelBuilder.Entity < Genero> ().Property(p => p.Nombre)
                .HasMaxLength(150)
                .IsRequired()
                .HasColumnName("NombreGenero")
             ;
            //Actor Api Fluente
            modelBuilder.Entity<Actor>().HasKey(p => p.Id);
            modelBuilder.Entity<Actor>().Property(p => p.Nombre)
                .HasMaxLength(150)
                .IsRequired()
            ;
            //Cine Api Fluente
            modelBuilder.Entity<Cine>().Property(p => p.Nombre)
                .HasMaxLength(150)
                .IsRequired()
                ;
     
            //Peliculas Api Fluente
            modelBuilder.Entity<Pelicula>().Property(p => p.Titulo)
                .HasMaxLength(250)
                .IsRequired()
                ;
            ///modelBuilder.Entity<Pelicula>().Property(p => p.FechaEstreno)
               // .HasColumnType("date")
               // ;
            modelBuilder.Entity<Pelicula>().Property(p => p.PosterURL)
                .HasMaxLength(500)
                .IsUnicode(false)
                ;
            //CineOferta Api Fluente
            modelBuilder.Entity<CineOferta>().Property(p => p.PorcentajeDescuento)
                .HasPrecision(precision: 5, scale: 2);
            //SALA CINES API FLUENTE
            modelBuilder.Entity<SalaCine>().Property(p => p.Precio)
             .HasPrecision(precision: 9, scale: 2)
             ;
            modelBuilder.Entity<SalaCine>().Property(p => p.TipoSalaCine)
                .HasDefaultValue(TipoSalaCine.DosDimensiones);
            //PELICULA ACTOR API FLUENTE
            modelBuilder.Entity<PeliculaActor>().HasKey(p => new { p.PeliculaId, p.ActorId });
            modelBuilder.Entity<PeliculaActor>().Property(p => p.Personaje)
                .HasMaxLength(150);
            
            //TABLAS
            modelBuilder.Entity<Genero>().ToTable(name: "tblGenero", schema: "Cine");
            modelBuilder.Entity<Actor>().ToTable(name: "tblActor", schema: "Cine");
            modelBuilder.Entity<Cine>().ToTable(name: "tblCine", schema: "Cine");
            modelBuilder.Entity<Pelicula>().ToTable(name: "tblPeliculas", schema: "Cine");
            modelBuilder.Entity<CineOferta>().ToTable(name: "TblCineOferta", schema: "Cine");
            modelBuilder.Entity<SalaCine>().ToTable(name: "tblSalaCines", schema: "Cine");
        }
        //modelos
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<CineOferta> CinesOfertas { get; set; }
        public DbSet<SalaCine> SalasCines { get; set; }
        public DbSet<PeliculaActor> PeliculasActores { get; set; }
    }
}
