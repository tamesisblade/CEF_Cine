using CEFPeliculas.Entidades;
using CEFPeliculas.Entidades.Configuraciones;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
            //API FLUENTE GENERO CONFIG
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //Cine Api Fluente
            /*     modelBuilder.Entity<Cine>().Property(p => p.Nombre)
                    .HasMaxLength(150)
                    .IsRequired()
                    ;*/
       
            
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
