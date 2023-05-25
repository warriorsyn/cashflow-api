FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY . ./
RUN dotnet restore "CashFlow.Api/CashFlow.Api.csproj"

RUN dotnet publish "CashFlow.Api/CashFlow.Api.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "CashFlow.Api.dll"]