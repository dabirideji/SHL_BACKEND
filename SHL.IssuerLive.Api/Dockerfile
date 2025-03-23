FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SHL.IssuerLive.Api.csproj", "./"]
RUN dotnet restore "SHL.IssuerLive.Api.csproj"
COPY . .
RUN dotnet publish "SHL.IssuerLive.Api.csproj" -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SHL.IssuerLive.Api.dll"]
