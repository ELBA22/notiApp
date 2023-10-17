using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EstadovsNotificacion : BaseEntity
    {
        public string NombreEstado {get; set;}

        public ICollection<MNotificacion> ModuloNotificaciones {get; set;}
    }
}