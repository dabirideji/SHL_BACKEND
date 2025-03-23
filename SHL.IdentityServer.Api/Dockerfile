FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SHL.IdentityServer.Api.csproj", "./"]
RUN dotnet restore "SHL.IdentityServer.Api.csproj"
COPY . .
RUN dotnet publish "SHL.IdentityServer.Api.csproj" -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SHL.IdentityServer.Api.dll"]
