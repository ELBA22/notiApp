using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;

namespace Infrastructure.Repositories 
{
    public class AuditoriaRepository : GenericRepository<Auditoria>, IAuditoria
    {
        private readonly notiAppContext _context;
        public AuditoriaRepository(notiAppContext context) : base(context)
        {
            _context = context;
        }
    }
}