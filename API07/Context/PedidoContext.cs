﻿using API07.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API07.Context
{
    public class PedidoContext : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=.\SqlExpress; Initial Catalog=Db_Produtos; user id=sa; password=sa132");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
