using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration;

public class BlockChainConfiguration : IEntityTypeConfiguration<BlockChain>
{
    public void Configure(EntityTypeBuilder<BlockChain> builder)
    {
        builder.ToTable("BlockChain"); //Nombre de la tabla= ToTable

        builder.HasKey(e => e.Id); //Haskey para decir cual es llave primaria
        builder.Property(e => e.Id);

        builder.Property(p => p.hashGenerado) //Property palabra que toma como string
        .IsRequired() //Requerido
        .HasMaxLength(100);//Longitud de la palabra

        builder.HasOne(e => e.HilosRespuestas) //HasOne se usa para indicar que es una referencia
        .WithMany(p => p.BlockChains)
        .HasForeignKey(p => p.IdHiloRespu);

        builder.HasOne(e => e.Auditorias)
        .WithMany(p => p.BlockChains)
        .HasForeignKey(p => p.IdAuditoria);

        builder.HasOne(p => p.TipoNotificaciones)
        .WithMany(p => p.BlockChains)
        .HasForeignKey(p => p.IdTipoNotificacion);

        builder.Property(p => p.FechaCreacion)
        .HasColumnType("datetime");

        builder.Property(p => p.FechaModificacion)
        .HasColumnType("datetime");

    }
}
