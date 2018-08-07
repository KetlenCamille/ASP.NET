using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }

        [Required(ErrorMessage ="Campo obrigatório!")]
        [Display(Name = "Nome do Código")]
        public string  Nome { get; set; }

        [Display(Name = "Descrição do código")]
        public string Descricao { get; set; }
    }
}