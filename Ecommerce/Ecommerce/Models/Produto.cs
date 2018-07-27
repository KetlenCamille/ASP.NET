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

        public string Descricao { get; set; }

        public double Preco { get; set; }

        public string Nome { get; set; }

        public string Categoria { get; set; }

        public string Imagem { get; set; }
    }
}