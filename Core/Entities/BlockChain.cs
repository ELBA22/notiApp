using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BlockChain : BaseEntity
    {
        public string hashGenerado {get; set;}
        public HiloRespu HilosRespuestas {get; set;}
        public int IdHiloRespu {get; set;}
        public Auditoria Auditorias {get; set;}
        public int IdAuditoria {get; set;}
        public TipoNotificacion TipoNotificaciones {get; set;}
        public int IdTipoNotificacion {get; set;}
    }
}