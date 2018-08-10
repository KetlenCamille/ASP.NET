using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecommerce.Models;
using Ecommerce.Controllers;

namespace Ecommerce.DAO
{
    public class CategoriaDAO
    {
        private Context context = Singleton.GetInstance();

        public bool Cadastrar(Categoria categoria)
        {
            if(BuscarPorNome(categoria) == null)
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
            return false;
        }

        public List<Categoria> ListarTodos()
        {
            return context.Categorias.ToList();
        }

        public void Editar(Categoria categoria)
        {
            if (categoria != null)
            {
                context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Excluir(int idCategoria)
        {
            context.Categorias.Remove(BuscarPorId(idCategoria));
            context.SaveChanges();
        }

        public Categoria BuscarPorId(int? id)
        {
            return context.Categorias.Find(id);
        } 

        public Categoria BuscarPorNome(Categoria categoria)
        {
            return context.Categorias.FirstOrDefault(x => x.Nome.Equals(categoria.Nome));
        }
    }
}