using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration
{
    public class TipoNotificacionConfiguration : IEntityTypeConfiguration<TipoNotificacion>
    {
        public void Configure(EntityTypeBuilder<TipoNotificacion> builder)
        {
            builder.ToTable("TipoNotificacion");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id);

            builder.Property(n => n.NombreTipo)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(f => f.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(f => f.FechaModificacion)
            .HasColumnType("datetime");

        }
    }
}