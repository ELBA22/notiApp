using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class GenericovsSubmodulo :BaseEntity
    {
        public PermisoGenerico PermisosGenericos {get; set;}
        public int IdPermisoGenerico {get; set;}

        public MaestrovsSubmodulo MaestrosvsSubmodulos {get; set;}
        public int IdMaestrovsSubmodulos {get; set;}

        public Rol Roles {get; set;}
        public int IdRoles {get; set;}
        
    }
}