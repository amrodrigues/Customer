using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace Projeto.Services.Models
{
    public class CustomerCadastroRequest
    {
        [Required(ErrorMessage ="Por favor, informe o CPF do cliente.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string Name { get; set; }

       [Required(ErrorMessage = "Por favor, informe a data de nascimento do cliente.")]
       [DataType(DataType.Date)]

        public DateTime DateOfBirth { get; set; }
    }
}