using Ecommerce.Controllers;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.DAO
{
    public class VendaDAO
    {
        private static Context context = Singleton.GetInstance();

        public bool Cadastrar(Venda venda)
        {
            if(venda != null)
            {
                context.Vendas.Add(venda);
                context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}