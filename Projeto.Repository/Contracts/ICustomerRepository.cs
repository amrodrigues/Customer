using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repository.Contracts
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        List<Customer> FindbyCPF(string cpf);
        List<Customer> FindbydateOfBirth(DateTime dateOfBirth);
    }
}
