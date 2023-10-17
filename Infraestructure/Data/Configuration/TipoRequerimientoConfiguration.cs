using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration
{
    public class TipoRequerimientoConfiguration : IEntityTypeConfiguration<TipoRequerimiento>
    {
        public void Configure(EntityTypeBuilder<TipoRequerimiento> builder)
        {
            builder.ToTable("TipoRequerimiento");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id);

            builder.Property( n => n.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(f => f.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(f => f.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}