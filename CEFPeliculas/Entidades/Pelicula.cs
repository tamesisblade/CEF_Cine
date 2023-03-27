namespace CEFPeliculas.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string PosterURL { get; set; }
        //muchos a muchos
        public HashSet<Genero> Generos { get; set; }
        public HashSet<SalaCine> SalasCines { get; set; }
        public HashSet<PeliculaActor> PeliculasActores { get; set; }
    }
}
