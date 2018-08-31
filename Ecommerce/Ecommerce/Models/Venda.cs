using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Venda
    {
        [Key]
        public int idVenda { get; set; }

        public Usuario usuario { get; set; }

        public string CarrinhoId { get; set; }

        public List<ItemVenda> ItensVenda { get; set; }
    }
}