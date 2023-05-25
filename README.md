Segue o README que você pediu:

---

# CashFlow API

A CashFlow API é uma API RESTful em .NET 6.0 que permite o controle do fluxo de caixa de um comerciante com lançamentos (débitos e créditos) e um relatório que disponibiliza o saldo diário consolidado.


# Casos de uso do projeto

![image](https://github.com/warriorsyn/cashflow-api/assets/39230805/aa6c8475-6017-445e-ab04-cfae4c20cada)

# Modelo conceitual do projeto

![image](https://github.com/warriorsyn/cashflow-api/assets/39230805/833fa322-70bb-4000-9a02-087ee349b0ba)


## Como executar

### Executando o projeto diretamente

Para executar o projeto diretamente, entre na pasta `CashFlow.Api` e execute o comando `dotnet run`.

Outra opção é abrir o projeto diretamente no Visual Studio e executar clicando no botão de play.

Por favor, note que esta API foi construída utilizando a versão 6 do .NET.

### Via Docker

Para executar o projeto via Docker Compose, execute na raiz do projeto o comando `docker-compose up`. Note que é necessário ter o Docker e o Docker Compose instalados em seu ambiente.

Após isso, a API estará executando na seguinte URL: `http://localhost:3200`.

Para acessar o Swagger, entre na URL `http://localhost:3200/swagger`.

Por favor, note que é possível realizar todas as operações da API diretamente pelo Swagger.

### Testes unitários

Para executas os testes unitários basta entrar na pasta CashFlow.Specs e executar o comando `dotnet test`

## Sobre o projeto

Este projeto utiliza os seguintes padrões e tecnologias:

- C# com .NET 6
- Entity Framework Core
- Padrão DDD (Domain-Driven Design)
- Princípios SOLID
- Testes de unitários
- Docker
