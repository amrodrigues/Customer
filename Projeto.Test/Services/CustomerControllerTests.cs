using Moq;
using Projeto.Entities;
using Projeto.Services.Controllers;
using Projeto.Services.Models;
using ProjetoBusiness.Contracts;
using ProjetoBusiness.Persistence;
using System;
using System.Net.Http;
using System.Web.Http;
using Xunit;

namespace Projeto.Test
{
    public class CustomerControllerTests : ApiController
    {
		readonly CustomerController customerController;
        readonly ICustomerBusiness business;
        public ICustomerBusiness Business1 => business;

        public CustomerControllerTests()
		{

        // customerController = new CustomerController(new Mock<ICustomerBusiness>().Object);
        customerController = new CustomerController(business)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        HttpResponseMessage response = new HttpResponseMessage();
        CustomerCadastroRequest model = new CustomerCadastroRequest();

    
        [Fact]
        public void ConsutarPorCPF()
        {
            var teste = "1111111";
            response = customerController.ConsutarPorCPF(teste);
            Assert.Equal("BadRequest", response.StatusCode.ToString());
        }

        [Fact]
        public void Cadastrar()
        {
            model.CPF = "09678595737";
            model.Name = "Anna Maria";
            model.DateOfBirth = Convert.ToDateTime("1982/07/13");
            response = customerController.Cadastrar(model);
            Assert.Equal("BadRequest", response.StatusCode.ToString());
        }

        [Fact]
        public void Consultar()
        {
            response = customerController.ConsutarPorId(1);
            Assert.Equal("BadRequest", response.StatusCode.ToString());
        }

        [Fact]
        public void Consultar2()
        {
            response = customerController.ConsutarPorId(5);
            Assert.Equal("BadRequest", response.StatusCode.ToString());
        }

    }
}
