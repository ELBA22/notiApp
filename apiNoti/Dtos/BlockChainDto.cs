using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiNoti.Dtos
{
    public class BlockChainDto
    {
        public int Id {get; set;}
        public int IdHiloRespu {get; set;}

        public int IdTipoNotificacion {get; set;}

        public string HashGenerado {get; set;}

        public DateTime FechaCreacion {get; set;}

        public DateTime FechaModificacion {get; set;}
    }
}