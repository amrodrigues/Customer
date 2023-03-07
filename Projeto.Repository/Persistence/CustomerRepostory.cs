using Projeto.Entities;
using Projeto.Repository.Context;
using Projeto.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repository.Persistence
{
    public class CustomerRepostory : BaseRepository<Customer>, ICustomerRepository
    {
        public List<Customer> FindbyCPF(string cpf)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Customer
                        .Where(c => c.CPF.Equals(cpf))
                        .ToList();
            }

        }

        public List<Customer> FindbydateOfBirth(DateTime dateOfBirth)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Customer
                        .Where(c => c.DateOfBirth.Equals(dateOfBirth))
                        .ToList();
            }

        }
    }
}
