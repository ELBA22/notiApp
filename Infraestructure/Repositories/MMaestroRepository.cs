using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Infrastructure.Repositories;

namespace Infraestructure.Repositories
{
    public class MMaestroRepository : GenericRepository<MMaestro>, IModuloMaestro
    {
        private readonly notiAppContext _context;
        public MMaestroRepository(notiAppContext context) : base(context)
        {
            _context = context;
        }
    }
}