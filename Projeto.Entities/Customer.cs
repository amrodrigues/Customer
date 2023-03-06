using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public string CPF { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }


        public Customer() { }

        public Customer(int idCustomer, string cpf, string name, DateTime dateOfBirth)
        {
            IdCustomer = idCustomer;
            CPF = cpf;
            Name = name;
            DateOfBirth = dateOfBirth;
        }

    }
}
