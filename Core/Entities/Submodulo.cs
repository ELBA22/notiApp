using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Submodulo : BaseEntity
    {
        public string NombreSubModulo {get; set;}

        public ICollection<MaestrovsSubmodulo> maestrovsSubmodulos {get; set;}
        public object MaestrovsSubmodulos { get; set; }
    }
}