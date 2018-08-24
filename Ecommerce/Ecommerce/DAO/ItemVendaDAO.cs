using Ecommerce.Controllers;
using Ecommerce.Models;
using Ecommerce.Utils;
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
        public void Atualizar (ItemVenda item)
        {
            if(item != null)
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Remover(int? id)
        {
            context.ItensVenda.Remove(BuscarPorId(id));
            context.SaveChanges();
        }
        
        public ItemVenda BuscarPorId(int? id)
        {
            return context.ItensVenda.Find(id);
        }

        public List<ItemVenda> ListarPorCarrinho(string guid)
        {
            return context.ItensVenda.Include("Produto").Where(xx => xx.CarrinhoId.Equals(guid)).ToList();
        }

        public int QuantidadeItensCarrinho()
        {
            int quantidade = 0;
            foreach (ItemVenda item in ListarPorCarrinho(Sessao.RetornarCarrinhoId().ToString()))
            {
                quantidade += item.Quantidade;
            }
            return quantidade;
        }
    }
}