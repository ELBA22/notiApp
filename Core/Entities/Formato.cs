using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;
    public class Formato : BaseEntity
    {
        public string NombreFormato {get; set;}

        public ICollection<MNotificacion> ModuloNotificaciones {get; set;}
    }
