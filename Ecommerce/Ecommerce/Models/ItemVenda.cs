using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class ItemVenda
    {
        [Key]
        public int idItemVenda { get; set; }

        public Produto Produto { get; set; }

        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Display(Name ="Preço")]
        public double Preco { get; set; }

        public DateTime Data { get; set; }
    }
}