using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBusiness.Contracts
{
    public interface ICustomerBusiness : IBaseBusiness<Customer>
    {
        List<Customer> ConsultaPorCPF(string cpf);

        List<Customer> ConsultarporDtNasc(DateTime dateOfBirth);
    }
}
