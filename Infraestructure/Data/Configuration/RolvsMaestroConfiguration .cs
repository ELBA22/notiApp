using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration
{
    public class RolvsMaestroConfiguration : IEntityTypeConfiguration<RolvsMaestro>
    {
        public void Configure(EntityTypeBuilder<RolvsMaestro> builder)
        {
            builder.ToTable("RolvsMaestro");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id);

            builder.HasOne(r => r.Roles)
            .WithMany(r => r.RolesvsMaestros)
            .HasForeignKey(r => r.IdMaestro);

            builder.Property(f => f.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(f => f.FechaModificacion)
            .HasColumnType("datetime");


        }
    }
}