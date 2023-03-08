using Moq;
using Projeto.Entities;
using Projeto.Services.Controllers;
using Projeto.Services.Models;
using ProjetoBusiness;
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



        customerController = new CustomerController(new Mock<ICustomerBusiness>().Object)
       // customerController = new CustomerController(business)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };


        }

        HttpResponseMessage response = new HttpResponseMessage();

        [Fact]
        public void ValidarCPFinvalido()
        {
            var teste = "1111111";
            var resultado = Validacoes.ValidaCPF(teste);
            Assert.False(resultado);
        }

        [Fact]
        public void ValidarCPFvalido()
        {
            var teste = "57852546030";
            var resultado = Validacoes.ValidaCPF(teste);
            Assert.True(resultado);
        }

        [Fact]
        public void ConsutarPorCPF()
        {
            var teste = "1111111";
            response = customerController.ConsutarPorCPF(teste);
            Assert.Equal("BadRequest", response.StatusCode.ToString());
        }

        //[Fact]
        //public void Cadastrar()
        //{
        //    CustomerCadastroRequest model = new CustomerCadastroRequest();
        //    model.CPF = "57852546030";
        //    model.Name = "Anna Maria";
        //    model.DateOfBirth = Convert.ToDateTime("2012/07/13");
        //    response = customerController.Cadastrar(model);
        //    Assert.Equal("BadRequest", response.StatusCode.ToString());
        //}

        [Fact]
        public void Atualizar()
        {
            CustomerEdicaoRequest model = new CustomerEdicaoRequest();
            model.IdCustomer = 1;
            model.CPF = "57852546030";
            model.Name = "Anna Maria";
            model.DateOfBirth = Convert.ToDateTime("2012/07/13");
            response = customerController.Atualizar(model);
            Assert.Equal("OK", response.StatusCode.ToString());
        }


        [Fact]
        public void ConsultarporId()
        {
            response = customerController.ConsutarPorId(5);
            Assert.Equal("BadRequest", response.StatusCode.ToString());
        }

        [Fact]
        public void ConsultarTodos()
        {
            response = customerController.ConsutarTodos();
            Assert.Equal("BadRequest", response.StatusCode.ToString());
        }

        [Fact]
        public void ConsultarporDtNasc()
        {
            response = customerController.ConsultarporDtNasc(Convert.ToDateTime("2012/01/01"));
            Assert.Equal("BadRequest", response.StatusCode.ToString());
        }

        [Fact]
        public void Excluir()
        {
            response = customerController.Excluir(1);
            Assert.Equal("BadRequest", response.StatusCode.ToString());
        }

    }
}
