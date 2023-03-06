using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models
{
    public class CustomerIdRequest
    {
        [Required(ErrorMessage = "Por favor, informe o id do cliente.")]

        public int IdCustomer { get; set; }
    }
}