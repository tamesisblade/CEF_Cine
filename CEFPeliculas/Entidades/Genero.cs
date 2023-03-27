using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CEFPeliculas.Entidades
{
    [Table("tblGeneros",Schema ="Cine")]
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        //[StringLength(150)]
        //[MaxLength(150)]
        // [Required]
        //[Column("NombreGenero")]
        public string Nombre { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }

    }
}
