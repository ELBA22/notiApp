using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration;
public class ModuloMaestroConfiguration : IEntityTypeConfiguration<MMaestro>
{
    public void Configure(EntityTypeBuilder<MMaestro> builder)
    {
        builder.ToTable("ModuloMaestro");

        builder.HasKey( I => I.Id);
        builder.Property(I => I.Id);

        builder.Property( p => p.NombreModulo)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(f => f.FechaCreacion)
        .HasColumnType("datetime");

        builder.Property( f => f.FechaModificacion)
        .HasColumnType("datetime");
    }
}