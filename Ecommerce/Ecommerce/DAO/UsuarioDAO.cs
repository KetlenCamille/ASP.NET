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

        public bool Cadastrar(Usuario usuario)
        {
            if(BuscarUsuarioPorEmail(usuario) == null)
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return true;
            }
            return false;
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

        public Usuario Autenticar(Usuario usu)
        {
            return context.Usuarios.FirstOrDefault(x => x.Email.Equals(usu.Email) && x.Senha.Equals(usu.Senha));
        }
        /*foreach (Usuario usuario in ListarTodos())
        {
            if (usuario.Email.Equals(usu.Email) && usuario.Senha.Equals(usu.Senha))
            {
                return usuario;
            }
        }
        return false;*/

        public Usuario BuscarUsuarioPorEmail(Usuario usuario)
        {
            return context.Usuarios.FirstOrDefault(x => x.Email.Equals(usuario.Email));
        }

    }
}