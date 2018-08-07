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

        [Display(Name ="Descrição do Produto")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Preço do Produto")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo dever conter no máximo 50 caracteres!")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [Display(Name = "Categoria do Produto")]
        public string Categoria { get; set; }

        public string Imagem { get; set; }
    }
}