using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiNoti.Dtos
{
    public class ModuloNotificacionDto
    {
        public int Id {get, set;}
        public string AsuntoNotificacion {get; set;}
        public int IdTipoNotificacion {get; set;}
        public int IRadicado {get; set;}
        public int IEstadovsNotificacion {get; set;}
        public int IdHiloRespu {get; set;}
        public int IdFormato{get; set;}
        public int IdTipoRequerimiento {get; set;}
        public string TextoNotificacion {get; set;}
        public DateTime FechaCreacion {get; set;}
        public DateTime FechaModificacion {get; set;}

    }
}