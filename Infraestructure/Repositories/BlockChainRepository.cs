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
    public class BlockChainRepository :GenericRepository<BlockChain>, IBlockChain
    {
        private readonly notiAppContext _context;

        public BlockChainRepository(notiAppContext context) : base(context)
        {
            _context = context;
        }
    }
}