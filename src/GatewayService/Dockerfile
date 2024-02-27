FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80

COPY CESICube.sln CESICube.sln
COPY src/EnchereService/EnchereService.csproj src/EnchereService/EnchereService.csproj
COPY src/RechercheService/RechercheService.csproj src/RechercheService/RechercheService.csproj
COPY src/GatewayService/GatewayService.csproj src/GatewayService/GatewayService.csproj
COPY src/Contracts/Contracts.csproj src/Contracts/Contracts.csproj
COPY src/IdentityService/IdentityService.csproj src/IdentityService/IdentityService.csproj

RUN dotnet restore CESICube.sln

COPY src/GatewayService src/GatewayService
WORKDIR /app/src/GatewayService
RUN dotnet publish -c Release -o /app/src/out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/src/out .
ENTRYPOINT [ "dotnet", "GatewayService.dll" ]