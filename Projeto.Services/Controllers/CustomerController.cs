using Projeto.Entities;
using Projeto.Services.Models;
using ProjetoBusiness.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using ProjetoBusiness;
using System.Globalization;

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private ICustomerBusiness business;

        public CustomerController(ICustomerBusiness business)
        {
            this.business = business;
        }

        [Route("cadastrar")]
        [HttpPost]
        public HttpResponseMessage Cadastrar(CustomerCadastroRequest request)
        {
            var response = new CustomerResponse();

            if (ModelState.IsValid)
            {
                Customer c = new Customer();
                if (Validacoes.ValidaCPF(request.CPF))
                {
                    if (business.ConsultaPorCPF(request.CPF).Count == 0)
                        { 
                c.CPF = request.CPF;
                c.Name = request.Name;
                c.DateOfBirth = request.DateOfBirth;

                business.Cadastrar(c);

                response.Mensagem = $"Cliente {request.Name} , cadastrado com sucesso.";
                return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                    else
                    {
                        response.Mensagem = $"CPF já cadastrado na base.";
                        return Request.CreateResponse(HttpStatusCode.BadRequest, response);

                    }

                }
                else
                {
                    response.Mensagem = $"Cliente {request.Name} , com CPF inválido.";
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);

                }

            }
            else
            {
                response.Mensagem = ObterMensagensDeValidacao(ModelState);

                //response.Mensagem = $"Ocorreram erros de validação.";
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);

            }
        }

        [Route("consultar")]
        [HttpGet]
        public HttpResponseMessage ConsutarTodos()
        {
            List<CustomerConsultaResponse> lista = new List<CustomerConsultaResponse>();
            try
            {
                foreach (Customer c in business.ConsultarTodos())
                {
                    CustomerConsultaResponse response = new CustomerConsultaResponse();
                    response.IdCustomer = c.IdCustomer;
                    response.CPF = c.CPF;
                    response.Name = c.Name;
                    response.DateOfBirth = c.DateOfBirth;

                    lista.Add(response);
                }
                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, lista);
            }
        }

        [Route("consultarporDtNasc")]
        [HttpGet]
        public HttpResponseMessage consultarporDtNasc(DateTime dateOfBirth)
        {
            List<CustomerConsultaResponse> lista = new List<CustomerConsultaResponse>();
            try
            {
                foreach (Customer c in business.consultarporDtNasc(dateOfBirth))
                {
                    CustomerConsultaResponse response = new CustomerConsultaResponse();
                    response.IdCustomer = c.IdCustomer;
                    response.CPF = c.CPF;
                    response.Name = c.Name;
                    response.DateOfBirth = c.DateOfBirth;

                    lista.Add(response);
                }
                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, lista);
            }
        }

        [Route("consultarporid")]
        [HttpGet]
        public HttpResponseMessage ConsutarPorId(int id)
        {
            CustomerConsultaResponse model = new CustomerConsultaResponse();
            try
            {
                    Customer c = business.ConsultarPorId(id);
                    model.IdCustomer = c.IdCustomer;
                    model.CPF = c.CPF;
                    model.Name = c.Name;
                    model.DateOfBirth = c.DateOfBirth;

               return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, model);
            }
        }


        [Route("consultarporCPF")]
        [HttpGet]
        public HttpResponseMessage ConsutarPorCPF(string cpf)
        {
            CustomerConsultaResponse model = new CustomerConsultaResponse();
            try
            {
                foreach (Customer c in business.ConsultaPorCPF(cpf))
                {

                    model.IdCustomer = c.IdCustomer;
                    model.CPF = c.CPF;
                    model.Name = c.Name;
                    model.DateOfBirth = c.DateOfBirth;

                    //      return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                if (model.IdCustomer == 0)
                { return Request.CreateResponse(HttpStatusCode.BadRequest, model); }

                else
                { return Request.CreateResponse(HttpStatusCode.OK, model); }

            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, model);
            }
        }

        [Route("atualizar")]
        [HttpPut]
        public HttpResponseMessage Atualizar(CustomerEdicaoRequest request)
        {
            var response = new CustomerResponse();
            if (ModelState.IsValid)
            {
                try
                {
                    Customer c = new Customer();
                    c.IdCustomer = request.IdCustomer;
                    c.CPF = request.CPF;
                    c.Name = request.Name;
                    c.DateOfBirth = request.DateOfBirth;

                    business.Atualizar(c);

                    response.Mensagem = $"Cliente {request.Name} , atualizado com sucesso.";
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                catch (Exception e)
                {

                    response.Mensagem = e.Message;
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);

                }
            }
            else
            {
                response.Mensagem = ObterMensagensDeValidacao(ModelState);
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }

        [Route("excluir")]
        [HttpDelete]
        public HttpResponseMessage Excluir(int id)
        {
            var response = new CustomerResponse();

            if (ModelState.IsValid) 
            {
                try
                {
                    Customer c = business.ConsultarPorId(id);
                    business.Excluir(c);

                    response.Mensagem = $"Cliente {c.Name} , excluido com sucesso.";
                    return Request.CreateResponse(HttpStatusCode.OK, response);

                }
                catch (Exception e)
                {
                    response.Mensagem =e.Message;
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }
            }
            else 
            {
                response.Mensagem = ObterMensagensDeValidacao(ModelState);
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }

        private string ObterMensagensDeValidacao(ModelStateDictionary model)
        {
            List<string> erros = new List<string>();
            foreach (var m in model)
            {
                if (m.Value.Errors.Count > 0)
                {
                    erros.Add(m.Value.Errors.Select

                    (s => s.ErrorMessage).FirstOrDefault());

                }
            }
            return string.Join(",", erros);
        }


    }
    
}