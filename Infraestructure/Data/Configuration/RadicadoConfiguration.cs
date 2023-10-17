using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration
{
    public class RadicadoConfiguration : IEntityTypeConfiguration<Radicado>
    {
        public void Configure(EntityTypeBuilder<Radicado> builder)
        {
            builder.ToTable("Radicado");

            builder.HasKey( i => i.Id);
            builder.Property( i => i.Id);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(f => f.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}