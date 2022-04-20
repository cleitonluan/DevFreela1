# DevFreela1
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

Projeto realizado no módulo Formação ASP NET Core, utilizando .NET 5.

O objetivo deste projeto é, aperfeiçoar o framework, construindo uma API REST, utilizamos vários recursos como:

- Swagger
- Arquitetura Limpa
- Camadas -> Core, Infrastructure, Application, API
- Entity Framework Core
- Dapper
- CQRS
- MediatR
- JWT -> Json Web Token
- xUnit -> Para testes unitários


Mas quais funcionalidades foram implementadas?

- Cadastro, Atualização, Cancelamento e Consulta de Serviço de Freelancers.
- Cadastro de Usuário e de perfis Freelancer e Cliente
- Adicionar comentários para um serviço de Freelancer
- Definir, iniciar e finalizar o projeto

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

Swagger
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

Ferramenta que simplifica o desenvolvimento de APIs, permitindo entre outras funcionalidades, a documentar e testar APIs. Ele consegue gerar uma interface gráfica contendo todos os pontos de acesso (Endpoints) da API, permitindo realizar requisições diretamente em sua interface. ![128607463-b449e0ca-1b39-4cce-9b8e-38fb1fa469e2](https://user-images.githubusercontent.com/89214405/164130678-e9d3fa65-8f43-47ef-b4cc-2feba265e3c5.png)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

Arquitetura Limpa
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
Também conhecida como Onion Architecture, ou Arquitetura Cebola. Tem como foco o domínio do sistema, tendo em sua essência o DDD - Domain Driven Design, sendo dividida em 4 camadas principais:

- Core, Infrastructure, Application e API.


![2](https://user-images.githubusercontent.com/89214405/164132833-96b8d776-6551-439d-a0f4-aecc2acead5b.png)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

Entity Framework Core
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
É a ORM mais utilizada para desenvolvimento em .NET, sendo multiplataforma, open-source e mantida pela Microsoft. É madura, tendo sido evoluída junto ao .NET Core, com performance e funcionalidades sendo melhoradas a cada versão. Os pacotes a serem utilizados são:

~~~ csharp
Microsoft.EntityFrameworkCore.SqlServer

Microsoft.EntityFrameworkCore.Tools

using Microsoft.EntityFrameworkCore;
~~~ 

![3](https://user-images.githubusercontent.com/89214405/164135352-15614fe7-0f8c-4f15-947b-24523b26da26.png)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

Dapper
----------------------------------------------------------------------------------------------------------------------------------------------------------------------
ORM mais performática e simples que o Entity Framework Core, de fácil adoção em um projeto que já utiliza o EF Core ou outros métodos de acessos de dados.

 - Apresenta métodos de extensão ao IDbConnection (no caso de Sql.Server, SqlConnection)

~~~ csharp
    using Dapper; 
~~~ 

![4](https://user-images.githubusercontent.com/89214405/164135848-ba441de3-4132-4bb3-b17f-b2d01a70d2c4.png)

CQRS
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
``Command-Query Responsability Segregation``


Padrão de desenvolvimento que separa as consultas (Queries) das ações que alteram o estado do sistema (Commands).
                                                                                             
                                                  
Melhora a legibilidade da aplicação, além de permitir maior separação de responsabilidades e estimula separação de modelos.![5](https://user-images.githubusercontent.com/89214405/164229670-5798e2c6-ac45-4ecf-a9f4-b3cffb8cb477.png)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

MediatR
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
Uma espécie de mensageria interna em memória Tem suporte a Commands e Queries, delegando eles para serem processados pelos seus respectivos Handlers Pacote MediatR


```MediatR.Extensions.Microsoft.DependencyInjection```


![6](https://user-images.githubusercontent.com/89214405/164230111-faad32c5-1070-4aee-86c7-51eebd2f6c7c.png)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

Json Web Token - JWT
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
Basicamente é uma cadeia de caracteres com dados da aplicação e usuário em base64, além de uma chave gerada com um algoritmo de hashing como o SHA256. Essa chave é gerada através de uma chave secreta definida na aplicação e que é validada ao receber a requisição. O JWT é enviado via cabeçalho Authorization. 

![8](https://user-images.githubusercontent.com/89214405/164230904-0de0a4ed-e3aa-49a9-81b4-4413b15c006f.png)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

xUnit
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

Ferramenta gratuita e open-source para testes unitários, sendo a principal opção atualmente junto com o NUnit. Funciona com o .NET Core, .NET Framework, Universal Windows Apps e Xamarin. Tem um template prório para o .NET Core, tanto via linha de comando quanto pelo Visual Studio 2019. Em um projeto de testes do xUnit, basta criar uma classe e inserir o método com a anotação [Fact].





```csharp
public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("Nome De Teste", "Descricao de Teste", 1, 2, 10000);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);

            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);

            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
        }
    }
