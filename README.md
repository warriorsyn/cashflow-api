Segue o README que você pediu:

---

# CashFlow API

A CashFlow API é uma API RESTful em .NET 6.0 que permite o controle do fluxo de caixa de um comerciante com lançamentos (débitos e créditos) e um relatório que disponibiliza o saldo diário consolidado.

# Requisitos do sistema

### Requisitos funcionais

[RF01] O sistema deve ser capaz de permitir um comerciante realizar lançamentos tanto de débito quanto de crédito.
[RF02] O sistema deve permitir a visualização de todos os lançamentos realizados.
[RF03] O sistema deve permitir a visualização de um lançamento em específico.
[RF04] O sistema deve permitir a atualização de lançamentos específicos.
[RF05] O sistema deve permitir a remoção de lançamentos.
[RF06] O sistema deve permitir a visualização de um relatório diário a partir de uma data qualquer do saldo consolidado naquele dia.

### Requisitos não funcionais

[RNF01] O sistema deve ser escrito em C# com .Net Core no modelo de api resful.
[RNF02] O sistema deve ter testes unitários para garantir a segurança de deliveries.
[RNF03] O sistema deve seguir boas práticas e uma arquitetura que separe a camada de domínio.


### Requisitos de domínio

[RD01] O sistema deve entender claramente como realizar os calculos de saldo de maneira correta a partir dos lançamentos criados.
[RF02] O sistema precisa entender a diferença entre lançamentos de débito e crédito para depois realizar calculos em cima desta informação.
[RF03] O sistema a partir dos calculos feitos em cima dos lançamentos deve ser capaz de consolidar esse saldo calculado em um relatório.

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
