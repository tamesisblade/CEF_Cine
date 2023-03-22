using CEFPeliculas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CEFPeliculas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
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
            modelBuilder.Entity<Actor>().Property(p => p.fechaNacimiento)
                .HasColumnType("date")
                
                ;
            //Cine Api Fluente
            modelBuilder.Entity<Cine>().Property(p => p.Nombre)
                .HasMaxLength(150)
                .IsRequired()
                ;
            modelBuilder.Entity<Cine>().Property(p => p.Precio)
                .HasPrecision(precision:9,scale:2)
                ;
            //TABLAS
            modelBuilder.Entity<Genero>().ToTable(name: "tblGenero", schema: "Cine");
            modelBuilder.Entity<Actor>().ToTable(name: "tblActor", schema: "Cine");
            modelBuilder.Entity<Cine>().ToTable(name: "tblCine", schema: "Cine");
        }
        //modelos
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
    }
}
