using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        public string DescricaoProduto { get; set; }

        public double PrecoProduto { get; set; }

        public string NomeProduto { get; set; }

        public string CategoriaProduto { get; set; }

        public string ImagemProduto { get; set; }
    }
}