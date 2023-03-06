using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models
{
    public class CustomerConsultaResponse
    {
        public int IdCustomer { get; set; }
        public string CPF { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}