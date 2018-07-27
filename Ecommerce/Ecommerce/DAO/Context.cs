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
    }
}