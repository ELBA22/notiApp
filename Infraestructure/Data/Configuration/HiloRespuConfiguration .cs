using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration;

public class HiloRespuConfiguration : IEntityTypeConfiguration<HiloRespu>
{
    public void Configure(EntityTypeBuilder<HiloRespu> builder)
    {
        builder.ToTable("HiloRespuesta");

        builder.HasKey(i => i.Id);
        builder.Property(p => p.Id);

        builder.Property(p => p.NombreTipo)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property( p => p.FechaCreacion)
        .HasColumnType("datetime");

        builder.Property(f => f.FechaModificacion)
        .HasColumnType("datetime");
    }
}
