using API07.Context;
using API07.Domains;
using API07.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API07.Repositories
{
    public class PedidoItemRepository : IPedidoItemRepository
    {
        private readonly PedidoContext _ctx;

        public PedidoItemRepository()
        {
            _ctx = new PedidoContext();
        }

       
    }
}
