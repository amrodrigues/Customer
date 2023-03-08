API de Cadastro de Cliente
O projeto foi organizado com a seguinte estrutura:
0- Modelagem de entidades
1- Sistema
  1-1- Camada de Apresentação
  1.2- Camada de Serviços
  1.3- Camada de Regras de Negócio
  1.4- Camada de Acesso a Dados
  1.5- Camada de Testes

O projeto da camada 0 - Entidades foi criado como uma Class Library e inserida a Class Customer, com os seguintes atributos:
   public int IdCustomer { get; set; }
   public string CPF { get; set; }
   public string Name { get; set; }
   public DateTime DateOfBirth { get; set; }

Na camada 1.1 - Camada de Apresentação foi criado um projeto Aplication Web ASP.Net vazio.
Foi instalado o bootstrap e angularjs pelo Gerenciador de Pacotes do NuGet .
Criando as páginas HTML para visualização do cadastro de cliente e consulta do Cliente, com a opção de alteração e exclusão do mesmo.

Na camada 1.2 - Camada de Serviços foi criado um projeto Aplication Web ASP.Net vazio c/ Web API.
Instalamos o Swashbuckle pelo Gerenciador de Pacotes do NuGet (Swagger).
Instalamos o EntityFramework através do Gerenciador de Pacotes do NuGet.
Instalamos o Simple Injector para WebApi através do Gerenciador de Pacotes do NuGet. 
Incluímos o Banco de dados e acrescentamos no Web.config.xml  a string de conexão com o Banco.


<connectionStrings>
<add
name="aula"
connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=<CAMINHO DO BANCO>
Projeto.Services\App_Data\Banco.mdf;Integrated Security=True";/>
</connectionStrings>

A estrutura dessa camada:
Controllers = CustomerController - Onde ficam os controles de inclusão , alteração , busca por CPF, buscar por ID e exclusão do Cliente
Model =  Onde ficam as models correspondentes a cada método do Controller

Na camada 1.3 - Camada de Regras de Negócio criamos um projeto Class Library criando as interfaces para comunicação com a camada de Acesso a Dados.

Na camada 1.4 - Camada de Acesso a Dados foi criado um projeto Class Library e instalando o EntityFramework através do Gerenciador de Pacotes do NuGet.
Incluída as referências do Projeto.Entities (Entidades) e a do Assemblies System.Configuration.
Criamos a Class CustomerMap , DataContext para fazer o mapeamento para criação do Banco de dados.
Para a criação do banco , utilizamos a opção Ferramentas do próprio Visual Studio e escolhemos o Console do Gerenciador de Pacotes.
Rodamos o seguinte comando :  enable-migrations -force, para a criação da Class Configuration e depois rodamos novamente o comando para a criação da tabela.
Ainda na camada 1.4 criamos os contratos com uma interface para a comunicação com o Banco.

obs: No projeto principal foi definido que os Projetos Services e Presentation tivessem a inicialização simultaneamente, através da propriedade do projeto.

Na camada 1.5 - Camada de Testes foi criado o projeto com Projeto de Teste do xUnit
e instalado o Moq através Gerenciador de Pacotes do NuGet

Melhorias:
1 - Na Camada de apresentação melhorar a validação do campo data de nascimento.
2 - Na Camada de testes, novos testes referentes às demais camadas do projeto.
3- .Na Camada de testes, corrigir a system.nullreferenceexception quando utilizamos o Mock da camada ICustomerBusiness.
