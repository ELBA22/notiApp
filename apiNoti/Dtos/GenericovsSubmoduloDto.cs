using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiNoti.Dtos
{
    public class GenericovsSubmoduloDto
    {
        public int Id {get; set;}

        public int IdPermisoGenerico {get; set;}

        public int IdMaetsrovsSubmodulos {get; set;}

        public int IdRol {get; set;}

        public DateTime FechaCreacion {get; set;}
        public DateTime FechaModificacion {get; set;}
    }
}