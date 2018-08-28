using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ecommerce.DAO
{
    public class Context : DbContext
    {
        public Context() : base("dbEcommerce")
        {

        }

        //Mapeamento das classes (que vão virar tabela no banco)
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<ItemVenda> ItensVenda { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Venda> Vendas { get; set; }
    }
}