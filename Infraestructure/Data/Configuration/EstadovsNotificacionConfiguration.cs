using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration;

public class EstadovsNotificacionConfiguration : IEntityTypeConfiguration<EstadovsNotificacion>
{
    public void Configure(EntityTypeBuilder<EstadovsNotificacion> builder)
    {
        builder.ToTable("EstadoNotificacion");

        builder.HasKey(e => e.Id);
        builder.Property(p => p.Id);

        builder.Property(n => n.NombreEstado)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(f => f.FechaCreacion)
        .HasColumnType("datetime");

        builder.Property(p => p.FechaModificacion)
        .HasColumnType("datetime");
    }
}
