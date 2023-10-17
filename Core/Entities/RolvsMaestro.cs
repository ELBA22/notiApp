using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class RolvsMaestro : BaseEntity
    {
        public Rol Roles {get; set;}

        public int IdRol {get; set;}

        public MMaestro ModulosMaestros {get; set;}
        public int IdMMaestro {get; set;}
        public object IdMaestro { get; set; }
    }
}