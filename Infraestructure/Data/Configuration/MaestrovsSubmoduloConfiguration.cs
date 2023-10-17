using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration;

public class MaestrovsSubmoduloConfiguration : IEntityTypeConfiguration<MaestrovsSubmodulo>
{
    public void Configure(EntityTypeBuilder<MaestrovsSubmodulo> builder)
    {
        builder.ToTable("MaestrovsSubmodulo");

        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id);

        builder.HasOne(e => e.ModulosMaestros)
        .WithMany(f => f.MaestrovsSubmodulos)
        .HasForeignKey(f => f.IdModuloMaestro);

        builder.HasOne(p => p.Submodulos)
        .WithMany(p => p.MaestrovsSubmodulos)
        .HasForeignKey(p => p.IdSubmodulo);

        builder.Property(f => f.FechaCreacion)
        .HasColumnType("datetime");

        builder.Property( f => f.FechaModificacion)
        .HasColumnType("datetime");
    }
}
