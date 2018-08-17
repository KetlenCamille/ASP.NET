using Ecommerce.Controllers;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.DAO
{
    public class ItemVendaDAO
    {
        private static Context context = Singleton.GetInstance();
        public void AdicionarItem(ItemVenda item)
        {
            if(item != null)
            {
                context.ItensVenda.Add(item);
                context.SaveChanges();
            }
        }

        public List<ItemVenda> ListarTodos()
        {
            return context.ItensVenda.ToList();
        }
        public void Remover(int id)
        {
            context.ItensVenda.Remove(BuscarPorId(id));
        }
        
        public ItemVenda BuscarPorId(int id)
        {
            return context.ItensVenda.Find(id);
        } 
    }
}