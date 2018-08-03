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
        Context context = new Context();
        public void Cadastrar(Produto produto)
        {
            if (produto != null)
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
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
    }
}