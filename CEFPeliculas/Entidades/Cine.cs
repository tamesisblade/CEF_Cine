﻿using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace CEFPeliculas.Entidades
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Point Ubicacion { get; set; }
        public CineOferta CineOferta { get; set; }
        public HashSet<SalaCine> SalasCines { get; set; }
    }
}
