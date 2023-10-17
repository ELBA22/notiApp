using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data;

public class notiAppContext : DbContext
{
    public notiAppContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Auditoria> Auditorias {get; set;}
    public DbSet<BlockChain> BlockChains {get; set;}
    public DbSet<EstadovsNotificacion> EstadoNotificaciones {get; set;}
    public DbSet<Formato> Formatos {get; set;}
    public DbSet<GenericovsSubmodulo> GenericosvsSubmodulos {get; set;}
    public DbSet<HiloRespu> HilosRepuestas {get; set;}
    public DbSet<MaestrovsSubmodulo> MaestrosvsSubmodulos {get; set;}
    public DbSet<MMaestro> ModulosMaestros {get; set;}
    public DbSet<MNotificacion> ModulosNotificaciones {get; set;}
    public DbSet<PermisoGenerico> PermisosGenericos {get; set;}
    public DbSet<Radicado> Radicados {get; set;}
    public DbSet<Rol> Roles {get; set;}
    public DbSet<RolvsMaestro> RolesvsMaestros {get; set;}
    public DbSet<Submodulo> Submodulos {get; set;}
    public DbSet<TipoNotificacion> TipoNotificaciones {get; set;}
    public DbSet<TipoRequerimiento> TipoRequerimientos {get; set;}

}
