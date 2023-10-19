using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration;

public class AuditoriaConfiguration : IEntityTypeConfiguration<Auditoria>
{
        public void Configure(EntityTypeBuilder<Auditoria> builder)
        {
            builder.ToTable("Auditoria");

            builder.HasKey(i =>i.Id);
            builder.Property(e =>e.Id);

            builder.Property(n =>n.NombreUsuario)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.DesAccion)
            .IsRequired()
            .HasColumnType("int"); 

            builder.Property(f => f.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
