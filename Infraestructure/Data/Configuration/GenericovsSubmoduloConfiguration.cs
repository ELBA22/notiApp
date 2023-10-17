using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration;
public class GenericovsSubmoduloConfiguration : IEntityTypeConfiguration<GenericovsSubmodulo>
{
    public void Configure(EntityTypeBuilder<GenericovsSubmodulo> builder)
    {
        builder.ToTable("GenericovsSubmodulo");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id);

        builder.HasOne(p => p.PermisosGenericos)
        .WithMany(g => g.GenericovsSubmodulos)
        .HasForeignKey(i => i.IdPermisoGenerico);

        builder.HasOne(m => m.MaestrosvsSubmodulos)
        .WithMany(p => p.GenericovsSubmodulos)
        .HasForeignKey(i => i.IdMaestrovsSubmodulos);

        builder.HasOne(r => r.Roles)
        .WithMany(p => p.GenericovsSubmodulos)
        .HasForeignKey(i => i.IdRoles);

        builder.Property(f => f.FechaCreacion)
        .HasColumnType("datetime");
    }
}
