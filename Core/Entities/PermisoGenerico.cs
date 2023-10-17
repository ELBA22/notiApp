using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class PermisoGenerico : BaseEntity
    {
        public string NombrPermiso {get; set;}

        public ICollection<GenericovsSubmodulo> GenericovsSubmodulos {get; set;}
        
    }
}