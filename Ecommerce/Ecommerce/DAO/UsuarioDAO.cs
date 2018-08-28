using Ecommerce.Controllers;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.DAO
{
    public class UsuarioDAO
    {
        private Context context = Singleton.GetInstance();

        public void Cadastrar(Usuario usuario)
        {
            if(usuario != null)
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        }

        public List<Usuario> ListarTodos()
        {
            return context.Usuarios.ToList();
        }

        public void Atualizar (Usuario usuario)
        {
            if (usuario != null)
            {
                context.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        
        public void Excluir (int id)
        {
            context.Usuarios.Remove(BuscarPorId(id));
            context.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return context.Usuarios.Find(id);
        }

        public bool Autenticar(string email, string senha)
        {

            foreach (Usuario usuario in ListarTodos())
            {
                if (usuario.Email.Equals(email) && usuario.Senha.Equals(senha))
                {
                    return true;
                }
            }
            return false;
        }
    }
}