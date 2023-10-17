using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class MNotificacion : BaseEntity
    {
        public string AsuntoNotificacion {get; set;}

        public TipoNotificacion TipoNotificaciones {get; set;}
        public int IdTipoNotificacion {get; set;}

        public Radicado Radicados {get; set;}
        public int IdRadicado {get; set;}

        public EstadovsNotificacion EstadosvsNotificaciones {get; set;}
        public int IdEstadoNotificacion {get; set;}

        public  HiloRespu HiloRespuestas {get; set;}
        public int IdHiloRespu {get; set;}

        public Formato Formatos {get; set;}
        public int IdFormato {get; set;}

        public TipoRequerimiento TiposRequerimientos {get; set;}
        public int IdTipoRequerimiento {get; set;}

        public string TextoNotificacion {get; set;}
        
    }
}