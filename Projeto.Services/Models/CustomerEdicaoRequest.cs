using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models
{
    public class CustomerEdicaoRequest
    {
        [Required(ErrorMessage = "Por favor, informe o id do cliente.")]
        public int IdCustomer { get; set; }


        [Required(ErrorMessage = "Por favor, informe o CPF do cliente.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do cliente.")]
        public DateTime DateOfBirth { get; set; }

    }
}