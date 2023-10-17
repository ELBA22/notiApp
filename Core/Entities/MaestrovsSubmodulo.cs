using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class MaestrovsSubmodulo : BaseEntity
    {
        public MMaestro ModulosMaestros {get; set;}
        public int IdModuloMaestro {get; set;}

        public Submodulo Submodulos {get; set;}
        public int IdSubmodulo {get; set;}

        public ICollection<GenericovsSubmodulo> GenericovsSubmodulos {get; set;}
    }
}