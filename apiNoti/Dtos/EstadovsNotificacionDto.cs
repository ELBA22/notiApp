using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiNoti.Dtos
{
    public class EstadovsNotificacionDto
    {
        public int Id {get; set;}
        public string NombreEstado {get; set;}

        public DateTime FechaCreacion {get; set;}

        public DateTime FechaModificacion {get; set;}

    }
}