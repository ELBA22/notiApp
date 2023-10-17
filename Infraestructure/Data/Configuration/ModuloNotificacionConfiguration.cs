using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration;
public class ModuloNotificacionConfiguration : IEntityTypeConfiguration<MNotificacion>
{
    public void Configure(EntityTypeBuilder<MNotificacion> builder)
    {
        builder.ToTable("ModuloNotificacion");

        builder.HasKey(i => i.Id);
        builder.Property( i => i.Id);

        builder.Property(e => e.AsuntoNotificacion)
        .IsRequired()
        .HasMaxLength(100);

        builder.HasOne(p => p.TipoNotificaciones)
        .WithMany(p => p.ModuloNotificaciones)
        .HasForeignKey(p => p.IdTipoNotificacion);

        builder.HasOne(f => f.Radicados)
        .WithMany(f => f.ModuloNotificaciones)
        .HasForeignKey( f => f.IdRadicado);

        builder.HasOne(e => e.EstadosNotificaciones)
        .WithMany(e => e.ModuloNotificaciones)
        .HasForeignKey(e => e.IdEstadoNotificacion);

        builder.HasOne(h => h.HiloRespuestas)
        .WithMany(h => h.ModuloNotificaciones)
        .HasForeignKey(h => h.IdHiloRespu);

        builder.HasOne(f => f.Formatos)
        .WithMany(f => f.ModuloNotificaciones)
        .HasForeignKey(f => f.IdFormato);

        builder.HasOne(t => t.TiposRequerimientos)
        .WithMany(t => t.ModuloNotificaciones)
        .HasForeignKey(t => t.IdTipoRequerimiento);

        builder.Property(p => p.TextoNotificacion)
        .IsRequired()
        .HasMaxLength(300);

        builder.Property(f => f.FechaCreacion)
        .HasColumnType("datetime");

        builder.Property( f => f.FechaModificacion)
        .HasColumnType("datetime");
    }
}
