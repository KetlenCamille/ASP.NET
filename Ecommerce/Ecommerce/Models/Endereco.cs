using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Endereco
    {
        [Key]
        public int idEndereco { get; set; }

        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public string Localidade { get; set; }

        public string UF { get; set; }
    }
}