using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAuditoria Auditorias {get;}
        IBlockChain BlockChains {get;}
        IEstadovsNotificacion EstadovsNotificaciones {get;}
        IFormato Formatos {get;}
        IGenericovsSubmodulo GenericovsSubmodulos {get;}
        IHiloRespuesta HiloRespuestas {get;}
        IMaestrovsSubmodulo MaestrovsSubmodulos {get;}
        IModuloMaestro ModulosMaestros {get;}
        IModuloNotificacion ModulosNotificaciones {get;}
        IPermisoGenerico PermisosGenericos {get;}
        IRadicado Radicados {get;}
        IRol Roles {get;}
        IRolvsMaestro RolvsMaestros {get;}
        ISubmodulo Submodulos {get;}
        ITipoNotificacion TipoNotificaciones {get;}
        ITipoRequerimiento TipoRequerimientos {get;}

        Task<int> SaveAsync();

    }
}