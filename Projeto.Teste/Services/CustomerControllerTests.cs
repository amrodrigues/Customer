
using Projeto.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ProjetoBusiness.Contracts;
using Xunit;

namespace Projeto.Teste.Services
{
	public class CustomerControllerTests
	{
		//private CustomerController customerController;

		//public CustomerControllerTests()
		//{
		//	customerController = new CustomerController(new Mock<ICustomerBusiness>().Object);
		//}

		[Fact]
		public void ConsutarPorCPF()
		{
			// var teste = "1111111";
			// var excepiton = Assert.Throws<Exception>(() => customerController.ConsutarPorCPF(teste));
			// Assert.Equal("CPF inválido", excepiton.Message);
			Assert.True(false);
		}
	}
}
