using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiNoti.Dtos;
    public class MaestrovsSubmoduloDto
    {
        public int Id {get; set;}
        public int IdModuloMaestro {get; set;}

        public int IdSubmodulo {get; set;}

        public DateTime FechaCreacion {get; set;}
        
        public DateTime FechaModificacion {get; set;}
    }