using Ecommerce.Controllers;
using Ecommerce.DAO;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.DAO
{
    public class ProdutoDAO
    {
        private static Context context = Singleton.GetInstance();
        public bool Cadastrar(Produto produto)
        {
            if ( BuscarPorNome(produto) == null )
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Produto> ListarTodos()
        {
            return context.Produtos.ToList();
        }

        public void Editar(Produto produto)
        {
            if (produto != null)
            {
                context.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Excluir(int idProduto)
        {
            context.Produtos.Remove(BuscarPorId(idProduto));
            context.SaveChanges();
        }

        public Produto BuscarPorId(int id)
        {
            return context.Produtos.Find(id);
        }

        public Produto BuscarPorNome(Produto produto)
        {
            return context.Produtos.FirstOrDefault(x => x.Nome.Equals(produto.Nome));
        }
    }
}