﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CEFPeliculas.Entidades.Configuraciones
{
    public class SalaCineConfig : IEntityTypeConfiguration<SalaCine>
    {
        public void Configure(EntityTypeBuilder<SalaCine> builder)
        {
            builder.Property(p => p.Precio)
            .HasPrecision(precision: 9, scale: 2)
            ;
            builder.Property(p => p.TipoSalaCine)
                .HasDefaultValue(TipoSalaCine.DosDimensiones);
        }
    }
}
