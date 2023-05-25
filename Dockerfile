# Etapa de compilação
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copia os arquivos de projeto e restaura as dependências
COPY *.sln .
COPY CashFlow.Api/*.csproj ./CashFlow.Api/
COPY CashFlow.Domain/*.csproj ./CashFlow.Domain/
COPY CashFlow.Dto/*.csproj ./CashFlow.Dto/
COPY CashFlow.Infra/*.csproj ./CashFlow.Infra/
COPY CashFlow.Services/*.csproj ./CashFlow.Services/
COPY CashFlow.Specs/*.csproj ./CashFlow.Specs/

RUN dotnet restore

# Copia e publica o aplicativo
COPY . .
WORKDIR /app/CashFlow.Api
RUN dotnet publish -c Release -o /out

# Etapa de execução
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /out ./

# Define a porta exposta pelo contêiner
EXPOSE 80

# Executa o aplicativo quando o contêiner for iniciado
ENTRYPOINT ["dotnet", "CashFlow.Api.dll"]
