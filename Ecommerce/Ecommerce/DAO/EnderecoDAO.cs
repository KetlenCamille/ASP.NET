using Ecommerce.Controllers;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.DAO
{
    public class EnderecoDAO
    {
        public class CategoriaDAO
        {
            private Context context = Singleton.GetInstance();

            public bool Cadastrar(Endereco endereco)
            {
                if (endereco != null)
                {
                    context.Enderecos.Add(endereco);
                    context.SaveChanges();
                }
                return false;
            }

            public List<Endereco> ListarTodos()
            {
                return context.Enderecos.ToList();
            }

            public void Editar(Endereco endereco)
            {
                if (endereco != null)
                {
                    context.Entry(endereco).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }

            public void Excluir(int id)
            {
                context.Enderecos.Remove(BuscarPorId(id));
                context.SaveChanges();
            }

            public Endereco BuscarPorId(int? id)
            {
                return context.Enderecos.Find(id);
            }
        }
    }
}