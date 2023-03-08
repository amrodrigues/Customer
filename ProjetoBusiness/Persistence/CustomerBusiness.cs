﻿using Projeto.Entities;
using Projeto.Repository.Contracts;
using ProjetoBusiness.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBusiness.Persistence
{
    public class CustomerBusiness : BaseBusiness<Customer>, ICustomerBusiness

    {
        private readonly ICustomerRepository repository;

        public CustomerBusiness(ICustomerRepository repository) : base(repository)
            {

            this.repository = repository;

            }
        public virtual List<Customer> ConsultaPorCPF(string cpf)
        {
            return repository.FindbyCPF(cpf);
        }


        public List<Customer> ConsultarporDtNasc(DateTime dateOfBirth)
        {
            return repository.FindbydateOfBirth(dateOfBirth);
        }

    }

}

