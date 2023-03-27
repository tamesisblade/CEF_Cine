﻿namespace CEFPeliculas.Entidades
{
    public class SalaCine
    {
        public int Id { get; set; }
        public TipoSalaCine TipoSalaCine { get; set; }
        public decimal Precio { get; set; }
        public int CineId { get; set; }
        public Cine Cine { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }
    }
}
